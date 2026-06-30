using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Network
{
    internal class ClientState
    {
        public Socket ClientSocket { get; internal set; } = null!;

        public byte[] Buffer { get; } = new byte[8192];

        public MemoryStream Stream { get; } = new();
    }
}
