using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EntityActionViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionCost Type { get; set; }
        public List<DamageRoll> DamageRolls { get; set; }

        public EntityActionViewModel(EntityAction entityAction)
        {
            Name = entityAction.Name;
            Description = entityAction.Description; 
            Type = entityAction.Type;
            DamageRolls = entityAction.DamageRolls;
        }
    }
}
