using System.Collections.ObjectModel;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel
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
            set { _selectedTab = value; }
        }
    }
}
