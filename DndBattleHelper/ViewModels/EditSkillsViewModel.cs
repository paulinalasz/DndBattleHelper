using DndBattleHelper.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EditSkillsViewModel : NotifyPropertyChanged
    {
        public SkillsViewModel SkillsViewModel { get; set; }
        public ObservableCollection<EditableSkillViewModel> EditableSkillViewModels { get; set; }

        public EditSkillsViewModel(SkillsViewModel skillsViewModel)
        {
            SkillsViewModel = skillsViewModel;
            ToAddModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));

            EditableSkillViewModels = new ObservableCollection<EditableSkillViewModel>();
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
        public ICommand AddSkillCommand => _addSkillCommand ?? (_addSkillCommand = new CommandHandler(() => AddSkill(), () => { return ToAddModifierViewModel.ModifierType != ModifierType.Neutral; }));

        public void AddSkill()
        {
            var skillToAdd = new Skill(SelectedToAdd, new Modifier(ToAddModifierViewModel.ModifierType, ToAddModifierViewModel.ModifierValue));

            SkillsViewModel.Skills.Add(skillToAdd);
            EditableSkillViewModels.Add(new EditableSkillViewModel(skillToAdd));

            OnPropertyChanged(nameof(SkillsViewModel));
            OnPropertyChanged(nameof(EditableSkillViewModels));
        }
    }
}
