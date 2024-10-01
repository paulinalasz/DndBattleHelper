using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableSkillViewModel : EditableTraitViewModel
    {
        public Skill Skill { get; set; }

        public ModifierViewModel ModifierViewModel { get; set; }

        public EditableSkillViewModel(Skill skill)
        {
            Skill = skill;
            ModifierViewModel = new ModifierViewModel(Skill.Modifier);
        }
    }
}
