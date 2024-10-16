using DndBattleHelper.Helpers;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyViewModel : NewEnemyViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider;
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        private readonly EnemyFactory _enemyFactory;
        private readonly EntityActionViewModelFactory _entityActionViewModelFactory;
        private readonly Presets _presets;

        public AddNewEnemyViewModel(EnemyFactory enemyFactory,
            EntityActionViewModelFactory entityActionViewModelFactory,
            Presets presets, 
            TargetArmourClassProvider targetArmourClassProvider, 
            AdvantageDisadvantageProvider advantageDisadvantageProvider) 
            : base(true, true, enemyFactory.CreateBlank(), targetArmourClassProvider, advantageDisadvantageProvider)
        {
            _entityActionViewModelFactory = entityActionViewModelFactory;
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
            _enemyFactory = enemyFactory;
            _presets = presets;
        }

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
            EditActionsViewModel = new EditActionsViewModel(_targetArmourClassProvider, _advantageDisadvantageProvider, SelectedEnemyPreset.Actions);
            HealthRollViewModel.DiceNumber = SelectedEnemyPreset.HealthRoll.NumberOfDice;
            HealthRollViewModel.DiceBase = SelectedEnemyPreset.HealthRoll.DiceBase;
            HealthRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.HealthRoll.ValueModifier.Copy());
            InitiativeRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.InitiativeRoll.ValueModifier.Copy());

            OnPropertyChanged(string.Empty);
        }

        public EnemyOutboxViewModel AddedEnemy { get; set; }

        public override void CreateNewEnemy()
        {
            var spellSlots = new List<SpellSlotAvailability>();

            foreach (var spellSlot in SpellSlots)
            {
                spellSlots.Add(spellSlot.CopyModel());
            }

            var enemy = _enemyFactory.Create(
                Name,
                Initiative,
                ArmourClass,
                Health,
                Speed,
                Strength,
                Dexterity,
                Constitution,
                Intelligence,
                Wisdom,
                Charisma,
                IsSpellCaster,
                spellSlots,
                EditSavingThrowsViewModel.CopyNewModels(),
                EditDamageVulnerabilitiesViewModel.CopyNewModels(),
                EditDamageResistancesViewModel.CopyNewModels(),
                EditDamageImmunitiesViewModel.CopyNewModels(),
                EditConditionImmunitiesViewModel.CopyNewModels(),
                EditSkillsViewModel.CopyNewModels(),
                EditSensesViewModel.CopyNewModels(),
                new PassivePerception(PassivePerception.Value),
                EditLanguagesViewModel.CopyNewModels(),
                ChallengeRatingViewModel.CopyModel(),
                EditAbilitiesViewModel.CopyNewModels(),
                EditActionsViewModel.CopyNewModels());


            AddedEnemy = new EnemyOutboxViewModel(enemy, _entityActionViewModelFactory, _targetArmourClassProvider, _advantageDisadvantageProvider);
        }
    }
}
