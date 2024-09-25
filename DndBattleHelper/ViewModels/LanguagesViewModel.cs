using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class LanguagesViewModel
    {
        public List<LanguageType> Languages { get; set; }

        public LanguagesViewModel(List<LanguageType> languages) 
        {
            Languages = languages;
        }

        public override string ToString()
        {
            var languagesString = string.Empty;

            foreach(var language in Languages)
            {
                languagesString += language.ToString();
                languagesString += ", ";
            }

            languagesString = languagesString.Substring(0, languagesString.Length - 2);

            return languagesString;
        }
    }
}
