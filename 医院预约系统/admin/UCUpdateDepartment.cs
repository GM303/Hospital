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
        admin adm;
        public UCUpdateDepartment()
        {
            InitializeComponent();
        }
        public UCUpdateDepartment(admin adm)
        {
            InitializeComponent();
            this.adm = adm;
            FreshTreeview();
        }
        public void FreshTreeview()
        {
            treeView1.Nodes.Clear();
            DataTable dt = new DataTable();
            dt = Fill("select * from departmentInfo ");
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                treeView1.Nodes.Add(dt.Rows[i]["deptid"].ToString(), dt.Rows[i]["deptname"].ToString());
            }
            foreach (TreeNode tn in treeView1.Nodes)
            {
                dt = Fill("select * from departmentInfo where departmentInfo.deptid ='"+deptid+"'");
                if (dt == null)
                {
                    MessageBox.Show("null");
                    break;
                }
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    tn.Nodes.Add(dt.Rows[i]["deptid"].ToString(), dt.Rows[i]["deptname"].ToString());
                }
            }
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
                    FreshTreeview();
                }
                else
                {
                    MessageBox.Show("科室编号重复");
                }
            }
        }
    }
}
