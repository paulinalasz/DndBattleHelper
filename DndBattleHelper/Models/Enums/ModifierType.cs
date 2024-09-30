using System.ComponentModel;

namespace DndBattleHelper.Models
{
    public enum ModifierType
    {
        [Description("")]
        Neutral,
        [Description("+")]
        Plus,
        [Description("-")]
        Minus
    }
}
