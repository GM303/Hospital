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
    public partial class register : FormBase
    {
       public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lpassword.UseSystemPasswordChar ^= true;
            Lcpassword.UseSystemPasswordChar ^= true;
        }
        private string InfoCheck(string account, string password,string cpassword ,string pid,string name)
        {
            try
            {
                if(account.Length==0)
                {
                    return "账号为空";
                }
                con.ConnectionString = strConn;
                cmd.CommandText = @"select * from  patientaccount where account = @account";
                cmd.Parameters.AddWithValue("@account", account);
                cmd.Connection = con;
                con.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    return "账号已存在";
                }
                if (password.Length == 0)
                {
                    return "密码为空";
                }
                if (password.Length <6)
                {
                    return "密码长度不得小于6位";
                }
                if (!password.Equals(cpassword))
                {
                    return "密码不一致";
                }
                if (name.Length == 0)
                {
                    return "姓名为空";
                }
                if (pid.Length == 0)
                {
                    return "身份证号为空";
                }
                cmd.CommandText = @"select * from patientaccount where  pid = @pid";
                //    cmd.Parameters.AddWithValue("@account", account);
                cmd.Parameters.AddWithValue("@pid", pid);
                if (cmd.ExecuteScalar() != null)
                {
                    return "身份证已存在";
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
            return "";
        }
        private void RegisterButtonClick(object sender, EventArgs e)
        {
            try
            {
                //    Encrypt enc = new Encrypt(); 
               // MessageBox.Show(Encrypt.MD5Encrypt32(password.Text));
                int res = NonQuery("insert into patientAccount(Account,Password,pid) values('" + Laccount.Text + "','" + Encrypt.MD5Encrypt32(Lpassword.Text) + "','" + Lid.Text + "')");
                int res1 = NonQuery("insert into patientInfo(pid,pname) values('" + Lid.Text + "','" + Lname.Text + "')");
                MessageBox.Show("注册成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void id_TextChanged(object sender, EventArgs e)
        {
            label6.Text = InfoCheck(Laccount.Text, Lpassword.Text, Lcpassword.Text, Lid.Text, Lname.Text);
            if(label6.Text.Length==0)
            {
                registerButton.Enabled = true;
            }
            else
            {
                registerButton.Enabled = false;
            }
        }
        private void account_TextChanged(object sender, EventArgs e)
        {
            label6.Text = InfoCheck(Laccount.Text, Lpassword.Text, Lcpassword.Text, Lid.Text, Lname.Text);
            if (label6.Text.Length == 0)
            {
                registerButton.Enabled = true;
            }
            else
            {
                registerButton.Enabled = false;
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            label6.Text = InfoCheck(Laccount.Text, Lpassword.Text, Lcpassword.Text, Lid.Text, Lname.Text);
            if (label6.Text.Length == 0)
            {
                registerButton.Enabled = true;
            }
            else
            {
                registerButton.Enabled = false;
            }
        }

        private void cpassword_TextChanged(object sender, EventArgs e)
        {
            label6.Text = InfoCheck(Laccount.Text, Lpassword.Text, Lcpassword.Text, Lid.Text, Lname.Text);
            if (label6.Text.Length == 0)
            {
                registerButton.Enabled = true;
            }
            else
            {
                registerButton.Enabled = false;
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            label6.Text = InfoCheck(Laccount.Text, Lpassword.Text, Lcpassword.Text, Lid.Text, Lname.Text);
            if (label6.Text.Length == 0)
            {
                registerButton.Enabled = true;
            }
            else
            {
                registerButton.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
