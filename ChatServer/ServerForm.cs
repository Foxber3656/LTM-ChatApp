using ChatServer.Network;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        private readonly TCPServer server = new();
        private readonly System.Windows.Forms.Timer timerClock = new();
        private readonly UDPDiscoveryServer discoveryServer = new();
        public ServerForm()
        {
            InitializeComponent();

            server.Onlog += AddLog;
            discoveryServer.OnLog += AddLog;
            server.OnUserListChanged += RefreshSystemTree;
            server.OnGroupListChanged += RefreshSystemTree;
            tvSystem.AfterSelect += tvSystem_AfterSelect;
            cbTypeSend.SelectedIndexChanged += cbTypeSend_SelectedIndexChanged;

            timerClock.Interval = 1000;
            timerClock.Tick += (s, e) =>
            {
                tsTime.Text = DateTime.Now.ToString("HH:mm:ss");
            };

            timerClock.Start();
        }
        #region methods
        private void AddLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddLog), message);
                return;
            }

            rtbLogs.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
            if (rtbLogs.Lines.Length > 500)
            {
                rtbLogs.Clear();
            }
        }
        //reload lại onl user
        private void RefreshSystemTree()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshSystemTree));
                return;
            }
            tvSystem.Nodes.Clear();
            TreeNode userRoot = new TreeNode($"Users ({server.OnlineCount})");

            foreach (string username in server.OnlineUsers)
            {
                userRoot.Nodes.Add(username);
            }
            TreeNode groupRoot = new TreeNode($"Groups ({server.GroupCount})");
            foreach (var group in server.Groups)
            {
                TreeNode groupNode = new TreeNode(group.Key);

                foreach (string member in group.Value)
                {
                    groupNode.Nodes.Add(member);
                }
                groupRoot.Nodes.Add(groupNode);
            }
            tvSystem.Nodes.Add(userRoot);
            tvSystem.Nodes.Add(groupRoot);

            userRoot.Expand();

            tsUsers.Text = $"Users: {server.OnlineCount}";
            tsGroups.Text = $"Groups: {server.GroupCount}";

            cbSelectedUser.Items.Clear();
            foreach (string user in server.OnlineUsers)
            {
                cbSelectedUser.Items.Add(user);
            }
            if (cbSelectedUser.Items.Count > 0)
            {
                cbSelectedUser.SelectedIndex = 0;
            }
        }

        private void tvSystem_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (server.OnlineUsers.Contains(e.Node.Text))
            {
                cbSelectedUser.Text = e.Node.Text;
                lbUserSTatus.Text = "● Online";
            }
            else if (server.GroupNames.Contains(e.Node.Text))
            {
                lbUserSTatus.Text = "● Group";
                cbSelectedUser.Text = e.Node.Text;
            }
        }
        private void cbTypeSend_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTarget.Items.Clear();
            switch (cbTypeSend.Text)
            {
                case "ALL":
                    cbTarget.Items.Add("ALL");
                    cbTarget.SelectedIndex = 0;
                    break;

                case "PRIVATE":
                    foreach (string user
                        in server.OnlineUsers)
                    {
                        cbTarget.Items.Add(user);
                    }

                    break;
                case "GROUP":
                    foreach (string group
                        in server.GroupNames)
                    {
                        cbTarget.Items.Add(group);
                    }
                    break;
            }
            if (cbTarget.Items.Count > 0)
            {
                cbTarget.SelectedIndex = 0;
            }
        }
        #endregion

        #region click
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (server.IsRunning)
                return;
            server.StartServer((int)nbPort.Value);
            discoveryServer.Start((int)nbPort.Value);

            tsStatusServer.Text = "Server: ● Online";
            tsPort.Text = $"Port: {nbPort.Value}";
            RefreshSystemTree();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!server.IsRunning)
                return;

            server.StopServer();
            discoveryServer.Stop();

            tsStatusServer.Text = "Server: ● Offline";
            RefreshSystemTree();
            tsUsers.Text = "Users: 0";
            tsGroups.Text = "Groups: 0";

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbBroadcast.Text))
                return;
            switch (cbTypeSend.Text)
            {
                case "ALL":
                    server.BroadcastMessage(txbBroadcast.Text);
                    break;

                case "PRIVATE":

                    if (cbTarget.SelectedItem == null)
                        return;

                    server.SendPrivateMessage(
                        cbTarget.Text,
                        txbBroadcast.Text);

                    break;

                case "GROUP":

                    if (cbTarget.SelectedItem == null)
                        return;

                    server.SendGroupMessage(
                        cbTarget.Text,
                        txbBroadcast.Text);

                    break;

                default:
                    MessageBox.Show("Vui lòng chọn Send Type.");
                    return;
            }
            txbBroadcast.Clear();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txbBroadcast.Clear();
            cbTypeSend.SelectedIndex = -1;
            cbTarget.SelectedIndex = -1;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbSelectedUser.SelectedItem == null)
                return;

            string username = cbSelectedUser.SelectedItem.ToString()!;

            if (server.OnlineUsers.Contains(username))
            {
                MessageBox.Show($"Username: {username}\nStatus: Online");
            }
            else if (server.GroupNames.Contains(username))
            {
                MessageBox.Show($"Group: {username}\nMembers: {server.Groups[username].Count}");
            }
        }
        private void btnKick_Click(object sender, EventArgs e)
        {
            if (cbSelectedUser.SelectedItem == null)
                return;

            string username =
                cbSelectedUser.SelectedItem.ToString()!;

            DialogResult result =
                MessageBox.Show(
                    $"Kick user {username} ?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                server.KickUser(username);
            }
        }
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server.IsRunning)
            {
                server.StopServer();
            }
        }
        #endregion

        #region load
        private void ServerForm_Load(object sender, EventArgs e)
        {
            RefreshSystemTree();
            tsTime.Text = DateTime.Now.ToString("HH:mm:ss");
            btnStop.Enabled = false;
            cbTypeSend.SelectedIndex = 0;
        }
        #endregion

    }
}
