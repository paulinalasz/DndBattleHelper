﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using DndBattleHelper.Models;
using System.Linq;
using DndBattleHelper.ViewModels.Editable.Actions;

namespace DndBattleHelper.ViewModels
{
    public class OutputBoxViewModel : ViewModelBase
    {
        public ObservableCollection<TakenActionViewModel> TakenActions { get; set; }

        public OutputBoxViewModel()
        {
            TakenActions = new ObservableCollection<TakenActionViewModel>();
            TakenActions.CollectionChanged += Names_CollectionChanged;
        }

        public string Output => ConvertToOutput();

        public string ConvertToOutput()
        {
            var output = string.Empty;

            foreach(var takenAction in TakenActions) 
            {
                output += takenAction.ToString();
                output += "\n";
            }

            return output;
        }

        public string TotalDamageOutput => CalculateTotalDamageOutput();

        public string CalculateTotalDamageOutput()
        {
            if (TakenActions.Where(x => x.AttackDamageViewModel != null).ToList().Count == 0) return "";

            var totalDamage = TakenActions
                .Where(x => x.AttackDamageViewModel != null)
                .SelectMany(action => action.AttackDamageViewModel.DamageRolled)
                .ToList();

            var totalDamagePerType = new Dictionary<DamageType, int>();

            foreach(var damage in totalDamage)
            {
                if(totalDamagePerType.ContainsKey(damage.DamageType)) 
                {
                    totalDamagePerType[damage.DamageType] += damage.Result;
                }
                else
                {
                    totalDamagePerType.Add(damage.DamageType, damage.Result);
                }
            }

            var totalDamageString = "Target takes ";

            foreach (var  damage in totalDamagePerType)
            {
                totalDamageString += ($"{damage.Value} {damage.Key} damage and ").ToLower();
            }

            totalDamageString = totalDamageString.Substring(0, totalDamageString.Length - 5);

            return totalDamageString;
        }

        public void Clear()
        {
            TakenActions.Clear();
        }

        private void Names_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Output));
            OnPropertyChanged(nameof(TotalDamageOutput));
        }
    }
}
