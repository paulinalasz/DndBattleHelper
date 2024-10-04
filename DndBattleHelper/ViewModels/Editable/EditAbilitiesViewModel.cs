using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditAbilitiesViewModel : EditTraitsViewModel
    {
        public EditAbilitiesViewModel() : base("Abilities", false) 
        {
            ResetDefaults();
        }

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

        public override void ResetDefaults()
        {
            Name = "";
            Description = "";
        }

        public List<Ability> CopyNewModels()
        {
            var abilities = new List<Ability>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var abilityViewModel = (AbilityViewModel)editableTraitViewModel.Content;
                abilities.Add(abilityViewModel.CopyModel());
            }

            return abilities;
        }
    }
}
