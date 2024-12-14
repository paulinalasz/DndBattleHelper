using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    public class AbilityViewModel : ViewModelBase, IEditable
    {
        private readonly Ability _ability;

        public AbilityViewModel(Ability ability)
        {
            _ability = ability;
        }

        public string Name
        {
            get { return _ability.Name; }
            set
            {
                _ability.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _ability.Description;
            set
            {
                _ability.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public Ability CopyModel()
        {
            return _ability.Copy();
        }
    }
}
