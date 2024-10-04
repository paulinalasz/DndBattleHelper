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

        public EntityActionViewModel Create(EntityAction model)
        {
            return new EntityActionViewModel(model);
        }

        public DamagingActionViewModel Create(DamagingAction model)
        {
            return new DamagingActionViewModel(model);
        }

        public AttackActionViewModel Create(AttackAction model) 
        {
            return new AttackActionViewModel(model, _targetArmourClassProvider, _advantageDisadvantageProvider);
        }

        public NonDamagingSpellViewModel Create(NonDamagingSpell model)
        {
            return new NonDamagingSpellViewModel(model);
        }

        public DamagingSpellWithSaveViewModel Create(DamagingSpellWithSave model)
        {
            return new DamagingSpellWithSaveViewModel(model);
        }

        public SpellAttackViewModel Create(SpellAttack model) 
        {
            return new SpellAttackViewModel(model, _targetArmourClassProvider, _advantageDisadvantageProvider);
        }
    }
}
