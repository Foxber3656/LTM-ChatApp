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
        public static List<T> Read<T>(string path)
        {
            if (!File.Exists(path))
                return new List<T>();

            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();
        }

        public static void Write<T>(string path, List<T> data)
        {
            string json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(path, json);
        }
    }
}


/*
 * -------------------------
 * Chức năng:
 * - Đọc dữ liệu từ file JSON.
 * - Ghi dữ liệu xuống file JSON.
 * - Là lớp nền cho toàn bộ Repository.
 *
 * Sử dụng cho:
 * - UserRepository
 * - MessageRepository
 * - GroupRepository
 * - OfflineMessageRepository
 */