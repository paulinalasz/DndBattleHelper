using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class EntityActionViewModel : NotifyPropertyChanged, IEditable
    {
        private EntityAction _action;

        public string Name 
        {
            get => _action.Name;
            set
            {
                _action.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description 
        { 
            get => _action.Description;
            set
            {
                _action.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ActionCost ActionCost 
        {
            get => _action.ActionCost;
            set
            {
                _action.ActionCost = value;
                OnPropertyChanged(nameof(ActionCost));
            }
        }

        public EntityActionViewModel(EntityAction entityAction)
        {
            _action = entityAction;
        }

        public Action ActionTaken;

        public virtual EntityAction CopyModel()
        {
            return _action.Copy();
        }
    }
}
