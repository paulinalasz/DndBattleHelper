using DndBattleHelper.Helpers;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable
{
    public class AbilityViewModel : NotifyPropertyChanged, IEditable
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
    }
}
