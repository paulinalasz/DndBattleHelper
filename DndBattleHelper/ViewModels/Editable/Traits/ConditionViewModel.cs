using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class ConditionViewModel : NotifyPropertyChanged, IEditable
    {
        private Condition _type;
        public Condition Type
        {
            get { return _type; }
            set 
            { 
                _type = value; 
                OnPropertyChanged(nameof(Type));
            }
        }

        public ConditionViewModel(Condition type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return _type.ToString();
        }
    }
}
