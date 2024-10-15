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
}
