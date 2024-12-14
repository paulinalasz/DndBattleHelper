using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Providers;

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
                FlySpeed,
                SwimSpeed,
                ClimbSpeed,
                BurrowSpeed,
                Strength,
                Dexterity,
                Constitution,
                Intelligence,
                Wisdom,
                Charisma,
                IsSpellCaster,
                spellSlots,
                SpellSaveDC,
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
