using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class ModifierViewModel : NotifyPropertyChanged
    {
        private Modifier _modifier { get; }

        public ModifierViewModel(Modifier modifier) 
        {
            _modifier = modifier;
        }

        public ModifierType ModifierType
        {
            get { return _modifier.Type; }
            set
            {
                _modifier.Type = value;
                OnPropertyChanged(nameof(ModifierType));
                OnPropertyChanged(nameof(IsModifierValueEnabled));
            }
        }

        public int ModifierValue
        {
            get { return _modifier.Value; }
            set
            {
                _modifier.Value = value;
                OnPropertyChanged(nameof(ModifierValue));
            }
        }

        public bool IsModifierValueEnabled => ModifierType != ModifierType.Neutral;

        public Modifier CopyModel()
        {
            return _modifier.Copy();
        }
    }
}
