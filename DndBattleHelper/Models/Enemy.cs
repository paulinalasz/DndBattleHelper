using DndBattleHelper.Models.ActionTypes;

namespace DndBattleHelper.Models
{
    public class Enemy : Entity
    {
        public string VersionNumber = "1.0.0";
        public int ArmourClass { get; set; }
        public int Speed { get; set; }
        public int FlySpeed { get; set; }
        public int SwimSpeed { get; set; }
        public int ClimbSpeed { get; set; }
        public int BurrowSpeed { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public bool IsSpellCaster { get; set; }
        public List<SpellSlotAvailability> SpellSlots { get; set; }
        public int SpellSaveDC { get; set; }

        public List<TraitWithModifier<AbilityScoreType>> SavingThrows { get; set; }
        public List<Trait<DamageType>> DamageVurnerabilities { get; set; }
        public List<Trait<DamageType>> DamageResistances { get; set; }
        public List<Trait<DamageType>> DamageImmunities { get; set; }
        public List<Trait<Condition>> ConditionImmunities { get; set; }
        public List<TraitWithModifier<SkillType>> Skills { get; set; }
        public List<TraitWithValue<SenseType>> Senses { get; set; }
        public PassivePerception PassivePerception { get; set; }
        public List<Trait<LanguageType>> Languages { get; set; }
        public ChallengeRating ChallengeRating { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<EntityAction> Actions { get; set; }

        public string LegendaryActionsDescription { get; set; }
        public string LairActionsDescription { get; set; }  

        public Enemy(string name, 
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
            string legendaryActionsDescription,
            string lairActionsDescription) : base(initiative, name, health)
        {
            ArmourClass = armourClass;
            Speed = speed;
            FlySpeed = flySpeed;
            SwimSpeed = swimSpeed;
            ClimbSpeed = climbSpeed;
            BurrowSpeed = burrowSpeed;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            IsSpellCaster = isSpellCaster;
            SpellSlots = spellSlots;
            SpellSaveDC = spellSaveDC;
            SavingThrows = savingThrows;
            DamageVurnerabilities = damageVurnerability;
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
            LegendaryActionsDescription = legendaryActionsDescription;
            LairActionsDescription = lairActionsDescription;
        }

        protected Enemy() { }

        public Enemy Copy()
        {
            return new Enemy(Name,
                Initiative,
                ArmourClass,
                Health,
                Speed,
                FlySpeed,
                SwimSpeed,
                ClimbSpeed,
                BurrowSpeed,
                Strength,
                Dexterity,
                Constitution,
                Intelligence,
                Wisdom,
                Charisma,
                IsSpellCaster,
                SpellSlots,
                SpellSaveDC,
                SavingThrows,
                DamageVurnerabilities,
                DamageResistances,
                DamageImmunities,
                ConditionImmunities,
                Skills,
                Senses,
                PassivePerception,
                Languages,
                ChallengeRating,
                Abilities,
                Actions,
                LegendaryActionsDescription,
                LairActionsDescription);
        }
    }
}
