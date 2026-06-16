using ChatApp_Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Shared.Packet
{
    public class Packet
    {
        public MessageType Type { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
