using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using DndBattleHelper.ViewModels.Editable.Actions;

namespace DndBattleHelper.ViewModels.Editable
{
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
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new DamageRollViewModel(new DamageRoll(DiceNumber, DiceBase, new Modifier(DamageModifierViewModel.ModifierType, DamageModifierViewModel.ModifierValue), SelectedDamageType))));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }

        public override void ResetDefaults()
        {
            DiceNumber = 0;
            DiceBase = 0;
            DamageModifierViewModel.ModifierType = 0;
            DamageModifierViewModel.ModifierValue = 0;
            SelectedDamageType = 0;
        }

        public List<DamageRoll> CopyNewModels()
        {
            var damageRolls = new List<DamageRoll>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var damageRollViewModel = (DamageRollViewModel)editableTraitViewModel.Content;

                damageRolls.Add(damageRollViewModel.CopyModel());
            }

            return damageRolls;
        }
    }
}
