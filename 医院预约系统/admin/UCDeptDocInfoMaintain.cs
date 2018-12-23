using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital
{
    public partial class UCDeptDocInfoMaintain : UCBase
    {
        public int modifyFlag;//为0时是添加，为1时是修改;
        public UCDeptDocInfoMaintain()
        {
            InitializeComponent();
            FreshTreeview();
            contextMenuStrip1.Items[1].Enabled = false;
            contextMenuStrip1.Items[2].Enabled = false;
            contextMenuStrip1.Items[3].Enabled = false;
        }
        public void FreshTreeview()
        {
            treeView1.Nodes.Clear();
            DataTable dt = new DataTable();
            dt = Fill("select * from departmentInfo");
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                treeView1.Nodes.Add(dt.Rows[i]["deptid"].ToString(), dt.Rows[i]["deptname"].ToString());
            }
            foreach (TreeNode tn in treeView1.Nodes)
            {
                dt = Fill("select * from doctorInfo,departmentInfo where doctorInfo.deptid=departmentInfo.deptid and departmentInfo.deptname='" + tn.Text + "'");
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    tn.Nodes.Add(dt.Rows[i]["did"].ToString(), dt.Rows[i]["dname"].ToString());
                }
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Left)
            {
                modifyFlag = 1;
                if (e.Node.Level == 0)
                {
                    name = e.Node.Text;
                    id = e.Node.Name;;
                    UCUpdateDepartment UC = new UCUpdateDepartment(this);
                    UC.Location = new System.Drawing.Point(0, 0);
                    panel1.Controls.Clear();
                    panel1.Controls.Add(UC);
                }
                else
                {
                    name = e.Node.Text;
                    id = e.Node.Name; ;
                    UCCreatDoctor UC = new UCCreatDoctor(this);
                    UC.Location = new System.Drawing.Point(0, 0);
                    panel1.Controls.Clear();
                    panel1.Controls.Add(UC);
                    panel1.Text = "添加医生";
                }
            }
            else
            {
                if (e.Node.Level == 0)
                {
                    deptid = e.Node.Name;
                    contextMenuStrip1.Items[1].Enabled = true;
                    contextMenuStrip1.Items[2].Enabled = true;
                }
                else
                {
                    name = e.Node.Text;
                    id = e.Node.Name;
                    contextMenuStrip1.Items[1].Enabled = true;
                    contextMenuStrip1.Items[2].Enabled = true;
                    contextMenuStrip1.Items[3].Enabled = true;
                }
            }
        }
        private void 添加科室ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifyFlag = 0;
            UCUpdateDepartment UC = new UCUpdateDepartment(this);
            UC.Location = new System.Drawing.Point(0, 0);
            panel1.Controls.Clear();
            panel1.Controls.Add(UC);
            panel1.Text = "添加科室";
        }
        private void 添加医生ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            modifyFlag = 0;
            UCCreatDoctor UC = new UCCreatDoctor(this);
            UC.Location = new System.Drawing.Point(0, 0);
            panel1.Controls.Clear();
            panel1.Controls.Add(UC);
            panel1.Text = "添加医生";
        }
        private void 删除医生ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NonQuery("delete from doctorInfo where did='" + id + "'");
            FreshTreeview();

        }
        private void 删除科室ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NonQuery("delete from departmentInfo where deptid='" + deptid + "'");
            FreshTreeview();

        }
        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            contextMenuStrip1.Items[1].Enabled = false;
            contextMenuStrip1.Items[2].Enabled = false;
            contextMenuStrip1.Items[3].Enabled = false;
        }
    }
}
