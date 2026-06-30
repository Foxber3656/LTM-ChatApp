using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared.Models
{
    public class ServerInfo
    {
        public string ServerName { get; set; } = "Fox Chat";

        public string IP { get; set; } = string.Empty;

        public int TcpPort { get; set; }

        public DateTime LastSeen { get; set; } = DateTime.Now;
    }
}