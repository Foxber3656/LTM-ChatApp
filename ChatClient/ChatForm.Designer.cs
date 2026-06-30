namespace ChatClient
{
    partial class ChatForm
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
            TreeNode treeNode1 = new TreeNode("Friends");
            TreeNode treeNode2 = new TreeNode("Nearby");
            TreeNode treeNode3 = new TreeNode("Groups");
            panel1 = new Panel();
            btnMenu = new Button();
            label1 = new Label();
            lblServer = new Label();
            spMain = new SplitContainer();
            spLeftCenter = new SplitContainer();
            gbContacts = new GroupBox();
            tvContacts = new TreeView();
            panel3 = new Panel();
            txbSreach = new TextBox();
            btnClear = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            btnSreach = new Button();
            lblTyping = new Label();
            rtbChat = new RichTextBox();
            tabInfo = new TabControl();
            tabInformation = new TabPage();
            groupBox2 = new GroupBox();
            lblUnread = new Label();
            lblTotalMessages = new Label();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            lblIP = new Label();
            lblLastSeen = new Label();
            lblPort = new Label();
            lblType = new Label();
            lblStatus = new Label();
            lblUsername = new Label();
            tabFiles = new TabPage();
            lstFiles = new ListBox();
            panel2 = new Panel();
            txbMessage = new TextBox();
            btnPicture = new Button();
            btnFile = new Button();
            btnSend = new Button();
            btnEmoji = new Button();
            statusStrip1 = new StatusStrip();
            tsStatus = new ToolStripStatusLabel();
            tsUser = new ToolStripStatusLabel();
            tsServer = new ToolStripStatusLabel();
            tsOnline = new ToolStripStatusLabel();
            tsTime = new ToolStripStatusLabel();
            tslTyping = new ToolStripStatusLabel();
            cmsMenu = new ContextMenuStrip(components);
            createGroupToolStripMenuItem = new ToolStripMenuItem();
            scanServerToolStripMenuItem = new ToolStripMenuItem();
            recallToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spMain).BeginInit();
            spMain.Panel1.SuspendLayout();
            spMain.Panel2.SuspendLayout();
            spMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spLeftCenter).BeginInit();
            spLeftCenter.Panel1.SuspendLayout();
            spLeftCenter.Panel2.SuspendLayout();
            spLeftCenter.SuspendLayout();
            gbContacts.SuspendLayout();
            panel3.SuspendLayout();
            tabInfo.SuspendLayout();
            tabInformation.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabFiles.SuspendLayout();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblServer);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1379, 54);
            panel1.TabIndex = 1;
            // 
            // btnMenu
            // 
            btnMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.Location = new Point(1255, 6);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(112, 42);
            btnMenu.TabIndex = 1;
            btnMenu.Text = "Menu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(1052, 11);
            label1.Name = "label1";
            label1.Size = new Size(158, 32);
            label1.TabIndex = 0;
            label1.Text = "● Connected";
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServer.Location = new Point(562, 9);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(245, 30);
            lblServer.TabIndex = 0;
            lblServer.Text = "Server : 127.0.0.1 : 5000";
            // 
            // spMain
            // 
            spMain.Location = new Point(0, 54);
            spMain.Name = "spMain";
            // 
            // spMain.Panel1
            // 
            spMain.Panel1.Controls.Add(spLeftCenter);
            // 
            // spMain.Panel2
            // 
            spMain.Panel2.Controls.Add(tabInfo);
            spMain.Size = new Size(1379, 555);
            spMain.SplitterDistance = 1062;
            spMain.TabIndex = 2;
            // 
            // spLeftCenter
            // 
            spLeftCenter.Dock = DockStyle.Fill;
            spLeftCenter.Location = new Point(0, 0);
            spLeftCenter.Name = "spLeftCenter";
            // 
            // spLeftCenter.Panel1
            // 
            spLeftCenter.Panel1.Controls.Add(gbContacts);
            // 
            // spLeftCenter.Panel2
            // 
            spLeftCenter.Panel2.Controls.Add(panel3);
            spLeftCenter.Panel2.Controls.Add(lblTyping);
            spLeftCenter.Panel2.Controls.Add(rtbChat);
            spLeftCenter.Size = new Size(1062, 555);
            spLeftCenter.SplitterDistance = 328;
            spLeftCenter.TabIndex = 0;
            // 
            // gbContacts
            // 
            gbContacts.Controls.Add(tvContacts);
            gbContacts.Dock = DockStyle.Fill;
            gbContacts.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbContacts.Location = new Point(0, 0);
            gbContacts.Name = "gbContacts";
            gbContacts.Size = new Size(328, 555);
            gbContacts.TabIndex = 0;
            gbContacts.TabStop = false;
            gbContacts.Text = "Contacts";
            // 
            // tvContacts
            // 
            tvContacts.Dock = DockStyle.Fill;
            tvContacts.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tvContacts.Location = new Point(3, 35);
            tvContacts.Name = "tvContacts";
            treeNode1.Name = "Friends";
            treeNode1.Text = "Friends";
            treeNode2.Name = "Nearby";
            treeNode2.Text = "Nearby";
            treeNode3.Name = "Groups";
            treeNode3.Text = "Groups";
            tvContacts.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            tvContacts.Size = new Size(322, 517);
            tvContacts.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(txbSreach);
            panel3.Controls.Add(btnClear);
            panel3.Controls.Add(btnPrev);
            panel3.Controls.Add(btnNext);
            panel3.Controls.Add(btnSreach);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(730, 58);
            panel3.TabIndex = 4;
            // 
            // txbSreach
            // 
            txbSreach.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbSreach.Location = new Point(61, 10);
            txbSreach.Name = "txbSreach";
            txbSreach.Size = new Size(373, 37);
            txbSreach.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(614, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 40);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnPrev
            // 
            btnPrev.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrev.Location = new Point(11, 7);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(46, 40);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(440, 10);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(46, 40);
            btnNext.TabIndex = 1;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnSreach
            // 
            btnSreach.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSreach.Location = new Point(496, 10);
            btnSreach.Name = "btnSreach";
            btnSreach.Size = new Size(112, 40);
            btnSreach.TabIndex = 1;
            btnSreach.Text = "Sreach";
            btnSreach.UseVisualStyleBackColor = true;
            btnSreach.Click += btnSreach_Click;
            // 
            // lblTyping
            // 
            lblTyping.AutoSize = true;
            lblTyping.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTyping.ForeColor = Color.Silver;
            lblTyping.Location = new Point(662, 513);
            lblTyping.Name = "lblTyping";
            lblTyping.Size = new Size(32, 32);
            lblTyping.TabIndex = 3;
            lblTyping.Text = "\"\"";
            lblTyping.Visible = false;
            lblTyping.TextChanged += txbMessage_TextChanged;
            // 
            // rtbChat
            // 
            rtbChat.BackColor = Color.WhiteSmoke;
            rtbChat.BorderStyle = BorderStyle.None;
            rtbChat.Dock = DockStyle.Fill;
            rtbChat.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbChat.Location = new Point(0, 0);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.Size = new Size(730, 555);
            rtbChat.TabIndex = 0;
            rtbChat.Text = "";
            rtbChat.TextChanged += txbMessage_TextChanged;
            // 
            // tabInfo
            // 
            tabInfo.Controls.Add(tabInformation);
            tabInfo.Controls.Add(tabFiles);
            tabInfo.Dock = DockStyle.Fill;
            tabInfo.Location = new Point(0, 0);
            tabInfo.Name = "tabInfo";
            tabInfo.SelectedIndex = 0;
            tabInfo.Size = new Size(313, 555);
            tabInfo.TabIndex = 0;
            // 
            // tabInformation
            // 
            tabInformation.Controls.Add(groupBox2);
            tabInformation.Controls.Add(groupBox1);
            tabInformation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabInformation.Location = new Point(4, 34);
            tabInformation.Name = "tabInformation";
            tabInformation.Padding = new Padding(3);
            tabInformation.Size = new Size(305, 517);
            tabInformation.TabIndex = 0;
            tabInformation.Text = "Information";
            tabInformation.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblUnread);
            groupBox2.Controls.Add(lblTotalMessages);
            groupBox2.Location = new Point(7, 376);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(290, 135);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Conversation";
            // 
            // lblUnread
            // 
            lblUnread.AutoSize = true;
            lblUnread.Location = new Point(12, 88);
            lblUnread.Name = "lblUnread";
            lblUnread.Size = new Size(116, 32);
            lblUnread.TabIndex = 2;
            lblUnread.Text = "Unread: 2";
            // 
            // lblTotalMessages
            // 
            lblTotalMessages.AutoSize = true;
            lblTotalMessages.Location = new Point(12, 44);
            lblTotalMessages.Name = "lblTotalMessages";
            lblTotalMessages.Size = new Size(214, 32);
            lblTotalMessages.TabIndex = 3;
            lblTotalMessages.Text = "Total Messages: 25";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(lblIP);
            groupBox1.Controls.Add(lblLastSeen);
            groupBox1.Controls.Add(lblPort);
            groupBox1.Controls.Add(lblType);
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Location = new Point(7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 371);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Profile";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(13, 57);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 70);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Location = new Point(9, 166);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(184, 32);
            lblIP.TabIndex = 3;
            lblIP.Text = "IP: 192.168.1.20 ";
            // 
            // lblLastSeen
            // 
            lblLastSeen.AutoSize = true;
            lblLastSeen.Location = new Point(13, 251);
            lblLastSeen.Name = "lblLastSeen";
            lblLastSeen.Size = new Size(215, 32);
            lblLastSeen.TabIndex = 4;
            lblLastSeen.Text = "Last Seen: 10:21:35";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(12, 207);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(120, 32);
            lblPort.TabIndex = 5;
            lblPort.Text = "Port: 5000";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(91, 115);
            lblType.Name = "lblType";
            lblType.Size = new Size(144, 32);
            lblType.TabIndex = 6;
            lblType.Text = "Type: Friend";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(89, 83);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(190, 32);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status: ● Online ";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(91, 48);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(192, 32);
            lblUsername.TabIndex = 8;
            lblUsername.Text = "Username: None";
            // 
            // tabFiles
            // 
            tabFiles.Controls.Add(lstFiles);
            tabFiles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabFiles.Location = new Point(4, 34);
            tabFiles.Name = "tabFiles";
            tabFiles.Padding = new Padding(3);
            tabFiles.Size = new Size(305, 517);
            tabFiles.TabIndex = 1;
            tabFiles.Text = "Files";
            tabFiles.UseVisualStyleBackColor = true;
            // 
            // lstFiles
            // 
            lstFiles.Dock = DockStyle.Fill;
            lstFiles.FormattingEnabled = true;
            lstFiles.Location = new Point(3, 3);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(299, 511);
            lstFiles.TabIndex = 0;
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(txbMessage);
            panel2.Controls.Add(btnPicture);
            panel2.Controls.Add(btnFile);
            panel2.Controls.Add(btnSend);
            panel2.Controls.Add(btnEmoji);
            panel2.Location = new Point(3, 615);
            panel2.Name = "panel2";
            panel2.Size = new Size(1372, 123);
            panel2.TabIndex = 2;
            // 
            // txbMessage
            // 
            txbMessage.Location = new Point(38, 49);
            txbMessage.Multiline = true;
            txbMessage.Name = "txbMessage";
            txbMessage.Size = new Size(1186, 61);
            txbMessage.TabIndex = 2;
            txbMessage.TextChanged += txbMessage_TextChanged;
            // 
            // btnPicture
            // 
            btnPicture.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPicture.Location = new Point(274, 3);
            btnPicture.Name = "btnPicture";
            btnPicture.Size = new Size(112, 40);
            btnPicture.TabIndex = 1;
            btnPicture.Text = "Picture";
            btnPicture.UseVisualStyleBackColor = true;
            btnPicture.Click += btnFile_Click;
            // 
            // btnFile
            // 
            btnFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFile.Location = new Point(156, 3);
            btnFile.Name = "btnFile";
            btnFile.Size = new Size(112, 40);
            btnFile.TabIndex = 1;
            btnFile.Text = "File";
            btnFile.UseVisualStyleBackColor = true;
            btnFile.Click += btnFile_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSend.Location = new Point(1242, 49);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(112, 61);
            btnSend.TabIndex = 1;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnEmoji
            // 
            btnEmoji.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmoji.Location = new Point(38, 3);
            btnEmoji.Name = "btnEmoji";
            btnEmoji.Size = new Size(112, 40);
            btnEmoji.TabIndex = 0;
            btnEmoji.Text = "Emoji";
            btnEmoji.UseVisualStyleBackColor = true;
            btnEmoji.Click += btnEmoji_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsStatus, tsUser, tsServer, tsOnline, tsTime, tslTyping });
            statusStrip1.Location = new Point(0, 724);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1379, 39);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            tsStatus.Name = "tsStatus";
            tsStatus.Size = new Size(117, 32);
            tsStatus.Text = "Status: Ready";
            // 
            // tsUser
            // 
            tsUser.Name = "tsUser";
            tsUser.Size = new Size(146, 32);
            tsUser.Text = "  User : Unknown";
            // 
            // tsServer
            // 
            tsServer.Name = "tsServer";
            tsServer.Size = new Size(92, 32);
            tsServer.Text = "  Server : -";
            // 
            // tsOnline
            // 
            tsOnline.Name = "tsOnline";
            tsOnline.Size = new Size(97, 32);
            tsOnline.Text = "  Online : 0";
            // 
            // tsTime
            // 
            tsTime.Name = "tsTime";
            tsTime.Size = new Size(456, 32);
            tsTime.Spring = true;
            tsTime.Text = "00:00:00";
            // 
            // tslTyping
            // 
            tslTyping.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tslTyping.Name = "tslTyping";
            tslTyping.Size = new Size(456, 32);
            tslTyping.Spring = true;
            tslTyping.Text = "\"\"";
            // 
            // cmsMenu
            // 
            cmsMenu.ImageScalingSize = new Size(24, 24);
            cmsMenu.Items.AddRange(new ToolStripItem[] { createGroupToolStripMenuItem, scanServerToolStripMenuItem, recallToolStripMenuItem, logoutToolStripMenuItem, disconnectToolStripMenuItem });
            cmsMenu.Name = "cmsMenu";
            cmsMenu.Size = new Size(190, 164);
            // 
            // createGroupToolStripMenuItem
            // 
            createGroupToolStripMenuItem.Name = "createGroupToolStripMenuItem";
            createGroupToolStripMenuItem.Size = new Size(189, 32);
            createGroupToolStripMenuItem.Text = "Create Group";
            createGroupToolStripMenuItem.Click += createGroupToolStripMenuItem_Click;
            // 
            // scanServerToolStripMenuItem
            // 
            scanServerToolStripMenuItem.Name = "scanServerToolStripMenuItem";
            scanServerToolStripMenuItem.Size = new Size(189, 32);
            scanServerToolStripMenuItem.Text = "Scan Server";
            // 
            // recallToolStripMenuItem
            // 
            recallToolStripMenuItem.Name = "recallToolStripMenuItem";
            recallToolStripMenuItem.Size = new Size(189, 32);
            recallToolStripMenuItem.Text = "Recall";
            recallToolStripMenuItem.Click += recallToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(189, 32);
            logoutToolStripMenuItem.Text = "Logout";
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(189, 32);
            disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1379, 763);
            Controls.Add(statusStrip1);
            Controls.Add(panel2);
            Controls.Add(spMain);
            Controls.Add(panel1);
            Name = "ChatForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatForm";
            Load += ChatForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            spMain.Panel1.ResumeLayout(false);
            spMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spMain).EndInit();
            spMain.ResumeLayout(false);
            spLeftCenter.Panel1.ResumeLayout(false);
            spLeftCenter.Panel2.ResumeLayout(false);
            spLeftCenter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spLeftCenter).EndInit();
            spLeftCenter.ResumeLayout(false);
            gbContacts.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabInfo.ResumeLayout(false);
            tabInformation.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabFiles.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblServer;
        private Label label1;
        private Button btnMenu;
        private SplitContainer spMain;
        private SplitContainer spLeftCenter;
        private GroupBox gbContacts;
        private TreeView tvContacts;
        private TabControl tabInfo;
        private TabPage tabInformation;
        private TabPage tabFiles;
        private Panel panel2;
        private StatusStrip statusStrip1;
        private TextBox txbMessage;
        private Button btnFile;
        private Button btnSend;
        private Button btnEmoji;
        private ToolStripStatusLabel tsStatus;
        private ToolStripStatusLabel tsUser;
        private ToolStripStatusLabel tsServer;
        private ToolStripStatusLabel tsOnline;
        private ToolStripStatusLabel tsTime;
        private ContextMenuStrip cmsMenu;
        private ToolStripMenuItem createGroupToolStripMenuItem;
        private ToolStripMenuItem scanServerToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ListBox lstFiles;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblUnread;
        private Label lblTotalMessages;
        private PictureBox pictureBox1;
        private Label lblIP;
        private Label lblLastSeen;
        private Label lblPort;
        private Label lblType;
        private Label lblStatus;
        private Label lblUsername;
        private Button btnPicture;
        private ToolStripMenuItem recallToolStripMenuItem;
        private Label lblTyping;
        private ToolStripStatusLabel tslTyping;
        private RichTextBox rtbChat;
        private Panel panel3;
        private TextBox txbSreach;
        private Button btnClear;
        private Button btnSreach;
        private Button btnPrev;
        private Button btnNext;
    }
}