using System.Collections.ObjectModel;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EntitiesInInitiativeViewModel : ViewModelBaseWithChildViewModels
    {
        public ObservableCollection<EntityViewModel> EntitiesInInitiative { get; set; }

        public EntitiesInInitiativeViewModel(ObservableCollection<EntityViewModel> entitiesInInitiative) : base(entitiesInInitiative)
        {
            EntitiesInInitiative = entitiesInInitiative;
        }

        public void Add(EntityViewModel entity)
        {
            SubscribeToEvents(entity);
            MoveOrInsertAtCorrectIndex(entity);
        }

        public void Remove(EntityViewModel entity)
        {
            EntitiesInInitiative.Remove(entity);
            UnsubscribeEvents(entity);

        }

        public void Clear()
        {
            EntitiesInInitiative.Clear();
        }

        public void CreateFromModels(List<Entity> entities)
        {
            Clear();

            foreach (var entity in entities)
            {
                if (entity is Enemy)
                {
                    Add(new EnemyInInitiativeViewModel((Enemy)entity));
                }
                else
                {
                    Add(new PlayerViewModel((Player)entity));
                }
            }
        }

        private void MoveOrInsertAtCorrectIndex(EntityViewModel entity)
        {
            // find the index that the item should be at
            var index = EntitiesInInitiative.ToList().BinarySearch(entity, Comparer<EntityViewModel>.Create((x, y) => y.Initiative.CompareTo(x.Initiative)));
            if (index < 0)
            {
                index = ~index;
            }

            // If already present in list, remove from list
            // We don't want to unsubscribe from events as we are only moving entity
            if (EntitiesInInitiative.Contains(entity))
            {
                EntitiesInInitiative.Remove(entity);
            }

            // add to list at correct index
            EntitiesInInitiative.Insert(index, entity);
        }

        private void SubscribeToEvents(EntityViewModel entity)
        {
            entity.InitiativeChanged += () =>
            {
                MoveOrInsertAtCorrectIndex(entity);
            };

            entity.RemoveRequested += (o, e) =>
            {
                Remove((EntityViewModel)o);
            };
        }

        private void UnsubscribeEvents(EntityViewModel entity)
        {
            entity.InitiativeChanged -= () =>
            {
                MoveOrInsertAtCorrectIndex(entity);
            };

            entity.RemoveRequested -= (o, e) =>
            {
                Remove((EntityViewModel)o);
            };
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
