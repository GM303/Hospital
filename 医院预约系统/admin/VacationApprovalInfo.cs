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
        public int status;
        public VacationApprovalInfo()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            status = 1;
            MessageBox.Show("审批成功");
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            status = 2;
            MessageBox.Show("审批成功");
            this.Close();
        }
    }
}
