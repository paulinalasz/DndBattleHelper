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
            SortByInitiative();

            newEntity.InitiativeChanged += () =>
            {
                SortByInitiative();
            };
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

            OnPropertyChanged(nameof(EntitiesInInitiative));
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
