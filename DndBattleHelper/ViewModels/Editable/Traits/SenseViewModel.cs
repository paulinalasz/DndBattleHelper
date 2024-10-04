using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class SenseViewModel : NotifyPropertyChanged, IEditable
    {
        private SenseType _type;
        public SenseType Type 
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public SenseViewModel(SenseType type)
        {
            _type = type;
        }
    }
}
