using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;
using System.Windows.Input;
using DndBattleHelper.Models.ActionTypes;
using DndBattleHelper.ViewModels.Editable;

namespace DndBattleHelper.ViewModels.Actions
{
    public class AttackActionViewModel : DamagingActionViewModel
    {
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        public AttackActionViewModel(AttackAction action, TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(action)
        {
            ToHit = action.ToHit;
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
        }

        //But only one To Hit Modifier
        public Modifier ToHit { get; set; }

        private ICommand _rollToHitAndDamageCommand;
        public ICommand RollToHitAndDamageCommand => _rollToHitAndDamageCommand ?? (_rollToHitAndDamageCommand = new CommandHandler(() => RollToHitAndDamage(_targetArmourClassProvider.TargetArmourClass), () => { return true; }));

        private ToHitRoll DoesAttackHit(int armourClass)
        {
            Random rand = new Random();
            var roll = rand.Next(1, 21);

            if (_advantageDisadvantageProvider.IsAdvantage)
            {
                var roll2 = rand.Next(1, 21);
                roll = roll > roll2 ? roll : roll2;
            }

            if (_advantageDisadvantageProvider.IsDisadvantage)
            {
                var roll2 = rand.Next(1, 21);
                roll = roll < roll2 ? roll : roll2;
            }

            var withModifier = roll + ToHit.ToInt();

            if (withModifier >= armourClass && roll != 1) return new ToHitRoll(true, roll, ToHit, withModifier);

            return new ToHitRoll(false, roll, ToHit, withModifier);
        }

        public void RollToHitAndDamage(int armourClass)
        {
            Random rand = new Random();
            var toHitRoll = DoesAttackHit(armourClass);

            if (!toHitRoll.DidAttackHit)
            {
                MostRecentDamageRolled = new AttackDamageViewModel(Name, toHitRoll);
                ActionTaken?.Invoke();
                return;
            }

            RollDamage(toHitRoll);
        }
    }
}
