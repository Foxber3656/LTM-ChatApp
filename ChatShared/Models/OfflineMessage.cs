using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShared.Models
{
    public class OfflineMessage
    {
        public string Receiver { get; set; } = string.Empty;
        public Message Message { get; set; } = new();
    }
}
