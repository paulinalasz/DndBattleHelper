using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public MainWindowViewModel() 
        {
            var abilities = new List<Ability>();
            var actions = new List<EntityAction>();

            var enemy1 = new Enemy("Minotaur 1", 10, 70, abilities, actions);
            var enemy2 = new Enemy("Minotaur 2", 10, 60, abilities, actions);
            var player1 = new Player("Bar", 132);

            EntitiesInInitiative = [new EnemyViewModel(enemy1), 
                new EnemyViewModel(enemy2),
                new PlayerViewModel(player1),
            ];
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

        private ICommand _previousTurnCommand;
        public ICommand PreviousTurnCommand => _previousTurnCommand ?? (_previousTurnCommand = new CommandHandler(() => GoToPreviousTurn(), () => { return true; }));

        public void GoToPreviousTurn()
        {
            if (SelectedTab -1 < 0)
            {
                SelectedTab = EntitiesInInitiative.Count - 1;
            }
            else
            {
                SelectedTab -= 1;
            }
        }

        private ICommand _nextTurnCommand;
        public ICommand NextTurnCommand => _nextTurnCommand ?? (_nextTurnCommand = new CommandHandler(() => GoToNextTurn(), () => { return true; }));

        public void GoToNextTurn()
        {
            if (SelectedTab + 1 > EntitiesInInitiative.Count - 1) 
            {
                SelectedTab = 0;
            }
            else
            {
                SelectedTab += 1;
            }
        }

    }
}
