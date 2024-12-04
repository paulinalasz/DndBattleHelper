using DndBattleHelper.Helpers;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers.DialogService;

namespace DndBattleHelper.ViewModels
{
    public partial class AddNewEnemyViewModel
    {
        public class AddEnemyGroupViewModel : NotifyPropertyChanged, IDialogRequestClose
        {
            private readonly AddEnemyGroupParameters _parameters;

            public RollViewModel InitiativeRollViewModel { get; }
            public RollViewModel HealthRollViewModel { get; }

            public AddEnemyGroupViewModel(int health, RollViewModel initiativeRollViewModel, RollViewModel healthRollViewModel)
            {
                _parameters = new AddEnemyGroupParameters(2, true, 10, false, health);
                InitiativeRollViewModel = initiativeRollViewModel;

                InitiativeRollViewModel.Rolled += () =>
                {
                    Initiative = InitiativeRollViewModel.ValueRolled;
                };

                HealthRollViewModel = healthRollViewModel;

                HealthRollViewModel.Rolled += () =>
                {
                    Health = HealthRollViewModel.ValueRolled;
                };
            }

            public int Number
            {
                get => _parameters.Number;
                set
                {
                    _parameters.Number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }

            public bool SameInitiative
            {
                get => _parameters.SameInitiative;
                set
                {
                    _parameters.SameInitiative = value;
                    OnPropertyChanged(nameof(SameInitiative));
                }
            }

            public int Initiative
            {
                get => _parameters.Initiative;
                set
                {
                    _parameters.Initiative = value;
                    OnPropertyChanged(nameof(Initiative));
                }
            }

            public bool SameHealth
            {
                get => _parameters.SameHealth;
                set
                {
                    _parameters.SameHealth = value;
                    OnPropertyChanged(nameof(SameHealth));
                }
            }

            public int Health
            {
                get => _parameters.Health;
                set
                {
                    _parameters.Health = value;
                    OnPropertyChanged(nameof(Health));
                }
            }

            public void Add()
            {
                CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
            }

            public AddEnemyGroupParameters AddEnemyGroupParameters { get; set; }

            #region dialogService
            public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

            private ICommand _addCommand;
            public ICommand AddCommand => _addCommand ??
                (_addCommand = new CommandHandler(Add, () => { return true; }));

            private ICommand _cancelCommand;
            public ICommand CancelCommand => _cancelCommand ??
                (_cancelCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), () => { return true; }));
            #endregion
        }
    }
}
