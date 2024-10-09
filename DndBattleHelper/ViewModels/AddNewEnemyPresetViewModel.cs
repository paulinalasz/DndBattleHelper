using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Editable.Traits;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyPresetViewModel : NewEnemyViewModel
    {
        public EnemyPreset AddedEnemyPreset { get; set; }

        public AddNewEnemyPresetViewModel(TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(false, false, targetArmourClassProvider, advantageDisadvantageProvider)
        {
        }

        public override void CreateNewEnemy()
        {
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
                            EditSkillsViewModel.CopyNewModels(),
                            EditSensesViewModel.CopyNewModels(),
                            new PassivePerception(PassivePerception.Value),
                            EditLanguagesViewModel.CopyNewModels(),
                            ChallengeRatingViewModel.CopyModel(),
                            EditAbilitiesViewModel.CopyNewModels(),
                            EditActionsViewModel.CopyNewModels(),
                            HealthRollViewModel.CopyModel(),
                            InitiativeRollViewModel.CopyModel());
        }
    }
}
