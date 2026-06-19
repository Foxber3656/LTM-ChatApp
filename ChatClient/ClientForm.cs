using ChatClient.Network;
using ChatClient.Managers;
using ChatClient.Helpers;
using ChatApp_Shared.Packet;
using ChatApp_Shared.Enums;

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        private TCPClient _client;
        private AuthManager _auth;
        private ChatManager _chat;
        private string _currentUsername = "";

        public ClientForm()
        {
            InitializeComponent();

            _client = new TCPClient();
            _auth = new AuthManager(_client);
            _chat = new ChatManager(_client);

            _client.OnConnected += OnConnected;
            _client.OnMessageReceived += OnMessageReceived;
            _client.OnDisconnected += OnDisconnected;
            _client.OnError += OnError;

            panelChat.Visible = false;
        }

        #region Sự kiện từ TCPClient
        private void OnConnected()
        {
            AppendLog("Connected to server.");
        }

        private void OnDisconnected(string reason)
        {
            AppendLog($"Disconnected: {reason}");
            this.Invoke(() =>
            {
                panelLogin.Visible = true;
                panelChat.Visible = false;
                btnLogin.Enabled = true;
            });
        }

        private void OnError(string error)
        {
            AppendLog($"Error: {error}");
        }

        private void OnMessageReceived(string json)
        {
            var packet = PacketHelper.Deserialize(json);
            if (packet == null) return;

            switch (packet.Type)
            {
                case MessageType.Login:
                    if (packet.Content == "OK")
                    {
                        AppendLog("Login successful.");
                        this.Invoke(() =>
                        {
                            panelLogin.Visible = false;
                            panelChat.Visible = true;
                            btnLogin.Enabled = true;
                            // Yêu cầu danh sách online
                            _chat.RequestOnlineUsersAsync();
                        });
                    }
                    else
                    {
                        AppendLog($"Login failed: {packet.Content}");
                        this.Invoke(() => btnLogin.Enabled = true);
                    }
                    break;

                case MessageType.PrivateMessage:
                    AppendMessage("Private", packet.Content);
                    break;

                case MessageType.GroupMessage:
                    AppendMessage("Group", packet.Content);
                    break;

                case MessageType.OnlineUsers:
                    UpdateOnlineList(packet.Content);
                    break;

                case MessageType.ServerBroadcast:
                    AppendLog($"Broadcast: {packet.Content}");
                    break;

                default:
                    AppendLog($"Received: {packet.Type} - {packet.Content}");
                    break;
            }
        }
        #endregion

        #region UI Helpers
        private void AppendLog(string text)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => AppendLog(text)));
                return;
            }
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {text}\n");
        }

        private void AppendMessage(string from, string content)
        {
            if (rtbChat.InvokeRequired)
            {
                rtbChat.Invoke(new Action(() => AppendMessage(from, content)));
                return;
            }
            rtbChat.AppendText($"[{from}] {content}\n");
        }

        private void UpdateOnlineList(string data)
        {
            if (lstUsers.InvokeRequired)
            {
                lstUsers.Invoke(new Action(() => UpdateOnlineList(data)));
                return;
            }
            lstUsers.Items.Clear();
            if (!string.IsNullOrEmpty(data))
            {
                var users = data.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var u in users)
                    lstUsers.Items.Add(u.Trim());
            }
        }
        #endregion

        #region Sự kiện Button
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên và mật khẩu.");
                return;
            }

            _currentUsername = username;
            btnLogin.Enabled = false;

            string ip = txtIP.Text.Trim();
            int port = (int)nudPort.Value;

            await _client.ConnectAsync(ip, port);
            if (_client.IsConnected)
            {
                await _auth.LoginAsync(username, password);
            }
            else
            {
                AppendLog("Cannot connect to server.");
                btnLogin.Enabled = true;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            if (lstUsers.SelectedItem != null)
            {
                string target = lstUsers.SelectedItem.ToString();
                await _chat.SendPrivateMessageAsync(target, msg);
            }
            else
            {
                await _chat.SendPrivateMessageAsync("*", msg); // Broadcast
            }
            txtMessage.Clear();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Disconnect();
        }
        #endregion
    }
}