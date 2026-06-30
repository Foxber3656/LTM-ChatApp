namespace ChatClient
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lbTitle = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            btnScan = new Button();
            cbServer = new ComboBox();
            nbPort = new NumericUpDown();
            label2 = new Label();
            txbIP = new TextBox();
            lblAvailableServers = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnRegister = new Button();
            btnLogin = new Button();
            chkRemeber = new CheckBox();
            txbPassword = new TextBox();
            txbUsername = new TextBox();
            Password = new Label();
            label7 = new Label();
            label5 = new Label();
            statusStrip1 = new StatusStrip();
            tsStatus = new ToolStripStatusLabel();
            bindingSource1 = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nbPort).BeginInit();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbTitle.BackColor = Color.FromArgb(255, 255, 192);
            lbTitle.FlatStyle = FlatStyle.Flat;
            lbTitle.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(12, 9);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(878, 64);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "CHAT APP CLIENT";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnScan);
            groupBox1.Controls.Add(cbServer);
            groupBox1.Controls.Add(nbPort);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txbIP);
            groupBox1.Controls.Add(lblAvailableServers);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(13, 91);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(423, 505);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "CONNECTION";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 212);
            label6.Name = "label6";
            label6.Size = new Size(250, 28);
            label6.TabIndex = 5;
            label6.Text = "Need help finding a server?";
            // 
            // btnScan
            // 
            btnScan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnScan.Location = new Point(111, 250);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(181, 52);
            btnScan.TabIndex = 4;
            btnScan.Text = "Scan Server";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // cbServer
            // 
            cbServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbServer.FormattingEnabled = true;
            cbServer.Location = new Point(17, 350);
            cbServer.Name = "cbServer";
            cbServer.Size = new Size(400, 40);
            cbServer.TabIndex = 3;
            cbServer.SelectedIndexChanged += cbServer_SelectedIndexChanged;
            // 
            // nbPort
            // 
            nbPort.Anchor = AnchorStyles.None;
            nbPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nbPort.Location = new Point(17, 163);
            nbPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nbPort.Name = "nbPort";
            nbPort.Size = new Size(400, 39);
            nbPort.TabIndex = 2;
            nbPort.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 128);
            label2.Name = "label2";
            label2.Size = new Size(61, 32);
            label2.TabIndex = 0;
            label2.Text = "Port:";
            // 
            // txbIP
            // 
            txbIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbIP.Location = new Point(17, 80);
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(400, 39);
            txbIP.TabIndex = 1;
            txbIP.Text = "127.0.0.1";
            // 
            // lblAvailableServers
            // 
            lblAvailableServers.AutoSize = true;
            lblAvailableServers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAvailableServers.Location = new Point(23, 315);
            lblAvailableServers.Name = "lblAvailableServers";
            lblAvailableServers.Size = new Size(361, 32);
            lblAvailableServers.TabIndex = 0;
            lblAvailableServers.Text = "Available Servers: 0 server found";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 77);
            label3.Name = "label3";
            label3.Size = new Size(112, 32);
            label3.TabIndex = 0;
            label3.Text = "Server IP:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 45);
            label1.Name = "label1";
            label1.Size = new Size(112, 32);
            label1.TabIndex = 0;
            label1.Text = "Server IP:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRegister);
            groupBox2.Controls.Add(btnLogin);
            groupBox2.Controls.Add(chkRemeber);
            groupBox2.Controls.Add(txbPassword);
            groupBox2.Controls.Add(txbUsername);
            groupBox2.Controls.Add(Password);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(442, 91);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(449, 506);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "LOGIN";
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(129, 373);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(181, 52);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(129, 250);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(181, 52);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // chkRemeber
            // 
            chkRemeber.AutoSize = true;
            chkRemeber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkRemeber.Location = new Point(29, 208);
            chkRemeber.Name = "chkRemeber";
            chkRemeber.Size = new Size(165, 32);
            chkRemeber.TabIndex = 4;
            chkRemeber.Text = "Remember Me";
            chkRemeber.UseVisualStyleBackColor = true;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbPassword.Location = new Point(29, 163);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(400, 39);
            txbPassword.TabIndex = 3;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // txbUsername
            // 
            txbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbUsername.Location = new Point(29, 80);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(400, 39);
            txbUsername.TabIndex = 3;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Password.Location = new Point(29, 128);
            Password.Name = "Password";
            Password.Size = new Size(116, 32);
            Password.TabIndex = 2;
            Password.Text = "Password:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(48, 333);
            label7.Name = "label7";
            label7.Size = new Size(329, 28);
            label7.TabIndex = 2;
            label7.Text = "Don't have account, create one now!";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 45);
            label5.Name = "label5";
            label5.Size = new Size(121, 32);
            label5.TabIndex = 2;
            label5.Text = "Username";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsStatus });
            statusStrip1.Location = new Point(0, 599);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(902, 32);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            tsStatus.Name = "tsStatus";
            tsStatus.Size = new Size(122, 25);
            tsStatus.Tag = "";
            tsStatus.Text = "Status : Ready";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 631);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lbTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nbPort).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private TextBox txbIP;
        private NumericUpDown nbPort;
        private ComboBox cbServer;
        private Label lblAvailableServers;
        private Label label3;
        private Button btnScan;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsStatus;
        private Button btnRegister;
        private Button btnLogin;
        private CheckBox chkRemeber;
        private TextBox txbPassword;
        private TextBox txbUsername;
        private Label Password;
        private Label label7;
        private Label label5;
        private Label label6;
        private BindingSource bindingSource1;
    }
}