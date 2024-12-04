using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyPresetViewModel : NewEnemyViewModel
    {
        public EnemyPreset AddedEnemyPreset { get; set; }

        public override bool IsAddGroupPossible => false;

        public AddNewEnemyPresetViewModel(
            EnemyFactory enemyFactory,
            Presets presets) 
            : base(false, false, enemyFactory.CreateBlank(), presets)
        {
        }

        public override void CreateNewEnemy()
        {
            var spellSlots = new List<SpellSlotAvailability>();

            foreach(var spellSlot in SpellSlots) 
            {
                spellSlots.Add(spellSlot.CopyModel());
            }

            AddedEnemyPreset = new EnemyPreset(
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
                            EditActionsViewModel.CopyNewModels(),
                            HealthRollViewModel.CopyModel(),
                            InitiativeRollViewModel.CopyModel(),
                            LegendaryActionsDescription,
                            LairActionsDescription);
        }

        public override void Add()
        {
            CreateNewEnemy();
            Added?.Invoke();
            base.Add();
        }
    }
}
