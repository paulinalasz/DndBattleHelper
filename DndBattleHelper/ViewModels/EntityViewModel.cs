using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public abstract class EntityViewModel : ViewModelBase, IEntityViewModel
    {
        private readonly Entity _entity;

        public string Name 
        {
            get => _entity.Name;
            set
            {
                _entity.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Initiative 
        {
            get => _entity.Initiative;
            set
            {
                _entity.Initiative = value;
                InitiativeChanged?.Invoke();
                OnPropertyChanged(nameof(Initiative));
            }
        }

        public int Health 
        {
            get => _entity.Health;
            set
            {
                _entity.Health = value; 
                OnPropertyChanged(nameof(Health));
            }
        }

        public EntityViewModel(Entity entity) 
        {
            _entity = entity;
        }

        public Action InitiativeChanged;

        public abstract Entity CopyModel();
    }
}
