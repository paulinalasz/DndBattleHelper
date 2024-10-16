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
            List<DamageRoll> damageRolls) 
            : base(name, description, cost, damageRolls)
        {
            DamageRolls = damageRolls;
            Concentration = concentration;
            SpellSlot = spellSlot;
        }

        protected DamagingSpellWithSave() { }

        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }

        public override DamagingSpellWithSave Copy()
        {
            return new DamagingSpellWithSave(Name, Description, ActionCost, Concentration, SpellSlot, DamageRolls);
        }
    }
}
