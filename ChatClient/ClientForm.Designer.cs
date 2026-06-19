namespace ChatClient
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            // Panel Login
            panelLogin = new Panel();
            labelIP = new Label();
            txtIP = new TextBox();
            labelPort = new Label();
            nudPort = new NumericUpDown();
            labelUser = new Label();
            txtUsername = new TextBox();
            labelPass = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();

            // Panel Chat
            panelChat = new Panel();
            rtbChat = new RichTextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            lstUsers = new ListBox();
            rtbLog = new RichTextBox();
            labelLog = new Label();

            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(labelIP);
            panelLogin.Controls.Add(txtIP);
            panelLogin.Controls.Add(labelPort);
            panelLogin.Controls.Add(nudPort);
            panelLogin.Controls.Add(labelUser);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(labelPass);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Location = new Point(12, 12);
            panelLogin.Size = new Size(360, 200);
            panelLogin.TabIndex = 0;

            // 
            // labelIP
            // 
            labelIP.AutoSize = true;
            labelIP.Location = new Point(20, 20);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(27, 15);
            labelIP.Text = "IP:";
            // Tương tự cho các label khác...

            // Vị trí các control (bạn có thể set tọa độ cụ thể)
            txtIP.Location = new Point(80, 17);
            txtIP.Size = new Size(150, 23);
            txtIP.Text = "127.0.0.1";

            labelPort.Location = new Point(20, 50);
            nudPort.Location = new Point(80, 47);
            nudPort.Maximum = 65535;
            nudPort.Value = 5000;

            labelUser.Location = new Point(20, 80);
            txtUsername.Location = new Point(80, 77);

            labelPass.Location = new Point(20, 110);
            txtPassword.Location = new Point(80, 107);
            txtPassword.PasswordChar = '*';

            btnLogin.Location = new Point(80, 140);
            btnLogin.Size = new Size(100, 30);
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;

            // 
            // panelChat
            // 
            panelChat.Controls.Add(rtbChat);
            panelChat.Controls.Add(txtMessage);
            panelChat.Controls.Add(btnSend);
            panelChat.Controls.Add(lstUsers);
            panelChat.Controls.Add(rtbLog);
            panelChat.Controls.Add(labelLog);
            panelChat.Location = new Point(12, 12);
            panelChat.Size = new Size(760, 450);
            panelChat.TabIndex = 1;
            panelChat.Visible = false;

            rtbChat.Location = new Point(10, 10);
            rtbChat.Size = new Size(540, 250);

            txtMessage.Location = new Point(10, 270);
            txtMessage.Size = new Size(440, 23);

            btnSend.Location = new Point(460, 268);
            btnSend.Size = new Size(90, 30);
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click;

            lstUsers.Location = new Point(560, 10);
            lstUsers.Size = new Size(180, 300);

            rtbLog.Location = new Point(10, 310);
            rtbLog.Size = new Size(730, 120);
            rtbLog.ReadOnly = true;

            labelLog.Text = "System Logs";
            labelLog.Location = new Point(10, 295);

            // 
            // ClientForm
            // 
            this.ClientSize = new Size(784, 481);
            this.Controls.Add(panelLogin);
            this.Controls.Add(panelChat);
            this.Text = "Chat Client";
            this.FormClosing += ClientForm_FormClosing;

            ResumeLayout(false);
        }
        #endregion

        // Khai báo các control để sử dụng trong ClientForm.cs
        private Panel panelLogin;
        private Panel panelChat;
        private Label labelIP, labelPort, labelUser, labelPass, labelLog;
        private TextBox txtIP, txtUsername, txtPassword, txtMessage;
        private NumericUpDown nudPort;
        private Button btnLogin, btnSend;
        private RichTextBox rtbChat, rtbLog;
        private ListBox lstUsers;
    }
}