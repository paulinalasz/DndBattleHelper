using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class SensesViewModel
    {
        public List<SenseType> Senses { get; set; }

        public Skill PassivePerception { get; set; }

        public SensesViewModel(List<SenseType> senses, Skill passivePerception)
        {
            Senses = senses;
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
