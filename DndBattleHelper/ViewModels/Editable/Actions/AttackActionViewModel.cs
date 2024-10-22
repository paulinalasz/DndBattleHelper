using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;
using System.Windows.Input;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class AttackActionViewModel : DamagingActionViewModel
    {
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        private readonly AttackAction _action;

        public AttackActionViewModel(AttackAction action, TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(action)
        {
            _action = action;
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
        }

        public Modifier ToHit
        {
            get => _action.ToHit;
            set
            {
                _action.ToHit = value;
                OnPropertyChanged(nameof(ToHit));
            }
        }

        private ICommand _rollToHitCommand;
        public ICommand RollToHitCommand => _rollToHitCommand ?? (_rollToHitCommand = new CommandHandler(() => JustAttackRoll(_targetArmourClassProvider.TargetArmourClass), () => { return true; }));

        private void JustAttackRoll(int armourClass)
        {
            MostRecentTakenAction = new TakenActionViewModel(Name, new ToHitRollViewModel(DoesAttackHit(armourClass)));
            ActionTaken?.Invoke();
        }

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

        public override void TakeAction()
        {
            Random rand = new Random();
            var toHitRoll = DoesAttackHit(_targetArmourClassProvider.TargetArmourClass);

            if (!toHitRoll.DidAttackHit)
            {
                MostRecentTakenAction = new TakenActionViewModel(Name, new ToHitRollViewModel(toHitRoll));
                ActionTaken?.Invoke();
                return;
            }

            RollDamage(toHitRoll);
        }

        public override string TakenActionContent => "Roll and Damage";
        public override bool IsTakeActionVisible => true;
        public override bool IsRollToHitVisible => true;
        public override bool IsRollDamageVisible => true;

        public override AttackAction CopyModel()
        {
            return _action.Copy();
        }
    }
}
