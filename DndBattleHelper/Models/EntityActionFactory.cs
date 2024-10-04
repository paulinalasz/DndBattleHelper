using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class EntityActionFactory()
    {
        public EntityAction Create(string name,
        string description,
        ActionCost actionCost,
        bool damageRollsEnabled,
        List<DamageRoll> damageRolls,
        bool hasModifier,
        Modifier toHitModifier,
        bool isSpell,
        SpellSlot spellSlot)
        {
            if (!isSpell && !hasModifier && !damageRollsEnabled)
            {
                return new EntityAction(name, description, actionCost);
            }
            else if (!isSpell && !hasModifier && damageRollsEnabled)
            {
                return new DamagingAction(name, description, actionCost, damageRolls);
            }
            else if (!isSpell && hasModifier && !damageRollsEnabled)
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if (!isSpell && hasModifier && damageRollsEnabled)
            {
                return new AttackAction(name, description, actionCost, damageRolls, toHitModifier);
            }
            else if (isSpell && !hasModifier && !damageRollsEnabled)
            {
                return new NonDamagingSpell(name, description, actionCost, true, spellSlot);
            }
            else if (isSpell && !hasModifier && damageRollsEnabled)
            {
                return new DamagingSpellWithSave(name, description, actionCost, true, spellSlot, damageRolls);
            }
            else if (isSpell && hasModifier && !damageRollsEnabled)
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if (isSpell && hasModifier && damageRollsEnabled)
            {
                return new SpellAttack(name, description, actionCost, true, damageRolls, toHitModifier, spellSlot);
            }
            else
            {
                throw new ArgumentException("if you got here you changed the check points and something went wrong");
            }
        }
    }
}
