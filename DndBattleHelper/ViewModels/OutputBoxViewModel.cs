using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Linq;

namespace DndBattleHelper.ViewModels
{
    public class OutputBoxViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<AttackDamageViewModel> AttackDamages { get; set; }

        public OutputBoxViewModel()
        {
            AttackDamages = new ObservableCollection<AttackDamageViewModel>();
            AttackDamages.CollectionChanged += Names_CollectionChanged;
        }

        public string Output => ConvertToOutput();

        public string ConvertToOutput()
        {
            var output = string.Empty;

            foreach(var damageRolled in AttackDamages) 
            {
                output += damageRolled.ToString();
                output += "\n";
            }

            return output;
        }

        public string TotalDamageOutput => CalculateTotalDamageOutput();

        public string CalculateTotalDamageOutput()
        {
            if (AttackDamages.Count == 0) return "";

            var totalDamage = (from attackDamage in AttackDamages
                               where attackDamage.DamageRolled != null
                               from damage in attackDamage.DamageRolled
                               select damage).ToList();

            var totalDamagePerType = new Dictionary<DamageType, int>();

            foreach(var damage in totalDamage)
            {
                if(totalDamagePerType.ContainsKey(damage.DamageType)) 
                {
                    totalDamagePerType[damage.DamageType] += damage.DamageGiven;
                }
                else
                {
                    totalDamagePerType.Add(damage.DamageType, damage.DamageGiven);
                }
            }

            var totalDamageString = "Target takes ";

            foreach (var  damage in totalDamagePerType)
            {
                totalDamageString += $"{damage.Value} {damage.Key} damage and ";
            }

            totalDamageString = totalDamageString.Substring(0, totalDamageString.Length - 5);

            return totalDamageString;
        }

        public void Clear()
        {
            AttackDamages.Clear();
        }

        private void Names_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Output));
            OnPropertyChanged(nameof(TotalDamageOutput));
        }
    }
}
