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
            SpellSlot spellSlot)
            : base(name, description, cost, damageRolls, toHit)
        {
            ToHit = toHit;
            DamageRolls = damageRolls;
            Concentration = concentration;
            SpellSlot = spellSlot;
        }

        protected SpellAttack() { }

        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }

        public SpellAttack Copy()
        {
            return new SpellAttack(Name, Description, ActionCost, Concentration, DamageRolls, ToHit, SpellSlot);
        }
    }
}
