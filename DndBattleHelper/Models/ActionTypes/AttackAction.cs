namespace DndBattleHelper.Models.ActionTypes
{
    public class AttackAction : DamagingAction
    {
        public AttackAction(string name, 
            string description, 
            ActionCost cost, 
            List<DamageRoll> damageRolls, 
            Modifier toHit) 
            : base(name, description, cost, damageRolls)
        {
            ToHit = toHit;
        }

        public Modifier ToHit { get; set; }

        public override AttackAction Copy()
        {
            return new AttackAction(Name, Description, ActionCost, DamageRolls, ToHit);
        }
    }
}
