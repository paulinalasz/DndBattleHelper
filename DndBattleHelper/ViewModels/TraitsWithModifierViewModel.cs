using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using Microsoft.Windows.Themes;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class TraitsWithModifierViewModel<T> : ViewModelBase where T : struct
    {
        public string Header { get; }

        public ObservableCollection<TraitWithModifierViewModel<T>> TraitsWithModifier { get; }

        public TraitsWithModifierViewModel(List<TraitWithModifier<T>> traits, string header)
        {
            TraitsWithModifier = new ObservableCollection<TraitWithModifierViewModel<T>>();

            foreach (var trait in traits)
            {
                TraitsWithModifier.Add(new TraitWithModifierViewModel<T>(trait));
            }

            Header = header;
        }

        public string TraitsString => ToString();

        public override string ToString()
        {
            var traitsString = string.Empty;

            foreach (var trait in TraitsWithModifier)
            {
                traitsString += trait.ToString();
                traitsString += ", ";
            }

            if (TraitsWithModifier.Count > 2)
            {
                traitsString = traitsString.Substring(0, traitsString.Length - 2);
            }

            return traitsString;
        }

        public bool IsVisible => TraitsWithModifier.Count > 0;
    }
}
