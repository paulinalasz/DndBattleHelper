using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public abstract class EntityViewModel : IEntityViewModel
    {
        public string Name { get; set; }
    }
}
