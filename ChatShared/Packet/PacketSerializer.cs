using ChatApp_Shared.DTOs;
using System.Text;
using System.Text.Json;

namespace ChatApp_Shared.Packet
{
    public static class PacketSerializer
    {
        public static byte[] Serialize<T>(T packet)
        {
            string json = JsonSerializer.Serialize(packet);

            byte[] body = Encoding.UTF8.GetBytes(json);

            byte[] length = BitConverter.GetBytes(body.Length);

            byte[] result = new byte[4 + body.Length];

            Buffer.BlockCopy(length, 0, result, 0, 4);

            Buffer.BlockCopy(body, 0, result, 4, body.Length);

            return result;
        }
        public static T? Deserialize<T>(byte[] data)
        {
            return Deserialize<T>(data, data.Length);
        }
        public static T? Deserialize<T>(byte[] data, int length)
        {
            string json = Encoding.UTF8.GetString(data, 0, length);
            return JsonSerializer.Deserialize<T>(json);
        }

        public static bool TryReadPacket(MemoryStream stream, out MessagePacket? packet)
        {
            packet = null;

            if (stream.Length < 4)
                return false;

            stream.Position = 0;

            byte[] lengthBuffer = new byte[4];
            stream.Read(lengthBuffer, 0, 4);

            int length = BitConverter.ToInt32(lengthBuffer, 0);

            if (length <= 0 || length > 10 * 1024 * 1024)
                throw new InvalidDataException("Invalid packet length.");

            if (stream.Length - 4 < length)
            {
                stream.Position = 0;
                return false;
            }

            byte[] body = new byte[length];

            stream.Read(body, 0, length);

            packet = Deserialize<MessagePacket>(body, length);

            byte[] remain = stream.ToArray()[(int)stream.Position..];

            stream.SetLength(0);

            stream.Write(remain, 0, remain.Length);

            stream.Position = stream.Length;

            return true;
        }
    }
}