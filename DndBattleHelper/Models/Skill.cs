namespace DndBattleHelper.Models
{
    public class Trait<T> 
    {
        public T Type { get; set; }
        public Trait(T type)
        {
            Type = type;
        }

        protected Trait() { }

        public override string ToString()
        {
            var traitString = string.Empty;

            traitString += Type.ToString();
            traitString += " ";

            return traitString;
        }

        public virtual Trait<T> Copy()
        {
            return new Trait<T>(Type);
        }
    }

    // where T is enum type
    public class TraitWithModifier<T> : Trait<T>
    {
        public Modifier Modifier { get; set; }

        public TraitWithModifier(T type, Modifier modifier) : base(type)
        {
            Modifier = modifier;
        }

        protected TraitWithModifier() { }

        public override string ToString()
        {
            var traitString = string.Empty;

            traitString += Type.ToString();
            traitString += " ";
            traitString += Modifier.ToString();

            return traitString;
        }

        public override TraitWithModifier<T> Copy()
        {
            return new TraitWithModifier<T>(Type, Modifier.Copy());
        }
    }
}
