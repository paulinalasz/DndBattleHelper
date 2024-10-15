using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class TraitViewModel<T> : NotifyPropertyChanged, IEditable where T : struct 
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

        public TraitViewModel(Trait<T> trait)
        {
            _trait = trait;
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
