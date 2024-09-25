using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class AbilityViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public AbilityViewModel(Ability ability)
        {
            Name = ability.Name;
            Description = ability.Description;
        }
    }
}
