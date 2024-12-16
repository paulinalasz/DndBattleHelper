namespace DndBattleHelper.Models
{
    public class DamageRollResult : RollResult
    {
        public DamageType DamageType { get; set; }

        public DamageRollResult(int result, List<int> diceRolls, Modifier modifier, DamageType damageType) : base(result, diceRolls, modifier)
        {
            DamageType = damageType;
        }

        public DamageRollResult() { }

        public override string ToString()
        {
            var damageOutput = base.ToString();

            damageOutput += $" {DamageType}";

            return damageOutput;
        }
    }
}
