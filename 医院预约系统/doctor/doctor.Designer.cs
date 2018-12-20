namespace Hospital
{
    partial class doctor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.显示预约ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看排班ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申请请假ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.申请调班ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示预约ToolStripMenuItem,
            this.查看排班ToolStripMenuItem,
            this.申请请假ToolStripMenuItem,
            this.申请调班ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 显示预约ToolStripMenuItem
            // 
            this.显示预约ToolStripMenuItem.Name = "显示预约ToolStripMenuItem";
            this.显示预约ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.显示预约ToolStripMenuItem.Text = "显示预约";
            this.显示预约ToolStripMenuItem.Click += new System.EventHandler(this.显示预约ToolStripMenuItem_Click);
            // 
            // 查看排班ToolStripMenuItem
            // 
            this.查看排班ToolStripMenuItem.Name = "查看排班ToolStripMenuItem";
            this.查看排班ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.查看排班ToolStripMenuItem.Text = "查看排班";
            this.查看排班ToolStripMenuItem.Click += new System.EventHandler(this.查看排班ToolStripMenuItem_Click);
            // 
            // 申请请假ToolStripMenuItem
            // 
            this.申请请假ToolStripMenuItem.Name = "申请请假ToolStripMenuItem";
            this.申请请假ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.申请请假ToolStripMenuItem.Text = "申请请假";
            this.申请请假ToolStripMenuItem.Click += new System.EventHandler(this.申请请假ToolStripMenuItem_Click);
            // 
            // 申请调班ToolStripMenuItem
            // 
            this.申请调班ToolStripMenuItem.Name = "申请调班ToolStripMenuItem";
            this.申请调班ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.申请调班ToolStripMenuItem.Text = "申请调班";
            this.申请调班ToolStripMenuItem.Click += new System.EventHandler(this.申请调班ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(840, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(887, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 689);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(934, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "doctor";
            this.Text = "医生";
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示预约ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看排班ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申请请假ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 申请调班ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}