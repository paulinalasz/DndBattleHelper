using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBattleHelper.Models
{
    public class Player : Entity
    {
        public Player(string name, int initiative, int health) : base(initiative, name, health) { }

        public Player() { }

        public Player Copy()
        {
            return new Player(Name, Initiative, Health);
        }
    }
}
