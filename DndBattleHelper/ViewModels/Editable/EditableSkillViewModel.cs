using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableSkillViewModel : EditableTraitViewModel
    {
        public Skill Skill { get; set; }
        public SkillType Type => Skill.Type;

        public ModifierViewModel ModifierViewModel { get; set; }

        public EditableSkillViewModel(Skill skill, bool isRemoveVisible = true)
        {
            Skill = skill;
            ModifierViewModel = new ModifierViewModel(Skill.Modifier);

            IsRemoveVisible = isRemoveVisible;
        }

        public override bool IsRemoveVisible { get; }
        public override bool HasModifier => true;
    }
}
