using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.ViewModels.Providers;
using System.Collections.ObjectModel;
using DndBattleHelper.ViewModels.Editable.Actions;

namespace DndBattleHelper.ViewModels
{
    public class EnemyViewModelFactory
    {
        private EntityActionViewModelFactory _entityActionViewModelFactory;
        private readonly TargetArmourClassProvider _targetArmourClassProvider;
        private readonly AdvantageDisadvantageProvider _advantageDisadvantageProvider;

        public EnemyViewModelFactory(EntityActionViewModelFactory entityActionViewModelFactory, TargetArmourClassProvider targetArmourClassProvider, AdvantageDisadvantageProvider advantageDisadvantageProvider)
        {
            _entityActionViewModelFactory = entityActionViewModelFactory;
            _targetArmourClassProvider = targetArmourClassProvider;
            _advantageDisadvantageProvider = advantageDisadvantageProvider;
        }

        public EnemyViewModel Create(Enemy enemy)
        {
            var actions = new ObservableCollection<EntityActionViewModel>();

            foreach(var action in enemy.Actions)
            {
                actions.Add(_entityActionViewModelFactory.Create(action));
            }

            return new EnemyViewModel(enemy, actions, _targetArmourClassProvider, _advantageDisadvantageProvider);
        }
    }
}
