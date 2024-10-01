using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableLangaugeViewModel : EditableTraitViewModel
    {
        public LanguageType Type { get; }

        public EditableLangaugeViewModel(LanguageType type) 
        {
            Type = type;
        }
    }
}
