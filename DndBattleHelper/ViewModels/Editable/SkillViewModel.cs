using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class SkillViewModel : NotifyPropertyChanged, IEditable
    {
        public Skill Skill { get; set; }
        public SkillType Type => Skill.Type;

        public ModifierViewModel ModifierViewModel { get; set; }

        public SkillViewModel(Skill skill, bool isRemoveVisible = true)
        {
            Skill = skill;
            ModifierViewModel = new ModifierViewModel(Skill.Modifier);
        }
    }
}
