using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Editable.Traits;
using DndBattleHelper.Models.ActionTypes;
using DndBattleHelper.ViewModels.Editable;

namespace DndBattleHelper.ViewModels
{
    public class EnemyInInitiativeViewModel : EnemyViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider;
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        private EntityListProvider _entityListProvider;

        public string SpeedOutput => GetSpeed();

        public string GetSpeed()
        {
            var speed = $"{Speed} ft.";

            if (FlySpeed != 0)
            {
                speed += $", fly {FlySpeed} ft.";
            }
            if (SwimSpeed != 0)
            {
                speed += $", swim {SwimSpeed} ft.";
            }
            if (ClimbSpeed != 0)
            {
                speed += $", climb {ClimbSpeed} ft.";
            }
            if (BurrowSpeed != 0)
            {
                speed += $", burrow {BurrowSpeed} ft.";
            }

            return speed;
        }

        public TraitsWithModifierViewModel<AbilityScoreType> SavingThrows { get;}
        public TraitsViewModel<DamageType> DamageVulnerabilities { get;}
        public TraitsViewModel<DamageType> DamageResistances { get; }
        public TraitsViewModel<DamageType> DamageImmunities { get; }
        public TraitsViewModel<Condition> ConditionImmunities { get; }
        public TraitsWithModifierViewModel<SkillType> Skills { get; }
        public TraitsWithValueViewModel<SenseType> Senses { get; }
        public TraitsViewModel<LanguageType> Languages { get; }
        public ChallengeRatingViewModel ChallengeRating { get; }
        public ObservableCollection<AbilityViewModel> Abilities { get; }
        public EntityActionsViewModel Actions { get; }
        public EntityActionsViewModel Reactions { get; }
        public EntityActionsViewModel LegendaryActions { get; }
        public EntityActionsViewModel LairActions { get; }

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

        public ObservableCollection<EntityViewModel> AvailableEntities
        {
            get
            {
                if (_entityListProvider?.EntitiesInInitiativeViewModel?.EntitiesInInitiative != null)
                {
                    return _entityListProvider.EntitiesInInitiativeViewModel.EntitiesInInitiative;
                }
                return new ObservableCollection<EntityViewModel>();
            }
        }

        private EntityViewModel _selectedEntity;
        public EntityViewModel SelectedEntity
        {
            get => _selectedEntity;
            set
            {
                _selectedEntity = value;
                if (value != null)
                {
                    TargetArmourClass = value.ArmourClass;
                }
                OnPropertyChanged(nameof(SelectedEntity));
            }
        }

        public EnemyInInitiativeViewModel(Enemy enemy, EntityListProvider entityListProvider = null) 
            : base(enemy)
        {
            SavingThrows = new TraitsWithModifierViewModel<AbilityScoreType>(enemy.SavingThrows, "Saving Throws:");
            DamageVulnerabilities = new TraitsViewModel<DamageType>(enemy.DamageVurnerabilities, "Damage Vulnerabilities:");
            DamageResistances = new TraitsViewModel<DamageType>(enemy.DamageResistances, "Damage Resistances:");
            DamageImmunities = new TraitsViewModel<DamageType>(enemy.DamageImmunities, "Damage Immunities:");
            ConditionImmunities = new TraitsViewModel<Condition>(enemy.ConditionImmunities, "Condition Immunities:");
            Skills = new TraitsWithModifierViewModel<SkillType>(enemy.Skills, "Skills:");
            Senses = new TraitsWithValueViewModel<SenseType>(enemy.Senses, "Senses:", enemy.PassivePerception);
            Languages = new TraitsViewModel<LanguageType>(enemy.Languages, "Languages:");
            ChallengeRating = new ChallengeRatingViewModel(enemy.ChallengeRating);

            Abilities = new ObservableCollection<AbilityViewModel>();

            foreach (var ability in enemy.Abilities)
            {
                Abilities.Add(new AbilityViewModel(ability));
            }

            _targetArmourClassProvider = new TargetArmourClassProvider();
            _advantageDisadvantageProvider = new AdvantageDisadvantageProvider();
            _entityListProvider = entityListProvider;

            var entityActionsViewModelFactory = new EntityActionsViewModelFactory(
                new EntityActionViewModelFactory(_targetArmourClassProvider, _advantageDisadvantageProvider));

            Actions = entityActionsViewModelFactory.Create("Actions", enemy.Actions.Where(x => x.ActionCost == ActionCost.MainAction || x.ActionCost == ActionCost.BonusAction));
            Reactions = entityActionsViewModelFactory.Create("Reactions", enemy.Actions.Where(x => x.ActionCost == ActionCost.Reaction));
            LegendaryActions = entityActionsViewModelFactory.Create("Legendary Actions", enemy.Actions.Where(x => x.ActionCost == ActionCost.LegendaryAction), LegendaryActionsDescription);
            LairActions = entityActionsViewModelFactory.Create("Lair Actions", enemy.Actions.Where(x => x.ActionCost == ActionCost.LairAction), LairActionsDescription);

            OutputBox = new OutputBoxViewModel();

            SubscribeActionsToEvents(Actions.Actions);
            SubscribeActionsToEvents(Reactions.Actions);
            SubscribeActionsToEvents(LegendaryActions.Actions);
            SubscribeActionsToEvents(LairActions.Actions);

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

        private void SubscribeActionsToEvents(IEnumerable<EntityActionViewModel> actions)
        {
            foreach (var action in actions)
            {
                if (action is ISpell)
                {
                    action.ActionTaken += () =>
                    {
                        var spellSlot = SpellSlots.FirstOrDefault(slot => slot.SpellSlotLevel == ((ISpell)action).SpellSlot);

                        if (spellSlot != null && spellSlot.NumberLeft > 0)
                        {
                            spellSlot.NumberLeft -= 1;
                        }
                    };
                }

                action.ActionTaken += () =>
                {
                    OutputBox.TakenActions.Add(action.MostRecentTakenAction);
                };
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
