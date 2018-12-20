namespace Hospital
{
    partial class register
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
            this.label1 = new System.Windows.Forms.Label();
            this.Laccount = new System.Windows.Forms.TextBox();
            this.Lpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lcpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Lname = new System.Windows.Forms.TextBox();
            this.Lid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(222, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // Laccount
            // 
            this.Laccount.Location = new System.Drawing.Point(341, 92);
            this.Laccount.Name = "Laccount";
            this.Laccount.Size = new System.Drawing.Size(163, 21);
            this.Laccount.TabIndex = 1;
            this.Laccount.TextChanged += new System.EventHandler(this.account_TextChanged);
            // 
            // Lpassword
            // 
            this.Lpassword.Location = new System.Drawing.Point(341, 119);
            this.Lpassword.Name = "Lpassword";
            this.Lpassword.Size = new System.Drawing.Size(163, 21);
            this.Lpassword.TabIndex = 3;
            this.Lpassword.UseSystemPasswordChar = true;
            this.Lpassword.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(222, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // Lcpassword
            // 
            this.Lcpassword.Location = new System.Drawing.Point(341, 146);
            this.Lcpassword.Name = "Lcpassword";
            this.Lcpassword.Size = new System.Drawing.Size(163, 21);
            this.Lcpassword.TabIndex = 5;
            this.Lcpassword.UseSystemPasswordChar = true;
            this.Lcpassword.TextChanged += new System.EventHandler(this.cpassword_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(222, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "确认密码";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 46);
            this.button1.TabIndex = 100;
            this.button1.Text = "更改可见状态";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // registerButton
            // 
            this.registerButton.Enabled = false;
            this.registerButton.Location = new System.Drawing.Point(159, 312);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(169, 57);
            this.registerButton.TabIndex = 99;
            this.registerButton.Text = "注册";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.RegisterButtonClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(222, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "真实姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(222, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "身份证ID";
            // 
            // Lname
            // 
            this.Lname.Location = new System.Drawing.Point(341, 173);
            this.Lname.Name = "Lname";
            this.Lname.Size = new System.Drawing.Size(163, 21);
            this.Lname.TabIndex = 10;
            this.Lname.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // Lid
            // 
            this.Lid.Location = new System.Drawing.Point(341, 200);
            this.Lid.Name = "Lid";
            this.Lid.Size = new System.Drawing.Size(163, 21);
            this.Lid.TabIndex = 11;
            this.Lid.TextChanged += new System.EventHandler(this.id_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(40, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(480, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 57);
            this.button2.TabIndex = 101;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lid);
            this.Controls.Add(this.Lname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.Lcpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Lpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Laccount);
            this.Controls.Add(this.label1);
            this.Name = "register";
            this.Text = "注册";
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Laccount;
        private System.Windows.Forms.TextBox Lpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Lcpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Lname;
        private System.Windows.Forms.TextBox Lid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}