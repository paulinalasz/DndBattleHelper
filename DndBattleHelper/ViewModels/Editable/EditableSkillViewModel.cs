using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableLangaugeViewModel : EditableTraitViewModel
    {
        public LanguageType LanguageType { get; }

        public EditableLangaugeViewModel(LanguageType languageType) 
        {
            LanguageType = languageType;
        }
    }

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
