using System.Collections.ObjectModel;
using DndBattleHelper.Models;
using DndBattleHelper.Helpers;

namespace DndBattleHelper.ViewModels
{
    public class EntitiesInInitiativeViewModel : ViewModelBase
    {
        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public EntitiesInInitiativeViewModel() 
        {
            EntitiesInInitiative = new ObservableCollection<EntityViewModel>();
        }

        public void Add(EntityViewModel newEntity)
        {
            EntitiesInInitiative.Add(newEntity);
            SortByInitiative();
            SubscribeToInitativeChangedEvent();
        }

        public void CreateFromModels(List<Entity> entities)
        {
            Clear();

            foreach (var entity in entities)
            {
                if (entity is Enemy)
                {
                    EntitiesInInitiative.Add(new EnemyInInitiativeViewModel((Enemy)entity));
                }
                else
                {
                    EntitiesInInitiative.Add(new PlayerViewModel((Player)entity));
                }
            }

            SortByInitiative();
            SubscribeToInitativeChangedEvent();
        }

        public void Clear()
        {
            EntitiesInInitiative.Clear();
        }

        private void SortByInitiative()
        {
            var entitiesSorted = EntitiesInInitiative.OrderByDescending(entity => entity.Initiative).ToList();
            EntitiesInInitiative.Clear();

            foreach (var entityViewModel in entitiesSorted)
            {
                EntitiesInInitiative.Add(entityViewModel);
            }
        }

        private void SubscribeToInitativeChangedEvent()
        {
            foreach (var entityViewModel in EntitiesInInitiative)
            {
                entityViewModel.InitiativeChanged += () =>
                {
                    SortByInitiative();
                };
            }
        }

        public List<Entity> GetEntityModels()
        {
            var entitiesInInitiative = new List<Entity>();

            foreach (var entityViewModel in EntitiesInInitiative)
            {
                entitiesInInitiative.Add(entityViewModel.CopyModel());
            }

            return entitiesInInitiative;
        }
    }
}
