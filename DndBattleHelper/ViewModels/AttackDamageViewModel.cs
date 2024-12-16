using DndBattleHelper.Models;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class AttackDamageViewModel
    {
        public ObservableCollection<DamageRollResult> DamageRolled { get; set; }

        public AttackDamageViewModel(ObservableCollection<DamageRollResult> damageRolled)
        {
            DamageRolled = damageRolled;
        }

        public override string ToString()
        {
            var attackDamageString = "Target takes ";

            foreach (RollResult damage in DamageRolled)
            {
                attackDamageString += damage.ToString();
                attackDamageString += " and ";
            }

            attackDamageString = attackDamageString.Substring(0, attackDamageString.Length - 4);

            return attackDamageString += "damage!";
        }
    }
}
