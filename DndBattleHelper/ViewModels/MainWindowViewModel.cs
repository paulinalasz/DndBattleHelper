using System.Collections.ObjectModel;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers;
using System;
using System.Windows;
using DndBattleHelper.Helpers.DialogService;

namespace DndBattleHelper.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;

        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public MainWindowViewModel(IDialogService dialogService) 
        {
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

            actions.Add(new EntityAction("Greataxe", "Melee Weapon Attack: +6 to hit, reach 5 ft., one target. Hit: (2d12 + 4) slashing damage.",
                ActionCost.MainAction, new Modifier(ModifierType.Plus, 6), damageRolls));
            actions.Add(new EntityAction("name", "test", ActionCost.MainAction, new Modifier(ModifierType.Plus, 6), damageRolls));

            var enemy1 = new Enemy("Minotaur 1", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, passivePerception, languages, 3, abilities, actions);
            var enemy2 = new Enemy("Minotaur 2", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, passivePerception, languages, 3, abilities, actions);
            var player1 = new Player("Bar", 132);

            EntitiesInInitiative = [new EnemyViewModel(enemy1), 
                new EnemyViewModel(enemy2),
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

        private ICommand _addNewCommand;
        public ICommand AddNewCommand => _addNewCommand ?? (_addNewCommand = new CommandHandler(() => AddNew(), () => { return true; }));

        public void AddNew()
        {
            //var skills = new List<Skill>();
            //var senses = new List<SenseType>();
            //var languages = new List<LanguageType>();
            //var abilities = new List<Ability>();
            //var actions = new List<EntityAction>();

            //skills.Add(new Skill(SkillType.Perception, new Modifier(ModifierType.Plus, 7)));
            //skills.Add(new Skill(SkillType.Insight, new Modifier(ModifierType.Plus, 9)));

            //senses.Add(SenseType.Darkvision60ft);

            //var passivePerception = new Skill(SkillType.PassivePerception, new Modifier(ModifierType.Plus, 7));

            //languages.Add(LanguageType.Common);
            //languages.Add(LanguageType.Abyssal);

            //var newEnemy = new Enemy("Minotaur new", 10, 70, 30, 10, 10, 10, 10, 10, 10, skills, senses, passivePerception, languages, 3, abilities, actions);

            var AddNewEnemyViewModel = new AddNewEnemyViewModel();
            bool? result = _dialogService.ShowDialog(AddNewEnemyViewModel);




            //EntitiesInInitiative.Add(new EnemyViewModel(newEnemy));
            OnPropertyChanged(string.Empty);
        }
    }
}
