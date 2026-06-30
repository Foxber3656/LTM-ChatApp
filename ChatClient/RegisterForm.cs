using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatApp_Shared.DTOs;
using ChatApp_Shared.Enums;
using ChatClient.Network;

namespace ChatClient
{
    public partial class RegisterForm : Form
    {
        private readonly TCPClient client;
        public RegisterForm(TCPClient client)
        {
            InitializeComponent();

            this.client = client;
            client.OnPacketReceived += ProcessPacket;
            txbPassword.UseSystemPasswordChar = true;
            txbConfPassword.UseSystemPasswordChar = true;
        }
        public string Username
        {
            get
            {
                return txbUsername.Text.Trim();
            }
        }
        private void ProcessPacket(MessagePacket packet)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<MessagePacket>(ProcessPacket), packet);
                return;
            }

            if (packet.Type != MessageType.Register)
                return;

            switch (packet.Content)
            {
                case "REGISTER_SUCCESS":
                    MessageBox.Show("Register successful.");
                    DialogResult = DialogResult.OK;
                    Close();
                    break;

                case "USERNAME_EXISTS":
                    MessageBox.Show("Username already exists.");
                    btnRegister.Enabled = true;
                    txbUsername.Focus();
                    break;
                default:
                    MessageBox.Show(packet.Content);
                    btnRegister.Enabled = true;
                    break;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text.Trim();
            string password = txbPassword.Text;
            string confirmPassword = txbConfPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter username.");
                txbUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter password.");
                txbPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Confirm password does not match.");
                txbConfPassword.Clear();
                txbConfPassword.Focus();
                return;
            }

            MessagePacket packet = new()
            {
                Type = MessageType.Register,
                Sender = username,
                Content = password
            };

            client.SendPacket(packet);
            btnRegister.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txbUsername.Focus();
        }
        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.OnPacketReceived -= ProcessPacket;
        }
    }
}
