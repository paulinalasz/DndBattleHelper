using System.ComponentModel;

namespace DndBattleHelper.Models
{
    public enum ActionCost
    {
        [Description("Action")]
        MainAction,
        [Description("Bonus Action")]
        BonusAction,
        [Description("Reaction")]
        Reaction
    }
}
