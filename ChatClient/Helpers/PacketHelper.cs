using System.Text.Json;
using ChatApp_Shared.Packet; // Giả định Packet nằm ở namespace này

namespace ChatClient.Helpers
{
    public static class PacketHelper
    {
        public static string Serialize(Packet packet)
        {
            return JsonSerializer.Serialize(packet);
        }

        public static Packet? Deserialize(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<Packet>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}