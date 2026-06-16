using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using ChatApp_Shared.Models;

namespace ChatServer.Storage
{
    public class UserRepository
    {
        private readonly string _path =@"..\..\..\..\Data\users.json";
        public List<Account> GetAll()
        {
            return JsonStorage.Read<Account>(_path);
        }
    }
}
