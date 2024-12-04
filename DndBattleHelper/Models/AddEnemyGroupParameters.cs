namespace DndBattleHelper.Models
{
    public class AddEnemyGroupParameters
    {
        public AddEnemyGroupParameters(int number, 
            bool sameInitiative, 
            int initiative,
            bool sameHealth,
            int health)
        {
            Number = number;
            SameInitiative = sameInitiative;
            Initiative = initiative;
            SameHealth = sameHealth;
            Health = health;
        }

        public int Number { get; set; }
        public bool SameInitiative { get; set; }
        public int Initiative { get; set; }
        public bool SameHealth { get; set; }
        public int Health { get; set; }
    }
}
