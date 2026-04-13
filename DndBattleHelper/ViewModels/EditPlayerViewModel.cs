using DndBattleHelper.Helpers;
using DndBattleHelper.Helpers.DialogService;
using DndBattleHelper.Models;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels
{
    public class EditPlayerViewModel : PlayerViewModel, IDialogRequestClose
    {
        public EditPlayerViewModel(PlayerViewModel playerViewModel)
            : base(new Player(playerViewModel.Name, playerViewModel.Initiative, playerViewModel.Health, playerViewModel.ArmourClass))
        {
        }

        #region dialogService
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _editCommand;
        public ICommand EditCommand => _editCommand ??
            (_editCommand = new CommandHandler(Edit, () => { return true; }));

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??
            (_cancelCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), () => { return true; }));
        #endregion

        public Action Edited;

        public void Edit()
        {
            Edited?.Invoke();
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }
    }
}
