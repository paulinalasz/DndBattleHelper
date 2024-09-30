using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class ModifierViewModel : NotifyPropertyChanged
    {
        public Modifier Modifier { get; }

        public ModifierViewModel(Modifier modifier) 
        {
            Modifier = modifier;
        }

        public ModifierType ModifierType
        {
            get { return Modifier.Type; }
            set
            {
                Modifier.Type = value;
                OnPropertyChanged(nameof(ModifierType));
                OnPropertyChanged(nameof(IsModifierValueEnabled));
            }
        }

        public int ModifierValue
        {
            get { return Modifier.Value; }
            set
            {
                Modifier.Value = value;
                OnPropertyChanged(nameof(ModifierValue));
            }
        }

        public bool IsModifierValueEnabled => ModifierType != ModifierType.Neutral;
    }
}
