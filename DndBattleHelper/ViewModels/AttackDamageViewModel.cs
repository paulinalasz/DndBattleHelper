using DndBattleHelper.Models;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class AttackDamageViewModel
    {
        public string Name { get; set; }
        public int ToHitRolled { get; set; }
        public bool Hits { get; }
        public ObservableCollection<Damage> DamageRolled { get; set; }

        public AttackDamageViewModel(string name, bool hits, ObservableCollection<Damage> damageRolled = null)
        {
            Name = name;
            DamageRolled = damageRolled;
            Hits = hits;
        }

        public override string ToString()
        {
            var attackDamageString = string.Empty;

            attackDamageString += Name;
            attackDamageString += ": Rolled to hit: ";
            attackDamageString += ToHitRolled;

            if (Hits)
            {
                attackDamageString += ". Its a hit! Target takes ";

                foreach (Damage damage in DamageRolled)
                {
                    attackDamageString += damage.ToString();
                    attackDamageString += " and ";
                }

                attackDamageString = attackDamageString.Substring(0, attackDamageString.Length - 5);
            }
            else
            {
                attackDamageString += "Its a miss!";
            }

            return attackDamageString;
        }
    }
}
