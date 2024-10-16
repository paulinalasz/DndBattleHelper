namespace DndBattleHelper.Models
{
    public class SpellSlotAvailability
    {
        public SpellSlot SpellSlotLevel { get; set; }
        public int Available { get; set; }
        public int NumberLeft { get; set; }

        public SpellSlotAvailability(SpellSlot spellSlotLevel, int number, int numberLeft)
        {
            SpellSlotLevel = spellSlotLevel;
            Available = number;
            NumberLeft = numberLeft;
        }

        public SpellSlotAvailability() { }

        public SpellSlotAvailability Copy()
        {
            return new SpellSlotAvailability(SpellSlotLevel, Available, NumberLeft);
        }
    }
}
