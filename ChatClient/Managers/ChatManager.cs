using ChatApp_Shared.Packet;
using ChatApp_Shared.Enums;
using ChatClient.Helpers;
using ChatClient.Network;

namespace ChatClient.Managers
{
    public class ChatManager
    {
        private readonly TCPClient _client;

        public ChatManager(TCPClient client)
        {
            _client = client;
        }

        public async Task SendPrivateMessageAsync(string receiver, string content)
        {
            var packet = new Packet
            {
                Type = MessageType.PrivateMessage,
                Content = $"{receiver}|{content}"
            };
            await _client.SendAsync(PacketHelper.Serialize(packet));
        }

        public async Task SendGroupMessageAsync(string groupName, string content)
        {
            var packet = new Packet
            {
                Type = MessageType.GroupMessage,
                Content = $"{groupName}|{content}"
            };
            await _client.SendAsync(PacketHelper.Serialize(packet));
        }

        public async Task RequestOnlineUsersAsync()
        {
            var packet = new Packet
            {
                Type = MessageType.OnlineUsers,
                Content = ""
            };
            await _client.SendAsync(PacketHelper.Serialize(packet));
        }

        // Thêm các phương thức khác nếu cần: CreateGroup, AddMember, ...
    }
}