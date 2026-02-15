using System.Xml.Serialization;

namespace DndBattleHelper.Models
{
    [XmlInclude(typeof(Enemy))]
    [XmlInclude(typeof(Player))]
    public class Entity
    {
        public int Initiative { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int ArmourClass { get; set; }

        public Entity(int initiative, string name, int health, int armourClass)
        {
            Initiative = initiative;
            Name = name;
            Health = health;
            ArmourClass = armourClass;
        }

        public Entity() { }
    }
}
