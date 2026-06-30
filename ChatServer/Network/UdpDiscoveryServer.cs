using ChatShared.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ChatServer.Network
{
    public class UDPDiscoveryServer
    {
        private const int DISCOVERY_PORT = 5001;

        private UdpClient? udpServer;
        private int tcpPort;
        public Action<string>? OnLog;

        public bool IsRunning
        {
            get
            {
                return udpServer != null;
            }
        }
        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                if (udpServer == null)
                    return;

                IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

                byte[] data = udpServer.EndReceive(result, ref remote);

                string request =
                    Encoding.UTF8.GetString(data);

                if (request == "DISCOVER_CHAT_SERVER")
                {
                    SendResponse(remote);
                }

                udpServer.BeginReceive(ReceiveCallback, null);
            }
            catch{}
        }
        private void SendResponse(IPEndPoint remote)
        {
            if (udpServer == null)
                return;

            ServerInfo info = new()
            {
                ServerName = "Fox Chat",
                IP = GetLocalIPAddress(),
                TcpPort = tcpPort,
                LastSeen = DateTime.Now
            };

            string json = JsonSerializer.Serialize(info);
            byte[] buffer = Encoding.UTF8.GetBytes(json);
            udpServer.Send(buffer, buffer.Length, remote);

            OnLog?.Invoke($"Discovery response -> {remote.Address}");
        }
        private string GetLocalIPAddress()
        {
            foreach (IPAddress ip in
                Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily ==
                    AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "127.0.0.1";
        }
        public void Start(int tcpPort)
        {
            this.tcpPort = tcpPort;

            udpServer = new UdpClient(DISCOVERY_PORT);
            udpServer.BeginReceive(ReceiveCallback, null);

            OnLog?.Invoke($"UDP Discovery listening at {DISCOVERY_PORT}");
        }

        public void Stop()
        {
            try
            {
                udpServer?.Close();
            }
            catch {}

            udpServer = null;
            OnLog?.Invoke("UDP Discovery stopped.");
        }
    }
}