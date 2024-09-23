using System.Collections.ObjectModel;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public MainWindowViewModel() 
        {
            var enemy1 = new Enemy("Minotaur 1", 70);
            var enemy2 = new Enemy("Minotaur 2", 60);

            EntitiesInInitiative = [new EnemyViewModel(enemy1), new EnemyViewModel(enemy2)];
        }
    }
}
