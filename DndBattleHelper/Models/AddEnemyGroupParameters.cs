namespace DndBattleHelper.Models
{
    public class AddEnemyGroupParameters
    {
        public AddEnemyGroupParameters(int number, bool sameInitiative, bool sameHealth)
        {
            Number = number;
            SameInitiative = sameInitiative;
            SameHealth = sameHealth;
        }

        public int Number { get; set; }
        public bool SameInitiative { get; set; }
        public bool SameHealth { get; set; }
    }
}
