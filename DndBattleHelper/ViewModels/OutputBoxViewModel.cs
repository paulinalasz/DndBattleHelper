using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class OutputBoxViewModel
    {
        public ObservableCollection<Damage> Damage { get; set; }

        public OutputBoxViewModel()
        {
            Damage = new ObservableCollection<Damage>();
        }

        public string Output => ConvertToOutput();

        public string ConvertToOutput()
        {
            return "testing";
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new CommandHandler(() => Clear(), () => { return true; }));

        public void Clear()
        {
            Damage.Clear();
        }
    }
}
