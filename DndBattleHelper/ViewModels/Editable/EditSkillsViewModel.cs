﻿using DndBattleHelper.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditLangaugesViewModel : NotifyPropertyChanged
    {
        //public EditableLanguageViewModelViewModels EditableLanguageViewModelViewModels { get; set; }

        public EditLangaugesViewModel() 
        {
            
        }

        private LanguageType _languageToAdd;
        public LanguageType LanguageToAdd
        {
            get {  return _languageToAdd; } 
            set 
            { 
                _languageToAdd = value; 
                OnPropertyChanged(nameof(LanguageToAdd)); 
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new CommandHandler(() => Add(), () => { return true; }));

        public void Add()
        {

        }
    }

    public class EditSkillsViewModel : NotifyPropertyChanged
    { 
        public EditableTraitViewModelsViewModel EditableSkillViewModelsViewModel { get; set; }

        public EditSkillsViewModel()
        {
            ToAddModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
            EditableSkillViewModelsViewModel = new EditableTraitViewModelsViewModel(new ObservableCollection<EditableTraitViewModel>());
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
            EditableSkillViewModelsViewModel.EditableTraitViewModels.Add(new EditableSkillViewModel(skillToAdd));
            OnPropertyChanged(nameof(EditableSkillViewModelsViewModel));
        }
    }
}
