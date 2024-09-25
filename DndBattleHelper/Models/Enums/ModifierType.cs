using System.ComponentModel;

namespace DndBattleHelper.Models
{
    public enum ModifierType
    {
        [Description("+")]
        Plus,
        [Description("-")]
        Minus,
        Neutral
    }
}
