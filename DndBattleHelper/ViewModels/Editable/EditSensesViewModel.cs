using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditSensesViewModel : EditTraitsViewModel
    {
        public EditSensesViewModel(string header) : base(header, false) { }

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
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableSenseViewModel(SelectedToAdd));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }
    }
}
