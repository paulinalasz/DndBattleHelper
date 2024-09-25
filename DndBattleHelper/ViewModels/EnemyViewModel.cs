using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels
{
    public class EnemyViewModel : EntityViewModel
    {
        public int ArmourClass { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }   
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom {  get; set; }
        public int Charisma { get; set; }
        public SkillsViewModel Skills { get; set; }
        public SensesViewModel Senses { get; set; }
        public LanguagesViewModel Languages { get; set; }
        public int Challenge { get; set; }
        public ObservableCollection<AbilityViewModel> Abilities { get; set; }
        public List<EntityAction> Actions { get; set; }

        public EnemyViewModel(Enemy enemy) 
        {
            Name = enemy.Name;
            ArmourClass = enemy.ArmourClass;
            Health = enemy.Health;
            Speed = enemy.Speed;
            Strength = enemy.Strength;
            Dexterity = enemy.Dexterity;
            Constitution = enemy.Constitution;
            Intelligence = enemy.Intelligence;
            Wisdom = enemy.Wisdom;
            Charisma = enemy.Charisma;
            Skills = new SkillsViewModel(enemy.Skills);
            Senses = new SensesViewModel(enemy.Senses, enemy.PassivePerception);
            Languages = new LanguagesViewModel(enemy.Languages);
            Challenge = enemy.Challenge;
            
            Abilities = new ObservableCollection<AbilityViewModel>();

            foreach(var ability in enemy.Abilities)
            {
                Abilities.Add(new AbilityViewModel(ability));
            }

            Actions = enemy.Actions;
        }
    }
}
