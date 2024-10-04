using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EntityActionFactory
    {
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;

        public EntityActionFactory(TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) 
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
        }

        public EntityActionViewModel Create(string name,
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
                return new EntityActionViewModel(new EntityAction(name, description, actionCost));
            }
            else if(!isSpell && !hasModifier && damageRollsEnabled)
            {
                return new DamagingActionViewModel(new DamagingAction(name, description, actionCost, damageRolls));
            }
            else if(!isSpell && hasModifier && !damageRollsEnabled) 
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if(!isSpell && hasModifier && damageRollsEnabled)
            {
                return new AttackActionViewModel(new AttackAction(name, description, actionCost, damageRolls, toHitModifier), _targetArmourClassProvider, _advantageDisadvantageProvider);
            }
            else if(isSpell && !hasModifier && !damageRollsEnabled)
            {
                return new NonDamagingSpellViewModel(new NonDamagingSpell(name, description, actionCost, true, spellSlot));
            }
            else if(isSpell && !hasModifier && damageRollsEnabled)
            {
                return new DamagingSpellWithSaveViewModel(new DamagingSpellWithSave(name, description, actionCost, true, spellSlot, damageRolls));
            }
            else if(isSpell && hasModifier && !damageRollsEnabled)
            {
                throw new ArgumentException("No such action type. Make this not possible with UI rules");
            }
            else if(isSpell && hasModifier && damageRollsEnabled)
            {
                return new SpellAttackViewModel(new SpellAttack(name, description, actionCost, true, damageRolls, toHitModifier, spellSlot), _targetArmourClassProvider, _advantageDisadvantageProvider);
            }
            else
            {
                throw new ArgumentException("if you got here you changed the check points and something went wrong");
            }
        }
    }
}
