using ChatApp_Shared.DTOs;
using ChatApp_Shared.Enums;
using ChatClient.Network;
using ChatShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        private readonly TCPClient client = new();
        private readonly UDPDiscoveryClient discovery = new();
        private readonly List<ServerInfo> servers = new();
        public LoginForm()
        {
            InitializeComponent();
            client.OnLog += AddLog;
            discovery.OnLog += AddLog;
            client.OnDisconnected += ClientDisconnected;
            discovery.OnServerFound += Discovery_OnServerFound;
            client.OnPacketReceived += ProcessPacket;
        }
        #region menthods
        private void ClientDisconnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClientDisconnected));
                return;
            }

            btnLogin.Enabled = true;
            tsStatus.Text = "Status : Disconnected";
            MessageBox.Show("Disconnected from server.", "Network",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AddLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddLog), message);
                return;
            }

            tsStatus.Text = $"Status : {message}";
        }
        private void Discovery_OnServerFound(ServerInfo info)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<ServerInfo>(Discovery_OnServerFound), info);
                return;
            }

            if (servers.Any(x => x.IP == info.IP &&
                                 x.TcpPort == info.TcpPort))
                return;

            servers.Add(info);

            cbServer.Items.Add(info.ServerName);
            cbServer.Enabled = true;
            lblAvailableServers.Text = $"Available Servers: {servers.Count} server(s) found";
            AddLog($"Found {info.ServerName}");
        }
        #endregion

        #region Packet
        private void ProcessPacket(MessagePacket packet)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<MessagePacket>(ProcessPacket), packet);
                return;
            }

            switch (packet.Type)
            {
                case MessageType.Login:

                    if (packet.Content == "LOGIN_SUCCESS")
                    {
                        ChatForm chat = new ChatForm(client, txbUsername.Text.Trim());

                        chat.FormClosed += (s, e) =>
                        {
                            Show();
                            btnLogin.Enabled = true;
                            txbPassword.Clear();
                            txbPassword.Focus();
                        };
                        Hide();
                        chat.Show();
                    }
                    else if (packet.Content == "USERNAME_ALREADY_ONLINE")
                    {
                        MessageBox.Show( "Username is already online.");

                        btnLogin.Enabled = true;
                    }
                    else if (packet.Content == "USERNAME_NOT_FOUND")
                    {
                        MessageBox.Show("Username does not exist.");
                        btnLogin.Enabled = true;
                    }
                    else if (packet.Content == "INVALID_PASSWORD")
                    {
                        MessageBox.Show("Incorrect password.");
                        btnLogin.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(packet.Content);
                        btnLogin.Enabled = true;
                    }
                    break;
            }
        }

        #endregion
        #region click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbUsername.Text))
            {
                MessageBox.Show("Please enter username.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbPassword.Text))
            {
                MessageBox.Show("Please enter password.");
                return;
            }

            MessagePacket packet = new MessagePacket()
            {
                Type = MessageType.Login,
                Sender = txbUsername.Text.Trim(),
                Content = txbPassword.Text.Trim()
            };

            if (!client.IsConnected)
            {
                client.Connect(txbIP.Text.Trim(), (int)nbPort.Value);
            }

            if (!client.IsConnected)
            {
                MessageBox.Show("Cannot connect to server.");
                return;
            }

            client.SendPacket(packet);

            btnLogin.Enabled = false;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!client.IsConnected)
            {
                client.Connect(txbIP.Text.Trim(), (int)nbPort.Value);

                if (!client.IsConnected)
                {
                    MessageBox.Show("Cannot connect to server.");
                    return;
                }
            }

            using RegisterForm frm = new(client);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txbUsername.Text = frm.Username;
                txbPassword.Clear();
                txbPassword.Focus();
            }
        }
        private async void btnScan_Click(object sender, EventArgs e)
        {
            servers.Clear();
            cbServer.Items.Clear();
            cbServer.Enabled = false;
            lblAvailableServers.Text = "Available Servers: Scanning...";
            await Task.Run(() =>
            {
                discovery.Scan();
            });

            if (servers.Count == 0)
            {
                lblAvailableServers.Text =
                    "Available Servers: 0 server found";
            }
            else
            {
                lblAvailableServers.Text = $"Available Servers: {servers.Count} server(s) found";
            }
            if (cbServer.Items.Count > 0)
            {
                cbServer.SelectedIndex = 0;
            }
        }
        private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbServer.SelectedIndex < 0)
                return;

            ServerInfo server =
                servers[cbServer.SelectedIndex];

            txbIP.Text = server.IP;

            nbPort.Value = server.TcpPort;
        }
        #endregion

        #region Load
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txbIP.Text = "127.0.0.1";

            nbPort.Value = 5000;

            txbPassword.UseSystemPasswordChar = true;

            cbServer.Enabled = false;

            tsStatus.Text = "Status : Ready";
        }

        #endregion
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
        }
    }
}
