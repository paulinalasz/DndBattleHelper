namespace DndBattleHelper.Models
{
    public class Damage
    {
        public int DamageGiven { get; set; }
        public DamageType DamageType { get; set; }
        public int ToHit { get; set; }

        public Damage(int damageGiven, DamageType damageType, int toHit)
        {
            DamageGiven = damageGiven;
            DamageType = damageType;
            ToHit = toHit;
        }
    }
}
