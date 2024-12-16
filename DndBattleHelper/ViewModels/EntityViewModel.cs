using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels
{
    public abstract class Tab : ViewModelBase
    {
        private ICommand _removeCommand;
        public ICommand RemoveCommand => _removeCommand ?? (new CommandHandler(Remove, () => { return true; }));

        public void Remove()
        {
            RemoveRequested?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler RemoveRequested;
    }

    public abstract class EntityViewModel : Tab, IEntityViewModel
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
