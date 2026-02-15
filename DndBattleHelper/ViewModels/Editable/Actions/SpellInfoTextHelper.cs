namespace DndBattleHelper.ViewModels.Editable.Actions
{
    public static class SpellInfoTextHelper
    {
        public static string Build(ISpellViewModel spell)
        {
            var parts = new List<string>();

            if (spell.Concentration)
            {
                parts.Add("Concentration");
            }

            if (!string.IsNullOrEmpty(spell.Range))
            {
                parts.Add($"Range: {spell.Range}");
            }

            if (!string.IsNullOrEmpty(spell.Duration))
            {
                parts.Add($"Duration: {spell.Duration}");
            }

            var components = BuildComponentsText(spell);
            if (!string.IsNullOrEmpty(components))
            {
                parts.Add($"Components: {components}");
            }

            return string.Join(", ", parts);
        }

        private static string BuildComponentsText(ISpellViewModel spell)
        {
            var componentParts = new List<string>();

            if (spell.HasVerbalComponent)
            {
                componentParts.Add("V");
            }

            if (spell.HasSomaticComponent)
            {
                componentParts.Add("S");
            }

            if (spell.HasMaterialComponent)
            {
                if (!string.IsNullOrEmpty(spell.MaterialComponent))
                {
                    componentParts.Add($"M ({spell.MaterialComponent})");
                }
                else
                {
                    componentParts.Add("M");
                }
            }

            return string.Join(", ", componentParts);
        }
    }
}
