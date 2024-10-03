using DndBattleHelper.Models;
using System.Security.Cryptography.X509Certificates;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableActionViewModel : EditableTraitViewModel
    {
        private readonly EntityAction _action;
        private readonly bool _hasModifier;

        public EditableActionViewModel(EntityAction action, bool hasModifier)
        {
            _action = action;
            _hasModifier = hasModifier;

            EditDamageRollsViewModel = new EditDamageRollsViewModel();
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

        public EditDamageRollsViewModel EditDamageRollsViewModel { get; }

        public override bool HasModifier => _hasModifier;
    }
}
