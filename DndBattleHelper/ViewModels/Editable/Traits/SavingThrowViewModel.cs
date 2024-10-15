using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class SavingThrowViewModel : NotifyPropertyChanged, IEditable
    {
        private readonly SavingThrow _savingThrow;

        public AbilityScoreType Type
        {
            get => _savingThrow.Type;
            set
            {
                _savingThrow.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public ModifierViewModel ModifierViewModel;

        public SavingThrowViewModel(SavingThrow savingThrow)
        {
            _savingThrow = savingThrow;
            ModifierViewModel = new ModifierViewModel(_savingThrow.Modifier);
        }

        public SavingThrow CopyModel()
        {
            return _savingThrow.Copy();
        }

        public override string ToString()
        {
            return _savingThrow.ToString();
        }
    }
}
