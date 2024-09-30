using DndBattleHelper.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EditSkillsViewModel : NotifyPropertyChanged
    {
        public SkillsViewModel SkillsViewModel { get; set; }
        public ObservableCollection<EditableSkill> EditableSkills { get; set; }

        public EditSkillsViewModel(SkillsViewModel skillsViewModel)
        {
            SkillsViewModel = skillsViewModel;
            ToAddModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
        }

        private SkillType _selectedToAdd;
        public SkillType SelectedToAdd 
        { 
            get { return _selectedToAdd; }
            set
            {
                _selectedToAdd = value;
                OnPropertyChanged(nameof(SelectedToAdd));
            }
        }

        public ModifierViewModel ToAddModifierViewModel { get; set; }

        private ICommand _addSkillCommand;
        public ICommand AddSkillCommand => _addSkillCommand ?? (_addSkillCommand = new CommandHandler(() => AddSkill(), () => { return true; }));

        public void AddSkill()
        {

        }
    }
}
