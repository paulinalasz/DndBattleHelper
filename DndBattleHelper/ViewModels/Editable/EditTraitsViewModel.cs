using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableDamageRoll : EditableTraitViewModel
    {
        private readonly DamageRoll _damageRoll;

        public EditableDamageRoll(DamageRoll damageRoll) 
        {
            _damageRoll = damageRoll;
        }

        public ModifierViewModel DamageModifierViewModel { get; }

        public override bool HasModifier => true;
    }

    public class EditDamageRollsViewModel : EditTraitsViewModel
    {
        public EditDamageRollsViewModel() : base("", false) 
        {
            DamageModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
        }

        private int _diceNumber;
        public int DiceNumber 
        { 
            get {  return _diceNumber; }
            set
            {
                _diceNumber = value;
                OnPropertyChanged(nameof(DiceNumber));
            }
        }

        private int _diceBase;
        public int DiceBase 
        { 
            get { return _diceBase; }
            set
            {
                _diceBase = value;
                OnPropertyChanged(nameof(DiceBase));
            }
        }

        public ModifierViewModel DamageModifierViewModel { get; }

        private DamageType _selectedDamageType;
        public DamageType SelectedDamageType
        {
            get => _selectedDamageType;
            set
            {
                _selectedDamageType = value;
                OnPropertyChanged(nameof(SelectedDamageType));
            }
        }

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new DamageRoll(DiceNumber, DiceBase, new Modifier(DamageModifierViewModel.ModifierType, DamageModifierViewModel.ModifierValue), SelectedDamageType));
            base.Add();
        }

        public override bool CanAdd()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class EditTraitsViewModel : NotifyPropertyChanged
    {
        public string Header { get; set; }
        public bool HasModifier { get; }
        public EditableTraitViewModelsViewModel EditableTraitViewModelsViewModel { get; set; }

        public EditTraitsViewModel(string header, bool hasModifier) 
        {
            Header = header;
            HasModifier = hasModifier;
            EditableTraitViewModelsViewModel = new EditableTraitViewModelsViewModel(new ObservableCollection<EditableTraitViewModel>());
        }

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new CommandHandler(() => Add(), () => CanAdd()));

        public virtual void Add()
        {
            OnPropertyChanged(nameof(EditableTraitViewModelsViewModel));
        }

        public abstract bool CanAdd();
    }
}
