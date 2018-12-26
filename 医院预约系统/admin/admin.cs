using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital
{
    public partial class admin : FormBase
    {
        login l;
        public admin()
        {
            InitializeComponent();
        }
        public admin(login l)
        {
            InitializeComponent();
            this.l = l;
            UCDeptDocInfoMaintain UC = new UCDeptDocInfoMaintain();
            groupBox1.Controls.Clear();
            UC.Location = groupBox1.Location;
            groupBox1.Controls.Add(UC);
            groupBox1.Text = "科室医生信息维护";
        }
        private void 科室医生信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCDeptDocInfoMaintain UC = new UCDeptDocInfoMaintain();
            groupBox1.Controls.Clear();
            UC.Location = groupBox1.Location;
            groupBox1.Controls.Add(UC);
            groupBox1.Text = "科室医生信息维护";
        }
        private void 医生排班ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCschedule UCs = new UCschedule(true);
            UCs.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(UCs);
            groupBox1.Text = "医生排班";
        }
        private void 请假审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCVacationApproval UCva = new UCVacationApproval();
            UCva.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(UCva);
            groupBox1.Text = "请假审批";
        }

        private void 调班审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCChangeShiftApproval UCcsa = new UCChangeShiftApproval();
            UCcsa.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(UCcsa);
            groupBox1.Text = "调班审批";
        }
    }
}
