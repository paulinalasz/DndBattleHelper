using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels
{
    public class EditableSkillViewModel : NotifyPropertyChanged
    {
        public Skill Skill { get; set; }

        public ModifierViewModel ModifierViewModel { get; set; }

        public EditableSkillViewModel(Skill skill)
        {
            Skill = skill;
            ModifierViewModel = new ModifierViewModel(Skill.Modifier);
        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand => _removeCommand ?? (_removeCommand = new CommandHandler(() => Remove(), () => { return true; }));

        public Action Removed;

        public void Remove()
        {
            Removed?.Invoke();
        }
    }
}
