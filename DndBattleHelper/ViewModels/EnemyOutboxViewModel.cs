using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Editable.Traits;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels
{
    public class EnemyOutboxViewModel : EnemyViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider;
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider;

        public TraitsWithModifierViewModel<AbilityScoreType> SavingThrows { get;}
        public TraitsViewModel<DamageType> DamageVulnerabilities { get;}
        public TraitsViewModel<DamageType> DamageResistances { get; }
        public TraitsViewModel<DamageType> DamageImmunities { get; }
        public TraitsViewModel<Condition> ConditionImmunities { get; }
        public TraitsWithModifierViewModel<SkillType> Skills { get; }
        public TraitsViewModel<SenseType> Senses { get; }
        public TraitsViewModel<LanguageType> Languages { get; }
        public ChallengeRatingViewModel ChallengeRating { get; }
        public ObservableCollection<AbilityViewModel> Abilities { get; }
        public ObservableCollection<EntityActionViewModel> Actions { get; }

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

        public EnemyOutboxViewModel(Enemy enemy, 
            EntityActionViewModelFactory entityActionViewModelFactory, 
            TargetArmourClassProvider targetArmourClassProvider, 
            AdvantageDisadvantageProvider advantageDisadvantageProvider) 
            : base(enemy)
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;

            SavingThrows = new TraitsWithModifierViewModel<AbilityScoreType>(enemy.SavingThrows, "Saving Throws:");
            DamageVulnerabilities = new TraitsViewModel<DamageType>(enemy.DamageVurnerabilities, "Damage Vulnerabilities:");
            DamageResistances = new TraitsViewModel<DamageType>(enemy.DamageResistances, "Damage Resistances:");
            DamageImmunities = new TraitsViewModel<DamageType>(enemy.DamageImmunities, "Damage Immunities:");
            ConditionImmunities = new TraitsViewModel<Condition>(enemy.ConditionImmunities, "Condition Immunities:");
            Skills = new TraitsWithModifierViewModel<SkillType>(enemy.Skills, "Skills:");
            Senses = new TraitsViewModel<SenseType>(enemy.Senses, "Senses:", enemy.PassivePerception);
            Languages = new TraitsViewModel<LanguageType>(enemy.Languages, "Languages:");
            ChallengeRating = new ChallengeRatingViewModel(enemy.ChallengeRating);

            Abilities = new ObservableCollection<AbilityViewModel>();

            foreach (var ability in enemy.Abilities)
            {
                Abilities.Add(new AbilityViewModel(ability));
            }

            Actions = new ObservableCollection<EntityActionViewModel>();

            foreach (var action in enemy.Actions)
            {
                var actionViewModel = entityActionViewModelFactory.Create(action);
                Actions.Add(actionViewModel);

                if (actionViewModel is ISpell)
                {
                    actionViewModel.ActionTaken += () =>
                    {
                        var spellSlot = SpellSlots.FirstOrDefault(slot => slot.SpellSlotLevel == ((ISpell)actionViewModel).SpellSlot);

                        if (spellSlot != null && spellSlot.NumberLeft > 0)
                        {
                            spellSlot.NumberLeft -= 1;
                        }
                    };
                }
            }

            OutputBox = new OutputBoxViewModel();

            foreach (var action in Actions)
            {
                action.ActionTaken += () =>
                {
                    OutputBox.TakenActions.Add(action.MostRecentTakenAction);
                };
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

        private ICommand _resetSpellSlotsUsedCommand;
        public ICommand ResetSpellSlotsUsedCommand => _resetSpellSlotsUsedCommand ?? (_resetSpellSlotsUsedCommand = new CommandHandler(ResetSpellSlotsUsed, () => { return true; }));

        public void ResetSpellSlotsUsed()
        {
            foreach (var spellSlot in SpellSlots)
            {
                spellSlot.ResetUsed();
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
