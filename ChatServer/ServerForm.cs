using ChatServer.Network;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            server = new TCPServer();
            server.Onlog += AddLog;
        }
        #region methods
        private void AddLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddLog), message);
                return;
            }
            rtbLogs.AppendText(message + Environment.NewLine);
        }
        #endregion

        private TCPServer server;


        #region click
        private void btnStart_Click(object sender, EventArgs e)
        {
            server.StartServer(int.Parse(nbPort.Text));
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            server.StopServer();
        }
        #endregion
    }
}
