using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;
using DndBattleHelper.ViewModels.Actions;
using DndBattleHelper.ViewModels.Providers;
using System.Printing;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditActionsViewModel : EditTraitsViewModel
    {
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;

        public EditActionsViewModel(TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base("Actions", false)
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;

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
            var damageRolls = new List<DamageRoll>();

            //foreach(var editableTraitViewModel in EditDamageRollsViewModel.EditableTraitViewModelsViewModel.EditableTraitViewModels)
            //{
            //    var damageRoll = (DamageRollViewModel)editableTraitViewModel;
            //    damageRolls.Add(
            //        new DamageRoll(damageRoll.DiceNumber, 
            //        damageRoll.DiceBase, 
            //        new Modifier(damageRoll.DamageModifierViewModel.ModifierType, 
            //        damageRoll.DamageModifierViewModel.ModifierValue), 
            //        damageRoll.SelectedDamageType));
            //}

            //EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(
            //    new EntityActionFactory(_targetArmourClassProvider, _advantageDisadvantageProvider).Create(
            //        Name, 
            //        Description,
            //        SelectedActionCost,
            //        DamageRollsEnabled,
            //        damageRolls,
            //        HasModifier,
            //        new Modifier(ToHitModifierViewModel.ModifierType, ToHitModifierViewModel.ModifierValue),
            //        IsSpell,
            //        SelectedSpellSlot)));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }
    }

    public class EntityActionFactory
    {
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;

        public EntityActionFactory(TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) 
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
        }

        public EntityActionViewModel Create(string name,
            string description,
            ActionCost actionCost,
            bool damageRollsEnabled,
            List<DamageRoll> damageRolls,
            bool hasModifier,
            Modifier toHitModifier,
            bool isSpell,
            SpellSlot spellSlot)
        {
            if (!isSpell && !hasModifier && !damageRollsEnabled)
            {
                return new EntityActionViewModel(new EntityAction(name, description, actionCost));
            }
            else if(!isSpell && !hasModifier && damageRollsEnabled)
            {
                return new DamagingActionViewModel(new DamagingAction(name, description, actionCost, damageRolls));
            }
            else if(!isSpell && hasModifier && !damageRollsEnabled) 
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if(!isSpell && hasModifier && damageRollsEnabled)
            {
                return new AttackActionViewModel(new AttackAction(name, description, actionCost, damageRolls, toHitModifier), _targetArmourClassProvider, _advantageDisadvantageProvider);
            }
            else if(isSpell && !hasModifier && !damageRollsEnabled)
            {
                return new NonDamagingSpellViewModel(new NonDamagingSpell(name, description, actionCost, true, spellSlot));
            }
            else if(isSpell && !hasModifier && damageRollsEnabled)
            {
                return new DamagingSpellWithSaveViewModel(new DamagingSpellWithSave(name, description, actionCost, true, spellSlot, damageRolls));
            }
            else if(isSpell && hasModifier && !damageRollsEnabled)
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if(isSpell && hasModifier && damageRollsEnabled)
            {
                return new SpellAttackViewModel(new SpellAttack(name, description, actionCost, true, damageRolls, toHitModifier, spellSlot), _targetArmourClassProvider, _advantageDisadvantageProvider);
            }
            else
            {
                throw new ArgumentException("if you got here you changed the check points and something went wrong");
            }
        }
    }
}
