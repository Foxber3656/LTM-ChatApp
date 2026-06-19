using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message = ChatShared.Models.Message;

namespace ChatServer.Storage
{
    public class MessageRepository
    {
        private readonly string _path = @"..\..\..\..\Data\messages.json";

        public List<Message> GetAll()
        {
            return JsonStorage.Read<Message>(_path);
        }
    }
}


/*
 * -------------------------
 * Chức năng:
 * - Lưu lịch sử chat.
 * - Truy xuất lịch sử hội thoại.
 * - Cập nhật trạng thái tin nhắn.
 * - Hỗ trợ thu hồi tin nhắn.
 *
 * Dữ liệu:
 * Data/messages.json
 *
 * Chức năng liên quan:
 * - Private Chat
 * - Group Chat
 * - History
 * - Recall Message
 */