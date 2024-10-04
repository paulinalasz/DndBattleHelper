namespace DndBattleHelper.Models.ActionTypes
{
    public class NonDamagingSpell : EntityAction, ISpell
    {
        public NonDamagingSpell(string name, 
            string description, 
            ActionCost cost, 
            bool concentration,
            SpellSlot spellSlot) 
            : base(name, description, cost)
        {
            Concentration = concentration;
            SpellSlot = spellSlot;
        }

        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }

        public NonDamagingSpell Copy()
        {
            return new NonDamagingSpell(Name, Description, ActionCost, Concentration, SpellSlot);
        }
    }
}
