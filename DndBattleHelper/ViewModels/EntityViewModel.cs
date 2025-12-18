using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{

    public abstract class EntityViewModel : Tab, IEntityViewModel, IInInitiative
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

        public int ArmourClass
        {
            get => _entity.ArmourClass;
            set
            {
                _entity.ArmourClass = value;
                OnPropertyChanged(nameof(ArmourClass));
            }
        }

        private bool _isMyTurn;
        public bool IsMyTurn 
        {
            get => _isMyTurn;
            set
            {
                _isMyTurn = value;
                OnPropertyChanged(nameof(IsMyTurn));
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
