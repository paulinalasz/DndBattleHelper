namespace DndBattleHelper.Models
{
    public class TraitWithValue<T> : Trait<T>
    {
        public int Value { get; set; }

        public TraitWithValue(T type, int value) : base(type)
        {
            Value = value;
        }

        protected TraitWithValue() { }

        public override string ToString()
        {
            var traitString = string.Empty;

            traitString += Type.ToString();
            traitString += " ";
            traitString += $"{Value.ToString()}ft";

            return traitString;
        }

        public override TraitWithValue<T> Copy()
        {
            return new TraitWithValue<T>(Type, Value);
        }
    }
}
