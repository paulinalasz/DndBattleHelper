using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Actions
{
    public class EntityActionViewModel
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
