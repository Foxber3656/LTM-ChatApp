using ChatShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Storage
{
    public class OfflineMessageRepository
    {
        private readonly string _path = @"..\..\..\..\Data\offline_messages.json";
        public List<OfflineMessage> GetAll()
        {
            return JsonStorage.Read<OfflineMessage>(_path);
        }
    }
}

/*
 * -------------------------
 * Chức năng:
 * - Lưu các tin nhắn gửi đến người dùng đang offline.
 * - Trả lại tin nhắn khi người dùng đăng nhập.
 * - Xóa tin nhắn đã nhận.
 *
 * Dữ liệu:
 * Data/offline_messages.json
 *
 * Chức năng liên quan:
 * - Offline Message Queue
 * - Auto Reconnect
 */