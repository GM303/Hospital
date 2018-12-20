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
    public partial class VacationApprovalInfo : FormBase
    {
        public string did, dname, lstarttime, lendtime,status;
        public VacationApprovalInfo()
        {
            InitializeComponent();
        }
        public VacationApprovalInfo(string did, string dname, string lstarttime, string lendtime,string isApprova)
        {
            InitializeComponent();
            this.did = did;
            this.dname = dname;
            this.lstarttime = lstarttime;
            this.lendtime = lendtime;
            this.status = isApprova;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = "1";
            MessageBox.Show("审批成功");
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            status = "2";
            MessageBox.Show("审批成功");
            this.Close();
        }
    }
}
