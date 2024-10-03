using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditActionsViewModel : EditTraitsViewModel
    {
        public EditActionsViewModel() : base("Actions", false)
        {
            ToHitModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
            EditDamageRollsViewModel = new EditDamageRollsViewModel();
            HasModifier = true;
            DamageRollsEnabled = true;
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

        private bool _damageRollsEnabled;
        public bool DamageRollsEnabled
        {
            get => _damageRollsEnabled;
            set
            {
                _damageRollsEnabled = value;
                OnPropertyChanged(nameof(DamageRollsEnabled));
                OnPropertyChanged(nameof(EditDamageRollsViewModel));
            }
        }

        public EditDamageRollsViewModel EditDamageRollsViewModel { get; }

        private bool _hasModifier;
        public new bool HasModifier
        {
            get { return _hasModifier; }
            set
            {
                _hasModifier = value;
                OnPropertyChanged(nameof(HasModifier));
                OnPropertyChanged(nameof(ToHitModifierViewModel));
            }
        }

        public ModifierViewModel ToHitModifierViewModel { get; set; }

        private bool _isSpell;
        public bool IsSpell
        {
            get { return _isSpell; }
            set
            {
                _isSpell = value;
                OnPropertyChanged(nameof(IsSpell));
            }
        }

        private SpellSlot _selectedSpellSlot;
        public SpellSlot SelectedSpellSlot
        {
            get => _selectedSpellSlot;
            set
            {
                _selectedSpellSlot = value;
                OnPropertyChanged(nameof(SelectedSpellSlot));
            }
        }

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(
                new EditableActionViewModel(
                    new EntityAction(Name, Description, SelectedActionCost/*, new Modifier(ToHitModifierViewModel.ModifierType, ToHitModifierViewModel.ModifierValue), new List<DamageRoll>())*/)));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }
    }
}
