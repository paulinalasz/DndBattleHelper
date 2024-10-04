using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditSensesViewModel : EditTraitsViewModel
    {
        public EditSensesViewModel() : base("Senses", false) { }

        private SenseType _selectedToAdd;
        public SenseType SelectedToAdd
        {
            get { return _selectedToAdd; }
            set
            {
                _selectedToAdd = value;
                OnPropertyChanged(nameof(SelectedToAdd));
            }
        }

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new SenseViewModel(SelectedToAdd)));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }
    }
}
