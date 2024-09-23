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

            EntitiesInInitiative = [
                new EntityViewModel(enemy1.Name, new EnemyContentViewModel(enemy1)), 
                new EntityViewModel(enemy2.Name, new EnemyContentViewModel(enemy2))];
        }
    }
}
