namespace DndBattleHelper.Models
{
    public class ToHitRoll
    {
        public bool DidAttackHit { get; set; }
        public int Roll { get; set; }
        public Modifier Modifier { get; set; }
        public int ToHitWithModifier { get; set; }

        public ToHitRoll(bool didAttackHit, int roll, Modifier modifier, int toHit)
        {
            DidAttackHit = didAttackHit;
            Roll = roll;
            Modifier = modifier;
            ToHitWithModifier = toHit;
        }
    }
}
