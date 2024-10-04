using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class LanguagesViewModel
    {
        public ObservableCollection<LanguageViewModel> Languages { get; set; }

        public LanguagesViewModel(List<LanguageType> languages) 
        {
            Languages = new ObservableCollection<LanguageViewModel>();

            foreach(LanguageType language in languages) 
            {
                Languages.Add(new LanguageViewModel(language));
            }
        }

        public override string ToString()
        {
            var languagesString = string.Empty;

            foreach(var language in Languages)
            {
                languagesString += language.ToString();
                languagesString += ", ";
            }

            if (Languages.Count > 2) 
            {
                languagesString = languagesString.Substring(0, languagesString.Length - 2);
            }

            return languagesString;
        }
    }
}
