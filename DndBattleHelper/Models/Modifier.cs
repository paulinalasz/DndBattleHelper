using DndBattleHelper.Helpers;

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

        private Modifier() { }

        public override string ToString()
        {
            var modifierString = EnumHelper.Description(Type);

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

        public Modifier Copy()
        {
            return new Modifier(Type, Value);
        }
    }
}
