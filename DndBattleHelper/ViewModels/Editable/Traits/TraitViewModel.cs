using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class TraitViewModel<T> : ViewModelBase, IEditable where T : struct 
    {
        private Trait<T> _trait;
        public T Type
        {
            get => _trait.Type;
            set
            {
                _trait.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public bool HasModifier { get; set; }
        public bool HasValue { get; set; }

        public TraitViewModel(Trait<T> trait)
        {
            _trait = trait;

            HasModifier = false;
            HasValue = false;
        }

        public override string ToString()
        {
            return _trait.ToString();
        }

        public virtual Trait<T> CopyModel()
        {
            return _trait.Copy();
        }
    }
}
