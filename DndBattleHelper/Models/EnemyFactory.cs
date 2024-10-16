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
            List<TraitWithModifier<AbilityScoreType>> savingThrows,
            List<Trait<DamageType>> damageVurnerability,
            List<Trait<DamageType>> damageResistances,
            List<Trait<DamageType>> damageImmunities,
            List<Trait<Condition>> conditionImmunities,
            List<TraitWithModifier<SkillType>> skills,
            List<Trait<SenseType>> senses,
            PassivePerception passivePerception,
            List<Trait<LanguageType>> languages,
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
                savingThrows,
                damageVurnerability,
                damageResistances,
                damageImmunities,
                conditionImmunities,
                skills,
                senses,
                passivePerception,
                languages,
                challengeRating,
                abilities,
                actions);
        }

        public Enemy CreateBlank()
        {
            return new Enemy("",
                10,
                10,
                0,
                30,
                10,
                10,
                10,
                10,
                10,
                10,
                new List<TraitWithModifier<AbilityScoreType>>(),
                new List<Trait<DamageType>>(),
                new List<Trait<DamageType>>(),
                new List<Trait<DamageType>>(),
                new List<Trait<Condition>>(),
                new List<TraitWithModifier<SkillType>>(),
                new List<Trait<SenseType>>(),
                new PassivePerception(10),
                new List<Trait<LanguageType>>(),
                new ChallengeRating(Enums.ChallengeRatingLevel.One),
                new List<Ability>(),
                new List<EntityAction>());

        }
    }
}
