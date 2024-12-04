using System.Collections.ObjectModel;
using DndBattleHelper.ViewModels.Editable.Actions;
using DndBattleHelper.ViewModels.Editable;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels
{
    public class EntityActionsViewModelFactory
    {
        private EntityActionViewModelFactory _entityActionViewModelFactory;

        public EntityActionsViewModelFactory(EntityActionViewModelFactory entityActionViewModelFactory)
        {
            _entityActionViewModelFactory = entityActionViewModelFactory;
        }

        public EntityActionsViewModel Create(string header, IEnumerable<EntityAction> actions)
        {
            var entityActions = new ObservableCollection<EntityActionViewModel>();

            foreach (var action in actions)
            {
                entityActions.Add(_entityActionViewModelFactory.Create(action));
            }

            return new EntityActionsViewModel(header, entityActions);
        }
    }
}
