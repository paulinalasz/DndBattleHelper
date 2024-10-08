using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class Enemy
    {
        public string Name { get; set; }
        public int ArmourClass { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public List<Skill> Skills { get; set; }
        public List<SenseType> Senses { get; set; }
        public Skill PassivePerception { get; set; }
        public List<LanguageType> Languages { get; set; }
        public ChallengeRating ChallengeRating { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<EntityAction> Actions { get; set; }

        public Enemy(string name, 
            int armourClass,
            int health,
            int speed,
            int strength,
            int dexterity,
            int constitution,
            int intelligence,
            int wisdom,
            int charisma,
            List<Skill> skills,
            List<SenseType> senses,
            Skill passivePerception,
            List<LanguageType> languages,
            ChallengeRating challengeRating,
            List<Ability> abilities,
            List<EntityAction> actions) 
        {
            Name = name;
            ArmourClass = armourClass;
            Health = health;
            Speed = speed;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            Skills = skills;
            PassivePerception = passivePerception;
            Senses = senses;
            Languages = languages;
            ChallengeRating = challengeRating;
            Abilities = abilities;
            Actions = actions;
        }

        protected Enemy() { }
    }
}
