using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;

namespace DndBattleHelper.ViewModels
{
    public class EnemyViewModel : EntityViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider { get; }
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider { get; }

        public int ArmourClass { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }   
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom {  get; set; }
        public int Charisma { get; set; }
        public SkillsViewModel Skills { get; set; }
        public SensesViewModel Senses { get; set; }
        public LanguagesViewModel Languages { get; set; }
        public int Challenge { get; set; }
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

        public EnemyViewModel(Enemy enemy) 
        {
            _targetArmourClassProvider = new TargetArmourClassProvider();
            _advantageDisadvantageProvider = new AdvantageDisadvantageProvider();

            Name = enemy.Name;
            ArmourClass = enemy.ArmourClass;
            Health = enemy.Health;
            Speed = enemy.Speed;
            Strength = enemy.Strength;
            Dexterity = enemy.Dexterity;
            Constitution = enemy.Constitution;
            Intelligence = enemy.Intelligence;
            Wisdom = enemy.Wisdom;
            Charisma = enemy.Charisma;
            Skills = new SkillsViewModel(enemy.Skills);
            Senses = new SensesViewModel(enemy.Senses, enemy.PassivePerception);
            Languages = new LanguagesViewModel(enemy.Languages);
            Challenge = enemy.Challenge;
            
            Abilities = new ObservableCollection<AbilityViewModel>();

            foreach(var ability in enemy.Abilities)
            {
                Abilities.Add(new AbilityViewModel(ability));
            }

            Actions = new ObservableCollection<EntityActionViewModel>();

            foreach(var action in enemy.Actions)
            {
                Actions.Add(new EntityActionViewModel(action, _targetArmourClassProvider, _advantageDisadvantageProvider));
            }

            OutputBox = new OutputBoxViewModel();

            foreach (var action in Actions)
            {
                action.ActionTaken += () => { OutputBox.AttackDamages.Add(action.MostRecentDamageRolled); };
            }
        }

        private bool _isAdvantage;
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

        private bool _isDisadvantage;
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
    }
}
