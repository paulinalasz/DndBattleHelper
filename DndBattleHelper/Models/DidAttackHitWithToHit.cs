namespace DndBattleHelper.Models
{
    public class DidAttackHitWithToHit
    {
        public bool DidAttackHit { get; set; }
        public int ToHit { get; set; }

        public DidAttackHitWithToHit(bool didAttackHit, int toHit)
        {
            DidAttackHit = didAttackHit;
            ToHit = toHit;
        }
    }
}
