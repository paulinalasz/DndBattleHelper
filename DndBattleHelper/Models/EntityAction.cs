namespace DndBattleHelper.Models
{
    public class EntityAction 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionCost Type { get; set; }
        public List<DamageRoll> DamageRolls { get; set; }

        public EntityAction(string name, string description, ActionCost cost, List<DamageRoll> damageRolls = null)
        {
            Name = name;
            Description = description;
            Type = cost;
            DamageRolls = damageRolls;
        }
    }
}
