using DndBattleHelper.Helpers;
using DndBattleHelper.Helpers.DialogService;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.Models.Enums;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels
{
    public abstract class NewEnemyViewModel : EnemyViewModel, IDialogRequestClose
    {
        private Presets _presets;

        public abstract bool IsAddGroupPossible { get; }
        public EditTraitsWithModifierViewModel<AbilityScoreType> EditSavingThrowsViewModel { get; set; }
        public EditTraitsViewModel<DamageType> EditDamageVulnerabilitiesViewModel { get; set; }
        public EditTraitsViewModel<DamageType> EditDamageResistancesViewModel { get; set; }
        public EditTraitsViewModel<DamageType> EditDamageImmunitiesViewModel { get; set; }
        public EditTraitsViewModel<Condition> EditConditionImmunitiesViewModel { get; set; }
        public EditTraitsWithModifierViewModel<SkillType> EditSkillsViewModel { get; set; }
        public EditTraitsViewModel<SenseType> EditSensesViewModel { get; set; }
        public EditTraitsViewModel<LanguageType> EditLanguagesViewModel { get; set; }

        public EditAbilitiesViewModel EditAbilitiesViewModel { get; set; }
        public EditActionsViewModel EditActionsViewModel { get; set; }

        public NewEnemyViewModel(bool isHealthRollVisible, 
            bool isInitiativeRollVisible,
            Enemy enemy,
            Presets presets) 
            : base(enemy)
        {
            _presets = presets;

            InitiativeRollViewModel = new RollViewModel(new Roll(1, 20, new Modifier(ModifierType.Neutral, 0)), "Roll Initiative: ", isInitiativeRollVisible, false);
            InitiativeRollViewModel.Rolled += () => { Initiative = InitiativeRollViewModel.ValueRolled; };

            HealthRollViewModel = new RollViewModel(new Roll(1, 10, new Modifier(ModifierType.Neutral, 0)), "Roll Health: ", isHealthRollVisible);
            HealthRollViewModel.Rolled += () => { Health = HealthRollViewModel.ValueRolled; };

            EditSavingThrowsViewModel = new EditTraitsWithModifierViewModel<AbilityScoreType>("Saving Throws: ");
            EditDamageVulnerabilitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Vurnerabilities: ");
            EditDamageResistancesViewModel = new EditTraitsViewModel<DamageType>("Damage Resistances: ");
            EditDamageImmunitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Immunities: ");
            EditConditionImmunitiesViewModel = new EditTraitsViewModel<Condition>("Condition Immunities: ");
            EditSkillsViewModel = new EditTraitsWithModifierViewModel<SkillType>("Skills: ");
            EditSensesViewModel = new EditTraitsViewModel<SenseType>("Senses: ");
            EditLanguagesViewModel = new EditTraitsViewModel<LanguageType>("Languages: ");
            EditAbilitiesViewModel = new EditAbilitiesViewModel();
            EditActionsViewModel = new EditActionsViewModel();
        }

        public RollViewModel InitiativeRollViewModel { get; set; }

        public RollViewModel HealthRollViewModel { get; set; }

        #region dialogService
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ??
            (_addCommand = new CommandHandler(Add, () => { return true; }));

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??
            (_cancelCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), () => { return true; }));
        #endregion 

        public Action Added;

        public virtual void Add()
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        public abstract void CreateNewEnemy();

        #region Apply Presets
        public List<EnemyPreset> EnemyPresets => _presets.EnemyPresets;

        private EnemyPreset _selectedEnemyPreset;
        public EnemyPreset SelectedEnemyPreset
        {
            get { return _selectedEnemyPreset; }
            set
            {
                _selectedEnemyPreset = value;
                OnPropertyChanged(nameof(SelectedEnemyPreset));
            }
        }

        private ICommand _usePresetCommand;
        public ICommand UsePresetCommand => _usePresetCommand ?? (_usePresetCommand = new CommandHandler(UsePreset, () => { return true; }));

        public void UsePreset()
        {
            var spellSlots = new List<SpellSlotAvailabilityViewModel>();

            foreach (var spellSlot in SelectedEnemyPreset.SpellSlots)
            {
                spellSlots.Add(new SpellSlotAvailabilityViewModel(spellSlot.Copy()));
            }

            Name = SelectedEnemyPreset.Name;
            ArmourClass = SelectedEnemyPreset.ArmourClass;
            Health = SelectedEnemyPreset.Health;
            Speed = SelectedEnemyPreset.Speed;
            Strength = SelectedEnemyPreset.Strength;
            Dexterity = SelectedEnemyPreset.Dexterity;
            Constitution = SelectedEnemyPreset.Constitution;
            Intelligence = SelectedEnemyPreset.Intelligence;
            Wisdom = SelectedEnemyPreset.Wisdom;
            Charisma = SelectedEnemyPreset.Charisma;
            IsSpellCaster = SelectedEnemyPreset.IsSpellCaster;
            SpellSlots = spellSlots;
            EditSavingThrowsViewModel = new EditTraitsWithModifierViewModel<AbilityScoreType>("Saving Throws: ", SelectedEnemyPreset.SavingThrows);
            EditDamageVulnerabilitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Vurnerabilities: ", SelectedEnemyPreset.DamageVurnerabilities);
            EditDamageResistancesViewModel = new EditTraitsViewModel<DamageType>("Damage Resistances: ", SelectedEnemyPreset.DamageResistances);
            EditDamageImmunitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Immunities: ", SelectedEnemyPreset.DamageResistances);
            EditConditionImmunitiesViewModel = new EditTraitsViewModel<Condition>("Condition Immunities: ", SelectedEnemyPreset.ConditionImmunities);
            EditSkillsViewModel = new EditTraitsWithModifierViewModel<SkillType>("Skills: ", SelectedEnemyPreset.Skills);
            EditSensesViewModel = new EditTraitsViewModel<SenseType>("Senses: ", SelectedEnemyPreset.Senses);
            PassivePerception = new PassivePerceptionViewModel(SelectedEnemyPreset.PassivePerception);
            EditLanguagesViewModel = new EditTraitsViewModel<LanguageType>("Languages: ", SelectedEnemyPreset.Languages);
            ChallengeRatingViewModel = new ChallengeRatingViewModel(SelectedEnemyPreset.ChallengeRating.Copy());
            EditAbilitiesViewModel = new EditAbilitiesViewModel(SelectedEnemyPreset.Abilities);
            EditActionsViewModel = new EditActionsViewModel(SelectedEnemyPreset.Actions);
            HealthRollViewModel.DiceNumber = SelectedEnemyPreset.HealthRoll.NumberOfDice;
            HealthRollViewModel.DiceBase = SelectedEnemyPreset.HealthRoll.DiceBase;
            HealthRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.HealthRoll.ValueModifier.Copy());
            InitiativeRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.InitiativeRoll.ValueModifier.Copy());
            LegendaryActionsDescription = SelectedEnemyPreset.LegendaryActionsDescription;
            LairActionsDescription = SelectedEnemyPreset.LairActionsDescription;

            OnPropertyChanged(string.Empty);
        }

        #endregion
    }
}
