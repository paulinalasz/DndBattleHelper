using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditAbilitiesViewModel : EditTraitsViewModel
    {
        public EditAbilitiesViewModel() : base("Abilities", false) { }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new AbilityViewModel(new Ability(Name, Description))));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }
    }
}
