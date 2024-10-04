using DndBattleHelper.Models;
using DndBattleHelper.ViewModels.Editable.Traits;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class SensesViewModel
    {
        public ObservableCollection<SenseViewModel> Senses { get; set; }

        public Skill PassivePerception { get; set; }

        public SensesViewModel(List<SenseType> senses, Skill passivePerception)
        {
            Senses = new ObservableCollection<SenseViewModel>();

            foreach (var sense in senses) 
            {
                Senses.Add(new SenseViewModel(sense));
            }

            PassivePerception = passivePerception;
        }

        public override string ToString()
        {
            var senseString = string.Empty;

            foreach(var sense in Senses)
            {
                senseString += sense.ToString();
                senseString += ", ";
            }

            senseString += PassivePerception.ToString();

            return senseString;
        }
    }
}
