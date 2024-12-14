using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class SpellSlotAvailabilityViewModel : ViewModelBase
    {
        private SpellSlotAvailability _spellSlotAvailability;

        public SpellSlotAvailabilityViewModel(SpellSlotAvailability spellSlotAvailability)
        {
            _spellSlotAvailability = spellSlotAvailability;
        }   

        public SpellSlot SpellSlotLevel 
        {
            get => _spellSlotAvailability.SpellSlotLevel;
            set
            {
                _spellSlotAvailability.SpellSlotLevel = value;
                OnPropertyChanged(nameof(SpellSlotLevel));
            }
        }

        public int Available
        {
            get => _spellSlotAvailability.Available; 
            set
            {
                _spellSlotAvailability.Available = value;
                _spellSlotAvailability.NumberLeft = value;
                OnPropertyChanged(nameof(Available));
                OnPropertyChanged(nameof(NumberLeft));
            }
        }

        public int NumberLeft
        {
            get { return _spellSlotAvailability.NumberLeft; }
            set
            {
                _spellSlotAvailability.NumberLeft = value;
                OnPropertyChanged(nameof(NumberLeft));
            }
        }

        public void ResetUsed()
        {
            NumberLeft = Available;
        }

        public SpellSlotAvailability CopyModel()
        {
            return _spellSlotAvailability.Copy();
        }
    }
}
