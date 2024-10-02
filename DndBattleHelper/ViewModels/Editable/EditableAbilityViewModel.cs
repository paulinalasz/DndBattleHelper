using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableAbilityViewModel : EditableTraitViewModel
    {
        private readonly Ability _ability; 

        public EditableAbilityViewModel(Ability ability)
        {
            _ability = ability;
        }

        public string Name
        {
            get { return _ability.Name; }
            set
            {
                _ability.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _ability.Description;
            set
            {
                _ability.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public override bool HasModifier => false;
    }
}
