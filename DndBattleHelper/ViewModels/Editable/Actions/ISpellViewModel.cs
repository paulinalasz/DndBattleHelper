using DndBattleHelper.Models;

namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public interface ISpellViewModel
    {
        public bool Concentration { get; set; }
        public SpellSlot SpellSlot { get; set; }
        public string Duration { get; set; }
        public string Range { get; set; }
        public bool HasVerbalComponent { get; set; }
        public bool HasSomaticComponent { get; set; }
        public bool HasMaterialComponent { get; set; }
        public string MaterialComponent { get; set; }
        public string SpellInfoText { get; }
        public bool IsSpellInfoVisible { get; }
    }
}
