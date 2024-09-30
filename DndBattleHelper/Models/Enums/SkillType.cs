using System.ComponentModel;

namespace DndBattleHelper.Models
{
    public enum SkillType
    {
        Athletics,
        Acrobatics,
        [Description("Sleight Of Hand")]
        SleightOfHand,
        Stealth,
        Arcana,
        History,
        Investigation,
        Nature,
        Religion,
        [Description("Animal Handling")]
        AnimalHandling,
        Insight,
        Medicine,
        Perception,
        Survival,
        Deception,
        Intimidation,
        Perfromance,
        Persuasion,
        [Description("Passive Perception")]
        PassivePerception
    }
}
