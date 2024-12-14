using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class TraitWithValueViewModel<T> : TraitViewModel<T>, IEditable where T : struct
    {
        TraitWithValue<T> _trait;

        public int Value
        {
            get { return _trait.Value; }
            set
            {
                _trait.Value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public TraitWithValueViewModel(TraitWithValue<T> trait) : base(trait)
        {
            _trait = trait;
            HasValue = true;
            Value = _trait.Value;
        }

        public override string ToString()
        {
            return _trait.ToString();
        }

        public TraitWithValue<T> CopyModel()
        {
            return _trait.Copy();
        }
    }
}
