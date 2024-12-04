using DndBattleHelper.Helpers;
using DndBattleHelper.Helpers.DialogService;
using System.Windows.Input;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.Models.Enums;
using DndBattleHelper.ViewModels.Providers;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels
{
    public abstract class NewEnemyViewModel : EnemyViewModel, IDialogRequestClose
    {
        public EditTraitsWithModifierViewModel<AbilityScoreType> EditSavingThrowsViewModel { get; set; }
        public EditTraitsViewModel<DamageType> EditDamageVulnerabilitiesViewModel { get; set; }
        public EditTraitsViewModel<DamageType> EditDamageResistancesViewModel { get; set; }
        public EditTraitsViewModel<DamageType> EditDamageImmunitiesViewModel { get; set; }
        public EditTraitsViewModel<Condition> EditConditionImmunitiesViewModel { get; set; }
        public EditTraitsWithModifierViewModel<SkillType> EditSkillsViewModel { get; set; }
        public EditTraitsViewModel<SenseType> EditSensesViewModel { get; set; }
        public EditTraitsViewModel<LanguageType> EditLanguagesViewModel { get; set; }

        public EditAbilitiesViewModel EditAbilitiesViewModel { get; set; }
        public EditActionsViewModel EditActionsViewModel { get; set; }

        public NewEnemyViewModel(bool isHealthRollVisible, 
            bool isInitiativeRollVisible,
            Enemy enemy,
            TargetArmourClassProvider targetArmourClassProvider,
            AdvantageDisadvantageProvider advantageDisadvantageProvider) 
            : base(enemy)
        {
            InitiativeRollViewModel = new RollViewModel(new Roll(1, 20, new Modifier(ModifierType.Neutral, 0)), "Roll Initiative: ", isInitiativeRollVisible, false);
            InitiativeRollViewModel.Rolled += () => { Initiative = InitiativeRollViewModel.ValueRolled; };

            HealthRollViewModel = new RollViewModel(new Roll(1, 10, new Modifier(ModifierType.Neutral, 0)), "Roll Health: ", isHealthRollVisible);
            HealthRollViewModel.Rolled += () => { Health = HealthRollViewModel.ValueRolled; };

            EditSavingThrowsViewModel = new EditTraitsWithModifierViewModel<AbilityScoreType>("Saving Throws: ");
            EditDamageVulnerabilitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Vurnerabilities: ");
            EditDamageResistancesViewModel = new EditTraitsViewModel<DamageType>("Damage Resistances: ");
            EditDamageImmunitiesViewModel = new EditTraitsViewModel<DamageType>("Damage Immunities: ");
            EditConditionImmunitiesViewModel = new EditTraitsViewModel<Condition>("Condition Immunities: ");
            EditSkillsViewModel = new EditTraitsWithModifierViewModel<SkillType>("Skills: ");
            EditSensesViewModel = new EditTraitsViewModel<SenseType>("Senses: ");
            EditLanguagesViewModel = new EditTraitsViewModel<LanguageType>("Languages: ");
            EditAbilitiesViewModel = new EditAbilitiesViewModel();
            EditActionsViewModel = new EditActionsViewModel(targetArmourClassProvider, advantageDisadvantageProvider);
        }

        public RollViewModel InitiativeRollViewModel { get; set; }

        public RollViewModel HealthRollViewModel { get; set; }

        #region dialogService
        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ??
            (_addCommand = new CommandHandler(Add, () => { return true; }));

        private ICommand _cancelCommand;
        public ICommand CancelCommand => _cancelCommand ??
            (_cancelCommand = new CommandHandler(() => CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(false)), () => { return true; }));
        #endregion 

        public Action Added;

        public virtual void Add()
        {
            CloseRequested?.Invoke(this, new DialogCloseRequestedEventArgs(true));
        }

        public abstract void CreateNewEnemy();
    }
}
