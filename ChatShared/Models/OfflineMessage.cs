using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Shared.Models
{
    public class OfflineMessage
    {
        public string Receiver { get; set; } = string.Empty;
        public Message Message { get; set; } = new();
    }
}
