using DndBattleHelper.Helpers;
using DndBattleHelper.Helpers.DialogService;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.Models.Enums;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels
{
    public abstract class NewEnemyViewModel : NotifyPropertyChanged, IDialogRequestClose
    {
        public EditTraitsWithModifierViewModel<SkillType> EditSkillsViewModel { get; set; }
        public EditTraitsViewModel<SenseType> EditSensesViewModel { get; set; }
        public PassivePerceptionViewModel PassivePerception { get; set; }
        public EditTraitsViewModel<LanguageType> EditLanguagesViewModel { get; set; }

        public ChallengeRatingViewModel ChallengeRatingViewModel { get; set; }
        public EditAbilitiesViewModel EditAbilitiesViewModel { get; set; }
        public EditActionsViewModel EditActionsViewModel { get; set; }

        public NewEnemyViewModel(bool isHealthRollVisible, 
            bool isInitiativeRollVisible, 
            TargetArmourClassProvider targetArmourClassProvider,
            AdvantageDisadvantageProvider advantageDisadvantageProvider)
        {
            Name = "";
            Initiative = 10;
            InitiativeRollViewModel = new RollViewModel(new Roll(1, 20, new Modifier(ModifierType.Neutral, 0)), "Roll Initiative: ", isInitiativeRollVisible, false);

            InitiativeRollViewModel.Rolled += () => { Initiative = InitiativeRollViewModel.ValueRolled; };

            ArmourClass = 10;
            Health = 0;
            HealthRollViewModel = new RollViewModel(new Roll(1, 10, new Modifier(ModifierType.Neutral, 0)), "Roll Health: ", isHealthRollVisible);

            HealthRollViewModel.Rolled += () => { Health = HealthRollViewModel.ValueRolled; };

            Speed = 30;
            Strength = 10;
            Dexterity = 10;
            Constitution = 10;
            Intelligence = 10;
            Wisdom = 10;
            Charisma = 10;

            ChallengeRatingViewModel = new ChallengeRatingViewModel(new ChallengeRating(ChallengeRatingLevel.One));

            EditSkillsViewModel = new EditTraitsWithModifierViewModel<SkillType>("Skills: ");
            EditSensesViewModel = new EditTraitsViewModel<SenseType>("Senses: ");
            PassivePerception = new PassivePerceptionViewModel(new PassivePerception(10));
            EditLanguagesViewModel = new EditTraitsViewModel<LanguageType>("Languages: ");
            EditAbilitiesViewModel = new EditAbilitiesViewModel();
            EditActionsViewModel = new EditActionsViewModel(targetArmourClassProvider, advantageDisadvantageProvider);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _initiative;
        public int Initiative
        {
            get => _initiative;
            set
            {
                _initiative = value;
                OnPropertyChanged(nameof(Initiative));
            }
        }

        public RollViewModel InitiativeRollViewModel { get; set; }

        private int _armourClass;
        public int ArmourClass
        {
            get { return _armourClass; }
            set
            {
                _armourClass = value;
                OnPropertyChanged(nameof(ArmourClass));
            }
        }

        private int _speed;
        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }

        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }

        private int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                _dexterity = value;
                OnPropertyChanged(nameof(Dexterity));
            }
        }

        private int _constitution;
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                _constitution = value;
                OnPropertyChanged(nameof(Constitution));
            }
        }

        private int _intelligence;
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _intelligence = value;
                OnPropertyChanged(nameof(Intelligence));
            }
        }

        private int _wisdom;
        public int Wisdom
        {
            get { return _wisdom; }
            set
            {
                _wisdom = value;
                OnPropertyChanged(nameof(Wisdom));
            }
        }

        private int _charisma;
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                _charisma = value;
                OnPropertyChanged(nameof(Charisma));
            }
        }

        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public RollViewModel HealthRollViewModel { get; set; }

        #region dialogService
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ??
            (_addCommand = new CommandHandler(Add, () => { return true; }));

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??
            (_cancelCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), () => { return true; }));
        #endregion 

        public Action Added;

        public virtual void Add()
        {
            CreateNewEnemy();
            Added?.Invoke();
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        public abstract void CreateNewEnemy();
    }
}
