using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditLanguagesViewModel : EditTraitsViewModel
    {
        public EditLanguagesViewModel() : base("Languages", false) { }

        private LanguageType _selectedToAdd;
        public LanguageType SelectedToAdd
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
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new LanguageViewModel(SelectedToAdd)));
            base.Add();
        }

        public override bool CanAdd() 
        {
            return true;
        }
    }
}
