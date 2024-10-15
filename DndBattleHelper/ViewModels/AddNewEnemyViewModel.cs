using DndBattleHelper.Helpers;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels
{
    public class AddNewEnemyViewModel : NewEnemyViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider;
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemyViewModelFactory _enemyViewModelFactory;
        private readonly Presets _presets;

        public AddNewEnemyViewModel(EnemyFactory enemyFactory,
            EnemyViewModelFactory enemyViewModelFactory,
            Presets presets, 
            TargetArmourClassProvider targetArmourClassProvider, 
            AdvantageDisadvantageProvider advantageDisadvantageProvider) 
            : base(true, true, targetArmourClassProvider, advantageDisadvantageProvider)
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
            _enemyFactory = enemyFactory;
            _enemyViewModelFactory = enemyViewModelFactory;
            _presets = presets;
        }

        public List<EnemyPreset> EnemyPresets => _presets.EnemyPresets;

        private EnemyPreset _selectedEnemyPreset;
        public EnemyPreset SelectedEnemyPreset
        {
            get { return _selectedEnemyPreset; }
            set
            {
                _selectedEnemyPreset = value;
                OnPropertyChanged(nameof(SelectedEnemyPreset));
            }
        }

        private ICommand _usePresetCommand;
        public ICommand UsePresetCommand => _usePresetCommand ?? (_usePresetCommand = new CommandHandler(UsePreset, () => { return true; }));

        public void UsePreset()
        {
            Name = SelectedEnemyPreset.Name;
            ArmourClass = SelectedEnemyPreset.ArmourClass;
            Health = SelectedEnemyPreset.Health;
            Speed = SelectedEnemyPreset.Speed;
            Strength = SelectedEnemyPreset.Strength;
            Dexterity = SelectedEnemyPreset.Dexterity;
            Constitution = SelectedEnemyPreset.Constitution;
            Intelligence = SelectedEnemyPreset.Intelligence;
            Wisdom = SelectedEnemyPreset.Wisdom;
            Charisma = SelectedEnemyPreset.Charisma;
            EditSkillsViewModel = new EditSkillsViewModel(SelectedEnemyPreset.Skills);
            EditSensesViewModel = new EditSensesViewModel(SelectedEnemyPreset.Senses);
            PassivePerception = new PassivePerceptionViewModel(SelectedEnemyPreset.PassivePerception);
            EditLanguagesViewModel = new EditLanguagesViewModel(SelectedEnemyPreset.Languages);
            ChallengeRatingViewModel = new ChallengeRatingViewModel(SelectedEnemyPreset.ChallengeRating.Copy());
            EditAbilitiesViewModel = new EditAbilitiesViewModel(SelectedEnemyPreset.Abilities);
            EditActionsViewModel = new EditActionsViewModel(_targetArmourClassProvider, _advantageDisadvantageProvider, SelectedEnemyPreset.Actions);
            HealthRollViewModel.DiceNumber = SelectedEnemyPreset.HealthRoll.NumberOfDice;
            HealthRollViewModel.DiceBase = SelectedEnemyPreset.HealthRoll.DiceBase;
            HealthRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.HealthRoll.ValueModifier.Copy());
            InitiativeRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.InitiativeRoll.ValueModifier.Copy());

            OnPropertyChanged(string.Empty);
        }

        public EnemyViewModel AddedEnemy { get; set; }

        public override void CreateNewEnemy()
        {
            var enemy = _enemyFactory.Create(
                Name, 
                Initiative,
                ArmourClass, 
                Health,
                Speed,
                Strength,
                Dexterity, 
                Constitution, 
                Intelligence, 
                Wisdom,
                Charisma,
                EditSkillsViewModel.CopyNewModels(),
                EditSensesViewModel.CopyNewModels(),
                new PassivePerception(SelectedEnemyPreset.PassivePerception.Value),
                EditLanguagesViewModel.CopyNewModels(),
                ChallengeRatingViewModel.CopyModel(),
                EditAbilitiesViewModel.CopyNewModels(),
                EditActionsViewModel.CopyNewModels());


            AddedEnemy = _enemyViewModelFactory.Create(
                enemy);
        }
    }
}
