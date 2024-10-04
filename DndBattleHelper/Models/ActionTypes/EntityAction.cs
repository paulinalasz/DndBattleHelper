namespace DndBattleHelper.Models.ActionTypes
{
    public class EntityAction 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionCost ActionCost { get; set; }


        public EntityAction(string name, string description, ActionCost actionCost)
        {
            Name = name;
            Description = description;
            ActionCost = actionCost;
        }
    }
}
