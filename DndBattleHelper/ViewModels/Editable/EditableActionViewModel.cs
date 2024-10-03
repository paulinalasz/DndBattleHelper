using DndBattleHelper.Models;
using System.Security.Cryptography.X509Certificates;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableActionViewModel : EditableTraitViewModel
    {
        private readonly EntityAction _action;

        public EditableActionViewModel(EntityAction action)
        {
            _action = action;
        }

        public string Name
        {
            get { return _action.Name; }
            set
            {
                _action.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _action.Description;
            set
            {
                _action.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
}
