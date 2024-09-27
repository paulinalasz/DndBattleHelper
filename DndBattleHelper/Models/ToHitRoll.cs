namespace DndBattleHelper.Models
{
    public class ToHitRoll
    {
        public bool DidAttackHit { get; set; }
        public int Roll { get; set; }
        public int ToHitWithModifier { get; set; }

        public ToHitRoll(bool didAttackHit, int roll, int toHit)
        {
            DidAttackHit = didAttackHit;
            Roll = roll;
            ToHitWithModifier = toHit;
        }
    }
}
