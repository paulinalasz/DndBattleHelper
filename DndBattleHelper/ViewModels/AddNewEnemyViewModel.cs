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
        private readonly Presets _presets;

        public AddNewEnemyViewModel(Presets presets, TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider) : base(targetArmourClassProvider, advantageDisadvantageProvider)
        {
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
            _presets = presets;
        }

        public List<Enemy> EnemyPresets => _presets.EnemyPresets;

        private Enemy _selectedEnemyPreset;
        public Enemy SelectedEnemyPreset
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
            PassivePerception = new SkillViewModel(SelectedEnemyPreset.PassivePerception);
            EditLanguagesViewModel = new EditLanguagesViewModel(SelectedEnemyPreset.Languages);
            ChallengeRatingViewModel = new ChallengeRatingViewModel(SelectedEnemyPreset.ChallengeRating.Copy());
            EditAbilitiesViewModel = new EditAbilitiesViewModel(SelectedEnemyPreset.Abilities);
            EditActionsViewModel = new EditActionsViewModel(_targetArmourClassProvider, _advantageDisadvantageProvider, SelectedEnemyPreset.Actions);
        
            OnPropertyChanged(string.Empty);
        }

        public override bool IsRollHealthVisible => true;

        private ICommand _rollHealthCommand;
        public ICommand RollHealthCommand => _rollHealthCommand ?? (_rollHealthCommand = new CommandHandler(RollHealth, () => { return true; }));

        public void RollHealth()
        {
            Health = new Roll(HealthDiceNumber, HealthDiceBase, new Modifier(HealthModifierViewModel.ModifierType, HealthModifierViewModel.ModifierValue)).RollValue();
        }

        public EnemyViewModel AddedEnemy { get; set; }

        public override void CreateNewEnemy()
        {
            var enemy = new EnemyFactory().Create(
                Name, 
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
                PassivePerception.CopyModel(),
                EditLanguagesViewModel.CopyNewModels(),
                ChallengeRatingViewModel.CopyModel(),
                EditAbilitiesViewModel.CopyNewModels(),
                EditActionsViewModel.CopyNewModels());


            AddedEnemy = new EnemyViewModelFactory(
                new EntityActionViewModelFactory(_targetArmourClassProvider, _advantageDisadvantageProvider),
               _targetArmourClassProvider, _advantageDisadvantageProvider).Create(
                enemy);
        }
    }
}
