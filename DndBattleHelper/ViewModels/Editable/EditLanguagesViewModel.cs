using DndBattleHelper.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditLanguagesViewModel : NotifyPropertyChanged
    {
        public EditableTraitViewModelsViewModel EditableLanguageViewModelsViewModel { get; set; }

        public EditLanguagesViewModel() 
        {
            EditableLanguageViewModelsViewModel = new EditableTraitViewModelsViewModel(new ObservableCollection<EditableTraitViewModel>());
        }

        private LanguageType _selectedToAdd;
        public LanguageType SelectedToAdd
        {
            get {  return _selectedToAdd; } 
            set 
            { 
                _selectedToAdd = value; 
                OnPropertyChanged(nameof(SelectedToAdd)); 
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new CommandHandler(() => Add(), () => { return true; }));

        public void Add()
        {
            EditableLanguageViewModelsViewModel.EditableTraitViewModels.Add(new EditableLangaugeViewModel(SelectedToAdd));
            OnPropertyChanged(nameof(EditableLanguageViewModelsViewModel));
        }
    }
}
