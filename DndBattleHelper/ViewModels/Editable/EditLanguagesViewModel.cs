using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

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

        public override void ResetDefaults()
        {
            SelectedToAdd = 0;
        }

        public List<LanguageType> CopyNewModels()
        {
            var languages = new List<LanguageType>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var language = (LanguageViewModel)editableTraitViewModel.Content;
                languages.Add(language.Type);
            }

            return languages;
        }
    }
}
