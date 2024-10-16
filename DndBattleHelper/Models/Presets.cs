using DndBattleHelper.Helpers;

namespace DndBattleHelper.Models
{
    public class Presets
    {
        private readonly FileIO _fileIo;

        public List<EnemyPreset> EnemyPresets { get; set; }

        public Presets(FileIO fileIo)
        {
            _fileIo = fileIo;
            DeserialisePresets();
        }

        public void DeserialisePresets()
        {
            var presets = _fileIo.DeserialisePresets();
            EnemyPresets = presets.OrderBy(preset => preset.Name).ToList();
        }
    }
}
