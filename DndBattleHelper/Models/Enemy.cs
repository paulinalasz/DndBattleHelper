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
        public int Health { get; set; }

        public Enemy(string name, int health) 
        {
            Name = name;
            Health = health;
        }
    }
}
