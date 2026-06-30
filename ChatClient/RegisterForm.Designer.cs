namespace ChatClient
{
    partial class RegisterForm
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
            label5 = new Label();
            Password = new Label();
            txbUsername = new TextBox();
            label1 = new Label();
            txbPassword = new TextBox();
            txbConfPassword = new TextBox();
            btnCancel = new Button();
            btnRegister = new Button();
            groupBox2 = new GroupBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
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
            // txbUsername
            // 
            txbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbUsername.Location = new Point(29, 80);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(400, 39);
            txbUsername.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 209);
            label1.Name = "label1";
            label1.Size = new Size(209, 32);
            label1.TabIndex = 2;
            label1.Text = "Confirm Password:";
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
            // txbConfPassword
            // 
            txbConfPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbConfPassword.Location = new Point(29, 244);
            txbConfPassword.Name = "txbConfPassword";
            txbConfPassword.Size = new Size(400, 39);
            txbConfPassword.TabIndex = 3;
            txbConfPassword.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(248, 308);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(181, 52);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(29, 308);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(181, 52);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnRegister);
            groupBox2.Controls.Add(btnCancel);
            groupBox2.Controls.Add(txbConfPassword);
            groupBox2.Controls.Add(txbPassword);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txbUsername);
            groupBox2.Controls.Add(Password);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(449, 385);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "REGISTER";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 409);
            Controls.Add(groupBox2);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            FormClosing += RegisterForm_FormClosing;
            Load += RegisterForm_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        private Label Password;
        private TextBox txbUsername;
        private Label label1;
        private TextBox txbPassword;
        private TextBox txbConfPassword;
        private Button btnCancel;
        private Button btnRegister;
        private GroupBox groupBox2;
    }
}