using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditTraitsWithValueViewModel<T> : EditTraitsViewModel where T : struct
    {
        public EditTraitsWithValueViewModel(string header, List<TraitWithValue<T>> traits = null) : base(header, false)
        {
            Distance = 60;

            if (traits != null)
            {
                foreach (var trait in traits)
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitWithValueViewModel<T>(trait.Copy())));
                }
            }
        }

        private T _selectedToAdd;
        public T SelectedToAdd
        {
            get { return _selectedToAdd; }
            set
            {
                _selectedToAdd = value;
                OnPropertyChanged(nameof(SelectedToAdd));
            }
        }

        private int _distance;
        public int Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        public override bool CanAdd()
        {
            if (EditableTraitViewModelsViewModel.EditableTraitViewModels.Select(x => ((TraitViewModel<T>)x.Content).Type).ToList().Contains(SelectedToAdd))
            {
                return false;
            }

            return true;
        }

        public override void ResetDefaults()
        {
            SelectedToAdd = (T)Enum.GetValues(typeof(T)).GetValue(0);
            Distance = 60;
        }

        protected override void CreateItem()
        {
            var traitToAdd = new TraitWithValue<T>(SelectedToAdd, Distance);
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitWithValueViewModel<T>(traitToAdd)));
        }

        protected override bool VerifyAdd()
        {
            return true;
        }

        public List<TraitWithValue<T>> CopyNewModels()
        {
            var traits = new List<TraitWithValue<T>>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var traitViewModel = (TraitWithValueViewModel<T>)editableTraitViewModel.Content;
                traits.Add(traitViewModel.CopyModel());
            }

            return traits;
        }
    }
}
