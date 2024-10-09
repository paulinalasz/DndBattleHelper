using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class EnemyPreset : Enemy
    {
        public Roll HealthRoll { get; set; }

        public EnemyPreset(string name,
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
            PassivePerception passivePerception,
            List<LanguageType> languages,
            ChallengeRating challengeRating,
            List<Ability> abilities,
            List<EntityAction> actions,
            Roll healthRoll) 
            : base(name,
                armourClass, 
                health, 
                speed, 
                strength,
                dexterity, 
                constitution,
                intelligence, 
                wisdom,
                charisma, 
                skills, 
                senses,
                passivePerception, 
                languages,
                challengeRating,
                abilities,
                actions)
        {
            HealthRoll = healthRoll;
        }

        public EnemyPreset() { }
    }
}
