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
            EnemyPresets = DeserialisePresets();
        }

        public List<EnemyPreset> DeserialisePresets()
        {
            return _fileIo.DeserialisePresets();
        }
    }
}
