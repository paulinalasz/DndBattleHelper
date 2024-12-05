using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditTraitsWithModifierViewModel<T> : EditTraitsViewModel where T : struct
    {
        public EditTraitsWithModifierViewModel(string header, List<TraitWithModifier<T>> traits = null) : base(header, true)
        {
            ToAddModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));

            if (traits != null)
            {
                foreach (var trait in traits)
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitWithModifierViewModel<T>(trait.Copy())));
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

        public ModifierViewModel ToAddModifierViewModel { get; set; }

        protected override void CreateItem()
        {
            var traitToAdd = new TraitWithModifier<T>(SelectedToAdd, new Modifier(ToAddModifierViewModel.ModifierType, ToAddModifierViewModel.ModifierValue));
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitWithModifierViewModel<T>(traitToAdd)));
        }

        protected override bool VerifyAdd()
        {
            return true;
        }

        public override bool CanAdd()
        {
            return ToAddModifierViewModel.ModifierType != ModifierType.Neutral;
        }

        public override void ResetDefaults()
        {
            SelectedToAdd = (T)Enum.GetValues(typeof(T)).GetValue(0);
            ToAddModifierViewModel = new ModifierViewModel(new Modifier(ModifierType.Neutral, 0));
            OnPropertyChanged(nameof(ToAddModifierViewModel));
        }

        public List<TraitWithModifier<T>> CopyNewModels()
        {
            var traits = new List<TraitWithModifier<T>>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var traitViewModel = (TraitWithModifierViewModel<T>)editableTraitViewModel.Content;
                traits.Add(traitViewModel.CopyModel());
            }

            return traits;
        }
    }
}
