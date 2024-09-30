using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableSkillViewModelsViewModel
    {
        public ObservableCollection<EditableSkillViewModel> EditableSkillViewModels { get; set; }

        public EditableSkillViewModelsViewModel(ObservableCollection<EditableSkillViewModel> editableSkillViewModels)
        {
            EditableSkillViewModels = editableSkillViewModels;
        }

    }
}
