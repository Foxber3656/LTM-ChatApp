using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Network
{
    public class ClientState
    {
        //Socket của client.
        public Socket ClientSocket { get; set; }

        //Buffer nhận dữ liệu.
        public byte[] Buffer { get; set; } = new byte[4096];
    }
}
