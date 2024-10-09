using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.ComponentModel;

namespace DndBattleHelper.ViewModels
{
    public abstract class EntityViewModel : NotifyPropertyChanged, IEntityViewModel
    {
        public int Initiative { get; set; }
        public string Name { get; set; }
    }
}
