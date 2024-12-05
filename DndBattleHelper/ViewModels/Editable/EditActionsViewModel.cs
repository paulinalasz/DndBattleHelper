﻿using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditActionsViewModel : EditTraitsViewModel
    {
        private readonly EntityActionViewModelFactory _entityActionViewModelFactory;

        public EditActionsViewModel(List<EntityAction> actions = null) : base("Actions", false)
        {
            _entityActionViewModelFactory = new EntityActionViewModelFactory(new TargetArmourClassProvider(), new AdvantageDisadvantageProvider());

            ToHitModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
            EditDamageRollsViewModel = new EditDamageRollsViewModel();
            HasModifier = true;
            DamageRollsEnabled = true;

            ResetDefaults();

            if (actions != null) 
            {
                foreach(EntityAction action in actions)
                { 
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new Traits.EditableTraitViewModel(_entityActionViewModelFactory.Create(action.Copy())));
                }
            }

            VerificationError = string.Empty;
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
            if (!VerifyAdd()) return;

            var damageRolls = EditDamageRollsViewModel.CopyNewModels();

            var action = new EntityActionFactory().Create(Name,
                    Description,
                    SelectedActionCost,
                    DamageRollsEnabled,
                    damageRolls,
                    HasModifier,
                    new Modifier(ToHitModifierViewModel.ModifierType, ToHitModifierViewModel.ModifierValue),
                    IsSpell,
                    SelectedSpellSlot);

            var newAction = _entityActionViewModelFactory.Create(action);
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new Traits.EditableTraitViewModel(newAction));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }

        private string _verificaitonError;
        public string VerificationError 
        {
            get => _verificaitonError; 
            set
            {
                _verificaitonError = value;
                OnPropertyChanged(nameof(VerificationError));
                OnPropertyChanged(nameof(IsVerificationErrorVisible));
            }
        }

        public bool IsVerificationErrorVisible => VerificationError.Any();

        private bool VerifyAdd()
        {
            var verified = true;
            VerificationError = "";

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
            if (DamageRollsEnabled && !EditDamageRollsViewModel.EditableTraitViewModelsViewModel.EditableTraitViewModels.Any())
            {
                AddVerificationError("Does Damage is selected. Please add at least one damage roll to this action.", out verified);
            }

            return verified;
        }

        private void AddVerificationError(string errorMessage, out bool verified)
        {
            if (VerificationError != "")
            {
                VerificationError += "\n";
            }

            VerificationError += errorMessage;
            verified = false;
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
