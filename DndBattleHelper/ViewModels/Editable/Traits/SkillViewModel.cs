using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class SkillViewModel : NotifyPropertyChanged, IEditable
    {
        private Skill _skill;
        public SkillType Type
        {
            get => _skill.Type;
            set
            {
                _skill.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public ModifierViewModel ModifierViewModel { get; }

        public SkillViewModel(Skill skill)
        {
            _skill = skill;
            ModifierViewModel = new ModifierViewModel(_skill.Modifier);
        }

        public Skill CopyModel()
        {
            return _skill.Copy();
        }
    }
}
