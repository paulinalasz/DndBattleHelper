using DndBattleHelper.Models;
using System.IO;

namespace DndBattleHelper.Helpers
{
    public class FileIO
    {
        public FileIO() { }

        private string GetFilePath(string fileName)
        {
            string dataFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Presets");
            string filePath = Path.Combine(dataFolderPath, fileName);

            return filePath;
        }

        public void OutputPreset(EnemyPreset enemy)
        {
            var path = GetFilePath(enemy.Name);
            File.WriteAllText(path, MySerialiser<EnemyPreset>.Serialize(enemy));
        }

        public List<EnemyPreset> DeserialisePresets()
        {
            var presets = new List<EnemyPreset>();
            var presetFileNames = Directory.GetFiles(GetFilePath(""));

            foreach(var presetFileName in presetFileNames) 
            {
                var xmlString = File.ReadAllText(GetFilePath(presetFileName));
                presets.Add(MySerialiser<EnemyPreset>.Deserialize(xmlString));
            }

            return presets;
        }

        public string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
