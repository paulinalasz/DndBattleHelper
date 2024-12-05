using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class TraitWithValueViewModel<T> : TraitViewModel<T>, IEditable where T : struct
    {
        TraitWithValue<T> _trait;

        public int Distance
        {
            get { return _trait.Distance; }
            set
            {
                _trait.Distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        public TraitWithValueViewModel(TraitWithValue<T> trait) : base(trait)
        {
            _trait = trait;
            Distance = _trait.Distance;
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
