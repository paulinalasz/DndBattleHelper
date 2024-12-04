using DndBattleHelper.Helpers;
using System.Windows.Input;
using DndBattleHelper.Models;
using System.Windows.Navigation;

namespace DndBattleHelper.ViewModels
{
    public class RollViewModel : NotifyPropertyChanged
    {
        private readonly Roll _roll;

        public string Title { get; set; }

        public RollViewModel(Roll roll, string title, bool isRollVisible, bool isDiceChangeEnabled = true) 
        {
            _roll = roll;
            IsRollVisible = isRollVisible;
            IsDiceChangeEnabled = isDiceChangeEnabled;

            Title = title;

            ValueModifierViewModel = new ModifierViewModel(_roll.ValueModifier);
        }

        public int DiceNumber
        {
            get => _roll.NumberOfDice;
            set
            {
                _roll.NumberOfDice = value;
                OnPropertyChanged(nameof(DiceNumber));
            }
        }

        public int DiceBase
        {
            get => _roll.DiceBase;
            set
            {
                _roll.DiceBase = value;
                OnPropertyChanged(nameof(DiceBase));
            }
        }

        public ModifierViewModel ValueModifierViewModel
        {
            get => new ModifierViewModel(_roll.ValueModifier);
            set
            {
                _roll.ValueModifier = new Modifier(value.ModifierType, value.ModifierValue);
                OnPropertyChanged(nameof(ValueModifierViewModel));
            }
        }



        private ICommand _rollCommand;
        public ICommand RollCommand => _rollCommand ?? (_rollCommand = new CommandHandler(RollValue, () => { return true; }));

        public Action Rolled;

        public int ValueRolled { get; set; }
        public bool IsRollVisible { get; }
        public bool IsDiceChangeEnabled { get; }

        public void RollValue()
        {
            ValueRolled = _roll.RollValue();
            Rolled?.Invoke();
        }

        public Roll CopyModel()
        {
            return _roll.Copy();
        }
    }
}
