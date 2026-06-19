using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatClient.Network
{
    public class TCPClient
    {
        private Socket? _socket;
        private readonly byte[] _buffer = new byte[4096];
        private readonly List<byte> _dataBuffer = new(); // Lưu dữ liệu chưa xử lý

        public event Action? OnConnected;
        public event Action<string>? OnMessageReceived; // nhận JSON string
        public event Action<string>? OnDisconnected;
        public event Action<string>? OnError;

        public bool IsConnected => _socket != null && _socket.Connected;

        public async Task ConnectAsync(string ip, int port)
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await _socket.ConnectAsync(IPAddress.Parse(ip), port);
                OnConnected?.Invoke();
                _ = ReceiveLoopAsync();
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message);
                Disconnect();
            }
        }

        private async Task ReceiveLoopAsync()
        {
            try
            {
                while (_socket != null && _socket.Connected)
                {
                    int bytesRead = await _socket.ReceiveAsync(_buffer, SocketFlags.None);
                    if (bytesRead == 0) break;

                    _dataBuffer.AddRange(_buffer.Take(bytesRead));

                    // Xử lý các gói tin kết thúc bằng '\n'
                    while (_dataBuffer.Count > 0)
                    {
                        int index = _dataBuffer.IndexOf((byte)'\n');
                        if (index == -1) break;

                        byte[] packetBytes = _dataBuffer.Take(index).ToArray();
                        _dataBuffer.RemoveRange(0, index + 1);

                        string json = Encoding.UTF8.GetString(packetBytes);
                        OnMessageReceived?.Invoke(json);
                    }
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        public async Task SendAsync(string jsonMessage)
        {
            if (!IsConnected) return;
            byte[] data = Encoding.UTF8.GetBytes(jsonMessage + "\n");
            await _socket!.SendAsync(data, SocketFlags.None);
        }

        public void Disconnect()
        {
            try
            {
                _socket?.Close();
                _socket = null;
                _dataBuffer.Clear();
                OnDisconnected?.Invoke("Disconnected.");
            }
            catch { }
        }
    }
}