using DndBattleHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBattleHelper.Helpers
{
    public class FileIO
    {
        public FileIO()
        {

        }

        private string GetFilePath(string fileName)
        {
            string dataFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Presets");
            string filePath = Path.Combine(dataFolderPath, fileName);

            return filePath;
        }

        public void OutputPreset(Enemy enemy)
        {
            var path = GetFilePath(enemy.Name);

            File.WriteAllText(path, MySerialiser<Enemy>.Serialize(enemy));
        }
    }
}
