using DndBattleHelper.Helpers;
using System.Windows.Input;

namespace DndBattleHelper.Models
{
    public class DamageRoll : Roll
    {
        public DamageType DamageType { get; set; }

        public DamageRoll(int number, int diceBase, Modifier modifier, DamageType damageType)
            : base(number, diceBase, modifier)
        {
            NumberOfDice = number;
            DiceBase = diceBase;
            ValueModifier = modifier;
            DamageType = damageType;
        }

        public Damage RollDamage(bool critialHit)
        {
            var damage = base.RollValue();

            if(critialHit) 
            {
                for (int i = 0; i < NumberOfDice; i++)
                {
                    damage += rand.Next(1, DiceBase + 1);
                }
            }

            return new Damage(damage, DamageType);
        }
    }
}
