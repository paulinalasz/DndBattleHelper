using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class SkillsViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<Skill> Skills { get; }

        public SkillsViewModel(ObservableCollection<Skill> skills)
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
