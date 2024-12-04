namespace DndBattleHelper.Models
{
    public class ToHitRoll
    {
        public bool DidAttackHit { get; set; }
        public int Roll { get; set; }
        public Modifier Modifier { get; set; }
        public int ToHitWithModifier { get; set; }
        public int AdvantageDisadvantageRoll { get; set; }

        public ToHitRoll(bool didAttackHit, int roll, Modifier modifier, int toHit, int advantageDisadvantageRoll = 0)
        {
            DidAttackHit = didAttackHit;
            Roll = roll;
            Modifier = modifier;
            ToHitWithModifier = toHit;
            AdvantageDisadvantageRoll = advantageDisadvantageRoll;
        }

        public ToHitRoll() { }
    }
}
