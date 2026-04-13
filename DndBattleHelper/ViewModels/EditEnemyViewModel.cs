using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Editable.Traits;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels
{
    public class EditEnemyViewModel : NewEnemyViewModel
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly EntityListProvider _entityListProvider;

        public EnemyInInitiativeViewModel EditedEnemy { get; set; }

        public Action Edited;

        public EditEnemyViewModel(EnemyFactory enemyFactory,
            Presets presets,
            Enemy enemy,
            EntityListProvider entityListProvider = null)
            : base(false, false, enemy.Copy(), presets)
        {
            _enemyFactory = enemyFactory;
            _entityListProvider = entityListProvider;

            PopulateFromEnemy(enemy);
        }

        private void PopulateFromEnemy(Enemy enemy)
        {
            var spellSlots = new List<SpellSlotAvailabilityViewModel>();

            foreach (var spellSlot in enemy.SpellSlots)
            {
                spellSlots.Add(new SpellSlotAvailabilityViewModel(spellSlot.Copy()));
            }

            SpellSlots = spellSlots;

            EditSavingThrowsViewModel = new EditTraitsWithModifierViewModel<AbilityScoreType>("Saving Throws: ", enemy.SavingThrows);
            EditDamageVulnerabilitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Vurnerabilities: ", enemy.DamageVurnerabilities);
            EditDamageResistancesViewModel = new EditTraitsViewModel<DamageType>("Damage Resistances: ", enemy.DamageResistances);
            EditDamageImmunitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Immunities: ", enemy.DamageImmunities);
            EditConditionImmunitiesViewModel = new EditTraitsViewModel<Condition>("Condition Immunities: ", enemy.ConditionImmunities);
            EditSkillsViewModel = new EditTraitsWithModifierViewModel<SkillType>("Skills: ", enemy.Skills);
            EditSensesViewModel = new EditTraitsWithValueViewModel<SenseType>("Senses: ", enemy.Senses);
            PassivePerception = new PassivePerceptionViewModel(enemy.PassivePerception);
            EditLanguagesViewModel = new EditTraitsViewModel<LanguageType>("Languages: ", enemy.Languages);
            ChallengeRatingViewModel = new ChallengeRatingViewModel(enemy.ChallengeRating.Copy());
            EditAbilitiesViewModel = new EditAbilitiesViewModel(enemy.Abilities);
            EditActionsViewModel = new EditActionsViewModel(enemy.Actions);

            OnPropertyChanged(string.Empty);
        }

        public override bool IsAddGroupPossible => false;

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
                FlySpeed,
                SwimSpeed,
                ClimbSpeed,
                BurrowSpeed,
                Strength,
                Dexterity,
                Constitution,
                Intelligence,
                Wisdom,
                Charisma,
                IsSpellCaster,
                spellSlots,
                SpellSaveDC,
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
                EditActionsViewModel.CopyNewModels(),
                LegendaryActionsDescription,
                LairActionsDescription);

            EditedEnemy = new EnemyInInitiativeViewModel(enemy, _entityListProvider);
        }

        public override void Add()
        {
            CreateNewEnemy();
            Edited?.Invoke();
            base.Add();
        }
    }
}

