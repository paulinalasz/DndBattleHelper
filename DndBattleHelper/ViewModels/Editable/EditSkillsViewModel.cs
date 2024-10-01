using DndBattleHelper.Models;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

namespace DndBattleHelper.ViewModels.Editable
{
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
