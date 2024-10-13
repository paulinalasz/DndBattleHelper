using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.ComponentModel;
using System.Windows.Controls;

namespace DndBattleHelper.ViewModels
{
    public abstract class EntityViewModel : NotifyPropertyChanged, IEntityViewModel
    {
        public int Initiative { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }

        public abstract Entity CopyModel();
        public abstract EntityViewModel Copy();
    }
}
