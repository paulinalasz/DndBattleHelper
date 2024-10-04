using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class LanguageViewModel : NotifyPropertyChanged, IEditable
    {
        public LanguageType Type { get; }

        public LanguageViewModel(LanguageType type) 
        {
            Type = type;
        }
    }
}
