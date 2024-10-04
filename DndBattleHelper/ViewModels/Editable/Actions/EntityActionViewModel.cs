using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class EntityActionViewModel : NotifyPropertyChanged, IEditable
    {
        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description 
        { 
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private ActionCost _actionCost;
        public ActionCost ActionCost 
        {
            get => _actionCost;
            set
            {
                _actionCost = value;
                OnPropertyChanged(nameof(ActionCost));
            }
        }

        public EntityActionViewModel(EntityAction entityAction)
        {
            _name = entityAction.Name;
            _description = entityAction.Description; 
            _actionCost = entityAction.ActionCost;
        }

        public Action ActionTaken;
    }
}
