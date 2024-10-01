using DndBattleHelper.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

namespace DndBattleHelper.ViewModels.Editable
{
    public abstract class EditTraitsViewModel : NotifyPropertyChanged
    {
        public string Header { get; set; }
        public bool HasModifier { get; }
        public EditableTraitViewModelsViewModel EditableTraitViewModelsViewModel { get; set; }

        public EditTraitsViewModel(string header, bool hasModifier) 
        {
            Header = header;
            HasModifier = hasModifier;
            EditableTraitViewModelsViewModel = new EditableTraitViewModelsViewModel(new ObservableCollection<EditableTraitViewModel>());
        }

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? (_addCommand = new CommandHandler(() => Add(), () => CanAdd()));

        public virtual void Add()
        {
            OnPropertyChanged(nameof(EditableTraitViewModelsViewModel));
        }

        public abstract bool CanAdd();
    }

    public class EditLanguagesViewModel : EditTraitsViewModel
    {
        public EditLanguagesViewModel(string header) : base(header, false) { }

        private LanguageType _selectedToAdd;
        public LanguageType SelectedToAdd
        {
            get { return _selectedToAdd; }
            set
            {
                _selectedToAdd = value;
                OnPropertyChanged(nameof(SelectedToAdd));
            }
        }

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableLanguageViewModel(SelectedToAdd));
            base.Add();
        }

        public override bool CanAdd() 
        {
            return true;
        }
    }

    public class EditSensesViewModel : EditTraitsViewModel
    {
        public EditSensesViewModel(string header) : base(header, false) { }

        private SenseType _selectedToAdd;
        public SenseType SelectedToAdd
        {
            get { return _selectedToAdd; }
            set
            {
                _selectedToAdd = value;
                OnPropertyChanged(nameof(SelectedToAdd));
            }
        }

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableSenseViewModel(SelectedToAdd));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }
    }

    public class EditSkillsViewModel : EditTraitsViewModel
    { 
        public EditSkillsViewModel(string header) : base (header, true)
        {
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

        public override void Add()
        {
            var skillToAdd = new Skill(SelectedToAdd, new Modifier(ToAddModifierViewModel.ModifierType, ToAddModifierViewModel.ModifierValue));
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableSkillViewModel(skillToAdd));
            base.Add();
        }

        public override bool CanAdd()
        {
            return ToAddModifierViewModel.ModifierType != ModifierType.Neutral;
        }
    }
}
