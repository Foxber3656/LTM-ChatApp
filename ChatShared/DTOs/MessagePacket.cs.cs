using ChatApp_Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Shared.DTOs
{
    public class MessagePacket
    {
        public MessageType Type { get; set; }
        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
