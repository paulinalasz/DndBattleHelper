namespace DndBattleHelper.Models
{
    public class RollResult
    {
        public int Result { get; set; }
        public List<int> DiceRolls { get; set; }
        public Modifier Modifier { get; set; }

        public RollResult(int result, List<int> diceRolls, Modifier modifier)
        {
            Result = result;
            DiceRolls = diceRolls;
            Modifier = modifier;
        }

        public RollResult() { }

        public override string ToString()
        {
            var output = Result.ToString();

            if (output.Length > 0)
            {
                output += " (";
                foreach (var roll in DiceRolls)
                {
                    output += $"{roll}, ";
                }

                output += Modifier.ToString();
                output += ")";
            }

            return output;
        }
    }
}
