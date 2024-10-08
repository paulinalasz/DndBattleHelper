using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Models.Enums;
using DndBattleHelper.Models.ActionTypes;
using DndBattleHelper.Helpers;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.Helpers.DialogService;
using DndBattleHelper.ViewModels.Providers;
using System;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;
        public readonly FileIO _fileIo;

        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public MainWindowViewModel(IDialogService dialogService) 
        {
            _targetArmourClassProvider = new TargetArmourClassProvider();
            _advantageDisadvantageProvider = new AdvantageDisadvantageProvider();
            _fileIo = new FileIO();

            _dialogService = dialogService;

            var skills = new List<Skill>();
            var senses = new List<SenseType>();
            var languages = new List<LanguageType>();
            var abilities = new List<Ability>();
            var actions = new List<EntityAction>();

            skills.Add(new Skill(SkillType.Perception, new Modifier(ModifierType.Plus, 7)));
            skills.Add(new Skill(SkillType.Insight, new Modifier(ModifierType.Plus, 9)));

            senses.Add(SenseType.Darkvision60ft);

            var passivePerception = new Skill(SkillType.PassivePerception, new Modifier(ModifierType.Plus, 7));

            languages.Add(LanguageType.Common);
            languages.Add(LanguageType.Abyssal);

            abilities.Add(new Ability("Charge", "If the minotaur moves at least 10 ft. straight toward a target and then hits it with a gore attack on the same turn, the target takes an extra 9 (2d8) piercing damage. If the target is a creature, it must succeed on a DC 14 Strength saving throw or be pushed up to 10 ft. away and knocked prone."));
            abilities.Add(new Ability("name", "desc"));

            var damageRolls = new List<DamageRoll>
            {
                new DamageRoll
                (2,
                12,
                new Modifier(ModifierType.Plus, 4),
                DamageType.Slashing),
                new DamageRoll
                (1, 6, new Modifier(ModifierType.Plus, 1), DamageType.Cold)
            };

            actions.Add(new AttackAction("Greataxe", "Melee Weapon Attack: +6 to hit, reach 5 ft., one target. Hit: (2d12 + 4) slashing damage.",
                ActionCost.MainAction, damageRolls, new Modifier(ModifierType.Plus, 6)));
            actions.Add(new AttackAction("name", "test", ActionCost.MainAction, damageRolls, new Modifier(ModifierType.Plus, 6)));

            var actionViewModels = new ObservableCollection<EntityActionViewModel>();
            foreach(var action in actions)
            {
                actionViewModels.Add(new AttackActionViewModel((AttackAction)action, _targetArmourClassProvider, _advantageDisadvantageProvider));
            }

            var challengeRating = new ChallengeRating(ChallengeRatingLevel.Three);

            var enemy1 = new Enemy("Minotaur 1", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, passivePerception, languages, challengeRating, abilities, actions);
            var enemy2 = new Enemy("Minotaur 2", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, passivePerception, languages, challengeRating, abilities, actions);
            var player1 = new Player("Bar", 132);

            EntitiesInInitiative = [new EnemyViewModel(enemy1, actionViewModels, _targetArmourClassProvider, _advantageDisadvantageProvider), 
                new EnemyViewModel(enemy2, actionViewModels, _targetArmourClassProvider, _advantageDisadvantageProvider),
                new PlayerViewModel(player1),
            ];

            TurnNumber = 0;
            SelectedTab = TurnNumber;
        }

        private int _selectedTab;
        public int SelectedTab
        {
            get { return _selectedTab; }
            set 
            { 
                _selectedTab = value; 
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        private int _turnNumber;
        public int TurnNumber 
        {
            get { return _turnNumber; } 
            set
            {
                _turnNumber = value;
                OnPropertyChanged(nameof(TurnNumber));
                OnPropertyChanged(nameof(DisplayTurnNumber));
            } 
        }

        private ICommand _previousTurnCommand;
        public ICommand PreviousTurnCommand => _previousTurnCommand ?? (_previousTurnCommand = new CommandHandler(() => GoToPreviousTurn(), () => { return true; }));

        public void GoToPreviousTurn()
        {
            if (TurnNumber - 1 < 0)
            {
                TurnNumber = EntitiesInInitiative.Count - 1;
            }
            else
            {
                TurnNumber -= 1;
            }

            SelectedTab = TurnNumber;
        }

        private ICommand _nextTurnCommand;
        public ICommand NextTurnCommand => _nextTurnCommand ?? (_nextTurnCommand = new CommandHandler(() => GoToNextTurn(), () => { return true; }));

        public void GoToNextTurn()
        {
            if (TurnNumber + 1 > EntitiesInInitiative.Count - 1) 
            {
                TurnNumber = 0;
            }
            else
            {
                TurnNumber += 1;
            }

            SelectedTab = TurnNumber;
        }

        private int _displayTurnNumber;
        public int DisplayTurnNumber => TurnNumber + 1;

        public int EntitiesInInitiativeCount => EntitiesInInitiative?.Count ?? 0;

        private ICommand _addNewEnemyCommand;
        public ICommand AddNewEnemyCommand => _addNewEnemyCommand ?? (_addNewEnemyCommand = new CommandHandler(() => AddEnemyNew(), () => { return true; }));

        public void AddEnemyNew()
        {
            var addNewEnemyViewModel = new AddNewEnemyViewModel(_targetArmourClassProvider, _advantageDisadvantageProvider);

            addNewEnemyViewModel.Added += () =>
            {
                EntitiesInInitiative.Add(addNewEnemyViewModel.AddedEnemy);
            };

            bool? result = _dialogService.ShowDialog(addNewEnemyViewModel);

            OnPropertyChanged(string.Empty);
        }

        private ICommand _addNewEnemyPresetCommand;
        public ICommand AddNewEnemyPresetCommand => _addNewEnemyPresetCommand ?? (_addNewEnemyPresetCommand = new CommandHandler(AddNewEnemyPreset, () => { return true; }));

        public void AddNewEnemyPreset()
        {
            var addNewEnemyPresetViewModel = new AddNewEnemyPresetViewModel(_targetArmourClassProvider, _advantageDisadvantageProvider);

            addNewEnemyPresetViewModel.Added += () =>
            {
                _fileIo.OutputPreset(addNewEnemyPresetViewModel.AddedEnemyPreset);
            };

            bool? result = _dialogService.ShowDialog(addNewEnemyPresetViewModel);
        }
    }
}
