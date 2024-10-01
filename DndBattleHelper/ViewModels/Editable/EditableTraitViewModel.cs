using DndBattleHelper.Helpers;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels.Editable
{
    public abstract class EditableTraitViewModel : NotifyPropertyChanged
    {
        private ICommand _removeCommand;
        public ICommand RemoveCommand => _removeCommand ?? (_removeCommand = new CommandHandler(() => Remove(), () => { return true; }));

        public Action Removed;
        
        public void Remove()
        {
            Removed?.Invoke();
        }

        public virtual bool IsRemoveVisible => true;
        public abstract bool HasModifier { get; }
    }
}
