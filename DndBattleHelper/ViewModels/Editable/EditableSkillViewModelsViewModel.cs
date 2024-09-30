using DndBattleHelper.Helpers;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditableSkillViewModelsViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<EditableSkillViewModel> EditableSkillViewModels { get; }

        public EditableSkillViewModelsViewModel(ObservableCollection<EditableSkillViewModel> editableSkillViewModels)
        {
            EditableSkillViewModels = editableSkillViewModels;
            foreach (var viewModel in EditableSkillViewModels)
            {
                viewModel.Removed += () =>
                {
                    Remove(viewModel);
                };
            }

            EditableSkillViewModels.CollectionChanged += EditableSkillViewModels_CollectionChanged;
        }

        private void EditableSkillViewModels_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var viewModel in EditableSkillViewModels)
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

        public void Remove(EditableSkillViewModel viewModel) 
        {
            EditableSkillViewModels.Remove(viewModel);
        }

    }
}
