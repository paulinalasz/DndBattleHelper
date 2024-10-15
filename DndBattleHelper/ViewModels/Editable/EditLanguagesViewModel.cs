using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditLanguagesViewModel : EditTraitsViewModel
    {
        public EditLanguagesViewModel(List<Trait<LanguageType>> languages = null) : base("Languages", false) 
        {
            if(languages != null)
            {
                foreach(var language in languages)
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitViewModel<LanguageType>(language)));
                }
            }
        }

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
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitViewModel<LanguageType>(new Trait<LanguageType>(SelectedToAdd))));
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

        public List<Trait<LanguageType>> CopyNewModels()
        {
            var languages = new List<Trait<LanguageType>>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var language = (TraitViewModel<LanguageType>)editableTraitViewModel.Content;
                languages.Add(new Trait<LanguageType>(language.Type));
            }

            return languages;
        }
    }
}
