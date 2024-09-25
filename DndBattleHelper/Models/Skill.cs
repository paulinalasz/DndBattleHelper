namespace DndBattleHelper.Models
{
    public class Skill 
    {
        public SkillType Type { get; set; }
        public Modifier Modifier { get; set; }

        public Skill(SkillType type, Modifier modifier)
        {
            Type = type;
            Modifier = modifier;
        }

        public override string ToString()
        {
            var skillString = string.Empty;

            skillString += Type.ToString();
            skillString += " ";
            skillString += Modifier.ToString();

            return skillString;
        }
    }
}
