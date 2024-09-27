using DndBattleHelper.Models;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class AttackDamageViewModel
    {
        public string Name { get; set; }
        public ToHitRoll ToHitRoll { get; set; }
        public ObservableCollection<Damage> DamageRolled { get; set; }

        public AttackDamageViewModel(string name, ToHitRoll toHitRoll = null, ObservableCollection<Damage> damageRolled = null)
        {
            Name = name;
            ToHitRoll = toHitRoll;
            DamageRolled = damageRolled;
        }

        public override string ToString()
        {
            var attackDamageString = string.Empty;

            attackDamageString += Name;

            if (ToHitRoll != null)
            {
                attackDamageString += ": Rolled to hit: ";
                attackDamageString += ToHitRoll.ToHitWithModifier;
                attackDamageString += ". ";

                if (ToHitRoll.DidAttackHit)
                {
                    attackDamageString += ToStringDamage();
                }
                else
                {
                    attackDamageString += "Its a miss!";
                }

                return attackDamageString;
            }
            else
            {
                return ToStringDamage();
            }
        }

        private string ToStringDamage()
        {
            var attackDamageString = "Its a hit! Target takes ";

            foreach (Damage damage in DamageRolled)
            {
                attackDamageString += damage.ToString();
                attackDamageString += " and ";
            }

            return attackDamageString.Substring(0, attackDamageString.Length - 5);
        }
    }
}
