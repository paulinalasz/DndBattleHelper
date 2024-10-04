using DndBattleHelper.Helpers;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels.Editable
{
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
            ResetDefaults();
        }

        public abstract void ResetDefaults();

        public abstract bool CanAdd();
    }
}
