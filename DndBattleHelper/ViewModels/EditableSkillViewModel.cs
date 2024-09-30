using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EditableSkillViewModel
    {
        public Skill Skill { get; set; }

        public EditableSkillViewModel(Skill skill)
        {
            Skill = skill;
        }
    }
}
