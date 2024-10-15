namespace DndBattleHelper.Models
{
    public class SavingThrow
    {
        public AbilityScoreType Type { get; set; }
        public Modifier Modifier { get; set; }

        public SavingThrow(AbilityScoreType type, Modifier modifier) 
        {
            Type = type;
            Modifier = modifier;
        }

        public SavingThrow() { }

        public SavingThrow Copy()
        {
            return new SavingThrow(Type, Modifier.Copy());
        }

        public override string ToString()
        {
            return Type.ToString() + " " + Modifier.ToString();
        }
    }
}
