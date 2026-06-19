using ChatApp_Shared.Packet;
using ChatApp_Shared.Enums;
using ChatClient.Helpers;
using ChatClient.Network;

namespace ChatClient.Managers
{
    public class AuthManager
    {
        private readonly TCPClient _client;

        public AuthManager(TCPClient client)
        {
            _client = client;
        }

        public async Task LoginAsync(string username, string password)
        {
            var packet = new Packet
            {
                Type = MessageType.Login,
                Content = $"{username}|{password}"  // Hoặc dùng JSON
            };
            await _client.SendAsync(PacketHelper.Serialize(packet));
        }

        public async Task RegisterAsync(string username, string password)
        {
            var packet = new Packet
            {
                Type = MessageType.Register,
                Content = $"{username}|{password}"
            };
            await _client.SendAsync(PacketHelper.Serialize(packet));
        }

        public async Task LogoutAsync()
        {
            var packet = new Packet
            {
                Type = MessageType.Logout,
                Content = ""
            };
            await _client.SendAsync(PacketHelper.Serialize(packet));
            _client.Disconnect();
        }
    }
}