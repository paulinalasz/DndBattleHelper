using DndBattleHelper.Helpers;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Traits;
using DndBattleHelper.Helpers.DialogService;
using System.Windows.Navigation;

namespace DndBattleHelper.ViewModels
{
    public partial class AddNewEnemyViewModel : NewEnemyViewModel
    {
        private TargetArmourClassProvider _targetArmourClassProvider;
        private AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        private readonly EnemyFactory _enemyFactory;
        private readonly Presets _presets;

        public AddNewEnemyViewModel(EnemyFactory enemyFactory,
            Presets presets) 
            : base(true, true, enemyFactory.CreateBlank(), presets)
        {
            _enemyFactory = enemyFactory;
            _presets = presets;

            AddGroup = false;
            NumberInGroup = 5;
            SameInitiative = true;
            SameHealth = false;
        }

        //#region Apply Presets
        //public List<EnemyPreset> EnemyPresets => _presets.EnemyPresets;

        //private EnemyPreset _selectedEnemyPreset;
        //public EnemyPreset SelectedEnemyPreset
        //{
        //    get { return _selectedEnemyPreset; }
        //    set
        //    {
        //        _selectedEnemyPreset = value;
        //        OnPropertyChanged(nameof(SelectedEnemyPreset));
        //    }
        //}

        //private ICommand _usePresetCommand;
        //public ICommand UsePresetCommand => _usePresetCommand ?? (_usePresetCommand = new CommandHandler(UsePreset, () => { return true; }));

        //public void UsePreset()
        //{
        //    var spellSlots = new List<SpellSlotAvailabilityViewModel>();

        //    foreach (var spellSlot in SelectedEnemyPreset.SpellSlots)
        //    {
        //        spellSlots.Add(new SpellSlotAvailabilityViewModel(spellSlot.Copy()));
        //    }

        //    Name = SelectedEnemyPreset.Name;
        //    ArmourClass = SelectedEnemyPreset.ArmourClass;
        //    Health = SelectedEnemyPreset.Health;
        //    Speed = SelectedEnemyPreset.Speed;
        //    Strength = SelectedEnemyPreset.Strength;
        //    Dexterity = SelectedEnemyPreset.Dexterity;
        //    Constitution = SelectedEnemyPreset.Constitution;
        //    Intelligence = SelectedEnemyPreset.Intelligence;
        //    Wisdom = SelectedEnemyPreset.Wisdom;
        //    Charisma = SelectedEnemyPreset.Charisma;
        //    IsSpellCaster = SelectedEnemyPreset.IsSpellCaster;
        //    SpellSlots = spellSlots;
        //    EditSavingThrowsViewModel = new EditTraitsWithModifierViewModel<AbilityScoreType>("Saving Throws: ", SelectedEnemyPreset.SavingThrows);
        //    EditDamageVulnerabilitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Vurnerabilities: ", SelectedEnemyPreset.DamageVurnerabilities);
        //    EditDamageResistancesViewModel = new EditTraitsViewModel<DamageType>("Damage Resistances: ", SelectedEnemyPreset.DamageResistances);
        //    EditDamageImmunitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Immunities: ", SelectedEnemyPreset.DamageResistances);
        //    EditConditionImmunitiesViewModel = new EditTraitsViewModel<Condition>("Condition Immunities: ", SelectedEnemyPreset.ConditionImmunities);
        //    EditSkillsViewModel = new EditTraitsWithModifierViewModel<SkillType>("Skills: ", SelectedEnemyPreset.Skills);
        //    EditSensesViewModel = new EditTraitsViewModel<SenseType>("Senses: ", SelectedEnemyPreset.Senses);
        //    PassivePerception = new PassivePerceptionViewModel(SelectedEnemyPreset.PassivePerception);
        //    EditLanguagesViewModel = new EditTraitsViewModel<LanguageType>("Languages: ", SelectedEnemyPreset.Languages);
        //    ChallengeRatingViewModel = new ChallengeRatingViewModel(SelectedEnemyPreset.ChallengeRating.Copy());
        //    EditAbilitiesViewModel = new EditAbilitiesViewModel(SelectedEnemyPreset.Abilities);
        //    EditActionsViewModel = new EditActionsViewModel(_targetArmourClassProvider, _advantageDisadvantageProvider, SelectedEnemyPreset.Actions);
        //    HealthRollViewModel.DiceNumber = SelectedEnemyPreset.HealthRoll.NumberOfDice;
        //    HealthRollViewModel.DiceBase = SelectedEnemyPreset.HealthRoll.DiceBase;
        //    HealthRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.HealthRoll.ValueModifier.Copy());
        //    InitiativeRollViewModel.ValueModifierViewModel = new ModifierViewModel(SelectedEnemyPreset.InitiativeRoll.ValueModifier.Copy());
        //    LegendaryActionsDescription = SelectedEnemyPreset.LegendaryActionsDescription;
        //    LairActionsDescription = SelectedEnemyPreset.LairActionsDescription;

        //    OnPropertyChanged(string.Empty);
        //}

        //#endregion

        public EnemyInInitiativeViewModel AddedEnemy { get; set; }

        public override void CreateNewEnemy()
        {
            var spellSlots = new List<SpellSlotAvailability>();

            foreach (var spellSlot in SpellSlots)
            {
                spellSlots.Add(spellSlot.CopyModel());
            }

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
                IsSpellCaster,
                spellSlots,
                EditSavingThrowsViewModel.CopyNewModels(),
                EditDamageVulnerabilitiesViewModel.CopyNewModels(),
                EditDamageResistancesViewModel.CopyNewModels(),
                EditDamageImmunitiesViewModel.CopyNewModels(),
                EditConditionImmunitiesViewModel.CopyNewModels(),
                EditSkillsViewModel.CopyNewModels(),
                EditSensesViewModel.CopyNewModels(),
                new PassivePerception(PassivePerception.Value),
                EditLanguagesViewModel.CopyNewModels(),
                ChallengeRatingViewModel.CopyModel(),
                EditAbilitiesViewModel.CopyNewModels(),
                EditActionsViewModel.CopyNewModels(),
                LegendaryActionsDescription,
                LairActionsDescription);

            AddedEnemy = new EnemyInInitiativeViewModel(enemy);
        }

        #region Add Group
        private bool _addGroup;
        public bool AddGroup 
        {
            get => _addGroup;
            set
            {
                _addGroup = value;
                OnPropertyChanged(nameof(AddGroup));
            }
        }

        private int _numberInGroup;
        public int NumberInGroup
        {
            get => _numberInGroup;
            set
            {
                _numberInGroup = value;
                OnPropertyChanged(nameof(NumberInGroup));
            }
        }

        private bool _sameInitiative;
        public bool SameInitiative 
        {
            get => _sameInitiative;
            set
            {
                _sameInitiative = value;
                OnPropertyChanged(nameof(SameInitiative));
            }
        }

        private bool _sameHealth;
        public bool SameHealth 
        {
            get => _sameHealth;
            set
            {
                _sameHealth = value;
                OnPropertyChanged(nameof(SameHealth));
            }
        }

        public Action AddedGroup;
        public List<EnemyInInitiativeViewModel> AddedEnemyInInitiativeViewModels { get; set; }
        public override bool IsAddGroupPossible => true;
        public void CreateNewEnemyGroup()
        {
            var enemyGroup = new List<EnemyInInitiativeViewModel>();

            for (int i = 0; i < NumberInGroup; i++)
            {
                CreateNewEnemy();
                var enemy = AddedEnemy;

                enemy.Name = enemy.Name + $" {i}";

                if (!SameInitiative)
                {
                    InitiativeRollViewModel.RollValue();
                    enemy.Initiative = InitiativeRollViewModel.ValueRolled;
                }

                if (!SameHealth)
                {
                    HealthRollViewModel.RollValue();
                    enemy.Health = HealthRollViewModel.ValueRolled;
                }

                enemyGroup.Add(enemy);
            }

            AddedEnemyInInitiativeViewModels = enemyGroup;
        }
        #endregion

        public override void Add()
        {
            if (AddGroup)
            {
                CreateNewEnemyGroup();
                AddedGroup?.Invoke();
                base.Add();
            }
            else
            {
                CreateNewEnemy();
                Added?.Invoke();
                base.Add();
            }
        }
    }
}
