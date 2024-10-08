using DndBattleHelper.Helpers;
using DndBattleHelper.Models;
using System.Collections.ObjectModel;

namespace DndBattleHelper.ViewModels
{
    public class PresetsViewModel
    {
        private readonly FileIO _fileIo;

        public List<Enemy> Presets { get; set; }

        public PresetsViewModel(FileIO fileIo)
        {
            _fileIo = fileIo;
            Presets = DeserialisePresets();
        }

        public List<Enemy> DeserialisePresets()
        {
            return _fileIo.DeserialisePresets();
        }
    }
}
