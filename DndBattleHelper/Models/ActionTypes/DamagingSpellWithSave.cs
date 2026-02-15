using System.Xml.Serialization;

namespace DndBattleHelper.Models.ActionTypes
{
    [XmlInclude(typeof(SpellAttack))]
    public class DamagingSpellWithSave : DamagingAction, ISpell
    {
        public DamagingSpellWithSave(string name,
            string description,
            ActionCost cost, 
            bool concentration,
            SpellSlot spellSlot,
            List<DamageRoll> damageRolls,
            string duration,
            string range,
            bool hasVerbalComponent,
            bool hasSomaticComponent,
            bool hasMaterialComponent,
            string materialComponent) 
            : base(name, description, cost, damageRolls)
        {
            DamageRolls = damageRolls;
            Concentration = concentration;
            SpellSlot = spellSlot;
            Duration = duration;
            Range = range;
            HasVerbalComponent = hasVerbalComponent;
            HasSomaticComponent = hasSomaticComponent;
            HasMaterialComponent = hasMaterialComponent;
            MaterialComponent = materialComponent;
        }

        protected DamagingSpellWithSave() { }

        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }
        public string Duration { get; set; }
        public string Range { get; set; }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }
        public string MaterialComponent { get; set; }

        public override DamagingSpellWithSave Copy()
        {
            return new DamagingSpellWithSave(Name, Description, ActionCost, Concentration, SpellSlot, DamageRolls,
                Duration, Range, HasVerbalComponent, HasSomaticComponent, HasMaterialComponent, MaterialComponent);
        }
    }
}
