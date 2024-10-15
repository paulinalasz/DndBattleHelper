using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels
{
    public class EnemyViewModel : EntityViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider;
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        private readonly Enemy _enemy;

        public int ArmourClass { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }   
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom {  get; set; }
        public int Charisma { get; set; }
        public TraitsWithModifierViewModel<SkillType> Skills { get; set; }
        public SensesViewModel Senses { get; set; }
        public LanguagesViewModel Languages { get; set; }
        public ChallengeRatingViewModel ChallengeRating { get; set; }
        public ObservableCollection<AbilityViewModel> Abilities { get; set; }
        public ObservableCollection<EntityActionViewModel> Actions { get; set; }

        public int TargetArmourClass 
        {
            get { return _targetArmourClassProvider.TargetArmourClass; }
            set 
            {
                _targetArmourClassProvider.TargetArmourClass = value;
                OnPropertyChanged(nameof(TargetArmourClass));
            }
        }

        public OutputBoxViewModel OutputBox { get; set; }

        public EnemyViewModel(Enemy enemy, ObservableCollection<EntityActionViewModel> actions, TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) 
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
            _enemy = enemy;

            Name = enemy.Name;
            Initiative = enemy.Initiative;
            ArmourClass = enemy.ArmourClass;
            Health = enemy.Health;
            Speed = enemy.Speed;
            Strength = enemy.Strength;
            Dexterity = enemy.Dexterity;
            Constitution = enemy.Constitution;
            Intelligence = enemy.Intelligence;
            Wisdom = enemy.Wisdom;
            Charisma = enemy.Charisma;
            Skills = new TraitsWithModifierViewModel<SkillType>(enemy.Skills);
            Senses = new SensesViewModel(enemy.Senses, enemy.PassivePerception);
            Languages = new LanguagesViewModel(enemy.Languages);
            ChallengeRating = new ChallengeRatingViewModel(enemy.ChallengeRating);
            
            Abilities = new ObservableCollection<AbilityViewModel>();

            foreach(var ability in enemy.Abilities)
            {
                Abilities.Add(new AbilityViewModel(ability));
            }

            Actions = actions;

            OutputBox = new OutputBoxViewModel();

            foreach (var action in Actions)
            {
                if(action is DamagingActionViewModel)
                {
                    action.ActionTaken += () => 
                    { 
                        OutputBox.AttackDamages.Add(((DamagingActionViewModel)action).MostRecentDamageRolled); 
                    };

                }
            }

            DamageToTake = 0;
        }

        public int DamageToTake { get; set; }

        private ICommand _takeDamageCommand;
        public ICommand TakeDamageCommand => _takeDamageCommand ?? (_takeDamageCommand = new CommandHandler(() => TakeDamage(), () => { return true; }));

        public void TakeDamage()
        {
            Health -= DamageToTake;

            if (Health < 0) 
            {
                Health = 0;
            }

            OnPropertyChanged(nameof(Health));
        }

        public bool IsAdvantage
        {
            get { return _advantageDisadvantageProvider.IsAdvantage; }
            set 
            {
                if (IsDisadvantage)
                {
                    IsDisadvantage = false;
                }
                _advantageDisadvantageProvider.IsAdvantage = value; 

                OnPropertyChanged(nameof(IsAdvantage));
                OnPropertyChanged(nameof(IsDisadvantage));
            }
        }

        public bool IsDisadvantage
        {
            get { return _advantageDisadvantageProvider.IsDisadvantage; }
            set
            {
                if (IsAdvantage)
                {
                    IsAdvantage = false;
                }
                _advantageDisadvantageProvider.IsDisadvantage = value;

                OnPropertyChanged(nameof(IsAdvantage));
                OnPropertyChanged(nameof(IsDisadvantage));
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand => _clearCommand ?? (_clearCommand = new CommandHandler(() => Clear(), () => { return true; }));

        public void Clear()
        {
            OutputBox.Clear();
        }

        public override Enemy CopyModel()
        {
            return _enemy.Copy();
        }

        public override EntityViewModel Copy()
        {
            return new EnemyViewModel(_enemy.Copy(), Actions, _targetArmourClassProvider, _advantageDisadvantageProvider);
        }
    }
}
