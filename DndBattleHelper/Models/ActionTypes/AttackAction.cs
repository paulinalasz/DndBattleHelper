namespace DndBattleHelper.Models.ActionTypes
{
    public class AttackAction : DamagingAction
    {
        protected AttackAction(string name, 
            string description, 
            ActionCost cost, 
            List<DamageRoll> damageRolls, 
            Modifier toHit) 
            : base(name, description, cost, damageRolls)
        {
            ToHit = toHit;
        }

        public Modifier ToHit { get; set; }
    }
}
