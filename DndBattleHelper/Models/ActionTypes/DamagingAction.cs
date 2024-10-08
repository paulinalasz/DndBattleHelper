using System.Xml.Serialization;

namespace DndBattleHelper.Models.ActionTypes
{
    [XmlInclude(typeof(AttackAction))]
    [XmlInclude(typeof(DamagingSpellWithSave))]
    [XmlInclude(typeof(SpellAttack))]
    public class DamagingAction : EntityAction 
    {
        public DamagingAction(string name, string description, ActionCost cost, List<DamageRoll> damageRolls) : base(name, description, cost)
        {
            DamageRolls = damageRolls;
        }

        protected DamagingAction() { }

        public List<DamageRoll> DamageRolls { get; set; }

        public override DamagingAction Copy()
        {
            return new DamagingAction(Name, Description, ActionCost, DamageRolls);
        }
    }
}
