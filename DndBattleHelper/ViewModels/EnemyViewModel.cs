using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EnemyViewModel : EntityViewModel
    {
        public int ArmourClass { get; set; }
        public int Health { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<EntityAction> Actions { get; set; }

        public EnemyViewModel(Enemy enemy) 
        {
            Name = enemy.Name;
            ArmourClass = enemy.ArmourClass;
            Health = enemy.Health;
            Abilities = enemy.Abilities;
            Actions = enemy.Actions;
        }
    }
}
