using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class PassivePerceptionViewModel : ViewModelBase, IEditable
    {
        private readonly PassivePerception _passivePerception;

        public PassivePerceptionViewModel(PassivePerception passivePerception) 
        {
            _passivePerception = passivePerception;
        }

        public SkillType SkillType => _passivePerception.Type;

        public int Value
        {
            get { return _passivePerception.Value; }
            set
            {
                _passivePerception.Value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    }
}
