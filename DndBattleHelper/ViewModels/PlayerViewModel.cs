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
        private readonly Player _player;

        public PlayerViewModel(Player player)
        {
            Name = player.Name;
            Initiative = player.Initiative;
            Health = player.Health;
            _player = player;
        }

        public override Entity CopyModel()
        {
            return _player.Copy();
        }

        public override EntityViewModel Copy()
        {
            return new PlayerViewModel(_player.Copy());
        }
    }
}
