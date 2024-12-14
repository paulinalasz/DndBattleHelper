using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class DamageTypeViewModel : ViewModelBase, IEditable
    {
        private DamageType _type;
        public DamageType Type
        {
            get { return _type; }
            set 
            { 
                _type = value; 
                OnPropertyChanged(nameof(Type));
            }
        }

        public DamageTypeViewModel(DamageType type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return _type.ToString();
        }
    }
}
