using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Actions
{
    public class SpellAttackViewModel : AttackActionViewModel, ISpell
    {
        public SpellAttackViewModel(SpellAttack action, TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(action, targetArmourClassProvider, advantageDisadvantageProvider)
        {
            Concentration = action.Concentration;
            SpellSlot = action.SpellSlot;
        }

        public bool Concentration { get; set; }

        public SpellSlot SpellSlot { get; set; }
    }
}
