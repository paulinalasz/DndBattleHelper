using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class OutputBoxViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<AttackDamageViewModel> DamageRolled { get; set; }

        public OutputBoxViewModel()
        {
            DamageRolled = new ObservableCollection<AttackDamageViewModel>();
            DamageRolled.CollectionChanged += Names_CollectionChanged;
        }

        public string Output => ConvertToOutput();

        public string ConvertToOutput()
        {
            var output = string.Empty;

            foreach(var damageRolled in DamageRolled) 
            {
                output += damageRolled.ToString();
                output += "\n";
            }

            return output;
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new CommandHandler(() => Clear(), () => { return true; }));

        public void Clear()
        {
            DamageRolled.Clear();
        }

        private void Names_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Output));
        }
    }
}
