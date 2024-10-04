using DndBattleHelper.Helpers;
using System.ComponentModel;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels.Editable.Traits
{

    public class EditableTraitViewModel : NotifyPropertyChanged
    {
        public IEditable Content { get; }

        public EditableTraitViewModel(IEditable content)
        {
            Content = content;
        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand => _removeCommand ?? (_removeCommand = new CommandHandler(() => Remove(), () => { return true; }));

        public Action Removed;

        public void Remove()
        {
            Removed?.Invoke();
        }

        public virtual bool IsRemoveVisible => true;
    }
}
