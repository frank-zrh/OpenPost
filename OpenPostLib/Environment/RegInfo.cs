using System;
using System.IO;
using System.Text.Json;

namespace OpenPostLib.Environment
{
    public class RegInfo
    {
        public string SelectedSolutionFile { get; set; }
        public string SelectedProjectId { get; set; }
        public string SelectedGroupId { get; set; }
        public string SelectedRequestId { get; set; }

        public void SaveToFile(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static RegInfo LoadFromFile(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<RegInfo>(jsonString);
        }
    }
}