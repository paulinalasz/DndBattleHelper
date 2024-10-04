using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class SpellAttackViewModel : AttackActionViewModel, ISpell
    {
        private SpellAttack _action;

        public SpellAttackViewModel(SpellAttack action, TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(action, targetArmourClassProvider, advantageDisadvantageProvider)
        {
            _action = action;
        }

        public bool Concentration
        {
            get => _action.Concentration;
            set
            {
                _action.Concentration = value;
                OnPropertyChanged(nameof(Concentration));
            }
        }

        public SpellSlot SpellSlot
        {
            get => _action.SpellSlot;
            set
            {
                _action.SpellSlot = value;
                OnPropertyChanged(nameof(SpellSlot));
            }
        }
    }
}
