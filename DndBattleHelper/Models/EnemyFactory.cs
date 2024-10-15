using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class EnemyFactory()
    {
        public Enemy Create(string name,
            int initiative,
            int armourClass,
            int health,
            int speed,
            int strength,
            int dexterity,
            int constitution,
            int intelligence,
            int wisdom,
            int charisma,
            List<TraitWithModifier<SkillType>> skills,
            List<SenseType> senses,
            PassivePerception passivePerception,
            List<LanguageType> languages,
            ChallengeRating challengeRating,
            List<Ability> abilities,
            List<EntityAction> actions)
        {
            return new Enemy(name,
                initiative,
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
                actions);
        }
    }
}
