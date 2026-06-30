using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Shared.DTOs
{
    public class RecallPacket
    {
        public Guid MessageId { get; set; }

        public string Sender { get; set; } = string.Empty;

        public string Receiver { get; set; } = string.Empty;
    }
}
