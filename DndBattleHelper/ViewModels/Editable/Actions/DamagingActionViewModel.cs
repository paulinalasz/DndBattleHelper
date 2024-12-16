using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class DamagingActionViewModel : EntityActionViewModel
    {
        public DamagingAction _action;

        public DamagingActionViewModel(DamagingAction action) : base(action)
        {
            _action = action;

            DamageRolls = new List<DamageRollViewModel>();
            foreach (var damageRoll in _action.DamageRolls)
            {
                DamageRolls.Add(new DamageRollViewModel(damageRoll));
            }
        }

        // Can have multiple damage rolls of different type for the same action
        public List<DamageRollViewModel> DamageRolls { get; set; }

        private ICommand _rollDamageCommand;
        public ICommand RollDamageCommand => _rollDamageCommand ?? (_rollDamageCommand = new CommandHandler(() => RollDamage(), () => { return true; }));

        public void RollDamage(ToHitRoll toHitRoll = null)
        {
            var damageRolled = new ObservableCollection<DamageRollResult>();

            foreach (var damageRoll in DamageRolls)
            {
                if (toHitRoll != null && toHitRoll.Roll == 20)
                {
                    damageRolled.Add(damageRoll.RollDamage(true));
                }
                else
                {
                    damageRolled.Add(damageRoll.RollDamage(false));
                }
            }

            ToHitRollViewModel toHitRollViewModel = null;
            AttackDamageViewModel attackDamageViewModel = null;

            if (toHitRoll != null)
            {
                toHitRollViewModel = new ToHitRollViewModel(toHitRoll);
            }

            if (damageRolled.Count > 0) 
            {
                attackDamageViewModel = new AttackDamageViewModel(damageRolled);
            }

            MostRecentTakenAction = new TakenActionViewModel(Name, toHitRollViewModel, attackDamageViewModel);
            ActionTaken?.Invoke();
        }

        public override bool IsTakeActionVisible => false;
        public override bool IsRollToHitVisible => false;
        public override bool IsRollDamageVisible => true;

        public override DamagingAction CopyModel()
        {
            return _action.Copy();
        }
    }
}
