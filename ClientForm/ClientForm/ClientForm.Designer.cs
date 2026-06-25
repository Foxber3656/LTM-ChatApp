namespace AuthForm
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

        private void InitializeComponent()
        {
            panelChat = new System.Windows.Forms.Panel();
            rtbChat = new System.Windows.Forms.RichTextBox();
            txtMessage = new System.Windows.Forms.TextBox();
            btnSend = new System.Windows.Forms.Button();
            lstUsers = new System.Windows.Forms.ListBox();
            rtbLog = new System.Windows.Forms.RichTextBox();
            labelLog = new System.Windows.Forms.Label();

            panelChat.SuspendLayout();
            SuspendLayout();

            // panelChat
            panelChat.Controls.Add(rtbChat);
            panelChat.Controls.Add(txtMessage);
            panelChat.Controls.Add(btnSend);
            panelChat.Controls.Add(lstUsers);
            panelChat.Controls.Add(rtbLog);
            panelChat.Controls.Add(labelLog);
            panelChat.Location = new System.Drawing.Point(12, 12);
            panelChat.Size = new System.Drawing.Size(760, 450);
            panelChat.TabIndex = 0;

            // rtbChat
            rtbChat.Location = new System.Drawing.Point(10, 10);
            rtbChat.Size = new System.Drawing.Size(540, 250);
            rtbChat.ReadOnly = true;

            // txtMessage
            txtMessage.Location = new System.Drawing.Point(10, 270);
            txtMessage.Size = new System.Drawing.Size(440, 23);
            txtMessage.KeyDown += txtMessage_KeyDown;

            // btnSend
            btnSend.Location = new System.Drawing.Point(460, 268);
            btnSend.Size = new System.Drawing.Size(90, 30);
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click;

            // lstUsers
            lstUsers.Location = new System.Drawing.Point(560, 10);
            lstUsers.Size = new System.Drawing.Size(180, 300);

            // rtbLog
            rtbLog.Location = new System.Drawing.Point(10, 310);
            rtbLog.Size = new System.Drawing.Size(730, 120);
            rtbLog.ReadOnly = true;

            // labelLog
            labelLog.Text = "System Logs";
            labelLog.Location = new System.Drawing.Point(10, 295);

            // ClientForm
            ClientSize = new System.Drawing.Size(784, 481);
            Controls.Add(panelChat);
            Text = "Chat Client";
            FormClosing += ClientForm_FormClosing;

            panelChat.ResumeLayout(false);
            panelChat.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label labelLog;
    }
}