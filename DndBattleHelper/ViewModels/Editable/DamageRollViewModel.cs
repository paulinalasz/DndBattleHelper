using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class DamageRollViewModel : NotifyPropertyChanged, IEditable
    {
        private readonly DamageRoll _damageRoll;

        public DamageRollViewModel(DamageRoll damageRoll) 
        {
            _damageRoll = damageRoll;
            DamageModifierViewModel = new ModifierViewModel(_damageRoll.ValueModifier);
        }

        public int DiceNumber
        {
            get { return _damageRoll.NumberOfDice; }
            set
            {
                _damageRoll.NumberOfDice = value;
                OnPropertyChanged(nameof(DiceNumber));
            }
        }

        public int DiceBase
        {
            get { return _damageRoll.DiceBase; }
            set
            {
                _damageRoll.DiceBase = value;
                OnPropertyChanged(nameof(DiceBase));
            }
        }

        public ModifierViewModel DamageModifierViewModel { get; }

        public DamageType SelectedDamageType
        {
            get { return _damageRoll.DamageType; }
            set
            {
                _damageRoll.DamageType = value;
                OnPropertyChanged(nameof(SelectedDamageType));
            }
        }

        public Damage RollDamage(bool criticalHit)
        {
            return _damageRoll.RollDamage(criticalHit);
        }
    }
}
