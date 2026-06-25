using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace AuthForm
{
    public partial class ClientForm : Form
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private Thread? _receiveThread;
        private bool _isConnected = false;
        private string _username;
        private string _password;
        private string _serverIp;
        private int _serverPort;

        public ClientForm(string ip, int port, string username, string password)
        {
            InitializeComponent();
            _serverIp = ip;
            _serverPort = port;
            _username = username;
            _password = password;
            this.Load += ClientForm_Load;
        }

        private async void ClientForm_Load(object? sender, EventArgs e)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(_serverIp, _serverPort);
                _stream = _client.GetStream();
                _isConnected = true;

                _receiveThread = new Thread(ReceiveDataLoop) { IsBackground = true };
                _receiveThread.Start();

                var loginData = new
                {
                    Type = "Login",
                    Username = _username,
                    Password = _password,
                    Timestamp = DateTime.Now
                };
                SendData(loginData);

                AppendLog("Hệ thống", $"Kết nối thành công! Nick: {_username}");
                this.Text = $"Chat Client - [{_username}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối tới server: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSend_Click(object? sender, EventArgs e)
        {
            SendMessageToServer();
        }

        private void txtMessage_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessageToServer();
            }
        }

        private void ClientForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            DisconnectFromServer();
        }

        private void SendMessageToServer()
        {
            string content = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(content)) return;

            var msgPacket = new
            {
                Type = "Message",
                Sender = _username,
                Content = content,
                Timestamp = DateTime.Now
            };

            SendData(msgPacket);
            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void SendData(object payload)
        {
            if (!_isConnected || _stream == null) return;

            try
            {
                string jsonString = JsonSerializer.Serialize(payload);
                byte[] dataBytes = Encoding.UTF8.GetBytes(jsonString + "\n");
                _stream.Write(dataBytes, 0, dataBytes.Length);
                _stream.Flush();
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi Gửi", ex.Message);
            }
        }

        private void ReceiveDataLoop()
        {
            if (_stream == null) return;

            using (StreamReader reader = new StreamReader(_stream, Encoding.UTF8))
            {
                while (_isConnected)
                {
                    try
                    {
                        string? jsonRow = reader.ReadLine();
                        if (jsonRow == null)
                        {
                            InvokeHandleDisconnect();
                            break;
                        }

                        Invoke(new Action(() => ProcessServerMessage(jsonRow)));
                    }
                    catch
                    {
                        InvokeHandleDisconnect();
                        break;
                    }
                }
            }
        }

        private void ProcessServerMessage(string rawJson)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(rawJson))
                {
                    JsonElement root = doc.RootElement;
                    if (root.TryGetProperty("Type", out JsonElement typeProp))
                    {
                        string msgType = typeProp.GetString() ?? "";

                        switch (msgType)
                        {
                            case "Message":
                                string sender = root.GetProperty("Sender").GetString() ?? "unknown";
                                string content = root.GetProperty("Content").GetString() ?? "";
                                AppendChatMessage(sender, content);
                                break;

                            case "UserList":
                                if (root.TryGetProperty("Users", out JsonElement usersProp))
                                {
                                    lstUsers.Items.Clear();
                                    foreach (var user in usersProp.EnumerateArray())
                                    {
                                        string? userName = user.GetString();
                                        lstUsers.Items.Add(userName ?? "(unknown)");
                                    }
                                }
                                break;

                            case "System":
                                string sysMsg = root.GetProperty("Content").GetString() ?? "";
                                AppendLog("Hệ thống", sysMsg);
                                break;

                            default:
                                AppendLog("Raw Data", rawJson);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AppendLog("Lỗi Parse", $"Không thể xử lý gói tin: {ex.Message}");
            }
        }

        private void InvokeHandleDisconnect()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(InvokeHandleDisconnect));
                return;
            }

            _isConnected = false;
            MessageBox.Show("Đã mất kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisconnectFromServer()
        {
            if (!_isConnected) return;

            try
            {
                SendData(new { Type = "Logout", Username = _username });
                _isConnected = false;
                _stream?.Close();
                _client?.Close();
            }
            catch { }
        }

        private void AppendChatMessage(string sender, string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;

            if (sender == _username)
            {
                rtbChat.SelectionColor = Color.Blue;
                rtbChat.AppendText($"[{timestamp}] Bạn: {message}\r\n");
            }
            else
            {
                rtbChat.SelectionColor = Color.Green;
                rtbChat.AppendText($"[{timestamp}] {sender}: {message}\r\n");
            }
            rtbChat.ScrollToCaret();
        }

        private void AppendLog(string tag, string text)
        {
            if (rtbLog.IsDisposed) return;
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] <{tag}> {text}\r\n");
            rtbLog.ScrollToCaret();
        }
    }
}