using DndBattleHelper.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EditableSkillViewModelsViewModel 
    {
        public ObservableCollection<EditableSkillViewModel> EditableSkillViewModels { get; set; }

        public EditableSkillViewModelsViewModel(ObservableCollection<EditableSkillViewModel> editableSkillViewModels) 
        {
            EditableSkillViewModels = editableSkillViewModels;
        }

    }

    public class EditSkillsViewModel : NotifyPropertyChanged
    {
        public SkillsViewModel SkillsViewModel { get; set; }

        public EditableSkillViewModelsViewModel EditableSkillViewModelsViewModel { get; set; }

        public EditSkillsViewModel(SkillsViewModel skillsViewModel)
        {
            SkillsViewModel = skillsViewModel;
            ToAddModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));

            var editableSkillViewModels = new ObservableCollection<EditableSkillViewModel>();
            EditableSkillViewModelsViewModel = new EditableSkillViewModelsViewModel(editableSkillViewModels);
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
            EditableSkillViewModelsViewModel.EditableSkillViewModels.Add(new EditableSkillViewModel(skillToAdd));

            OnPropertyChanged(nameof(SkillsViewModel));
            OnPropertyChanged(nameof(EditableSkillViewModelsViewModel));
        }
    }
}
