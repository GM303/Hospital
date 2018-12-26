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
        int status;
        UCDeptDocInfoMaintain UC;
        public UCCreatDoctor()
        {
            InitializeComponent();
        }
        public UCCreatDoctor(UCDeptDocInfoMaintain UC)
        {
            InitializeComponent();
            this.UC = UC;
            comboBox1.Items.Add("医生");
            comboBox1.Items.Add("科室主任");

            comboBox2.Items.Add("在岗");
            comboBox2.Items.Add("离岗");
            if (UC.modifyFlag == 0)
            {
                textBox4.Text = UC.deptid;
                comboBox1.Text = "医生";
                comboBox2.Text = "在岗";
            }
            else
            {
                dname = UC.name;
                did = UC.id;
                DataTable dt = new DataTable();
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
                if (Convert.ToInt32(dt.Rows[0]["status"]) == 1)
                {
                    comboBox2.Text = "在岗";
                }
                else
                {
                    comboBox2.Text = "离岗";
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (UC.modifyFlag == 0)//添加
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
                    if (comboBox2.Text.Equals("在岗") == true)
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }
                    dt = Fill("select * from doctorinfo where did='" + did + "'");
                    dt0 = Fill("select * from doctorinfo where account='" + account + "'");
                    if (dt.Rows.Count == 0 || dt0.Rows.Count == 0)
                    {
                        int res = NonQuery("insert into doctorinfo values('" + did + "','" + dname + "','" + dsex + "','" + deptid + "','" + account + "','" + is_Director + "',"+status+")");
                        string password = Encrypt.MD5Encrypt32("303303");
                        int res0 = NonQuery("insert into doctoraccount values('"+account+"','"+password+"','"+did+"')");
                        MessageBox.Show("保存成功");
                        UC.FreshTreeview();
                    }
                    else
                    {
                        MessageBox.Show("医生编号或帐号重复！");
                    }
                }
            }
            else//修改
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
                    if (comboBox2.Text.Equals("在岗") == true)
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }
                    int res0 = NonQuery("delete doctorinfo where did='" + did + "'");
                    int res = NonQuery("insert into doctorinfo values('" + did + "','" + dname + "','" + dsex + "','" + deptid + "','" + account + "','" + is_Director + "'," + status + ")");
                    string password = Encrypt.MD5Encrypt32("303303");
                    int res1 = NonQuery("insert into doctoraccount values('" + account + "','" + password + "','" + did + "')");
                    MessageBox.Show("保存成功");
                }

            }
        }
    }
}
