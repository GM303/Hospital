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
            button1.Enabled = false;
        }
        private void InfoCheck(string deptid,string deptname)
        {
            if(deptid=="")
            {
                label3.Text = "科室编号不能为空";
                return;
            }
            dt = Fill("select * from departmentInfo where departmentInfo.deptid ='" + deptid + "'");
            if(dt.Rows.Count!=0)
            {
                label3.Text = "科室编号已存在";
                return;
            }
            if (deptname == "")
            {
                label3.Text = "科室名称不能为空";
                return;
            }
            label3.Text = "";
            button1.Enabled = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string deptid, deptname;
            deptid = textBox1.Text;
            deptname = textBox2.Text;
            int res = NonQuery("insert into departmentInfo values('" + deptid + "','" + deptname + "')");
            MessageBox.Show("保存成功！");
            UC.FreshTreeview();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            InfoCheck(textBox1.Text, textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            InfoCheck(textBox1.Text, textBox2.Text);
        }
    }
}
