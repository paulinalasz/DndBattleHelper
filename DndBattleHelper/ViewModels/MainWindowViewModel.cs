using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers;
using DndBattleHelper.Helpers.DialogService;
using Microsoft.Win32;
using System.Windows;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private readonly FileIO _fileIo;
        private readonly Presets _presets;
        private readonly EnemyFactory _enemyFactory;

        public EntitiesInInitiativeViewModel EntitiesInInitiativeViewModel { get; set; }

        public MainWindowViewModel(IDialogService dialogService) 
        {
            _fileIo = new FileIO();
            _presets = new Presets(_fileIo);
            _enemyFactory = new EnemyFactory();

            _dialogService = dialogService;

            EntitiesInInitiativeViewModel = new EntitiesInInitiativeViewModel(new ObservableCollection<EntityViewModel>());

            TurnEntityIndex = 0;
            SelectedTab = -1;
        }

        private int _selectedTab;
        public int SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                var count = EntitiesInInitiativeViewModel.EntitiesInInitiative.Count;
                // If list is empty, only allow -1 (no selection)
                if (count == 0 && value != -1)
                {
                    _selectedTab = -1;
                }
                // If list has items, ensure index is valid
                else if (count > 0 && (value < 0 || value >= count))
                {
                    // Invalid index, set to -1 or clamp to valid range
                    _selectedTab = -1;
                }
                else
                {
                    _selectedTab = value;
                }
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        #region FileIO
        private ICommand _newFileCommand;
        public ICommand NewFileCommand => _newFileCommand ?? (_newFileCommand = new CommandHandler(NewFile, () => { return true; }));

        public void NewFile()
        {
            if (EntitiesInInitiativeViewModel.IsChanged)
            {
                var messageResult = MessageBox.Show("Would you like to save before opening a new file?", "New File", MessageBoxButton.YesNoCancel);

                if (messageResult == MessageBoxResult.Yes)
                {
                    if (Save())
                    {
                        EntitiesInInitiativeViewModel.Clear();
                        SelectedTab = -1;
                        TurnEntityIndex = 0;
                    }
                }
                else if (messageResult == MessageBoxResult.No)
                {
                    EntitiesInInitiativeViewModel.Clear();
                    SelectedTab = -1;
                    TurnEntityIndex = 0;
                }
            }
            else
            {
                EntitiesInInitiativeViewModel.Clear();
                SelectedTab = -1;
                TurnEntityIndex = 0;
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new CommandHandler(() => { Save(); }, () => { return true; }));

        public bool Save()
        {
            var saveFileDialog = new SaveFileDialog();
            var result = saveFileDialog.ShowDialog();

            if (result == false) return false;

            _fileIo.OutputSaveFile(EntitiesInInitiativeViewModel.GetEntityModels(), saveFileDialog.FileName);
            
            AcceptChanges();
            return true;
        }

        private ICommand _openCommand;
        public ICommand OpenCommand => _openCommand ?? (_openCommand = new CommandHandler(Open, () => { return true; }));

        public void Open()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result == false) return;

            EntitiesInInitiativeViewModel.CreateFromModels(_fileIo.OpenSavedFiles(openFileDialog.FileName));

            AcceptChanges();

            if (EntitiesInInitiativeViewModel.EntitiesInInitiative.Count > 0)
            {
                TurnEntityIndex = 0;
                EntitiesInInitiativeViewModel.EntitiesInInitiative[0].IsMyTurn = true;
            }
            else
            {
                TurnEntityIndex = 0;
                SelectedTab = -1;
            }
        }
        #endregion

        #region Turn Keeping
        private int _turnEntityIndex;
        public int TurnEntityIndex 
        {
            get { return _turnEntityIndex; } 
            set
            {
                var indexOfEntityOfPreviousTurn = _turnEntityIndex;
                _turnEntityIndex = value;
                var count = EntitiesInInitiativeViewModel.EntitiesInInitiative.Count;

                if (count > 0 && count > TurnEntityIndex && TurnEntityIndex >= 0)
                {
                    // Only access previous index if it's valid
                    if (indexOfEntityOfPreviousTurn >= 0 && indexOfEntityOfPreviousTurn < count)
                    {
                        EntitiesInInitiativeViewModel.EntitiesInInitiative[indexOfEntityOfPreviousTurn].IsMyTurn = false;
                    }
                    EntitiesInInitiativeViewModel.EntitiesInInitiative[TurnEntityIndex].IsMyTurn = true;
                    SelectedTab = TurnEntityIndex;
                }
                else
                {
                    // List is empty or index is invalid, set SelectedTab to -1 (no selection)
                    SelectedTab = -1;
                }

                OnPropertyChanged(nameof(TurnEntityIndex));
                OnPropertyChanged(nameof(InitiativeCount));
            } 
        }

        private ICommand _previousTurnCommand;
        public ICommand PreviousTurnCommand => _previousTurnCommand ?? (_previousTurnCommand = new CommandHandler(() => GoToPreviousTurn(), () => { return true; }));

        public void GoToPreviousTurn()
        {
            var count = EntitiesInInitiativeViewModel.EntitiesInInitiative.Count;
            if (count == 0) return;

            if (TurnEntityIndex - 1 < 0)
            {
                TurnEntityIndex = count - 1;
            }
            else
            {
                TurnEntityIndex -= 1;
            }
        }

        private ICommand _nextTurnCommand;
        public ICommand NextTurnCommand => _nextTurnCommand ?? (_nextTurnCommand = new CommandHandler(() => GoToNextTurn(), () => { return true; }));

        public void GoToNextTurn()
        {
            var count = EntitiesInInitiativeViewModel.EntitiesInInitiative.Count;
            if (count == 0) return;

            if (TurnEntityIndex + 1 > count - 1) 
            {
                TurnEntityIndex = 0;
            }
            else
            {
                TurnEntityIndex += 1;
            }
        }

        public int InitiativeCount => EntitiesInInitiativeViewModel.EntitiesInInitiative.Any() ? EntitiesInInitiativeViewModel.EntitiesInInitiative[TurnEntityIndex].Initiative : 0;
        #endregion

        #region Add Entities and Presets
        private ICommand _addNewPlayerCommand;
        public ICommand AddNewPlayerCommand => _addNewPlayerCommand ?? (_addNewPlayerCommand = new CommandHandler(AddNewPlayer, () => { return true; }));

        public void AddNewPlayer()
        {
            var addPlayerViewModel = new AddNewPlayerViewModel();

            addPlayerViewModel.Added += () =>
            {
                EntitiesInInitiativeViewModel.Add(addPlayerViewModel.AddedPlayerViewModel);
            };

            bool? result = _dialogService.ShowDialog(addPlayerViewModel);
            OnPropertyChanged(string.Empty);
        }

        private ICommand _addNewEnemyCommand;
        public ICommand AddNewEnemyCommand => _addNewEnemyCommand ?? (_addNewEnemyCommand = new CommandHandler(() => AddEnemyNew(), () => { return true; }));

        public void AddEnemyNew()
        {
            var addNewEnemyViewModel = new AddNewEnemyViewModel(_enemyFactory, _presets, EntitiesInInitiativeViewModel.EntityListProvider);

            addNewEnemyViewModel.Added += () =>
            {
                EntitiesInInitiativeViewModel.Add(addNewEnemyViewModel.AddedEnemy);

            };

            addNewEnemyViewModel.AddedGroup += () =>
            {
                foreach (var enemy in addNewEnemyViewModel.AddedEnemyInInitiativeViewModels)
                {
                    EntitiesInInitiativeViewModel.Add(enemy);
                }
            };

            var result = _dialogService.ShowDialog(addNewEnemyViewModel);

            OnPropertyChanged(string.Empty);
        }

        private ICommand _addNewEnemyPresetCommand;
        public ICommand AddNewEnemyPresetCommand => _addNewEnemyPresetCommand ?? (_addNewEnemyPresetCommand = new CommandHandler(AddNewEnemyPreset, () => { return true; }));

        public void AddNewEnemyPreset()
        {
            var addNewEnemyPresetViewModel = new AddNewEnemyPresetViewModel(_enemyFactory, _presets);

            addNewEnemyPresetViewModel.Added += () =>
            {
                _fileIo.OutputPreset(addNewEnemyPresetViewModel.AddedEnemyPreset);
                _presets.DeserialisePresets();
            };

            bool? result = _dialogService.ShowDialog(addNewEnemyPresetViewModel);
        }
        #endregion
    }
}
