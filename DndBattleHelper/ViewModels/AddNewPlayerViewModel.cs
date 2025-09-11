using DndBattleHelper.Helpers;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers.DialogService;
using System.Windows;

namespace DndBattleHelper.ViewModels
{
    public class AddNewPlayerViewModel : ViewModelBase, IDialogRequestClose
    {
        public AddNewPlayerViewModel() 
        {
            
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _initiative;
        public int Initiative
        {
            get { return _initiative; }
            set
            {
                _initiative = value;
                OnPropertyChanged(nameof(Initiative));
            }
        }

        private int _health;
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        #region dialogService
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ??
            (_addCommand = new CommandHandler(Add, () => { return true; }));

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??
            (_cancelCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), () => { return true; }));
        #endregion 

        public PlayerViewModel AddedPlayerViewModel { get; set; }

        public Action Added;

        public void Add()
        {
            if (Name == "")
            {
                MessageBox.Show("Preset needs a name!", "Warning");
                return;
            }

            AddedPlayerViewModel = new PlayerViewModel(new Player(Name, Initiative, Health));
            Added?.Invoke();
        }
    }
}
