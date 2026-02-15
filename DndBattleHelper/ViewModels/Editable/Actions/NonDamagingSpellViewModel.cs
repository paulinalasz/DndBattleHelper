using DndBattleHelper.Models;
using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public class NonDamagingSpellViewModel : EntityActionViewModel, ISpellViewModel
    {
        private NonDamagingSpell _action;

        public NonDamagingSpellViewModel(NonDamagingSpell action) : base(action)
        {
            _action = action;
        }

        public bool Concentration
        {
            get => _action.Concentration;
            set
            {
                _action.Concentration = value;
                OnPropertyChanged(nameof(Concentration));
            }
        }

        public SpellSlot SpellSlot
        {
            get => _action.SpellSlot;
            set
            {
                _action.SpellSlot = value;
                OnPropertyChanged(nameof(SpellSlot));
            }
        }

        public string Duration
        {
            get => _action.Duration;
            set
            {
                _action.Duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public string Range
        {
            get => _action.Range;
            set
            {
                _action.Range = value;
                OnPropertyChanged(nameof(Range));
            }
        }

        public bool HasVerbalComponent
        {
            get => _action.HasVerbalComponent;
            set
            {
                _action.HasVerbalComponent = value;
                OnPropertyChanged(nameof(HasVerbalComponent));
            }
        }

        public bool HasSomaticComponent
        {
            get => _action.HasSomaticComponent;
            set
            {
                _action.HasSomaticComponent = value;
                OnPropertyChanged(nameof(HasSomaticComponent));
            }
        }

        public bool HasMaterialComponent
        {
            get => _action.HasMaterialComponent;
            set
            {
                _action.HasMaterialComponent = value;
                OnPropertyChanged(nameof(HasMaterialComponent));
            }
        }

        public string MaterialComponent
        {
            get => _action.MaterialComponent;
            set
            {
                _action.MaterialComponent = value;
                OnPropertyChanged(nameof(MaterialComponent));
            }
        }

        public string SpellInfoText => SpellInfoTextHelper.Build(this);
        public bool IsSpellInfoVisible => SpellInfoText.Length > 0;

        public override NonDamagingSpell CopyModel()
        {
            return _action.Copy();
        }
    }
}
