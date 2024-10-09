namespace DndBattleHelper.Models
{
    public class PassivePerception
    {
        public SkillType Type => SkillType.PassivePerception;

        public int Value;

        public PassivePerception(int value) 
        {
            Value = value;
        }

        protected PassivePerception() { }

        public override string ToString()
        {
            return $"Passive Perception: {Value}";
        }
    }
}
