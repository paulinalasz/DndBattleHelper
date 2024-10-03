namespace DndBattleHelper.Models.ActionTypes
{
    public interface ISpell
    {
        public bool Concentration { get; }
        public SpellSlot SpellSlot { get; }
    }
}
