using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditSensesViewModel : EditTraitsViewModel
    {
        public EditSensesViewModel(List<SenseType> senses = null) : base("Senses", false) 
        {
            if (senses != null) 
            {
                foreach (SenseType sense in senses)
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new SenseViewModel(sense)));
                }
            }
        }

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

        public override void ResetDefaults()
        {
            SelectedToAdd = 0;
        }

        public List<SenseType> CopyNewModels()
        {
            var senses = new List<SenseType>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var senseViewModel = (SenseViewModel)editableTraitViewModel.Content;
                senses.Add(senseViewModel.Type);
            }

            return senses;
        }
    }
}
