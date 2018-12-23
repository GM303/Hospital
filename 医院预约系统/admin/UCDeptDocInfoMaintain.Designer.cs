namespace Hospital
{
    partial class UCDeptDocInfoMaintain
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加科室ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除科室ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加医生ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除医生ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(230, 652);
            this.treeView1.TabIndex = 13;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加科室ToolStripMenuItem,
            this.删除科室ToolStripMenuItem1,
            this.添加医生ToolStripMenuItem1,
            this.删除医生ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            // 
            // 添加科室ToolStripMenuItem
            // 
            this.添加科室ToolStripMenuItem.Name = "添加科室ToolStripMenuItem";
            this.添加科室ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加科室ToolStripMenuItem.Text = "添加科室";
            this.添加科室ToolStripMenuItem.Click += new System.EventHandler(this.添加科室ToolStripMenuItem_Click);
            // 
            // 删除科室ToolStripMenuItem1
            // 
            this.删除科室ToolStripMenuItem1.Name = "删除科室ToolStripMenuItem1";
            this.删除科室ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.删除科室ToolStripMenuItem1.Text = "删除科室";
            this.删除科室ToolStripMenuItem1.Click += new System.EventHandler(this.删除科室ToolStripMenuItem1_Click);
            // 
            // 添加医生ToolStripMenuItem1
            // 
            this.添加医生ToolStripMenuItem1.Name = "添加医生ToolStripMenuItem1";
            this.添加医生ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.添加医生ToolStripMenuItem1.Text = "添加医生";
            this.添加医生ToolStripMenuItem1.Click += new System.EventHandler(this.添加医生ToolStripMenuItem1_Click);
            // 
            // 删除医生ToolStripMenuItem1
            // 
            this.删除医生ToolStripMenuItem1.Name = "删除医生ToolStripMenuItem1";
            this.删除医生ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.删除医生ToolStripMenuItem1.Text = "删除医生";
            this.删除医生ToolStripMenuItem1.Click += new System.EventHandler(this.删除医生ToolStripMenuItem1_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(240, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 652);
            this.panel1.TabIndex = 14;
            // 
            // UCDeptDocInfoMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Name = "UCDeptDocInfoMaintain";
            this.Size = new System.Drawing.Size(970, 659);
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加科室ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除科室ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加医生ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除医生ToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
    }
}
