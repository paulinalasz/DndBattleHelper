using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class TraitsViewModel<T> : ViewModelBase where T : struct
    {
        public string Header { get; }

        public ObservableCollection<TraitViewModel<T>> Traits { get; }

        public TraitsViewModel(List<Trait<T>> traits, string header)
        {
            Traits = new ObservableCollection<TraitViewModel<T>>();

            foreach (var trait in traits)
            {
                Traits.Add(new TraitViewModel<T>(trait));
            }

            Header = header;
        }

        public string TraitsString => ToString();

        public override string ToString()
        {
            var traitsString = string.Empty;

            foreach (var trait in Traits)
            {
                traitsString += trait.ToString();
                traitsString += ", ";
            }

            if (Traits.Count > 2)
            {
                traitsString = traitsString.Substring(0, traitsString.Length - 2);
            }

            return traitsString;
        }

        public bool IsVisible => Traits.Count > 0;
    }
}
