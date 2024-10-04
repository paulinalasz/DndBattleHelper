namespace DndBattleHelper.Models.ActionTypes
{
    public interface ISpell
    {
        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }
    }
}
