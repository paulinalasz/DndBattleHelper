using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class EnemyPreset : Enemy
    {
        public Roll HealthRoll { get; set; }

        public Roll InitiativeRoll { get; set; }

        public EnemyPreset(string name,
            int initiative,
            int armourClass,
            int health,
            int speed,
            int flySpeed,
            int swimSpeed,
            int climbSpeed,
            int burrowSpeed,
            int strength,
            int dexterity,
            int constitution,
            int intelligence,
            int wisdom,
            int charisma,
            bool isSpellCaster,
            List<SpellSlotAvailability> spellSlots,
            int spellSaveDC,
            List<TraitWithModifier<AbilityScoreType>> savingThrows,
            List<Trait<DamageType>> damageVurnerability,
            List<Trait<DamageType>> damageResistances,
            List<Trait<DamageType>> damageImmunities,
            List<Trait<Condition>> conditionImmunities,
            List<TraitWithModifier<SkillType>> skills,
            List<TraitWithValue<SenseType>> senses,
            PassivePerception passivePerception,
            List<Trait<LanguageType>> languages,
            ChallengeRating challengeRating,
            List<Ability> abilities,
            List<EntityAction> actions,
            Roll healthRoll,
            Roll initiativeRoll,
            string legendaryActionsDescription,
            string lairActionsDescription) 
            : base(name,
                initiative,
                armourClass, 
                health, 
                speed, 
                flySpeed,
                swimSpeed,
                climbSpeed,
                burrowSpeed,
                strength,
                dexterity, 
                constitution,
                intelligence, 
                wisdom,
                charisma,
                isSpellCaster,
                spellSlots,
                spellSaveDC,
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
                actions,
                legendaryActionsDescription,
                lairActionsDescription)
        {
            HealthRoll = healthRoll;
            InitiativeRoll = initiativeRoll;
        }

        public EnemyPreset() { }
    }
}
