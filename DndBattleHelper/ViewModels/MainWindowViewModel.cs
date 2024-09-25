using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers;
using System;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public MainWindowViewModel() 
        {
            var skills = new List<SkillType>();
            var senses = new List<SenseType>();
            var languages = new List<LanguageType>();
            var abilities = new List<Ability>();
            var actions = new List<EntityAction>();

            skills.Add(SkillType.Perception);

            var enemy1 = new Enemy("Minotaur 1", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, languages, 3, abilities, actions);
            var enemy2 = new Enemy("Minotaur 2", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, languages, 3, abilities, actions);
            var player1 = new Player("Bar", 132);

            EntitiesInInitiative = [new EnemyViewModel(enemy1), 
                new EnemyViewModel(enemy2),
                new PlayerViewModel(player1),
            ];

            TurnNumber = 0;
            SelectedTab = TurnNumber;
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

        private int _displayTurnNumber;
        public int DisplayTurnNumber => TurnNumber + 1;

        public int EntitiesInInitiativeCount => EntitiesInInitiative?.Count ?? 0;

        private ICommand _addNewCommand;
        public ICommand AddNewCommand => _addNewCommand ?? (_addNewCommand = new CommandHandler(() => AddNew(), () => { return true; }));

        public void AddNew()
        {
            var skills = new List<SkillType>();
            var senses = new List<SenseType>();
            var languages = new List<LanguageType>();
            var abilities = new List<Ability>();
            var actions = new List<EntityAction>();

            var newEnemy = new Enemy("Minotaur new", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, languages, 3, abilities, actions);

            EntitiesInInitiative.Add(new EnemyViewModel(newEnemy));

            OnPropertyChanged(string.Empty);
        }
    }
}
