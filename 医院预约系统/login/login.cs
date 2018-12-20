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
    public partial class login : FormBase
    {
        public login()
        {
            InitializeComponent();
            AutoUpdateNumberSource.run();
         //   AutoInsertNumberSources();
        }
        private int AccountCheck(string account, string password, string tableName)//返回0表示正确，返回1表示账号不存在，返回2表示密码错误
        {
            try
            {
                con.ConnectionString = strConn;
                cmd.CommandText = @"select * from " + tableName + " where account = @account";
                cmd.Parameters.AddWithValue("@account", account);
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteScalar() == null)
                {
                    return 1;
                }
                cmd.CommandText = @"select * from " + tableName + " where account = @account and password = @password";
                //cmd.Parameters.AddWithValue("@account", account);
                cmd.Parameters.AddWithValue("@password", password);
                if (cmd.ExecuteScalar() == null)
                {
                    return 2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                con.Close();
            }
            return 0;
        }
        private int IsFreeze(string account)//返回0表示账号正常，返回1表示账号被冻结
        {
            dt = Fill(@"select * from reservationInfo res , patientAccount pa where pa.account='"+account+ "' and res.pid=pa.pid and res.status='1'");
            if (dt.Rows.Count >= 3)
                return 1;
            else
                return 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar ^= true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register reg=new register();
            reg.StartPosition = FormStartPosition.CenterParent;
            reg.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text;
            string password = Encrypt.MD5Encrypt32(textBox2.Text);
            if (radioButton1.Checked)
            {
                switch (AccountCheck(account, password, "patientAccount"))
                {
                    case 0:
                        //  MessageBox.Show("验证成功");
                        if (IsFreeze(account) == 0)
                        {
                            patient ap = new patient(account);
                            ap.ShowDialog();
                        }
                        else
                        {
                            ReleaseFreezeApplication rfp = new ReleaseFreezeApplication();
                            rfp.ShowDialog();
                        }
                        break;
                    case 1:
                        MessageBox.Show("账号不存在");
                        break;
                    case 2:
                        MessageBox.Show("密码错误");
                        break;
                }
            }
            else if (radioButton2.Checked)
            {
                switch (AccountCheck(account, password, "doctorAccount"))
                {
                    case 0:
                        // MessageBox.Show("验证成功");
                        doctor d = new doctor(account);
                        d.ShowDialog();
                        break;
                    case 1:
                        MessageBox.Show("账号不存在");
                        break;
                    case 2:
                        MessageBox.Show("密码错误");
                        break;
                }
            }
            else if (radioButton3.Checked)
            {
                switch (AccountCheck(account, password, "adminAccount"))
                {
                    case 0:
                        //MessageBox.Show("验证成功");
                        admin adm = new admin(this);
                        adm.ShowDialog();
                       
                        break;
                    case 1:
                        MessageBox.Show("账号不存在");
                        break;
                    case 2:
                        MessageBox.Show("密码错误");
                        break;
                }
            }
        }
    }
}