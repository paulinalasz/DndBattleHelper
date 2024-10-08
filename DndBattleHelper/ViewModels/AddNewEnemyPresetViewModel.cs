using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyPresetViewModel : NewEnemyViewModel
    {
        public EnemyPreset AddedEnemyPreset { get; set; }

        public AddNewEnemyPresetViewModel(TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(targetArmourClassProvider, advantageDisadvantageProvider)
        {
        }

        public override bool IsRollHealthVisible => false;

        public override void CreateNewEnemy()
        {
            AddedEnemyPreset = new EnemyPreset(
                            Name,
                            ArmourClass,
                            Health,
                            Speed,
                            Strength,
                            Dexterity,
                            Constitution,
                            Intelligence,
                            Wisdom,
                            Charisma,
                            EditSkillsViewModel.CopyNewModels(),
                            EditSensesViewModel.CopyNewModels(),
                            PassivePerception.CopyModel(),
                            EditLanguagesViewModel.CopyNewModels(),
                            ChallengeRatingViewModel.CopyModel(),
                            EditAbilitiesViewModel.CopyNewModels(),
                            EditActionsViewModel.CopyNewModels(),
                            new Roll(HealthDiceNumber, HealthDiceBase, HealthModifierViewModel.CopyModel()));
        }
    }
}
