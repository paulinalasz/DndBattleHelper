using System.Xml.Serialization;

namespace DndBattleHelper.Models.ActionTypes
{
    [XmlInclude(typeof(DamagingAction))]
    [XmlInclude(typeof(DamagingSpellWithSave))]
    [XmlInclude(typeof(AttackAction))]
    [XmlInclude(typeof(NonDamagingSpell))]
    [XmlInclude(typeof(SpellAttack))]
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

        protected EntityAction() { }

        public virtual EntityAction Copy()
        {
            return new EntityAction(Name, Description, ActionCost);
        }
    }
}
