using System;
using System.Windows.Forms;

namespace AuthForm
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string ip = textBox1.Text.Trim();
            string portText = textBox2.Text.Trim();
            string username = textBox4.Text.Trim();   // Email làm username
            string password = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(portText) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ (1-65535)!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ClientForm clientForm = new ClientForm(ip, port, username, password);
                this.Hide();
                clientForm.ShowDialog();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở Client: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            btnLogin.PerformClick();
        }
    }
}