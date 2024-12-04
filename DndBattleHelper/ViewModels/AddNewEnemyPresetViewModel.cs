using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Editable.Traits;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyPresetViewModel : NewEnemyViewModel
    {
        public EnemyPreset AddedEnemyPreset { get; set; }

        public AddNewEnemyPresetViewModel(
            EnemyFactory enemyFactory,
            TargetArmourClassProvider targetArmourClassProvider,
            AdvantageDisadvantageProvider advantageDisadvantageProvider) 
            : base(false, false, enemyFactory.CreateBlank(), targetArmourClassProvider, advantageDisadvantageProvider)
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

        public override void CreateNewEnemyGroup(AddEnemyGroupParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
