using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class NonDamagingSpellViewModel : EntityActionViewModel, ISpell
    {
        private NonDamagingSpell _action;

        public NonDamagingSpellViewModel(NonDamagingSpell action) : base(action)
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

        public override NonDamagingSpell CopyModel()
        {
            return _action.Copy();
        }
    }
}
