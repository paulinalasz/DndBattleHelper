namespace DndBattleHelper.Models.ActionTypes
{
    public class EntityAction 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionCost Type { get; set; }


        public EntityAction(string name, string description, ActionCost cost)
        {
            Name = name;
            Description = description;
            Type = cost;
        }
    }
}
