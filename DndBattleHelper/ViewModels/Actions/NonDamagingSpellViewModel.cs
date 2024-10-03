using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Actions
{
    public class NonDamagingSpellViewModel : EntityActionViewModel, ISpell
    {
        public NonDamagingSpellViewModel(NonDamagingSpell action) : base(action)
        {
            Concentration = action.Concentration;
            SpellSlot = action.SpellSlot;
        }

        public bool Concentration { get; set; }

        public SpellSlot SpellSlot { get; set; }
    }
}
