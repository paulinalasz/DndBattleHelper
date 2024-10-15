using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditSensesViewModel : EditTraitsViewModel
    {
        public EditSensesViewModel(List<Trait<SenseType>> senses = null) : base("Senses", false) 
        {
            if (senses != null) 
            {
                foreach (var sense in senses)
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitViewModel<SenseType>(sense)));
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
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitViewModel<SenseType>(new Trait<SenseType>(SelectedToAdd))));
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

        public List<Trait<SenseType>> CopyNewModels()
        {
            var senses = new List<Trait<SenseType>>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var senseViewModel = (TraitViewModel<SenseType>)editableTraitViewModel.Content;
                senses.Add(new Trait<SenseType>(senseViewModel.Type));
            }

            return senses;
        }
    }
}
