using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using Microsoft.Windows.Themes;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    //public class SavingThrowsViewModel : NotifyPropertyChanged
    //{
    //    public ObservableCollection<SavingThrowViewModel> SavingThrows { get; set; }

    //    public SavingThrowsViewModel(List<SavingThrow> savingThrows) 
    //    {
    //        SavingThrows = new ObservableCollection<SavingThrowViewModel>();

    //        foreach (var savingThrow in savingThrows)
    //        {
    //            SavingThrows.Add(new SavingThrowViewModel(savingThrow));
    //        }
    //    }


    //}

    //VM is TraitWithModifierViewModel
    //M is Model
    //T is the type

    public class TraitsViewModel<T> : NotifyPropertyChanged where T : struct
    {
        public ObservableCollection<TraitViewModel<T>> Traits { get; }
        public PassivePerception PassivePerception { get; }

        public TraitsViewModel(List<Trait<T>> traits, PassivePerception passivePerception = null)
        {
            Traits = new ObservableCollection<TraitViewModel<T>>();

            foreach (var trait in traits)
            {
                Traits.Add(new TraitViewModel<T>(trait));
            }

            PassivePerception = passivePerception;
        }

        public override string ToString()
        {
            var traitsString = string.Empty;

            foreach (var trait in Traits)
            {
                traitsString += trait.ToString();
                traitsString += ", ";
            }

            if (PassivePerception != null)
            {
                traitsString += PassivePerception.ToString();
            }
            else if (Traits.Count > 2)
            {
                traitsString = traitsString.Substring(0, traitsString.Length - 2);
            }

            return traitsString;
        }
    }

    public class TraitsWithModifierViewModel<T> : NotifyPropertyChanged where T : struct
    {
        public ObservableCollection<TraitWithModifierViewModel<T>> TraitsWithModifier { get; }

        public TraitsWithModifierViewModel(List<TraitWithModifier<T>> traits)
        {
            TraitsWithModifier = new ObservableCollection<TraitWithModifierViewModel<T>>();

            foreach (var trait in traits)
            {
                TraitsWithModifier.Add(new TraitWithModifierViewModel<T>(trait));
            }
        }

        public override string ToString()
        {
            var traitsString = string.Empty;

            foreach (var trait in TraitsWithModifier)
            {
                traitsString += trait.ToString();
                traitsString += ", ";
            }

            if (TraitsWithModifier.Count > 2)
            {
                traitsString = traitsString.Substring(0, traitsString.Length - 2);
            }

            return traitsString;
        }
    }

    //public class TraitsWithModifierViewModel<VM, M, T> : NotifyPropertyChanged where VM : TraitWithModifierViewModel<M, T> where M : TraitWithModifier<T> where T : struct
    //{
    //    public ObservableCollection<VM> TraitsWithModifier { get; }

    //    public TraitsWithModifierViewModel(List<M> traits, IFactory<M, VM> viewModelFactory)
    //    {
    //        TraitsWithModifier = new ObservableCollection<VM>();

    //        foreach(var trait in traits) 
    //        {
    //            TraitsWithModifier.Add(viewModelFactory.Create);
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        var traitsString = string.Empty;

    //        foreach (var trait in TraitsWithModifier)
    //        {
    //            traitsString += trait.ToString();
    //            traitsString += ", ";
    //        }

    //        if (TraitsWithModifier.Count > 2)
    //        {
    //            traitsString = traitsString.Substring(0, traitsString.Length - 2);
    //        }

    //        return traitsString;
    //    }
    //}


    //public class SkillsViewModel : NotifyPropertyChanged
    //{
    //    public ObservableCollection<SkillViewModel> Skills { get; }

    //    public SkillsViewModel(List<Skill> skills)
    //    {
    //        Skills = new ObservableCollection<SkillViewModel>();

    //        foreach(var skill in skills)
    //        {
    //            Skills.Add(new SkillViewModel(skill));
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        var skillsString = string.Empty;

    //        foreach (var skill in Skills)
    //        {
    //            skillsString += skill.ToString();
    //            skillsString += ", ";
    //        }

    //        if (Skills.Count > 2)
    //        {
    //            skillsString = skillsString.Substring(0, skillsString.Length - 2);
    //        }

    //        return skillsString;
    //    }
    //}
}
