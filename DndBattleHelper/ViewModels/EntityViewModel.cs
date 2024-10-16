using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public abstract class EntityViewModel : NotifyPropertyChanged, IEntityViewModel
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

        public abstract Entity CopyModel();
    }
}
