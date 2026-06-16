using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Shared.Models
{
    public class BufferFile
    {
        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public byte[] Buffer { get; set; } = Array.Empty<byte>();
        public string Extension { get; set; } = string.Empty;
    }
}
