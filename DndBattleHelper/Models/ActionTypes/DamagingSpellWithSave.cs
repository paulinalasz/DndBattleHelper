namespace DndBattleHelper.Models.ActionTypes
{
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

        public bool Concentration { get; }
        public SpellSlot SpellSlot { get; }
    }
}
