using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableSenseViewModel : EditableTraitViewModel
    {
        public SenseType Type { get; set; }

        public EditableSenseViewModel(SenseType type) 
        {
            Type = type;
        }

        public bool HasModifier => false;
    }
}
