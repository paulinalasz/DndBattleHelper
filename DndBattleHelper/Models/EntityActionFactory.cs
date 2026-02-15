using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class EntityActionFactory()
    {
        public EntityAction Create(string name,
        string description,
        ActionCost actionCost,
        bool hasDamageRolls,
        List<DamageRoll> damageRolls,
        bool hasModifier,
        Modifier toHitModifier,
        bool isSpell,
        SpellSlot spellSlot,
        bool concentration,
        string duration,
        string range,
        bool hasVerbalComponent,
        bool hasSomaticComponent,
        bool hasMaterialComponent,
        string materialComponent)
        {
            if (!isSpell && !hasModifier && !hasDamageRolls)
            {
                return new EntityAction(name, description, actionCost);
            }
            else if (!isSpell && !hasModifier && hasDamageRolls)
            {
                return new DamagingAction(name, description, actionCost, damageRolls);
            }
            else if (!isSpell && hasModifier && !hasDamageRolls)
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if (!isSpell && hasModifier && hasDamageRolls)
            {
                return new AttackAction(name, description, actionCost, damageRolls, toHitModifier);
            }
            else if (isSpell && !hasModifier && !hasDamageRolls)
            {
                return new NonDamagingSpell(name, description, actionCost, concentration, spellSlot,
                    duration, range, hasVerbalComponent, hasSomaticComponent, hasMaterialComponent, materialComponent);
            }
            else if (isSpell && !hasModifier && hasDamageRolls)
            {
                return new DamagingSpellWithSave(name, description, actionCost, concentration, spellSlot, damageRolls,
                    duration, range, hasVerbalComponent, hasSomaticComponent, hasMaterialComponent, materialComponent);
            }
            else if (isSpell && hasModifier && !hasDamageRolls)
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if (isSpell && hasModifier && hasDamageRolls)
            {
                return new SpellAttack(name, description, actionCost, concentration, damageRolls, toHitModifier, spellSlot,
                    duration, range, hasVerbalComponent, hasSomaticComponent, hasMaterialComponent, materialComponent);
            }
            else
            {
                throw new ArgumentException("if you got here you changed the check points and something went wrong");
            }
        }
    }
}
