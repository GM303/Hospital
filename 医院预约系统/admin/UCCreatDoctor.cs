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
    public partial class UCCreatDoctor : UCBase
    {
        string dname, did, dsex, is_Director;
        int flag;
        UCDeptDocInfoMaintain UC;
        public UCCreatDoctor()
        {
            InitializeComponent();
        }
        public UCCreatDoctor(UCDeptDocInfoMaintain UC)
        {
            InitializeComponent();
            this.UC = UC;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                DataTable dt0 = new DataTable();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("请完整填入信息！");
                }
                else
                {
                    dname = textBox1.Text;
                    dsex = textBox2.Text;
                    did = textBox3.Text;
                    deptid = textBox4.Text;
                    account = textBox6.Text;
                    if (comboBox1.Text.Equals("医生") == true)
                    {
                        is_Director = 0.ToString();
                    }
                    else
                    {
                        is_Director = 1.ToString();
                    }
                    dt = Fill("select * from doctorinfo where did='" + did + "'");
                    dt0 = Fill("select * from doctorinfo where account='" + account + "'");
                    if (dt.Rows.Count == 0 || dt0.Rows.Count == 0)
                    {
                        int res = NonQuery("insert into doctorinfo values('" + did + "','" + dname + "','" + dsex + "','" + deptid + "','" + account + "','" + is_Director + "')");
                        string password = Encrypt.MD5Encrypt32("303303");
                        int res0 = NonQuery("insert into doctoraccount values('"+account+"','"+password+"','"+did+"')");
                        int res1 = NonQuery("insert into scheduleInfo values('" + did + "','" + deptid + "','00000000000000','0-0-0-0-0-0-0-0-0-0-0-0-0-0')");
                        MessageBox.Show("保存成功");
                  //      FreshTreeview();
                    }
                    else
                    {
                        MessageBox.Show("医生编号或帐号重复！");
                    }
                }
            }
            if(flag==1)
            {

                DataTable dt0 = new DataTable();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("请完整填入信息！");
                }
                else
                {
                    dname = textBox1.Text;
                    dsex = textBox2.Text;
                    did = textBox3.Text;
                    deptid = textBox4.Text;
                    account = textBox6.Text;
                    if (comboBox1.Text.Equals("医生") == true)
                    {
                        is_Director = 0.ToString();
                    }
                    else
                    {
                        is_Director = 1.ToString();
                    }
                    int res0 = NonQuery("delete doctorinfo where did='" + did + "'");
                    int res = NonQuery("insert into doctorinfo values('" + did + "','" + dname + "','" + dsex + "','" + deptid + "','" + account + "','" + is_Director + "')");
                    string password = Encrypt.MD5Encrypt32("66");
                    MessageBox.Show("保存成功");
                //    FreshTreeview();
                }

            }
            if(flag==2)
            {

            }
        }

        private void 添加医生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;
            textBox4.Text = deptid;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("医生");
            comboBox1.Items.Add("科室主任");
            comboBox1.Text = "医生";
            textBox6.Text = "";
        }
        private void 删除医生ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            flag = 2;
            int res0 = NonQuery("delete doctorinfo where did='" + did + "'");
      //      FreshTreeview();
        }
        private void 修改医生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
            dt = Fill("select * from doctorinfo where did='" + did + "'");
            textBox1.Text = dt.Rows[0]["dname"].ToString();
            textBox2.Text = dt.Rows[0]["dsex"].ToString();
            textBox3.Text = dt.Rows[0]["did"].ToString();
            textBox4.Text = dt.Rows[0]["deptid"].ToString();
            textBox6.Text = dt.Rows[0]["account"].ToString();
            if (dt.Rows[0]["isDirector"].ToString() == "0")
            {
                comboBox1.Text = "医生";
            }
            else
            {
                comboBox1.Text = "科室主任";
            }
        }
        /*
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            if (e.Button==MouseButtons.Right)
            {
                if(e.Node.Level==0)
                {
                    contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Items[2].Enabled = false;
                    contextMenuStrip1.Items[0].Enabled = true;
                    deptid = e.Node.Name;
                }
                else
                {
                    contextMenuStrip1.Items[1].Enabled = true;
                    contextMenuStrip1.Items[2].Enabled = true;
                    contextMenuStrip1.Items[0].Enabled = false;
                    dname = e.Node.Text;
                    did = e.Node.Name;
                }
                this.contextMenuStrip1.Show(Control.MousePosition);
            }
            else
            {
                if(e.Node.Level==1)
                {
                    dname = e.Node.Text;
                    did = e.Node.Name;
                    DataTable dt = new DataTable();
                    flag = 1;
                    dt = Fill("select * from doctorinfo where did='" + did + "'");
                    textBox1.Text = dt.Rows[0]["dname"].ToString();
                    textBox2.Text = dt.Rows[0]["dsex"].ToString();
                    textBox3.Text = dt.Rows[0]["did"].ToString();
                    textBox4.Text = dt.Rows[0]["deptid"].ToString();
                    textBox6.Text = dt.Rows[0]["account"].ToString();
                    if (dt.Rows[0]["isDirector"].ToString() == "0")
                    {
                        comboBox1.Text = "医生";
                    }
                    else
                    {
                        comboBox1.Text = "科室主任";
                    }
                }
            }
        }*/
    }
}
