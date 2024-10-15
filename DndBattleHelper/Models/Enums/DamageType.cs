using System.ComponentModel;

namespace DndBattleHelper.Models
{
    public enum DamageType
    {
        Piercing,
        Bludgeoning,
        Slashing,
        Cold,
        Fire,
        Lightning,
        Thunder,
        Poison,
        Acid,
        Necrotic,
        Radiant,
        Force,
        Psychic,
        [Description("Non-Silvered Bludgeoning, Piercing, And Slashing")]
        NonSilvered
    }
}
