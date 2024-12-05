using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditAbilitiesViewModel : EditTraitsViewModel
    {
        public EditAbilitiesViewModel(List<Ability> abilities = null) : base("Abilities", false) 
        {
            ResetDefaults();

            if(abilities != null)
            {
                foreach(var ability in abilities) 
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new AbilityViewModel(ability.Copy())));
                }
            }
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

        protected override void CreateItem()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new AbilityViewModel(new Ability(Name, Description))));
        }

        public override bool CanAdd()
        {
            return true;
        }

        protected override bool VerifyAdd()
        {
            var verified = true;

            if(Name == "")
            {
                AddVerificationError("Ability needs a name.", out verified);
            }
            if(Description == "")
            {
                AddVerificationError("Ability needs a description", out verified);
            }

            return verified;
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
