using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;
using DndBattleHelper.ViewModels.Editable;

namespace DndBattleHelper.ViewModels.Actions
{
    public class EntityActionViewModel : IEditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionCost Type { get; set; }

        public EntityActionViewModel(EntityAction entityAction)
        {
            Name = entityAction.Name;
            Description = entityAction.Description; 
            Type = entityAction.Type;
        }

        public Action ActionTaken;
    }
}
