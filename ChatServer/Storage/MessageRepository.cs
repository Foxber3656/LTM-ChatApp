using ChatApp_Shared.DTOs;

namespace ChatServer.Storage
{
    public class MessageRepository
    {
        private readonly string file =
            Path.Combine("Data", "messages.json");

        private readonly List<MessagePacket> messages;

        public MessageRepository()
        {
            Directory.CreateDirectory("Data");
            messages = JsonStorage.Load<MessagePacket>(file);
        }

        public List<MessagePacket> GetAll()
        {
            return messages;
        }

        public void Add(MessagePacket message)
        {
            messages.Add(message);
            Save();
        }

        public List<MessagePacket> GetConversation(string user1, string user2)
        {
            return messages.Where(x =>
                (x.Sender == user1 && x.Receiver == user2) ||
                (x.Sender == user2 && x.Receiver == user1))
                .OrderBy(x => x.TimeStamp)
                .ToList();
        }

        public List<MessagePacket> GetGroupMessages(string groupName)
        {
            return messages
                .Where(x =>
                    x.Type == ChatApp_Shared.Enums.MessageType.GroupMessage &&
                    x.Receiver == groupName)
                .OrderBy(x => x.TimeStamp)
                .ToList();
        }

        public void Save()
        {
            JsonStorage.Save(file, messages);
        }
    }
}