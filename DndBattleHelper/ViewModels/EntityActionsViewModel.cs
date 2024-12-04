using System.Collections.ObjectModel;
using DndBattleHelper.Helpers;
using DndBattleHelper.ViewModels.Editable.Actions;

namespace DndBattleHelper.ViewModels
{
    public class EntityActionsViewModel : NotifyPropertyChanged
    {
        public string Header { get; }
        public ObservableCollection<EntityActionViewModel> Actions { get; }
        public bool IsVisible => Actions != null && Actions.Any();

        public EntityActionsViewModel(string header,
            ObservableCollection<EntityActionViewModel> actions)
        {
            Header = header;
            Actions = actions;
        }
    }
}
