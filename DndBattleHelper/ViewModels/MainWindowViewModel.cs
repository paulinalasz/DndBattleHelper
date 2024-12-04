using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers;
using DndBattleHelper.Helpers.DialogService;
using DndBattleHelper.ViewModels.Providers;
using Microsoft.Win32;
using DndBattleHelper.ViewModels.Editable;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        private readonly FileIO _fileIo;
        private readonly Presets _presets;
        private readonly EntityActionViewModelFactory _entityActionViewModelFactory;
        private readonly EnemyFactory _enemyFactory;

        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public MainWindowViewModel(IDialogService dialogService) 
        {
            _targetArmourClassProvider = new TargetArmourClassProvider();
            _advantageDisadvantageProvider = new AdvantageDisadvantageProvider();
            _fileIo = new FileIO();
            _presets = new Presets(_fileIo);

            _entityActionViewModelFactory = new EntityActionViewModelFactory(_targetArmourClassProvider, _advantageDisadvantageProvider);
            _enemyFactory = new EnemyFactory();

            _dialogService = dialogService;

            EntitiesInInitiative = new ObservableCollection<EntityViewModel>();

            TurnNumber = 0;
            SelectedTab = TurnNumber;
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new CommandHandler(Save, () => { return true; }));

        public void Save()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();

            var entitiesInInitiative = new List<Entity>();

            foreach(var entityViewModel in EntitiesInInitiative)
            {
                entitiesInInitiative.Add(entityViewModel.CopyModel());
            }

            _fileIo.OutputSaveFile(entitiesInInitiative, saveFileDialog.FileName);
        }

        private ICommand _openCommand;
        public ICommand OpenCommand => _openCommand ?? (_openCommand = new CommandHandler(Open, () => { return true; }));

        public void Open()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            var entities = _fileIo.OpenSavedFiles(openFileDialog.FileName);

            // User cancelled request to open save files
            if(entities == null)
            {
                return;
            }

            EntitiesInInitiative.Clear();

            foreach(var entity in entities)
            {
                if (entity is Enemy)
                {
                    EntitiesInInitiative.Add(new EnemyOutboxViewModel((Enemy)entity, _entityActionViewModelFactory, _targetArmourClassProvider, _advantageDisadvantageProvider));
                }
                else
                {
                    EntitiesInInitiative.Add(new PlayerViewModel((Player)entity));
                }

                var entitiesSorted = EntitiesInInitiative.OrderByDescending(entity => entity.Initiative).ToList();
                EntitiesInInitiative.Clear();

                foreach (var entityViewModel in entitiesSorted)
                {
                    EntitiesInInitiative.Add(entityViewModel);
                }
            }

            SubscribeToInitativeChangedEvent();
        }

        private int _selectedTab;
        public int SelectedTab
        {
            get { return _selectedTab; }
            set 
            { 
                _selectedTab = value; 
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        private int _turnNumber;
        public int TurnNumber 
        {
            get { return _turnNumber; } 
            set
            {
                _turnNumber = value;
                OnPropertyChanged(nameof(TurnNumber));
                OnPropertyChanged(nameof(DisplayTurnNumber));
            } 
        }

        private ICommand _previousTurnCommand;
        public ICommand PreviousTurnCommand => _previousTurnCommand ?? (_previousTurnCommand = new CommandHandler(() => GoToPreviousTurn(), () => { return true; }));

        public void GoToPreviousTurn()
        {
            if (TurnNumber - 1 < 0)
            {
                TurnNumber = EntitiesInInitiative.Count - 1;
            }
            else
            {
                TurnNumber -= 1;
            }

            SelectedTab = TurnNumber;
        }

        private ICommand _nextTurnCommand;
        public ICommand NextTurnCommand => _nextTurnCommand ?? (_nextTurnCommand = new CommandHandler(() => GoToNextTurn(), () => { return true; }));

        public void GoToNextTurn()
        {
            if (TurnNumber + 1 > EntitiesInInitiative.Count - 1) 
            {
                TurnNumber = 0;
            }
            else
            {
                TurnNumber += 1;
            }

            SelectedTab = TurnNumber;
        }

        public int DisplayTurnNumber => TurnNumber + 1;

        public int EntitiesInInitiativeCount => EntitiesInInitiative?.Count ?? 0;

        private ICommand _addNewEnemyCommand;
        public ICommand AddNewEnemyCommand => _addNewEnemyCommand ?? (_addNewEnemyCommand = new CommandHandler(() => AddEnemyNew(), () => { return true; }));

        public void AddEnemyNew()
        {
            var addNewEnemyViewModel = new AddNewEnemyViewModel(_enemyFactory, _entityActionViewModelFactory, _presets, _targetArmourClassProvider, _advantageDisadvantageProvider);

            addNewEnemyViewModel.Added += () =>
            {
                EntitiesInInitiative.Add(addNewEnemyViewModel.AddedEnemy);
                SortByInitiative(); 
            };

            bool? result = _dialogService.ShowDialog(addNewEnemyViewModel);

            OnPropertyChanged(string.Empty);
        }

        private ICommand _addNewEnemyPresetCommand;
        public ICommand AddNewEnemyPresetCommand => _addNewEnemyPresetCommand ?? (_addNewEnemyPresetCommand = new CommandHandler(AddNewEnemyPreset, () => { return true; }));

        public void AddNewEnemyPreset()
        {
            var addNewEnemyPresetViewModel = new AddNewEnemyPresetViewModel(_enemyFactory, _targetArmourClassProvider, _advantageDisadvantageProvider);

            addNewEnemyPresetViewModel.Added += () =>
            {
                _fileIo.OutputPreset(addNewEnemyPresetViewModel.AddedEnemyPreset);
                _presets.DeserialisePresets();
            };

            bool? result = _dialogService.ShowDialog(addNewEnemyPresetViewModel);
        }

        private ICommand _addNewPlayerCommand;
        public ICommand AddNewPlayerCommand => _addNewPlayerCommand ?? (_addNewPlayerCommand = new CommandHandler(AddNewPlayer, () => { return true; }));

        public void AddNewPlayer()
        {
            var addPlayerViewModel = new AddNewPlayerViewModel();

            addPlayerViewModel.Added += () =>
            {
                EntitiesInInitiative.Add(addPlayerViewModel.AddedPlayerViewModel);
                SortByInitiative();
                SubscribeToInitativeChangedEvent();
            };

            bool? result = _dialogService.ShowDialog(addPlayerViewModel);

            OnPropertyChanged(string.Empty);
        }

        private void SortByInitiative()
        {
            var entitiesSorted = EntitiesInInitiative.OrderByDescending(entity => entity.Initiative).ToList();
            EntitiesInInitiative.Clear();

            foreach (var entityViewModel in entitiesSorted)
            {
                EntitiesInInitiative.Add(entityViewModel);
            }
        }

        private void SubscribeToInitativeChangedEvent()
        {
            foreach(var entityViewModel in EntitiesInInitiative)
            {
                entityViewModel.InitiativeChanged += () =>
                {
                    SortByInitiative();
                };
            }
        }
    }
}
