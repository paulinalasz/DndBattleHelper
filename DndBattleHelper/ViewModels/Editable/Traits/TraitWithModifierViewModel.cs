using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class TraitWithModifierViewModel<T> : TraitViewModel<T>, IEditable where T : struct
    {
        private TraitWithModifier<T> _trait;

        public ModifierViewModel ModifierViewModel { get; }

        public TraitWithModifierViewModel(TraitWithModifier<T> trait) : base(trait)
        {
            _trait = trait;
            HasModifier = true;
            ModifierViewModel = new ModifierViewModel(_trait.Modifier);
        }

        public override string ToString()
        {
            return _trait.ToString();
        }

        public TraitWithModifier<T> CopyModel()
        {
            return _trait.Copy();
        }
    }
}
