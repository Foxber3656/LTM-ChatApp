namespace ChatServer
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            gbBroadCast = new GroupBox();
            cbTarget = new ComboBox();
            cbTypeSend = new ComboBox();
<<<<<<< HEAD
            txbBroadcast = new TextBox();
=======
            textBox2 = new TextBox();
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            btnSend = new Button();
            btnCancel = new Button();
            label6 = new Label();
            label5 = new Label();
<<<<<<< HEAD
            gbUserManagement = new GroupBox();
=======
            groupBox1 = new GroupBox();
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            cbSelectedUser = new ComboBox();
            btnView = new Button();
            btnKick = new Button();
            lbSelcetdUserTile = new Label();
            lbUserSTatus = new Label();
            label4 = new Label();
<<<<<<< HEAD
            gbSystem = new GroupBox();
            tvSystem = new TreeView();
=======
            gbUser = new GroupBox();
            lstOnlineUsers = new ListBox();
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            gbLog = new GroupBox();
            rtbLogs = new RichTextBox();
            panel2 = new Panel();
            txbIPAddress = new TextBox();
            btnStop = new Button();
            btnStart = new Button();
            nbPort = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            lbTitle = new Label();
            statusStrip1 = new StatusStrip();
            tsStatusServer = new ToolStripStatusLabel();
<<<<<<< HEAD
            tsPort = new ToolStripStatusLabel();
=======
            toolStripStatusLabel1 = new ToolStripStatusLabel();
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            tsUsers = new ToolStripStatusLabel();
            tsMessages = new ToolStripStatusLabel();
            tsGroups = new ToolStripStatusLabel();
            tsTime = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            gbBroadCast.SuspendLayout();
<<<<<<< HEAD
            gbUserManagement.SuspendLayout();
            gbSystem.SuspendLayout();
=======
            groupBox1.SuspendLayout();
            gbUser.SuspendLayout();
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            gbLog.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nbPort).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(gbBroadCast);
<<<<<<< HEAD
            panel1.Controls.Add(gbUserManagement);
            panel1.Controls.Add(gbSystem);
=======
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(gbUser);
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            panel1.Controls.Add(gbLog);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lbTitle);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1368, 743);
            panel1.TabIndex = 1;
            // 
            // gbBroadCast
            // 
            gbBroadCast.Controls.Add(cbTarget);
            gbBroadCast.Controls.Add(cbTypeSend);
<<<<<<< HEAD
            gbBroadCast.Controls.Add(txbBroadcast);
=======
            gbBroadCast.Controls.Add(textBox2);
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            gbBroadCast.Controls.Add(btnSend);
            gbBroadCast.Controls.Add(btnCancel);
            gbBroadCast.Controls.Add(label6);
            gbBroadCast.Controls.Add(label5);
            gbBroadCast.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbBroadCast.Location = new Point(9, 544);
            gbBroadCast.Name = "gbBroadCast";
            gbBroadCast.Size = new Size(1356, 196);
            gbBroadCast.TabIndex = 3;
            gbBroadCast.TabStop = false;
            gbBroadCast.Text = "BROADCAST";
            // 
            // cbTarget
            // 
            cbTarget.FormattingEnabled = true;
<<<<<<< HEAD
            cbTarget.Items.AddRange(new object[] { "" });
=======
            cbTarget.Items.AddRange(new object[] { "ALL", "PRIVATE", "GROUP" });
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            cbTarget.Location = new Point(462, 140);
            cbTarget.Name = "cbTarget";
            cbTarget.Size = new Size(240, 40);
            cbTarget.TabIndex = 1;
            cbTarget.Text = "None";
            // 
            // cbTypeSend
            // 
            cbTypeSend.FormattingEnabled = true;
            cbTypeSend.Items.AddRange(new object[] { "ALL", "PRIVATE", "GROUP" });
            cbTypeSend.Location = new Point(85, 137);
            cbTypeSend.Name = "cbTypeSend";
            cbTypeSend.Size = new Size(240, 40);
            cbTypeSend.TabIndex = 1;
            cbTypeSend.Text = "None";
            // 
<<<<<<< HEAD
            // txbBroadcast
            // 
            txbBroadcast.Cursor = Cursors.IBeam;
            txbBroadcast.Location = new Point(9, 38);
            txbBroadcast.Multiline = true;
            txbBroadcast.Name = "txbBroadcast";
            txbBroadcast.Size = new Size(1344, 79);
            txbBroadcast.TabIndex = 0;
=======
            // textBox2
            // 
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Location = new Point(9, 38);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(1344, 79);
            textBox2.TabIndex = 0;
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(903, 123);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(219, 62);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            btnSend.Click += btnSend_Click;
=======
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(1128, 123);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(219, 62);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            btnCancel.Click += btnCancel_Click;
=======
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(372, 145);
            label6.Name = "label6";
            label6.Size = new Size(84, 32);
            label6.TabIndex = 0;
            label6.Text = "Targer:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 140);
            label5.Name = "label5";
            label5.Size = new Size(70, 32);
            label5.TabIndex = 0;
            label5.Text = "Type:";
            // 
<<<<<<< HEAD
            // gbUserManagement
            // 
            gbUserManagement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gbUserManagement.Controls.Add(cbSelectedUser);
            gbUserManagement.Controls.Add(btnView);
            gbUserManagement.Controls.Add(btnKick);
            gbUserManagement.Controls.Add(lbSelcetdUserTile);
            gbUserManagement.Controls.Add(lbUserSTatus);
            gbUserManagement.Controls.Add(label4);
            gbUserManagement.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbUserManagement.Location = new Point(939, 191);
            gbUserManagement.Name = "gbUserManagement";
            gbUserManagement.Size = new Size(423, 350);
            gbUserManagement.TabIndex = 2;
            gbUserManagement.TabStop = false;
            gbUserManagement.Text = "USER MANAGEMENT";
=======
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(cbSelectedUser);
            groupBox1.Controls.Add(btnView);
            groupBox1.Controls.Add(btnKick);
            groupBox1.Controls.Add(lbSelcetdUserTile);
            groupBox1.Controls.Add(lbUserSTatus);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(939, 191);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(423, 350);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "USER MANAGEMENT";
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // cbSelectedUser
            // 
            cbSelectedUser.FormattingEnabled = true;
            cbSelectedUser.Location = new Point(176, 38);
            cbSelectedUser.Name = "cbSelectedUser";
            cbSelectedUser.Size = new Size(240, 40);
            cbSelectedUser.TabIndex = 1;
            cbSelectedUser.Text = "None";
            // 
            // btnView
            // 
            btnView.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnView.Location = new Point(18, 141);
            btnView.Name = "btnView";
            btnView.Size = new Size(196, 62);
            btnView.TabIndex = 2;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            btnView.Click += btnView_Click;
=======
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // btnKick
            // 
            btnKick.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKick.Location = new Point(220, 141);
            btnKick.Name = "btnKick";
            btnKick.Size = new Size(196, 62);
            btnKick.TabIndex = 2;
            btnKick.Text = "Kick";
            btnKick.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            btnKick.Click += btnKick_Click;
=======
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // lbSelcetdUserTile
            // 
            lbSelcetdUserTile.AutoSize = true;
            lbSelcetdUserTile.Location = new Point(6, 41);
            lbSelcetdUserTile.Name = "lbSelcetdUserTile";
            lbSelcetdUserTile.Size = new Size(164, 32);
            lbSelcetdUserTile.TabIndex = 0;
            lbSelcetdUserTile.Text = "Selected User:";
            // 
            // lbUserSTatus
            // 
            lbUserSTatus.Anchor = AnchorStyles.Left;
            lbUserSTatus.AutoSize = true;
            lbUserSTatus.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserSTatus.Location = new Point(103, 91);
            lbUserSTatus.Name = "lbUserSTatus";
            lbUserSTatus.Size = new Size(115, 32);
            lbUserSTatus.TabIndex = 0;
            lbUserSTatus.Text = "● Offline";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 91);
            label4.Name = "label4";
            label4.Size = new Size(91, 32);
            label4.TabIndex = 0;
            label4.Text = "Status :";
            // 
<<<<<<< HEAD
            // gbSystem
            // 
            gbSystem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gbSystem.Controls.Add(tvSystem);
            gbSystem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbSystem.Location = new Point(6, 191);
            gbSystem.Name = "gbSystem";
            gbSystem.Size = new Size(300, 350);
            gbSystem.TabIndex = 2;
            gbSystem.TabStop = false;
            gbSystem.Text = "OVERVIEW";
            // 
            // tvSystem
            // 
            tvSystem.FullRowSelect = true;
            tvSystem.HideSelection = false;
            tvSystem.Location = new Point(3, 35);
            tvSystem.Name = "tvSystem";
            tvSystem.Size = new Size(291, 309);
            tvSystem.TabIndex = 0;
=======
            // gbUser
            // 
            gbUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gbUser.Controls.Add(lstOnlineUsers);
            gbUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbUser.Location = new Point(6, 191);
            gbUser.Name = "gbUser";
            gbUser.Size = new Size(300, 350);
            gbUser.TabIndex = 2;
            gbUser.TabStop = false;
            gbUser.Text = "ONLINE USERS";
            // 
            // lstOnlineUsers
            // 
            lstOnlineUsers.Dock = DockStyle.Fill;
            lstOnlineUsers.FormattingEnabled = true;
            lstOnlineUsers.Location = new Point(3, 35);
            lstOnlineUsers.Name = "lstOnlineUsers";
            lstOnlineUsers.Size = new Size(294, 312);
            lstOnlineUsers.TabIndex = 0;
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // gbLog
            // 
            gbLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbLog.Controls.Add(rtbLogs);
            gbLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbLog.Location = new Point(312, 191);
            gbLog.Name = "gbLog";
            gbLog.Size = new Size(621, 350);
            gbLog.TabIndex = 2;
            gbLog.TabStop = false;
            gbLog.Text = "SYSTEM LOGS";
            // 
            // rtbLogs
            // 
            rtbLogs.Dock = DockStyle.Fill;
            rtbLogs.Location = new Point(3, 35);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.ReadOnly = true;
            rtbLogs.Size = new Size(615, 312);
            rtbLogs.TabIndex = 0;
            rtbLogs.Text = "";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoSize = true;
            panel2.Controls.Add(txbIPAddress);
            panel2.Controls.Add(btnStop);
            panel2.Controls.Add(btnStart);
            panel2.Controls.Add(nbPort);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(6, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(1356, 118);
            panel2.TabIndex = 1;
            // 
            // txbIPAddress
            // 
            txbIPAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbIPAddress.Location = new Point(150, 39);
            txbIPAddress.Name = "txbIPAddress";
            txbIPAddress.Size = new Size(199, 39);
            txbIPAddress.TabIndex = 3;
            txbIPAddress.Text = "127.0.0.1";
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStop.Location = new Point(1119, 30);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(216, 62);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(884, 30);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(219, 62);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // nbPort
            // 
            nbPort.Anchor = AnchorStyles.None;
            nbPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nbPort.Location = new Point(430, 40);
            nbPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nbPort.Name = "nbPort";
            nbPort.Size = new Size(194, 39);
            nbPort.TabIndex = 1;
            nbPort.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(136, 32);
            label2.TabIndex = 0;
            label2.Text = "IP Address :";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(355, 42);
            label3.Name = "label3";
            label3.Size = new Size(69, 32);
            label3.TabIndex = 0;
            label3.Text = "Port :";
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbTitle.BackColor = Color.FromArgb(255, 255, 192);
            lbTitle.FlatStyle = FlatStyle.Flat;
            lbTitle.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(6, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(1359, 64);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "CHAT SERVER DASHBOARD";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.LemonChiffon;
            statusStrip1.ImageScalingSize = new Size(24, 24);
<<<<<<< HEAD
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsStatusServer, tsPort, tsUsers, tsMessages, tsGroups, tsTime });
=======
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsStatusServer, toolStripStatusLabel1, tsUsers, tsMessages, tsGroups, tsTime });
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            statusStrip1.Location = new Point(0, 758);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1380, 39);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusServer
            // 
            tsStatusServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsStatusServer.Name = "tsStatusServer";
            tsStatusServer.Padding = new Padding(0, 0, 10, 0);
            tsStatusServer.Size = new Size(198, 32);
            tsStatusServer.Text = "Server: ● Offline";
            // 
<<<<<<< HEAD
            // tsPort
            // 
            tsPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsPort.Name = "tsPort";
            tsPort.Padding = new Padding(0, 0, 50, 0);
            tsPort.Size = new Size(170, 32);
            tsPort.Text = "Port: 5000";
=======
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Padding = new Padding(0, 0, 50, 0);
            toolStripStatusLabel1.Size = new Size(170, 32);
            toolStripStatusLabel1.Text = "Port: 5000";
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            // 
            // tsUsers
            // 
            tsUsers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsUsers.Name = "tsUsers";
            tsUsers.Padding = new Padding(0, 0, 50, 0);
            tsUsers.Size = new Size(146, 32);
            tsUsers.Text = "Users: 0";
            // 
            // tsMessages
            // 
            tsMessages.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsMessages.Name = "tsMessages";
            tsMessages.Padding = new Padding(0, 0, 50, 0);
            tsMessages.Size = new Size(193, 32);
            tsMessages.Text = "Messages: 0";
            // 
            // tsGroups
            // 
            tsGroups.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsGroups.Name = "tsGroups";
            tsGroups.Padding = new Padding(0, 0, 50, 0);
            tsGroups.Size = new Size(165, 32);
            tsGroups.Text = "Groups: 0";
            // 
            // tsTime
            // 
            tsTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsTime.ForeColor = Color.Black;
            tsTime.Name = "tsTime";
            tsTime.Padding = new Padding(0, 0, 50, 0);
            tsTime.Size = new Size(121, 32);
            tsTime.Text = "00:00";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
<<<<<<< HEAD
            BackColor = Color.White;
=======
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            ClientSize = new Size(1380, 797);
            Controls.Add(statusStrip1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat Server";
<<<<<<< HEAD
            Load += ServerForm_Load;
=======
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gbBroadCast.ResumeLayout(false);
            gbBroadCast.PerformLayout();
<<<<<<< HEAD
            gbUserManagement.ResumeLayout(false);
            gbUserManagement.PerformLayout();
            gbSystem.ResumeLayout(false);
=======
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbUser.ResumeLayout(false);
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
            gbLog.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nbPort).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label lbTitle;
        private Panel panel2;
        private Button btnStop;
        private Button btnStart;
        private NumericUpDown nbPort;
        private Label label3;
        private GroupBox gbLog;
<<<<<<< HEAD
        private GroupBox gbSystem;
=======
        private GroupBox gbUser;
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsStatusServer;
        private ToolStripStatusLabel tsUsers;
        private ToolStripStatusLabel tsMessages;
        private ToolStripStatusLabel tsGroups;
        private ToolStripStatusLabel tsTime;
        private Label label2;
<<<<<<< HEAD
        private RichTextBox rtbLogs;
        private GroupBox gbBroadCast;
        private TextBox txbBroadcast;
        private Button btnSend;
        private Button btnCancel;
        private GroupBox gbUserManagement;
=======
        private ListBox lstOnlineUsers;
        private RichTextBox rtbLogs;
        private GroupBox gbBroadCast;
        private TextBox textBox2;
        private Button btnSend;
        private Button btnCancel;
        private GroupBox groupBox1;
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
        private Label lbSelcetdUserTile;
        private ComboBox cbSelectedUser;
        private Button btnKick;
        private Label lbUserSTatus;
        private Label label4;
        private ComboBox cbTypeSend;
        private Label label5;
        private Button btnView;
        private ComboBox cbTarget;
        private Label label6;
        private TextBox txbIPAddress;
<<<<<<< HEAD
        private ToolStripStatusLabel tsPort;
        private TreeView tvSystem;
=======
        private ToolStripStatusLabel toolStripStatusLabel1;
>>>>>>> c9586379bdf71fa3ea0837fe1bad7b2ba3c4486d
    }
}
