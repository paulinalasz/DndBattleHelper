﻿using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class Enemy : Entity
    {
        public int ArmourClass { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public List<TraitWithModifier<AbilityScoreType>> SavingThrows { get; set; }
        public List<Trait<DamageType>> DamageVurnerability { get; set; }
        public List<Trait<DamageType>> DamageResistances { get; set; }
        public List<Trait<DamageType>> DamageImmunities { get; set; }
        public List<Trait<Condition>> ConditionImmunities { get; set; }
        public List<TraitWithModifier<SkillType>> Skills { get; set; }
        public List<Trait<SenseType>> Senses { get; set; }
        public PassivePerception PassivePerception { get; set; }
        public List<Trait<LanguageType>> Languages { get; set; }
        public ChallengeRating ChallengeRating { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<EntityAction> Actions { get; set; }

        public Enemy(string name, 
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
            List<EntityAction> actions) : base(initiative, name, health)
        {
            ArmourClass = armourClass;
            Speed = speed;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            SavingThrows = savingThrows;
            DamageVurnerability = damageVurnerability;
            DamageResistances = damageResistances;
            DamageImmunities = damageImmunities;
            ConditionImmunities = conditionImmunities;
            Skills = skills;
            PassivePerception = passivePerception;
            Senses = senses;
            Languages = languages;
            ChallengeRating = challengeRating;
            Abilities = abilities;
            Actions = actions;
        }

        protected Enemy() { }

        public Enemy Copy()
        {
            return new Enemy(Name,
                Initiative,
                ArmourClass,
                Health,
                Speed,
                Strength,
                Dexterity,
                Constitution,
                Intelligence,
                Wisdom,
                Charisma,
                SavingThrows,
                DamageVurnerability,
                DamageResistances,
                DamageImmunities,
                ConditionImmunities,
                Skills,
                Senses,
                PassivePerception,
                Languages,
                ChallengeRating,
                Abilities,
                Actions);
        }
    }
}
