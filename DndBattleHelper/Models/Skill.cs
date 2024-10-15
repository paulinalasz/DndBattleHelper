namespace DndBattleHelper.Models
{
    // where T is enum type
    public class TraitWithModifier<T>
    {
        public T Type { get; set; }
        public Modifier Modifier { get; set; }
        public TraitWithModifier(T type, Modifier modifier)
        {
            Type = type;
            Modifier = modifier;
        }

        private TraitWithModifier() { }

        public override string ToString()
        {
            var skillString = string.Empty;

            skillString += Type.ToString();
            skillString += " ";
            skillString += Modifier.ToString();

            return skillString;
        }

        public TraitWithModifier<T> Copy()
        {
            return new TraitWithModifier<T>(Type, Modifier.Copy());
        }
    }

    public class Skill 
    {
        public SkillType Type { get; set; }
        public Modifier Modifier { get; set; }

        public Skill(SkillType type, Modifier modifier)
        {
            Type = type;
            Modifier = modifier;
        }

        private Skill() { }

        public override string ToString()
        {
            var skillString = string.Empty;

            skillString += Type.ToString();
            skillString += " ";
            skillString += Modifier.ToString();

            return skillString;
        }

        public Skill Copy()
        {
            return new Skill(Type, Modifier.Copy());
        }
    }
}
