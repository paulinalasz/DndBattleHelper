﻿using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using Microsoft.Windows.Themes;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class TraitsWithModifierViewModel<T> : NotifyPropertyChanged where T : struct
    {
        public ObservableCollection<TraitWithModifierViewModel<T>> TraitsWithModifier { get; }

        public TraitsWithModifierViewModel(List<TraitWithModifier<T>> traits)
        {
            TraitsWithModifier = new ObservableCollection<TraitWithModifierViewModel<T>>();

            foreach (var trait in traits)
            {
                TraitsWithModifier.Add(new TraitWithModifierViewModel<T>(trait));
            }
        }

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
