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
using System.Text.Json;
using ChatClient.Network;


namespace ChatClient
{
    public partial class CreateGroupForm : Form
    {
        private readonly TCPClient client;
        private readonly string username;
        private readonly List<string> friends;

        public CreateGroupForm(TCPClient client, string username, List<string> friends)
        {
            InitializeComponent();

            this.client = client;
            this.username = username;
            this.friends = friends;
            Load += CreateGroupForm_Load;
        }
        private void CreateGroupForm_Load(object sender, EventArgs e)
        {
            clbMembers.Items.Clear();

            foreach (string user in friends)
            {
                if (user == username)
                    continue;

                clbMembers.Items.Add(user);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string groupName = txbGroupName.Text.Trim();

            if (string.IsNullOrWhiteSpace(groupName))
            {
                MessageBox.Show("Please enter group name.");
                return;
            }

            List<string> members = new();

            members.Add(username);

            foreach (object item in clbMembers.CheckedItems)
            {
                members.Add(item.ToString()!);
            }

            if (members.Count < 2)
            {
                MessageBox.Show(
                    "Select at least one member.");
                return;
            }

            MessagePacket packet = new()
            {
                Type = MessageType.CreateGroup,
                Sender = username,
                Receiver = groupName,
                Content = JsonSerializer.Serialize(members)
            };

            client.SendPacket(packet);

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
