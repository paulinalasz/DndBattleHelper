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

        public bool Concentration { get; }
        public SpellSlot SpellSlot { get; }
    }
}
