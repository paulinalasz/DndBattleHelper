namespace DndBattleHelper.Models
{
    public class AdvantageDisadvantageRoll
    {
        public int SecondRoll { get; set; }
        public AdvantageDisadvantage AdvantageDisadvantage { get; set; }

        public AdvantageDisadvantageRoll(int secondRoll, AdvantageDisadvantage advantageDisadvantage)
        {
            SecondRoll = secondRoll;
            AdvantageDisadvantage = advantageDisadvantage;
        }   

        public AdvantageDisadvantageRoll() { }
    }
}
