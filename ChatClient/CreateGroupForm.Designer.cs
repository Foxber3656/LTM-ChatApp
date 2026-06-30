namespace ChatClient
{
    partial class CreateGroupForm
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
            panel1 = new Panel();
            lblWelcome = new Label();
            lblGroupName = new Label();
            txbGroupName = new TextBox();
            clbMembers = new CheckedListBox();
            btnCreate = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblWelcome);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 54);
            panel1.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(118, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(220, 38);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "CREATE GROUP";
            // 
            // lblGroupName
            // 
            lblGroupName.AutoSize = true;
            lblGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGroupName.Location = new Point(12, 79);
            lblGroupName.Name = "lblGroupName";
            lblGroupName.Size = new Size(170, 32);
            lblGroupName.TabIndex = 3;
            lblGroupName.Text = "Group name :";
            // 
            // txbGroupName
            // 
            txbGroupName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbGroupName.Location = new Point(12, 114);
            txbGroupName.Name = "txbGroupName";
            txbGroupName.Size = new Size(474, 39);
            txbGroupName.TabIndex = 4;
            // 
            // clbMembers
            // 
            clbMembers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbMembers.FormattingEnabled = true;
            clbMembers.Location = new Point(12, 173);
            clbMembers.Name = "clbMembers";
            clbMembers.Size = new Size(474, 148);
            clbMembers.TabIndex = 5;
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCreate.Location = new Point(54, 341);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(165, 59);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(263, 341);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 59);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CreateGroupForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 431);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Controls.Add(clbMembers);
            Controls.Add(txbGroupName);
            Controls.Add(lblGroupName);
            Controls.Add(panel1);
            Name = "CreateGroupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateGroupForm";
            Load += CreateGroupForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblWelcome;
        private Label lblGroupName;
        private TextBox txbGroupName;
        private CheckedListBox clbMembers;
        private Button btnCreate;
        private Button btnCancel;
    }
}