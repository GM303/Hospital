using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Hospital
{
    class AutoUpdateNumberSource
    {
        static public SqlConnection con = new SqlConnection();
        static public SqlCommand cmd = new SqlCommand();
        static public SqlDataAdapter sda = new SqlDataAdapter();
        static public DataTable dt = new DataTable();
        static public string strConn = @"Data Source=(local);Initial Catalog=Hospital;Integrated Security=True";

        //static public string strConn = @"Data Source=DESKTOP-1OT1J4U;Initial Catalog=Hospital;Integrated Security=True";
        //static public string strConn = @"Data Source=127.0.0.1;Initial Catalog=Hospital;Integrated Security=True";
        ///public string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Hospital.mdf;Integrated Security=True;Connect Timeout=30";
        //public string id, name, account, deptid, deptname, status;
        //public string year, month, day, ampm;
        private static DataTable Fill(string s)
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
        static public int NonQuery(string s)
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
        static public void run()
        {
            DataTable dt = new DataTable();
            DataTable dt0 = new DataTable();
            string[] dayofweek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string year, month, day, did;
            string[] ampmArr = { "am", "pm" };
            dt = Fill("select * from scheduleInfo");
            DateTime now;
            now = DateTime.Now;
            for (int i = 0; i < 7; ++i)
            {
                now = now.AddDays(1);
                year = now.Year.ToString();
                month = now.Month.ToString();
                day = now.Day.ToString();
                int index = 0;
                foreach (string ampm in ampmArr)
                {

                    for (int j = 0; j < dt.Rows.Count; ++j)
                    {
                        did = dt.Rows[j]["did"].ToString();
                        dt0 = Fill(@"select status from numSourceInfo where numSourceInfo.year='" + year + "' and numSourceInfo.month='" + month + "' and numSourceInfo.day='" + day + "' and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did='" + did + "'");
                        if (dt0.Rows.Count == 0)
                        {
                            string tmp = dt.Rows[j]["maxnum"].ToString();
                            string[] maxnum = Regex.Split(tmp, "-");
                            int p = 0;
                            for (int k = 0; k < dayofweek.Length; ++k)
                            {
                                if (dayofweek[k].Equals(now.DayOfWeek.ToString()))
                                {
                                    p = k * 2 + index;/*
                                    if (day.Equals("21"))
                                    {
                                        MessageBox.Show("!" + maxnum[p] + " " + p.ToString());
                                        MessageBox.Show(now.DayOfWeek.ToString() + " " + dayofweek[k] + " " + p.ToString());
                                    }*/
                                }
                            }
                            if (Convert.ToInt32(maxnum[p]) > 0)
                            {
                                string status = "";
                                for (int k = 0; k < Convert.ToInt32(maxnum[p]); ++k)
                                {
                                    status += '0';
                                }
                                int res = NonQuery("insert into numSourceInfo(year,month,day,ampm,did,status) values('" + year + "','" + month + "','" + day + "','" + ampm + "','" + did + "','" + status + "')");
                            }
                        }
                    }
                    index++;
                }

            }
            DeleteVacation();

        }
        static private void UpdateStatus(string year, string month, string day, string ampm, string did, string status)
        {

            NonQuery(@"update numSourceInfo set status='" + status + "' where numSourceInfo.year=" + year + " and numSourceInfo.month=" + month + " and numSourceInfo.day=" + day + " and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did=" + did);

        }
        static private string GetStatus(string year, string month, string day, string ampm, string did)
        {
            DataTable dt = new DataTable();
            dt = Fill(@"select status from numSourceInfo where numSourceInfo.year='" + year + "' and numSourceInfo.month='" + month + "' and numSourceInfo.day='" + day + "' and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did='" + did + "'");
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["status"].ToString();
            }
        }
        static public void DeleteVacation()
        {
            dt = Fill("select * from vacationInfo where lstatus='" + "1" + "'");
            DateTime start, end;
            for (int i = 0; i < dt.Rows.Count;++i)
            {
                string tmp = dt.Rows[i]["lstarttime"].ToString();
                string[] time = Regex.Split(tmp, "-");
                tmp = dt.Rows[i]["lstarttime"].ToString();
                time = Regex.Split(tmp, "-");
                start = new DateTime(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]));
                tmp = dt.Rows[i]["lendtime"].ToString();
                time = Regex.Split(tmp, "-");
                end = new DateTime(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]));
                while(start<=end)
                {
                    string year = start.Year.ToString();
                    string month = start.Month.ToString();
                    string day = start.Day.ToString();
                    NonQuery("delete from numSourceInfo where year='" + year + "' and month='" + month + "' and day='" + day + "' and did='" + dt.Rows[i]["did"].ToString()+ "'");
                    NonQuery("delete from reservationInfo where year='" + year + "' and month='" + month + "' and day='" + day + "' and did='" + dt.Rows[i]["did"].ToString() + "'");
                    start=start.AddDays(1);
                }
            }
        }
        static public void run(string did)
        {
            run();
            DataTable dt = new DataTable();
            DataTable dt0 = new DataTable();
            string[] dayofweek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string year, month, day;
            string[] ampmArr = { "am", "pm" };
            dt = Fill("select * from scheduleInfo where did='"+did+"'");
            DateTime now;
            now = DateTime.Now;
            for (int i = 0; i < 7; ++i)
            {
                now = now.AddDays(1);
                year = now.Year.ToString();
                month = now.Month.ToString();
                day = now.Day.ToString();
                int index = 0;
                foreach (string ampm in ampmArr)
                {

                    for (int j = 0; j < dt.Rows.Count; ++j)
                    {
                        did = dt.Rows[j]["did"].ToString();
                        dt0 = Fill(@"select status from numSourceInfo where numSourceInfo.year='" + year + "' and numSourceInfo.month='" + month + "' and numSourceInfo.day='" + day + "' and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did='" + did + "'");
                        string tmp = dt.Rows[j]["maxnum"].ToString();
                        string[] maxnum = Regex.Split(tmp, "-");
                        int p = 0;
                        for (int k = 0; k < dayofweek.Length; ++k)
                        {
                            if (dayofweek[k].Equals(now.DayOfWeek.ToString()))
                            {
                                p = k * 2 + index;
                            }
                        }
                        if (Convert.ToInt32(maxnum[p]) == 0)
                        {
                            int res = NonQuery("delete from numSourceInfo where numSourceInfo.year='" + year + "' and numSourceInfo.month='" + month + "' and numSourceInfo.day='" + day + "' and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did='" + did + "'");
                        }
                        else
                        {
                            string status;
                            string newStatus = "";
                            status = GetStatus(year, month, day, ampm, did);
                            if(Convert.ToInt32(maxnum[p])>status.Length)
                            {
                                for(int k=0;k<status.Length;++k)
                                {
                                    newStatus += status[k];
                                }
                                for (int k = status.Length; k < Convert.ToInt32(maxnum[p]); ++k)
                                {
                                    newStatus += "0";
                                }
                            }
                            if (Convert.ToInt32(maxnum[p]) < status.Length)
                            {
                                for (int k = 0; k < Convert.ToInt32(maxnum[p]); ++k)
                                {
                                    newStatus += status[k];
                                }
                                for(int k= Convert.ToInt32(maxnum[p]); k<status.Length;++k)
                                {
                                    NonQuery("delete from reservationInfo where year='" + year + "' and month='" + month + "' and day='" + day + "' and ampm='" + ampm + "' and did='" + did + "' and rid='" + (k+1).ToString()+"'");
                                }
                            }
                            UpdateStatus(year, month, day, ampm, did, newStatus);
                        }
                    }
                    index++;
                }

            }
            DeleteVacation();

        }
    }
}
