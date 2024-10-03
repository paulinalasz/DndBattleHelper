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

        public bool Concentration { get; }
        public SpellSlot SpellSlot { get; }
    }
}
