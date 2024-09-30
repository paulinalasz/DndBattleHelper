using System.ComponentModel;

namespace DndBattleHelper.Models
{
    public enum ModifierType
    {
        [Description("No Modifier")]
        Neutral,
        [Description("+")]
        Plus,
        [Description("-")]
        Minus
    }
}
