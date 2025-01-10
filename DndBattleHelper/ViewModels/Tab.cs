using DndBattleHelper.Helpers;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels
{
    public abstract class Tab : ViewModelBase
    {
        private ICommand _removeCommand;
        public ICommand RemoveCommand => _removeCommand ?? (new CommandHandler(Remove, () => { return true; }));

        public void Remove()
        {
            RemoveRequested?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler RemoveRequested;
    }
}
