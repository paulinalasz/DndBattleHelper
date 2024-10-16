using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class PlayerViewModel : EntityViewModel
    {
        private readonly Player _player;

        public PlayerViewModel(Player player) : base(player)
        {
            _player = player;
        }

        public override Player CopyModel()
        {
            return new Player(Name, Initiative, Health);
        }
    }
}
