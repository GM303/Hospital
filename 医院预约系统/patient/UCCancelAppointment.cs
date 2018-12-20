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
    public partial class UCCancelAppointment : UCBase
    {
        patient pa;
        public UCCancelAppointment()
        {
            InitializeComponent();
            FreshCList();
        }
        public UCCancelAppointment(patient pa)
        {
            InitializeComponent();
            this.pa = pa;
            FreshCList();
        }
        private string GetStatus(string year, string month, string day, string ampm, string did)
        {
            DataTable dt = new DataTable();
            dt = Fill(@"select status from numSourceInfo where numSourceInfo.year='" + year + "' and numSourceInfo.month='" + month + "' and numSourceInfo.day='" + day + "' and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did='" + did + "'");
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0]["status"].ToString();
            }
            else
            {
                return "";
            }
        }
        private void UpdateStatus(string year, string month, string day, string ampm, string did, string rid)
        {
            string status = GetStatus(year, month, day, ampm, did);
            string res = "";
            for (int i = 0; i < status.Length; ++i)
            {
                if (i == Convert.ToInt32(rid) - 1)
                {
                    res += '0';
                }
                else
                {
                    res += status[i];
                }
            }
      //      MessageBox.Show(status + " " + rid + System.Environment.NewLine + res);
            NonQuery(@"update numSourceInfo set status='" + res + "' where numSourceInfo.year=" + year + " and numSourceInfo.month=" + month + " and numSourceInfo.day=" + day + " and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did=" + did);
        }
        public string GetDname(string did)
        {
            string res;
            DataTable dt = new DataTable();
            dt = Fill(@"select * from doctorinfo where doctorinfo.did='" + did + "'");
            res = dt.Rows[0]["dname"].ToString().Trim();
            return res;
        }
        private void FreshCList()
        {
            checkedListBox1.Items.Clear();
            DataTable dt = new DataTable();
            dt = Fill("select * from reservationInfo where reservationInfo.pid='" + pa.id + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if(dt.Rows[i]["ampm"].ToString().Equals("am"))
                {
                    checkedListBox1.Items.Add("医生ID:" + dt.Rows[i]["did"].ToString() +
                                      "  医生姓名:" + GetDname(dt.Rows[i]["did"].ToString()) +
                                      "  预约号:" + dt.Rows[i]["rid"].ToString() +
                                      "  时间:" + dt.Rows[i]["year"].ToString() + "年" + dt.Rows[i]["month"].ToString() + "月" + dt.Rows[i]["day"].ToString() + "日 上午");

                }
                else
                {
                    checkedListBox1.Items.Add("医生ID:" + dt.Rows[i]["did"].ToString() +
                                 "  医生姓名:" + GetDname(dt.Rows[i]["did"].ToString()) +
                                 "  预约号:" + dt.Rows[i]["rid"].ToString() +
                                 "  时间:" + dt.Rows[i]["year"].ToString() + "年" + dt.Rows[i]["month"].ToString() + "月" + dt.Rows[i]["day"].ToString() + "日 下午");


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DateTime time = new DateTime();
            time = DateTime.Now;
            dt = Fill("select * from reservationInfo where reservationInfo.pid='" + pa.id + "'");
            
            if(Convert.ToInt32 (dt.Rows[0]["year"])<=Convert.ToInt32(time.Year))
                if(Convert.ToInt32(dt.Rows[0]["month"]) <= Convert.ToInt32(time.Month) )
                    if(Convert.ToInt32(dt.Rows[0]["day"]) <= (Convert.ToInt32(time.Day)))
                    {
                         MessageBox.Show("无法取消此预约，请提前一天取消预约！");
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("确定取消此预约？", "取消申请", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (checkedListBox1.GetItemChecked(i))
                                {
                                    UpdateStatus(dt.Rows[i]["year"].ToString().Trim(), dt.Rows[i]["month"].ToString().Trim(), dt.Rows[i]["day"].ToString().Trim(), dt.Rows[i]["ampm"].ToString(), dt.Rows[i]["did"].ToString().Trim(), dt.Rows[i]["rid"].ToString().Trim());
                                    NonQuery("delete from reservationInfo where id='" + dt.Rows[i]["id"].ToString() + "'");
                                }
                            }
                            FreshCList();
                        }
                    }
           
        }
    }
}
