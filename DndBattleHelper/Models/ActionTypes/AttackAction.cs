using System.Xml.Serialization;

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

        protected AttackAction() { }

        public Modifier ToHit { get; set; }

        public override AttackAction Copy()
        {
            return new AttackAction(Name, Description, ActionCost, DamageRolls, ToHit);
        }
    }
}
