namespace DndBattleHelper.Models
{
    public class DamageRoll
    {
        public int NumberOfDice { get; set; }
        public int DiceBase { get; set; }
        public Modifier DamageModifier { get; set; }
        public DamageType DamageType { get; set; }
        public Modifier ToHitModifier { get; set; }

        public DamageRoll(int number, int diceBase, Modifier modifier, DamageType damageType, Modifier toHitModifier)
        {
            NumberOfDice = number;
            DiceBase = diceBase;
            DamageModifier = modifier;
            DamageType = damageType;
            ToHitModifier = toHitModifier;
        }

        public bool DoesAttackHit(int armourClass)
        {
            Random rand = new Random();

            var roll = rand.Next(1, 21);

            var withModifier = roll + ToHitModifier.ToInt();

            if (withModifier >= armourClass)
            {
                return true;
            }

            return false;
        }

        public Damage RollDamage()
        {
            Random rand = new Random();

            var damage = 0;

            for(int i = 0; i <= NumberOfDice; i++) 
            {
                damage += rand.Next(1, DiceBase + 1);
            }

            return new Damage(damage, DamageType);
        }

        public Damage RollToHitAndDamage(int armourClass)
        {
            Random rand = new Random();

            if (!DoesAttackHit(armourClass))
            {
                return new Damage(0, DamageType.Miss);
            }

            return RollDamage();
        }
    }
}
