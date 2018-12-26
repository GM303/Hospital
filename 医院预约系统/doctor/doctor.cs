using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Hospital
{
    public partial class doctor : FormBase
    {
        public doctor()
        {
            InitializeComponent();
        }
        public doctor(string account):base(account)
        {
            InitializeComponent();   
            GetIdNameDept(account);
            UCShowAppointment ucsa = new UCShowAppointment(this);
            ucsa.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(ucsa);
            groupBox1.Text = "显示预约";

        }
        public void GetIdNameDept(string account)
        {
            DataTable dt = new DataTable();
            dt = Fill(@"select * from doctoraccount,doctorinfo where doctoraccount.did=doctorinfo.did and '" + account + " '=doctorinfo.account");
            //获取医生信息
            name = dt.Rows[0]["dname"].ToString();
            id = dt.Rows[0]["did"].ToString();
            deptid = dt.Rows[0]["deptid"].ToString();
            isDirector = dt.Rows[0]["isDirector"].ToString();
            //获取科室信息
            dt = Fill(@"select *from departmentinfo where '"+deptid+"'=departmentinfo.deptid");
            deptname = dt.Rows[0]["deptname"].ToString();
            label1.Text = id;
            label2.Text = name;
            label3.Text = deptname;
        }
        private void 显示预约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCShowAppointment ucsa = new UCShowAppointment(this);
            ucsa.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(ucsa);
            groupBox1.Text = "显示预约";
        }
        private void 申请调班ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCChangeShifts uccs = new UCChangeShifts(this);
            uccs.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(uccs);
            groupBox1.Text = "申请调班";

        }
        private void 申请请假ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCVacation ucv = new UCVacation(this);
            ucv.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(ucv);
            groupBox1.Text = "申请请假";
        }
        private void 查看排班ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCschedule ucss = new UCschedule(false);
            ucss.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(ucss);
            groupBox1.Text = "查看排班";
        }

        private void 辅助预约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCHelpAppointment uchp = new UCHelpAppointment(this);
            uchp.Location = groupBox1.Location;
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(uchp);
            groupBox1.Text = "辅助预约";
        }
    }
}
