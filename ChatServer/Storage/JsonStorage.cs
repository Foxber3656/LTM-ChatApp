using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ChatServer.Storage
{
    public static class JsonStorage
    {
        private static readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };
        public static List<T> Load<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Save(filePath, new List<T>());
            }
            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();
        }
        public static void Save<T>(string filePath, List<T> data)
        {
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }
    }
}