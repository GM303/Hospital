using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital
{

    public partial class UCBase : UserControl
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter sda = new SqlDataAdapter();
        public DataTable dt = new DataTable();
        public string strConn = @"Data Source=(local);Initial Catalog=Hospital;Integrated Security=True";
       
        //public string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Hospital.mdf;Integrated Security=True;Connect Timeout=30";
        public string id, name, account,deptid,deptname,status;
        public string year, month, day, ampm;
        public DataTable Fill(string s)
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
        public int NonQuery(string s)
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
                MessageBox.Show(e.Message);
            }
            cmd.Dispose();
            con.Close();
            return res;
        }
        public UCBase()
        {
            InitializeComponent();
        }
    }
}
