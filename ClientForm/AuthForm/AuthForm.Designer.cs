namespace AuthForm
{
    partial class AuthForm
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
            btnLogin = new Button();
            btnRegister = new Button();
            panel1 = new Panel();
            button3 = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button4 = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();

            // btnLogin
            btnLogin.Location = new Point(12, 12);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(266, 45);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;   // Đã sửa đúng tên

            // btnRegister
            btnRegister.Location = new Point(290, 12);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(266, 45);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;

            // panel1
            panel1.Controls.Add(button3);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(544, 375);
            panel1.TabIndex = 2;

            // button3
            button3.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button3.Location = new Point(148, 271);
            button3.Name = "button3";
            button3.Size = new Size(257, 65);
            button3.TabIndex = 9;
            button3.Text = "LOGIN";
            button3.UseVisualStyleBackColor = true;

            // textBox3
            textBox3.Location = new Point(183, 216);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(222, 23);
            textBox3.TabIndex = 8;

            // label4
            label4.AutoSize = true;
            label4.Location = new Point(100, 219);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 7;
            label4.Text = "Password:";

            // textBox4
            textBox4.Location = new Point(183, 168);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(222, 23);
            textBox4.TabIndex = 6;

            // label5
            label5.AutoSize = true;
            label5.Location = new Point(121, 171);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 5;
            label5.Text = "Email:";

            // textBox2
            textBox2.Location = new Point(183, 122);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(222, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "5000";

            // label3
            label3.AutoSize = true;
            label3.Location = new Point(128, 125);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 3;
            label3.Text = "Port:";

            // textBox1
            textBox1.Location = new Point(183, 74);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "127.0.0.1";

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(95, 77);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 1;
            label2.Text = "IP Address:";

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(215, 13);
            label1.Name = "label1";
            label1.Size = new Size(113, 45);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";

            // panel2
            panel2.Controls.Add(button4);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox8);
            panel2.Controls.Add(textBox7);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(12, 63);
            panel2.Name = "panel2";
            panel2.Size = new Size(544, 375);
            panel2.TabIndex = 10;

            // button4
            button4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 163);
            button4.Location = new Point(148, 271);
            button4.Name = "button4";
            button4.Size = new Size(257, 63);
            button4.TabIndex = 10;
            button4.Text = "REGISTER";
            button4.UseVisualStyleBackColor = true;

            // label10
            label10.AutoSize = true;
            label10.Location = new Point(85, 216);
            label10.Name = "label10";
            label10.Size = new Size(107, 15);
            label10.TabIndex = 9;
            label10.Text = "Confirm Password:";

            // label9
            label9.AutoSize = true;
            label9.Location = new Point(132, 166);
            label9.Name = "label9";
            label9.Size = new Size(60, 15);
            label9.TabIndex = 8;
            label9.Text = "Password:";

            // label8
            label8.AutoSize = true;
            label8.Location = new Point(153, 120);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 7;
            label8.Text = "Email:";

            // label7
            label7.AutoSize = true;
            label7.Location = new Point(128, 77);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 6;
            label7.Text = "Nickname:";

            // textBox8
            textBox8.Location = new Point(215, 211);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(190, 23);
            textBox8.TabIndex = 4;

            // textBox7
            textBox7.Location = new Point(215, 163);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(190, 23);
            textBox7.TabIndex = 3;

            // textBox6
            textBox6.Location = new Point(215, 117);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(190, 23);
            textBox6.TabIndex = 2;

            // textBox5
            textBox5.Location = new Point(215, 74);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(190, 23);
            textBox5.TabIndex = 1;

            // label6
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label6.Location = new Point(192, 13);
            label6.Name = "label6";
            label6.Size = new Size(155, 45);
            label6.TabIndex = 0;
            label6.Text = "REGISTER";

            // AuthForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Name = "AuthForm";
            Text = "AuthForm";

            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        // Khai báo biến
        private Button btnLogin;
        private Button btnRegister;
        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Button button3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox2;
        private Label label3;
        private Panel panel2;
        private Label label6;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private TextBox textBox5;
        private Button button4;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}