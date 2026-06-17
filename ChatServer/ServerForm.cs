using ChatServer.Network;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            serverManager = new TCPServer();
            serverManager.Onlog += AddLog;
        }
        private TCPServer serverManager;

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
