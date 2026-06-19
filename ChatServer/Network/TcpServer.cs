using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Network
{
    public class TCPServer
    {
        private Socket sckServer;
        private readonly List<Socket> sckClients = new();
        private readonly byte[] rcvBuffer = new byte[4096]; // ReceiveCallback

        //gui thong bao
        public Action<string>? Onlog;

        // Socket -> Bind -> Listen -> Accept
        public void StartServer(int port)
        {
            try
            {
                //tao sck
                sckServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //gan ket noi
                IPEndPoint serverEP = new IPEndPoint(IPAddress.Any, port);
                sckServer.Bind(serverEP);

                //tao hang doi
                sckServer.Listen(10);

                //Ghi log 
                Onlog?.Invoke($"Server started at port {port}");

                //Cho ket noi
                sckServer.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.Message);
            }
        }

        //accept va luu client vao list
        private void AcceptCallback(IAsyncResult result)
        {
            try
            {
                Socket client = sckServer.EndAccept(result);
                sckClients.Add(client);

                Onlog?.Invoke($"Client connected: {client.RemoteEndPoint}");
                sckServer.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception ex)
            {
                Onlog?.Invoke(ex.Message);
            }
        }
        //dem onl user
        public int OnlineCount
        {
            get
            {
                return sckClients.Count;
            }
        }
        //dong server
        public void StopServer()
        {
            foreach (Socket client in sckClients)
            {
                sckServer?.Close();
                sckServer = null;
            }
            sckClients.Clear();
            sckServer?.Close();
            Onlog?.Invoke("Server stopped.");
        }
        public bool IsRunning
        {
            get
            {
                return sckServer != null;
            }
        }
    }
}