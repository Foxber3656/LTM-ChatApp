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
<<<<<<< HEAD
        public Socket ClientSocket { get; set; }
=======
        public Socket sckClient { get; set; }
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d

        //Buffer nhận dữ liệu.
        public byte[] Buffer { get; set; } = new byte[4096];
    }
}
