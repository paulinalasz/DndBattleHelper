namespace DndBattleHelper.Models
{
    public class TraitWithValue<T> : Trait<T>
    {
        public int Distance { get; set; }

        public TraitWithValue(T type, int distance) : base(type)
        {
            Distance = distance;
        }

        protected TraitWithValue() { }

        public override string ToString()
        {
            var traitString = string.Empty;

            traitString += Type.ToString();
            traitString += " ";
            traitString += $"{Distance.ToString()}ft";

            return traitString;
        }

        public override TraitWithValue<T> Copy()
        {
            return new TraitWithValue<T>(Type, Distance);
        }
    }
}
