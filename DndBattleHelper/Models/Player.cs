using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBattleHelper.Models
{
    public class Player : Entity
    {
        public Player(string name, int initiative, int health, int armourClass) : base(initiative, name, health, armourClass) { }

        public Player() { }

        public Player Copy()
        {
            return new Player(Name, Initiative, Health, ArmourClass);
        }
    }
}
