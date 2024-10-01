using DndBattleHelper.Models;
using System.Windows.Navigation;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableSkillViewModel : EditableTraitViewModel
    {
        public Skill Skill { get; set; }
        public SkillType Type => Skill.Type;

        public ModifierViewModel ModifierViewModel { get; set; }

        public EditableSkillViewModel(Skill skill)
        {
            Skill = skill;
            ModifierViewModel = new ModifierViewModel(Skill.Modifier);
        }

        public override bool HasModifier => true;
    }
}
