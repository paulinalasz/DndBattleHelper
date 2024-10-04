using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class SenseViewModel : NotifyPropertyChanged, IEditable
    {
        public SenseType Type { get; }

        public SenseViewModel(SenseType type) 
        {
            Type = type;
        }
    }
}
