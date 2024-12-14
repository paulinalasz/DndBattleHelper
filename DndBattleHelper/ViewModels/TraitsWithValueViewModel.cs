using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class TraitsWithValueViewModel<T> : ViewModelBase where T : struct 
    {
        public string Header { get; }

        public ObservableCollection<TraitWithValueViewModel<T>> TraitsWithValue { get; }

        public PassivePerception PassivePerception { get; }

        public TraitsWithValueViewModel(List<TraitWithValue<T>> traits, string header, PassivePerception passivePerception = null)
        {
            TraitsWithValue = new ObservableCollection<TraitWithValueViewModel<T>>();

            foreach (var trait in traits)
            {
                TraitsWithValue.Add(new TraitWithValueViewModel<T>(trait));
            }

            Header = header;
            PassivePerception = passivePerception;
        }

        public string TraitsString => ToString();

        public override string ToString()
        {
            var traitsString = string.Empty;

            foreach (var trait in TraitsWithValue)
            {
                traitsString += trait.ToString();
                traitsString += ", ";
            }

            if (PassivePerception != null)
            {
                traitsString += PassivePerception.ToString();
            }
            else if (TraitsWithValue.Count > 2)
            {
                traitsString = traitsString.Substring(0, traitsString.Length - 2);
            }

            return traitsString;
        }

        public bool IsVisible => TraitsWithValue.Count > 0;
    }
}
