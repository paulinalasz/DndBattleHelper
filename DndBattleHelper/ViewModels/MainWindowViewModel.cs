﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers;
using DndBattleHelper.Helpers.DialogService;
using Microsoft.Win32;
using System.Windows;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;
        private readonly FileIO _fileIo;
        private readonly Presets _presets;
        private readonly EntityActionsViewModelFactory _entityActionsViewModelFactory;
        private readonly EnemyFactory _enemyFactory;

        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public MainWindowViewModel(IDialogService dialogService) 
        {
            _fileIo = new FileIO();
            _presets = new Presets(_fileIo);
            _enemyFactory = new EnemyFactory();

            _dialogService = dialogService;

            EntitiesInInitiative = new ObservableCollection<EntityViewModel>();

            TurnNumber = 0;
            SelectedTab = TurnNumber;
        }

        #region FileIO
        private ICommand _newFileCommand;
        public ICommand NewFileCommand => _newFileCommand ?? (_newFileCommand = new CommandHandler(NewFile, () => { return true; }));

        public void NewFile()
        {
            var messageResult = MessageBox.Show("Would you like to save before opening a new file?", "New File", MessageBoxButton.YesNoCancel);

            if (messageResult == MessageBoxResult.Yes)
            {
                if (SaveWithResult())
                {
                    EntitiesInInitiative.Clear();
                }
            }
            else if (messageResult == MessageBoxResult.No)
            {
                EntitiesInInitiative.Clear();
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new CommandHandler(SaveFileCommand, () => { return true; }));

        public void SaveFileCommand()
        {
            SaveWithResult();
        }

        public bool SaveWithResult()
        {
            var saveFileDialog = new SaveFileDialog();
            var result = saveFileDialog.ShowDialog();

            if (result == false) return false;

            var entitiesInInitiative = new List<Entity>();
            foreach (var entityViewModel in EntitiesInInitiative)
            {
                entitiesInInitiative.Add(entityViewModel.CopyModel());
            }

            _fileIo.OutputSaveFile(entitiesInInitiative, saveFileDialog.FileName);
            return true;
        }

        private ICommand _openCommand;
        public ICommand OpenCommand => _openCommand ?? (_openCommand = new CommandHandler(Open, () => { return true; }));

        public void Open()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result == false) return;

            var entities = _fileIo.OpenSavedFiles(openFileDialog.FileName);

            EntitiesInInitiative.Clear();

            foreach(var entity in entities)
            {
                if (entity is Enemy)
                {
                    EntitiesInInitiative.Add(new EnemyInInitiativeViewModel((Enemy)entity));
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
        #endregion

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
            var addNewEnemyViewModel = new AddNewEnemyViewModel(_enemyFactory, _presets);

            addNewEnemyViewModel.Added += () =>
            {
                EntitiesInInitiative.Add(addNewEnemyViewModel.AddedEnemy);
                SortByInitiative(); 
            };

            addNewEnemyViewModel.AddedGroup += () =>
            {
                foreach (var enemy in addNewEnemyViewModel.AddedEnemyInInitiativeViewModels)
                {
                    EntitiesInInitiative.Add(enemy);
                }
                
                SortByInitiative();
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
