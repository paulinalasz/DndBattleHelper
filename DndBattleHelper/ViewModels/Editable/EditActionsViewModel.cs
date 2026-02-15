using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditActionsViewModel : EditTraitsViewModel
    {
        private readonly EntityActionViewModelFactory _entityActionViewModelFactory;

        public EditActionsViewModel(List<EntityAction> actions = null) : base("Actions")
        {
            _entityActionViewModelFactory = new EntityActionViewModelFactory(new TargetArmourClassProvider(), new AdvantageDisadvantageProvider());

            ToHitModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
            EditDamageRollsViewModel = new EditDamageRollsViewModel();
            HasModifier = true;
            HasDamageRolls = true;

            ResetDefaults();

            if (actions != null) 
            {
                foreach(EntityAction action in actions)
                { 
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new Traits.EditableTraitViewModel(_entityActionViewModelFactory.Create(action.Copy())));
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

        private bool _hasDamageRolls;
        public bool HasDamageRolls
        {
            get => _hasDamageRolls;
            set
            {
                _hasDamageRolls = value;
                OnPropertyChanged(nameof(HasDamageRolls));
                OnPropertyChanged(nameof(EditDamageRollsViewModel));
            }
        }

        public bool HasDamageRollsEnabled => !HasModifier; 

        public EditDamageRollsViewModel EditDamageRollsViewModel { get; }

        private bool _hasModifier;
        public new bool HasModifier
        {
            get { return _hasModifier; }
            set
            {
                _hasModifier = value;
                if (value)
                {
                    HasDamageRolls = true;
                }

                OnPropertyChanged(nameof(HasModifier));
                OnPropertyChanged(nameof(ToHitModifierViewModel));
                OnPropertyChanged(nameof(HasDamageRollsEnabled));
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

        private bool _concentration;
        public bool Concentration
        {
            get => _concentration;
            set
            {
                _concentration = value;
                OnPropertyChanged(nameof(Concentration));
            }
        }

        private string _duration;
        public string Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        private string _range;
        public string Range
        {
            get => _range;
            set
            {
                _range = value;
                OnPropertyChanged(nameof(Range));
            }
        }

        private bool _hasVerbalComponent;
        public bool HasVerbalComponent
        {
            get => _hasVerbalComponent;
            set
            {
                _hasVerbalComponent = value;
                OnPropertyChanged(nameof(HasVerbalComponent));
            }
        }

        private bool _hasSomaticComponent;
        public bool HasSomaticComponent
        {
            get => _hasSomaticComponent;
            set
            {
                _hasSomaticComponent = value;
                OnPropertyChanged(nameof(HasSomaticComponent));
            }
        }

        private bool _hasMaterialComponent;
        public bool HasMaterialComponent
        {
            get => _hasMaterialComponent;
            set
            {
                _hasMaterialComponent = value;
                OnPropertyChanged(nameof(HasMaterialComponent));
            }
        }

        private string _materialComponent;
        public string MaterialComponent
        {
            get => _materialComponent;
            set
            {
                _materialComponent = value;
                OnPropertyChanged(nameof(MaterialComponent));
            }
        }

        protected override void CreateItem()
        {
            var damageRolls = EditDamageRollsViewModel.CopyNewModels();

            var action = new EntityActionFactory().Create(Name,
                    Description,
                    SelectedActionCost,
                    HasDamageRolls,
                    damageRolls,
                    HasModifier,
                    new Modifier(ToHitModifierViewModel.ModifierType, ToHitModifierViewModel.ModifierValue),
                    IsSpell,
                    SelectedSpellSlot,
                    Concentration,
                    Duration,
                    Range,
                    HasVerbalComponent,
                    HasSomaticComponent,
                    HasMaterialComponent,
                    MaterialComponent);

            var newAction = _entityActionViewModelFactory.Create(action);
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new Traits.EditableTraitViewModel(newAction));
        }

        public override bool CanAdd()
        {
            return true;
        }

        protected override bool VerifyAdd()
        {
            var verified = true;

            if (!Name.Any())
            {
                AddVerificationError("Action needs a name.", out verified);
            }
            if (!Description.Any())
            {
                AddVerificationError("Action needs a description.", out verified);
            }
            if (HasModifier && (ToHitModifierViewModel.ModifierType == ModifierType.Neutral))
            {
                AddVerificationError("To Hit Modifier is selected. Please set modifier.", out verified);
            }
            if (HasDamageRolls && !EditDamageRollsViewModel.EditableTraitViewModelsViewModel.EditableTraitViewModels.Any())
            {
                AddVerificationError("Does Damage is selected. Please add at least one damage roll to this action.", out verified);
            }

            return verified;
        }

        public override void ResetDefaults()
        {
            Name = "";
            Description = "";
            SelectedActionCost = 0;
            EditDamageRollsViewModel.ResetDefaults();
            ToHitModifierViewModel.ModifierType = 0;
            ToHitModifierViewModel.ModifierValue = 0;
            SelectedSpellSlot = 0;
            Concentration = false;
            Duration = "";
            Range = "";
            HasVerbalComponent = false;
            HasSomaticComponent = false;
            HasMaterialComponent = false;
            MaterialComponent = "";
            EditDamageRollsViewModel.EditableTraitViewModelsViewModel.EditableTraitViewModels.Clear();
        }

        public List<EntityAction> CopyNewModels()
        {
            var actions = new List<EntityAction>();

            foreach(var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var entityActionViewModel = (EntityActionViewModel)editableTraitViewModel.Content;
                actions.Add(entityActionViewModel.CopyModel());
            }

            return actions;
        }
    }
}
