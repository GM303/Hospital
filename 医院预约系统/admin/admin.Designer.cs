namespace Hospital
{
    partial class admin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.添加科室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改科室信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医生排班ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.请假审核ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 689);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加科室ToolStripMenuItem,
            this.修改科室信息ToolStripMenuItem,
            this.医生排班ToolStripMenuItem,
            this.请假审核ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 添加科室ToolStripMenuItem
            // 
            this.添加科室ToolStripMenuItem.Name = "添加科室ToolStripMenuItem";
            this.添加科室ToolStripMenuItem.Size = new System.Drawing.Size(12, 21);
            // 
            // 修改科室信息ToolStripMenuItem
            // 
            this.修改科室信息ToolStripMenuItem.Name = "修改科室信息ToolStripMenuItem";
            this.修改科室信息ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.修改科室信息ToolStripMenuItem.Text = "科室医生信息维护";
            this.修改科室信息ToolStripMenuItem.Click += new System.EventHandler(this.科室医生信息维护ToolStripMenuItem_Click);
            // 
            // 医生排班ToolStripMenuItem
            // 
            this.医生排班ToolStripMenuItem.Name = "医生排班ToolStripMenuItem";
            this.医生排班ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.医生排班ToolStripMenuItem.Text = "医生排班";
            this.医生排班ToolStripMenuItem.Click += new System.EventHandler(this.医生排班ToolStripMenuItem_Click);
            // 
            // 请假审核ToolStripMenuItem
            // 
            this.请假审核ToolStripMenuItem.Name = "请假审核ToolStripMenuItem";
            this.请假审核ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.请假审核ToolStripMenuItem.Text = "请假审核";
            this.请假审核ToolStripMenuItem.Click += new System.EventHandler(this.请假审批ToolStripMenuItem_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "admin";
            this.Text = "管理员";
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加科室ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改科室信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医生排班ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 请假审核ToolStripMenuItem;
    }
}