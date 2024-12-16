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

        public void Add(EntityViewModel newEntity)
        {
            EntitiesInInitiative.Add(newEntity);
            SubscribeToEvents(newEntity);
            SortByInitiative();
        }

        public void Remove(EntityViewModel entity)
        {
            EntitiesInInitiative.Remove(entity);
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

            OnPropertyChanged(nameof(EntitiesInInitiative));
        }

        private void SubscribeToEvents(EntityViewModel entityViewModel)
        {
            entityViewModel.InitiativeChanged += () =>
            {
                SortByInitiative();
            };

            entityViewModel.RemoveRequested += (o, e) =>
            {
                Remove((EntityViewModel)o);
            };
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
