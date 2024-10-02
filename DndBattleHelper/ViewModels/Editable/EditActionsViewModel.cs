using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditActionsViewModel : EditTraitsViewModel
    {
        public EditActionsViewModel() : base("Actions", false)
        {
            ToHitModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private ActionCost _selectedActionCost;
        public ActionCost SelectedActionCost 
        {
            get { return _selectedActionCost; }
            set
            {
                _selectedActionCost = value;
                OnPropertyChanged(nameof(SelectedActionCost));
            }
        }

        public ModifierViewModel ToHitModifierViewModel { get; set; }

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(
                new EditableActionViewModel(
                    new EntityAction(Name, Description, SelectedActionCost, new Modifier(ToHitModifierViewModel.ModifierType, ToHitModifierViewModel.ModifierValue), new List<DamageRoll>()),
                    true));
        }

        public override bool CanAdd()
        {
            return true;
        }
    }
}
