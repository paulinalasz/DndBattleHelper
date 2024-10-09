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

        public int RollValue()
        {
            var roll = 0;

            for (int i = 0; i < NumberOfDice; i++)
            {
                roll += rand.Next(1, DiceBase + 1);
            }

            roll += ValueModifier.ToInt();

            return roll;
        }
    }
}
