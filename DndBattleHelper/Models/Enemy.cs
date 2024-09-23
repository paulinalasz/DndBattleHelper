using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBattleHelper.Models
{
    public class Enemy
    {
        public string Name { get; set; }
        public int ArmourClass { get; set; }
        public int Health { get; set; }

        public List<Ability> Abilities { get; set; }    

        public List<EntityAction> Actions { get; set; } 

        public Enemy(string name, 
            int armourClass,
            int health,
            List<Ability> abilities,
            List<EntityAction> actions) 
        {
            Name = name;
            ArmourClass = armourClass;
            Health = health;
            Abilities = abilities;
            Actions = actions;
        }
    }

    public class Ability { }
    public class EntityAction { }
}
