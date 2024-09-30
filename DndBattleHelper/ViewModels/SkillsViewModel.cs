using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class SkillsViewModel
    {
        public List<Skill> Skills { get; }

        public SkillsViewModel(List<Skill> skills)
        {
            Skills = skills;
        }

        public override string ToString()
        {
            var skillsString = string.Empty;

            foreach(var skill in Skills) 
            {
                skillsString += skill.ToString();
                skillsString += ", ";
            }

            if (Skills.Count > 2)
            {
                skillsString = skillsString.Substring(0, skillsString.Length - 2);
            }

            return skillsString;
        }
    }
}
