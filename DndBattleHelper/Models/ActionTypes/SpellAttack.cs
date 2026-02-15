namespace DndBattleHelper.Models.ActionTypes
{
    public class SpellAttack : AttackAction, ISpell
    {
        public SpellAttack(string name,
            string description,
            ActionCost cost,
            bool concentration,
            List<DamageRoll> damageRolls,
            Modifier toHit,
            SpellSlot spellSlot,
            string duration,
            string range,
            bool hasVerbalComponent,
            bool hasSomaticComponent,
            bool hasMaterialComponent,
            string materialComponent)
            : base(name, description, cost, damageRolls, toHit)
        {
            ToHit = toHit;
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

        protected SpellAttack() { }

        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }
        public string Duration { get; set; }
        public string Range { get; set; }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }
        public string MaterialComponent { get; set; }

        public override SpellAttack Copy()
        {
            return new SpellAttack(Name, Description, ActionCost, Concentration, DamageRolls, ToHit, SpellSlot,
                Duration, Range, HasVerbalComponent, HasSomaticComponent, HasMaterialComponent, MaterialComponent);
        }
    }
}
