using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EntityActionViewModelFactory
    {
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;

        public EntityActionViewModelFactory(TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) 
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
        }

        private DamagingActionViewModel Create(DamagingAction model)
        {
            return new DamagingActionViewModel(model);
        }

        private AttackActionViewModel Create(AttackAction model) 
        {
            return new AttackActionViewModel(model, _targetArmourClassProvider, _advantageDisadvantageProvider);
        }

        private NonDamagingSpellViewModel Create(NonDamagingSpell model)
        {
            return new NonDamagingSpellViewModel(model);
        }

        private DamagingSpellWithSaveViewModel Create(DamagingSpellWithSave model)
        {
            return new DamagingSpellWithSaveViewModel(model);
        }

        private SpellAttackViewModel Create(SpellAttack model) 
        {
            return new SpellAttackViewModel(model, _targetArmourClassProvider, _advantageDisadvantageProvider);
        }

        public EntityActionViewModel Create(EntityAction model)
        {
            if (model is ISpell)
            {
                switch (model)
                {
                    case SpellAttack spellAttack:
                        return Create(spellAttack);
                    case NonDamagingSpell nonDamagingSpell:
                        return Create(nonDamagingSpell);
                    case DamagingSpellWithSave damagingSpellWithSave:
                        return Create(damagingSpellWithSave);
                    default:
                        return new EntityActionViewModel(model);
                }
            }

            switch (model)
            {
                case AttackAction attackAction:
                    return Create(attackAction);
                case DamagingAction damagingAction:
                    return Create(damagingAction);
                default:
                    return new EntityActionViewModel(model);
            }
        }
    }
}
