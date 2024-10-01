using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableLanguageViewModel : EditableTraitViewModel
    {
        public LanguageType Type { get; }

        public EditableLanguageViewModel(LanguageType type) 
        {
            Type = type;
        }

        public override bool HasModifier => false;
    }
}
