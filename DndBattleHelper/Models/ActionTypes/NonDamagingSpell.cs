namespace DndBattleHelper.Models.ActionTypes
{
    public class NonDamagingSpell : EntityAction, ISpell
    {
        public NonDamagingSpell(string name, 
            string description, 
            ActionCost cost, 
            bool concentration,
            SpellSlot spellSlot,
            string duration,
            string range,
            bool hasVerbalComponent,
            bool hasSomaticComponent,
            bool hasMaterialComponent,
            string materialComponent) 
            : base(name, description, cost)
        {
            Concentration = concentration;
            SpellSlot = spellSlot;
            Duration = duration;
            Range = range;
            HasVerbalComponent = hasVerbalComponent;
            HasSomaticComponent = hasSomaticComponent;
            HasMaterialComponent = hasMaterialComponent;
            MaterialComponent = materialComponent;
        }

        public NonDamagingSpell() { }

        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }
        public string Duration { get; set; }
        public string Range { get; set; }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }
        public string MaterialComponent { get; set; }

        public override NonDamagingSpell Copy()
        {
            return new NonDamagingSpell(Name, Description, ActionCost, Concentration, SpellSlot,
                Duration, Range, HasVerbalComponent, HasSomaticComponent, HasMaterialComponent, MaterialComponent);
        }
    }
}
