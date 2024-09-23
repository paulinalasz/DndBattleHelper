using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EntityViewModel
    {
        public string Name { get; set; }

        public IEntityContentViewModel EntityContentViewModel { get; set; }

        public EntityViewModel(string name, IEntityContentViewModel entityContentViewModel)
        {
            Name = name;
            EntityContentViewModel = entityContentViewModel;
        }
    }
}
