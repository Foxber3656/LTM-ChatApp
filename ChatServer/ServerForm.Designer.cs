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
            lbTitle = new Label();
            panel2 = new Panel();
            label2 = new Label();
            lbStatus = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lbTitle);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 663);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbTitle.FlatStyle = FlatStyle.Flat;
            lbTitle.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(3, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(673, 64);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "CHAT SERVER DASHBOARD";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            lbTitle.Click += lbTitle_Click;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(numericUpDown1);
            panel2.Controls.Add(lbStatus);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(673, 118);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 13);
            label2.Name = "label2";
            label2.Size = new Size(165, 32);
            label2.TabIndex = 0;
            label2.Text = "Server Status :";
            // 
            // lbStatus
            // 
            lbStatus.Anchor = AnchorStyles.Left;
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbStatus.Location = new Point(189, 13);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(115, 32);
            lbStatus.TabIndex = 0;
            lbStatus.Text = "● Offline";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDown1.Location = new Point(189, 61);
            numericUpDown1.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(115, 39);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 63);
            label3.Name = "label3";
            label3.Size = new Size(69, 32);
            label3.TabIndex = 0;
            label3.Text = "Port :";
            // 
            // button1
            // 
            button1.Location = new Point(328, 47);
            button1.Name = "button1";
            button1.Size = new Size(147, 53);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(496, 47);
            button2.Name = "button2";
            button2.Size = new Size(147, 53);
            button2.TabIndex = 2;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 687);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "ServerForm";
            Text = "Chat Server";
            Load += ServerForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label lbTitle;
        private Panel panel2;
        private Label lbStatus;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Button button2;
        private Button button1;
    }
}
