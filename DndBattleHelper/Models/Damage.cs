namespace DndBattleHelper.Models
{
    public class Damage
    {
        public int DamageGiven { get; set; }
        public DamageType DamageType { get; set; }

        public Damage(int damageGiven, DamageType damageType)
        {
            DamageGiven = damageGiven;
            DamageType = damageType;
        }
    }
}
