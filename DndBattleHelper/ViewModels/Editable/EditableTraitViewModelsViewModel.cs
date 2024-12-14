using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableTraitViewModelsViewModel : ViewModelBase
    {
        public ObservableCollection<EditableTraitViewModel> EditableTraitViewModels { get; }

        public EditableTraitViewModelsViewModel(ObservableCollection<EditableTraitViewModel> editableTraitViewModels)
        {
            EditableTraitViewModels = editableTraitViewModels;

            foreach (var viewModel in EditableTraitViewModels)
            {
                viewModel.Removed += () =>
                {
                    Remove(viewModel);
                };
            }

            EditableTraitViewModels.CollectionChanged += EditableTraitViewModels_CollectionChanged;
        }

        private void EditableTraitViewModels_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var viewModel in EditableTraitViewModels)
                    {
                        viewModel.Removed += () =>
                        {
                            Remove(viewModel);
                        };
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
            }
        }

        public void Remove(EditableTraitViewModel viewModel)
        {
            EditableTraitViewModels.Remove(viewModel);
        }
    }
}
