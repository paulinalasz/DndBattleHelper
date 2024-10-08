using DndBattleHelper.Helpers;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyViewModel : NewEnemyViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider;
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider;

        public AddNewEnemyViewModel(TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(targetArmourClassProvider, advantageDisadvantageProvider)
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
        }

        public override bool IsRollHealthVisible => true;

        private ICommand _rollHealthCommand;
        public ICommand RollHealthCommand => _rollHealthCommand ?? (_rollHealthCommand = new CommandHandler(() => RollHealth(), () => { return true; }));

        public void RollHealth()
        {
            Health = new Roll(HealthDiceNumber, HealthDiceBase, new Modifier(HealthModifierViewModel.ModifierType, HealthModifierViewModel.ModifierValue)).RollValue();
        }

        public EnemyViewModel AddedEnemy { get; set; }

        public override void CreateNewEnemy()
        {
            var enemy = new EnemyFactory().Create(
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
                EditActionsViewModel.CopyNewModels());


            AddedEnemy = new EnemyViewModelFactory(
                new EntityActionViewModelFactory(_targetArmourClassProvider, _advantageDisadvantageProvider),
               _targetArmourClassProvider, _advantageDisadvantageProvider).Create(
                enemy);
        }
    }
}
