namespace DndBattleHelper.Models
{
    public class DamageRoll : Roll
    {
        public DamageType DamageType { get; set; }

        public DamageRoll(int number, int diceBase, Modifier damageModifier, DamageType damageType)
            : base(number, diceBase, damageModifier)
        {
            NumberOfDice = number;
            DiceBase = diceBase;
            ValueModifier = damageModifier;
            DamageType = damageType;
        }

        public DamageRoll() { }

        public DamageRollResult RollDamage(bool critialHit)
        {
            var rollResult = DoRoll(); 

            if(critialHit) 
            {
                var criticalDamage = DoRoll();

                // We want to take away one modifier value else we have added it twice.
                rollResult.Result += criticalDamage.Result - ValueModifier.ToInt();
                rollResult.DiceRolls.AddRange(criticalDamage.DiceRolls);
            }

            return new DamageRollResult(rollResult.Result, rollResult.DiceRolls, ValueModifier.Copy(), DamageType);
        }

        public DamageRoll Copy()
        {
            return new DamageRoll(NumberOfDice, DiceBase, ValueModifier.Copy(), DamageType);
        }
    }
}
