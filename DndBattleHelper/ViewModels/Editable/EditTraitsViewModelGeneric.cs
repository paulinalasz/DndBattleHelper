﻿using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DndBattleHelper.ViewModels.Editable
{
    public class EditTraitsViewModel<T> : EditTraitsViewModel where T : struct
    {
        public EditTraitsViewModel(string header, List<Trait<T>> traits = null) : base(header, false)
        {
            if (traits != null)
            {
                foreach (var trait in traits)
                {
                    EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitViewModel<T>(trait)));
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

        public override void Add()
        {
            EditableTraitViewModelsViewModel.EditableTraitViewModels.Add(new EditableTraitViewModel(new TraitViewModel<T>(new Trait<T>(SelectedToAdd))));
            base.Add();
        }

        public override bool CanAdd()
        {
            return true;
        }

        public override void ResetDefaults()
        {
            SelectedToAdd = (T)Enum.GetValues(typeof(T)).GetValue(0);
        }

        public List<Trait<T>> CopyNewModels()
        {
            var traits = new List<Trait<T>>();

            foreach (var editableTraitViewModel in EditableTraitViewModelsViewModel.EditableTraitViewModels)
            {
                var traitViewModel = (TraitViewModel<T>)editableTraitViewModel.Content;
                traits.Add(new Trait<T>(traitViewModel.Type));
            }

            return traits;
        }
    }
}
