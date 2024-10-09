using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditSkillsViewModel : EditTraitsViewModel
    { 
        public EditSkillsViewModel(List<Skill> skills = null) : base ("Skills", true)
        {
            ToAddModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));

            if (skills != null) 
            {
                foreach(var skill in skills) 
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new SkillViewModel(skill.Copy())));
                }
            }
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
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new SkillViewModel(skillToAdd)));
            base.Add();
        }

        public override bool CanAdd()
        {
            return ToAddModifierViewModel.ModifierType != ModifierType.Neutral;
        }

        public override void ResetDefaults()
        {
            SelectedToAdd = 0;
        }

        public List<Skill> CopyNewModels()
        {
            var skills = new List<Skill>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var skillViewModel = (SkillViewModel)editableTraitViewModel.Content;
                skills.Add(skillViewModel.CopyModel());
            }

            return skills;
        }
    }
}
