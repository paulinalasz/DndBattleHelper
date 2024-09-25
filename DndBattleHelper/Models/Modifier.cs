namespace DndBattleHelper.Models
{
    public class Modifier
    {
        public ModifierType Type { get; set; }
        public int Value { get; set; }  

        public Modifier(ModifierType modifierType, int value)
        {
            Type = modifierType;
            Value = value;
        }

        public override string ToString()
        {
            var modifierString = string.Empty;

            switch (Type)
            {
                case ModifierType.Plus:
                    modifierString = "+";
                    break;
                case ModifierType.Minus:
                    modifierString = "-";
                    break;
                case ModifierType.Neutral:
                    modifierString = string.Empty;
                    break;
            }

            modifierString += Value.ToString();
            return modifierString;
        }

        public int ToInt()
        {
            if (Type == ModifierType.Minus)
            {
                return Value * -1;
            }

            return Value;
        }
    }
}
