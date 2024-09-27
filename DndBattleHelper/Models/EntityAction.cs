namespace DndBattleHelper.Models
{
    public class EntityAction 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionCost Type { get; set; }
        public Modifier ToHit { get; set; }
        public List<DamageRoll> DamageRolls { get; set; }

        public EntityAction(string name, string description, ActionCost cost, Modifier toHit, List<DamageRoll> damageRolls = null)
        {
            Name = name;
            Description = description;
            Type = cost;
            ToHit = toHit;
            DamageRolls = damageRolls;
        }
    }
}
