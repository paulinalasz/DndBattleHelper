using System.Collections.ObjectModel;
using DndBattleHelper.Helpers;
using DndBattleHelper.ViewModels.Editable.Actions;

namespace DndBattleHelper.ViewModels
{
    public class EntityActionsViewModel : NotifyPropertyChanged
    {
        public string Header { get; }
        public ObservableCollection<EntityActionViewModel> Actions { get; }
        public string Description { get; }
        public bool IsDescriptionVisible => Description.Any();
        public bool IsVisible => Actions != null && Actions.Any();

        public EntityActionsViewModel(string header,
            ObservableCollection<EntityActionViewModel> actions,
            string description = "")
        {
            Header = header;
            Actions = actions;

            //TODO: Remove this once released and upgrade code for presets is introduced.
            if (description != null)
            {
                Description = description;
            }
            else
            {
                Description = "";
            }
        }
    }
}
