using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class PlayerViewModel : EntityViewModel
    {
        public PlayerViewModel(Player player)
        {
            Name = player.Name;
        }
    }
}
