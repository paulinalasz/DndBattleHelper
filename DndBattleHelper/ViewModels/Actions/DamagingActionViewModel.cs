using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Actions
{
    public class DamagingActionViewModel : EntityActionViewModel
    {
        public DamagingActionViewModel(DamagingAction action) : base(action)
        {
            DamageRolls = new List<DamageRollViewModel>();
            foreach (var damageRoll in action.DamageRolls)
            {
                DamageRolls.Add(new DamageRollViewModel(damageRoll));
            }
        }

        // Can have multiple damage rolls of different type for the same action
        public List<DamageRollViewModel> DamageRolls { get; set; }

        public AttackDamageViewModel MostRecentDamageRolled { get; set; }

        private ICommand _rollDamageCommand;
        public ICommand RollDamageCommand => _rollDamageCommand ?? (_rollDamageCommand = new CommandHandler(() => RollDamage(), () => { return true; }));

        public void RollDamage(ToHitRoll toHitRoll = null)
        {
            var damageRolled = new ObservableCollection<Damage>();

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

            MostRecentDamageRolled = new AttackDamageViewModel(Name, toHitRoll, damageRolled);
            ActionTaken?.Invoke();
        }
    }
}
