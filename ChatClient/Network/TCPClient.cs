using ChatApp_Shared.DTOs;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using ChatApp_Shared.Packet;

namespace ChatClient.Network
{
    public class TCPClient
    {
        #region Fields
        private Socket? sckClient;
        #endregion

        #region Events
        public Action<string>? OnLog;
        public Action<MessagePacket>? OnPacketReceived;
        public Action? OnDisconnected;

        #endregion

        #region Socket Callback
        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                ClientState state = (ClientState)result.AsyncState!;
                Socket client = state.ClientSocket;
                int size = client.EndReceive(result);
                if (size <= 0)
                {
                    Disconnect();
                    return;
                }
                // Ghi dữ liệu nhận được vào Stream
                state.Stream.Position = state.Stream.Length;
                state.Stream.Write(state.Buffer, 0, size);

                MessagePacket? packet;
                while (PacketSerializer.TryReadPacket(state.Stream, out packet))
                {
                    if (packet != null)
                    {
                        ProcessPacket(packet);
                    }
                }
                client.BeginReceive(state.Buffer, 0, state.Buffer.Length,
                    SocketFlags.None, ReceiveCallback, state);
            }
            catch (Exception ex)
            {
                OnLog?.Invoke(ex.Message);
                Disconnect();
            }
        }
        #endregion

        #region Connection
        public void Connect(string ip, int port)
        {
            try
            {
                sckClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sckClient.Connect(IPAddress.Parse(ip), port);
                ClientState state = new ClientState()
                {
                    ClientSocket = sckClient
                };
                sckClient.BeginReceive(state.Buffer, 0, state.Buffer.Length, 
                    SocketFlags.None, ReceiveCallback, state);
                OnLog?.Invoke( $"Connected to {ip}:{port}");
            }
            catch (Exception ex)
            {
                OnLog?.Invoke(ex.Message);
            }
        }
        public void Disconnect()
        {
            try
            {
                sckClient?.Close();
            }
            catch {}
            sckClient = null;
            OnDisconnected?.Invoke();
            OnLog?.Invoke("Disconnected.");
        }
        #endregion

        #region Packet
        public void SendPacket(MessagePacket packet)
        {
            if (!IsConnected)
                return;
            try
            {
                byte[] data = PacketSerializer.Serialize(packet);
                sckClient!.Send(data);
            }
            catch (Exception ex)
            {
                OnLog?.Invoke(ex.Message);
            }
        }
        private void ProcessPacket(MessagePacket packet)
        {
            OnPacketReceived?.Invoke(packet);
        }
        #endregion

        #region Properties
        public bool IsConnected
        {
            get
            {
                return sckClient != null && sckClient.Connected;
            }
        }
        public Socket? ClientSocket
        {
            get
            {
                return sckClient;
            }
        }
        #endregion
    }
}
