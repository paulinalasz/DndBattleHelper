using System.Collections.ObjectModel;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<IEntity> EntitiesInInitiative { get; set; }

        public MainWindowViewModel() 
        {
            EntitiesInInitiative = [new Enemy("Minotaur", 70), new Enemy("Minotaur 2", 63)];
        }
    }
}
