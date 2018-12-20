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
    public partial class UCUpdateDepartment : UCBase
    {
        UCDeptDocInfoMaintain UC;
        public UCUpdateDepartment()
        {
            InitializeComponent();
        }
        public UCUpdateDepartment(UCDeptDocInfoMaintain UC)
        {
            InitializeComponent();
            this.UC = UC;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string deptid, deptname;
            deptid = textBox1.Text;
            deptname = textBox2.Text;
            dt = Fill("select * from departmentInfo where departmentInfo.deptid ='" + deptid + "'");
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请完整填入信息！");
            }
            else
            { 
                if (dt.Rows.Count == 0)
                {
                    int res = NonQuery("insert into departmentInfo values('" + deptid + "','" + deptname + "')");
                    MessageBox.Show("保存成功！");
                    UC.FreshTreeview();

                }
                else
                {
                    MessageBox.Show("科室编号重复");
                }
            }
        }
    }
}
