using DndBattleHelper.Models;
using System.IO;

namespace DndBattleHelper.Helpers
{
    public static class FileIONames
    {
        public static string PresetsFolder => "Presets";
    }

    public class FileIO
    {
        public FileIO() { }

        private string GetFilePath(string fileName, string folderName)
        {
            string dataFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, folderName);
            string filePath = Path.Combine(dataFolderPath, fileName);

            return filePath;
        }

        public void OutputPreset(EnemyPreset enemy)
        {
            var path = GetFilePath(enemy.Name, FileIONames.PresetsFolder);
            File.WriteAllText(path, MySerialiser<EnemyPreset>.Serialize(enemy));
        }

        public List<EnemyPreset> DeserialisePresets()
        {
            var presets = new List<EnemyPreset>();
            var presetFileNames = Directory.GetFiles(GetFilePath("", FileIONames.PresetsFolder));

            foreach(var presetFileName in presetFileNames) 
            {
                var xmlString = File.ReadAllText(GetFilePath(presetFileName, FileIONames.PresetsFolder));
                presets.Add(MySerialiser<EnemyPreset>.Deserialize(xmlString));
            }

            return presets;
        }

        public string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void OutputSaveFile(List<Entity> entitiesInInitiative, string path)
        {
            File.WriteAllText(path, MySerialiser<List<Entity>>.Serialize(entitiesInInitiative));
        }

        public List<Entity> OpenSavedFiles(string path)
        {
            if (path != string.Empty)
            {
                var xmlString = File.ReadAllText(path);
                return MySerialiser<List<Entity>>.Deserialize(xmlString);
            }
            else
            {
                return null;
            }
        }
    }
}
