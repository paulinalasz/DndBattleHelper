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
        public EnemyViewModel(Enemy enemy) 
        {
            Name = enemy.Name;
        }
    }
}
