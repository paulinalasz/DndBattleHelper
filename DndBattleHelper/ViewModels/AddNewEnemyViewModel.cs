using DndBattleHelper.Helpers;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyViewModel : IDialogRequestClose
    {
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        public AddNewEnemyViewModel()
        {
        }

        private ICommand _okCommand;
        public ICommand OkCommand => _okCommand ?? 
            (_okCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true)), () => { return true; }));

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ?? 
            (_cancelCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), () => {  return true; }));
    }
}
