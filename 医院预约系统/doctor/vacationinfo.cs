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
    public partial class vacationinfo : Form
    {
        string did, dname,lstatus,reason;
        string leftstartTime,leftendTime;
        private string strConn = @"Data Source=(local);Initial Catalog=Hospital;Integrated Security=True";
        private SqlConnection con = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter sda = new SqlDataAdapter();
        private DataTable dt = new DataTable();
        public vacationinfo()
        {
            InitializeComponent();
        }
        public vacationinfo(string did,string dname,string leftStartTime, string leftEndTime,string reason)
        {
            InitializeComponent();
            lstatus = "0";
            this.did = did;
            this.dname = dname;
            this.leftstartTime = leftStartTime;
            this.leftendTime = leftEndTime;
            this.reason = reason;
            label1.Text = "姓名：" + dname + System.Environment.NewLine + System.Environment.NewLine +
                          "编号：" + did + System.Environment.NewLine + System.Environment.NewLine +
                          "请假开始时间：" + leftstartTime+ System.Environment.NewLine + System.Environment.NewLine +
                          "请假结束时间：" + leftendTime + System.Environment.NewLine + System.Environment.NewLine +
                          "请假原因："+reason;
        }


        DataTable Fill(string s)
        {
            DataTable res = new DataTable();
            try
            {
                con.ConnectionString = strConn;
                cmd.CommandText = s;
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                con.Open();
                sda.Fill(res);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                sda.Dispose();
                cmd.Dispose();
                con.Close();
            }

            return res;
        }
        int NonQuery(string s)
        {
            int res = -1;
            con.ConnectionString = strConn;
            cmd.CommandText = s;
            cmd.Connection = con;
            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                cmd.Dispose();
                con.Close();

            }
            /* con.Open();
             res = cmd.ExecuteNonQuery();*/
            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int res1 = NonQuery("insert into vacationinfo(did,lstarttime,lendtime,lstatus,reason) values('" + did + "','" + leftstartTime + "','" + leftendTime + "','" + lstatus + "','"+reason+"')");
            MessageBox.Show("申请提交成功！");
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
