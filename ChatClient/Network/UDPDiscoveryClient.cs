using ChatShared.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ChatClient.Network
{
    public class UDPDiscoveryClient
    {
        private const int DISCOVERY_PORT = 5001;
        public Action<ServerInfo>? OnServerFound;
        public Action<string>? OnLog;

        public void Scan()
        {
            try
            {
                using UdpClient client = new();
                client.EnableBroadcast = true;

                byte[] data = Encoding.UTF8.GetBytes("DISCOVER_CHAT_SERVER");

                client.Send(data, data.Length, 
                    new IPEndPoint(IPAddress.Broadcast, DISCOVERY_PORT));
                client.Client.ReceiveTimeout = 1000;

                while (true)
                {
                    try
                    {
                        IPEndPoint remote = new(IPAddress.Any, 0);
                        byte[] buffer = client.Receive(ref remote);
                        string json = Encoding.UTF8.GetString(buffer);
                        ServerInfo? info = JsonSerializer.Deserialize<ServerInfo>(json);

                        if (info != null)
                        {
                            OnServerFound?.Invoke(info);
                        }
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                OnLog?.Invoke(ex.Message);
            }
        }
    }
}