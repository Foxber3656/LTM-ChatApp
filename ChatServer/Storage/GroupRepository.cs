using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatShared.Models;

namespace ChatServer.Storage
{
    public class GroupRepository
    {
        private readonly string _path =@"..\..\..\..\Data\groups.json";
        public List<Group> GetAll()
        {
            return JsonStorage.Read<Group>(_path);
        }
    }
}

/*
 * -------------------------
 * Chức năng:
 * - Lưu thông tin nhóm chat.
 * - Tạo nhóm.
 * - Thêm thành viên.
 * - Xóa thành viên.
 * - Truy xuất danh sách nhóm.
 *
 * Dữ liệu:
 * Data/groups.json
 *
 * Chức năng liên quan:
 * - Group Chat
 * - Create Group
 * - Add Member
 * - Remove Member
 */