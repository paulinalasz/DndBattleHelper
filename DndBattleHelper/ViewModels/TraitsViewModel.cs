using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class TraitsViewModel<T> : NotifyPropertyChanged where T : struct
    {
        public ObservableCollection<TraitViewModel<T>> Traits { get; }
        public PassivePerception PassivePerception { get; }

        public TraitsViewModel(List<Trait<T>> traits, PassivePerception passivePerception = null)
        {
            Traits = new ObservableCollection<TraitViewModel<T>>();

            foreach (var trait in traits)
            {
                Traits.Add(new TraitViewModel<T>(trait));
            }

            PassivePerception = passivePerception;
        }

        public override string ToString()
        {
            var traitsString = string.Empty;

            foreach (var trait in Traits)
            {
                traitsString += trait.ToString();
                traitsString += ", ";
            }

            if (PassivePerception != null)
            {
                traitsString += PassivePerception.ToString();
            }
            else if (Traits.Count > 2)
            {
                traitsString = traitsString.Substring(0, traitsString.Length - 2);
            }

            return traitsString;
        }

        public bool IsVisible => Traits.Count > 0;
    }
}
