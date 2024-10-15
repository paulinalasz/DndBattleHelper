using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using Microsoft.Windows.Themes;

namespace DndBattleHelper.ViewModels.Editable.Traits
{
    // M is Model
    // T is the enum used 
    public class TraitWithModifierViewModel<T> : NotifyPropertyChanged, IEditable where T : struct
    {
        private TraitWithModifier<T> _trait;
        public T Type
        {
            get => _trait.Type;
            set
            {
                _trait.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public ModifierViewModel ModifierViewModel { get; }

        public TraitWithModifierViewModel(TraitWithModifier<T> trait)
        {
            _trait = trait;
            ModifierViewModel = new ModifierViewModel(_trait.Modifier);
        }

        public override string ToString()
        {
            return _trait.ToString();
        }

        public TraitWithModifier<T> CopyModel()
        {
            return _trait.Copy();
        }
    }

    //// M is Model
    //// T is the enum used 
    //public class TraitWithModifierViewModel<M, T> : NotifyPropertyChanged, IEditable where M : TraitWithModifier<T> where T : struct
    //{
    //    private M _trait;
    //    public T Type
    //    {
    //        get => _trait.Type;
    //        set
    //        {
    //            _trait.Type = value;
    //            OnPropertyChanged(nameof(Type));
    //        }
    //    }

    //    public ModifierViewModel ModifierViewModel { get; }

    //    public TraitWithModifierViewModel(M trait)
    //    {
    //        _trait = trait;
    //        ModifierViewModel = new ModifierViewModel(_trait.Modifier);
    //    }

    //    public override string ToString()
    //    {
    //        return _trait.ToString();
    //    }

    //    public TraitWithModifier<T> CopyModel()
    //    {
    //        return _trait.Copy();
    //    }
    //}

    public class SkillViewModel : NotifyPropertyChanged, IEditable
    {
        private Skill _skill;
        public SkillType Type
        {
            get => _skill.Type;
            set
            {
                _skill.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public ModifierViewModel ModifierViewModel { get; }

        public SkillViewModel(Skill skill)
        {
            _skill = skill;
            ModifierViewModel = new ModifierViewModel(_skill.Modifier);
        }

        public override string ToString()
        {
            return _skill.ToString();
        }

        public Skill CopyModel()
        {
            return _skill.Copy();
        }
    }
}
