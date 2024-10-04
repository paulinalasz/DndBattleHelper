using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class SkillsViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<SkillViewModel> Skills { get; }

        public SkillsViewModel(List<Skill> skills)
        {
            Skills = new ObservableCollection<SkillViewModel>();

            foreach(var skill in skills)
            {
                Skills.Add(new SkillViewModel(skill));
            }
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
