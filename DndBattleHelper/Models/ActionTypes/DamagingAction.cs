namespace DndBattleHelper.Models.ActionTypes
{
    public class DamagingAction : EntityAction 
    {
        protected DamagingAction(string name, string description, ActionCost cost, List<DamageRoll> damageRolls) : base(name, description, cost)
        {
            DamageRolls = damageRolls;
        }

        public List<DamageRoll> DamageRolls { get; set; }
    }
}
