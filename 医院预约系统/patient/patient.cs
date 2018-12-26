using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Hospital
{
    public partial class patient : FormBase
    {

        public patient()
        {
            InitializeComponent();
        }
        public patient(string account) : base(account)
        {
            this.account = account;
            GetIdName(account);
            InitializeComponent();
            groupBox1.Controls.Clear();
            UCappointment uca = new UCappointment(this);
            uca.Location = groupBox1.Location;
            groupBox1.Controls.Add(uca);
            groupBox1.Text = "预约";

        }
        public void GetIdName(string account)
        {
            DataTable dt = new DataTable();
            dt = Fill(@"select * from patientaccount pa,patientinfo pt where pa.pid=pt.pid and '" + account + " '=pa.account");
            if (dt.Rows.Count == 0)
            {
            }
            else
            {
                name = dt.Rows[0]["pname"].ToString();
                id = dt.Rows[0]["pid"].ToString();
            }
        }
        private void 预约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            UCappointment uca=new UCappointment(this);
         //   UCappointmentSP uca =new UCappointmentSP(this);
            uca.Location = groupBox1.Location;
            groupBox1.Controls.Add(uca);
            groupBox1.Text = "预约";
        }
        private void 取消预约ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            UCCancelAppointment ucca = new UCCancelAppointment(this);
            ucca.Location = groupBox1.Location; groupBox1.Controls.Add(ucca);
            groupBox1.Controls.Add(ucca);
            groupBox1.Text = "取消预约";
        }
    }
}
