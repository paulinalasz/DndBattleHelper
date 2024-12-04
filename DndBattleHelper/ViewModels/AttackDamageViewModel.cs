using DndBattleHelper.Models;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class AttackDamageViewModel
    {
        public ObservableCollection<Damage> DamageRolled { get; set; }

        public AttackDamageViewModel(ObservableCollection<Damage> damageRolled)
        {
            DamageRolled = damageRolled;
        }

        public override string ToString()
        {
            var attackDamageString = "Target takes ";

            foreach (Damage damage in DamageRolled)
            {
                attackDamageString += damage.ToString();
                attackDamageString += " and ";
            }

            attackDamageString.Substring(0, attackDamageString.Length - 4);

            return attackDamageString += "damage!";
        }
    }
}
