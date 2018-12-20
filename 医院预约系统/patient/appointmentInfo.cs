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
    public partial class appointmentInfo : FormBase
    {
        string pname, pid, did, dname, paccount, rid;
        DateTime time;
        
        public appointmentInfo(string pname, string pid, string did, string dname, string paccount, DateTime time, string ampm, string rid)//nid为预约号
        {
            InitializeComponent();
            string str = "";
            str = "姓名：" + pname + System.Environment.NewLine + System.Environment.NewLine +
                "预约医生：" + dname + System.Environment.NewLine + System.Environment.NewLine +
                "预约时间：" + time.Year + "-" + time.Month + "-" + time.Day;
            if (ampm == "am")
                str += "上午" + System.Environment.NewLine + System.Environment.NewLine;
            else
                str += "下午" + System.Environment.NewLine + System.Environment.NewLine;
            str += "预约号：" + rid + "号";
            label1.Text = str;
            this.time = time;
            this.pname = pname;
            this.pid = pid;
            this.did = did;
            this.dname = dname;
            this.paccount = paccount;
            this.ampm = ampm;
            this.rid = rid;

        }
        public appointmentInfo()
        {
            InitializeComponent();
        }


        string GetNextStatus(string status,string rid)
        {
            string res="";
            for(int i=0;i<status.Length;++i)
            {
                if(i==Convert.ToInt32(rid)-1)
                {
                    res += '1';
                }
                else
                {
                    res += status[i];
                }
            }
            return res;
            
        }
    
        private void UpdateStatus(string year, string month, string day, string ampm, string did,string rid)
        {
            string status = GetStatus(year, month,day, ampm, did);
            string res = GetNextStatus(status, rid);
            NonQuery(@"update numSourceInfo set status='"+res+"' where numSourceInfo.year=" + year + " and numSourceInfo.month=" + month + " and numSourceInfo.day=" + day + " and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did=" + did);

        }
        private string GetStatus(string year, string month, string day, string ampm, string did)
        {
            DataTable dt = new DataTable();
            dt = Fill(@"select status from numSourceInfo where numSourceInfo.year=" + year + " and numSourceInfo.month=" + month + " and numSourceInfo.day=" + day + " and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did=" + did);
            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["status"].ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = time.Year.ToString() + time.Month.ToString() + time.Day.ToString();
            if (ampm == "am")
            {
                id = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + "0" + did + rid;
            }
            else
            {
                id = time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + "1" + did + rid;
            }
            dt = Fill("select * from reservationInfo where reservationInfo.pid='" + pid + "' and reservationInfo.year='" + time.Year + "'and reservationInfo.month='" + time.Month+ "'and reservationInfo.day='" + time.Day + "'and reservationInfo.ampm='" + ampm + "'");
        //    MessageBox.Show(dt.Rows.Count.ToString());
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("您在此时间段由预约，请勿重复预约！");
            }
            else
            {
           //     MessageBox.Show("insert into reservationInfo(id,pid,did,rid,year,month,day) values ('" + id + "','" + pid + "','" + did + "','" + rid + "','" + time.Year.ToString() + "','" + time.Month.ToString() + "','" + time.Day.ToString() + "')");
                UpdateStatus(time.Year.ToString(), time.Month.ToString(), time.Day.ToString(), ampm, did, rid);
                int res = NonQuery("insert into reservationInfo(id,pid,did,rid,year,month,day,ampm) values ('" + id + "','" + pid + "','" + did + "','" + rid + "','" + time.Year.ToString() + "','" + time.Month.ToString() + "','" + time.Day.ToString() + "','" + ampm + "')");
                MessageBox.Show("预约成功");
            }
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
