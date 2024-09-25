using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<SkillType> Skills { get; set; }
        public List<SenseType> Senses { get; set; }
        public List<LanguageType> Languages { get; set; }
        public int Challenge { get; set; }
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
            List<SkillType> skills,
            List<SenseType> senses,
            List<LanguageType> languages,
            int challenge,
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
            Senses = senses;
            Languages = languages;
            Challenge = challenge;
            Abilities = abilities;
            Actions = actions;
        }
    }
}
