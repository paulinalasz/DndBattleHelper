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
            VerificationError = string.Empty;
        }

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new CommandHandler(() => Add(), () => CanAdd()));

        #region Verification
        private string _verificaitonError;
        public string VerificationError
        {
            get => _verificaitonError;
            set
            {
                _verificaitonError = value;
                OnPropertyChanged(nameof(VerificationError));
                OnPropertyChanged(nameof(IsVerificationErrorVisible));
            }
        }

        protected void AddVerificationError(string errorMessage, out bool verified)
        {
            if (VerificationError != "")
            {
                VerificationError += "\n";
            }

            VerificationError += errorMessage;
            verified = false;
        }

        public bool IsVerificationErrorVisible => VerificationError.Any();

        protected abstract bool VerifyAdd();
        #endregion

        protected abstract void CreateItem();

        public void Add()
        {
            VerificationError = "";
            if (!VerifyAdd()) return;
            CreateItem();
            OnPropertyChanged(nameof(EditableTraitViewModelsViewModel));
            ResetDefaults();
        }

        public abstract bool CanAdd();
        public abstract void ResetDefaults();
    }
}
