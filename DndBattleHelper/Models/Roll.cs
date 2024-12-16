namespace DndBattleHelper.Models
{
    public class Roll
    {
        public int NumberOfDice { get; set; }
        public int DiceBase { get; set; }
        public Modifier ValueModifier { get; set; }

        protected Random rand = new Random();

        public Roll(int number, int diceBase, Modifier modifier)
        {
            NumberOfDice = number;
            DiceBase = diceBase;
            ValueModifier = modifier;
        }

        public Roll() { }

        public RollResult DoRoll()
        {
            var result = 0;
            var rolls = new List<int>();

            for (int i = 0; i < NumberOfDice; i++)
            {
                var roll = rand.Next(1, DiceBase + 1);
                result += roll;
                rolls.Add(roll);
            }

            result += ValueModifier.ToInt();

            return new RollResult(result, rolls, ValueModifier.Copy());
        }

        public Roll Copy()
        {
            return new Roll(NumberOfDice, DiceBase, ValueModifier);
        }
    }
}
