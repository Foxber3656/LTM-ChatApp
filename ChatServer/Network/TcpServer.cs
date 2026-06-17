using Microsoft.VisualBasic.Logging;
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
        private Socket sckClient;
        private readonly byte[] rcvBuffer = new byte[4096];

        //gui thong bao
        public Action<string>? Onlog;

        public void StartServer(int port)
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
        private void AcceptCallback(IAsyncResult result)
        {
            sckClient = sckServer.EndAccept(result);

            Onlog?.Invoke($"Client connected: {sckClient.RemoteEndPoint}");

            //nhan du lieu
            sckClient.BeginReceive(rcvBuffer, 0, rcvBuffer.Length, 
                SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);

            //cho client
            sckServer.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        private void ReceiveCallBack(IAsyncResult result)
        {
            int size = sckClient.EndReceive(result);
            if (size == 0)
                return;

            string msg = Encoding.UTF8.GetString(rcvBuffer, 0, size);
            Onlog?.Invoke($"Client: {msg}");
            sckClient.BeginReceive(rcvBuffer, 0, rcvBuffer.Length,
                SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);
        }
        public void Send(string msg)
        {
            if (sckClient == null) return;
            byte[] data = Encoding.UTF8.GetBytes(msg);
            sckClient.Send(data);
        }
    }
}

/*
 * -------------------------
 * Chức năng:
 * - Tạo Socket Server.
 * - Bind Port.
 * - Listen Client.
 * - Accept Client.
 * - Receive dữ liệu.
 * - Send dữ liệu.
 */