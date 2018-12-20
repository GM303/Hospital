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
    public partial class UCShowAppointment : UCBase
    {
        doctor doc;
        public UCShowAppointment()
        {
            InitializeComponent();
        }
        public UCShowAppointment(doctor doc)
        {
            InitializeComponent();
            this.doc = doc;
            FreshCList();
        }
        public string GetPname(string pid)
        {
            string res;
            DataTable dt = new DataTable();
            dt = Fill(@"select * from patientinfo where pid='" + pid + "'");
            res = dt.Rows[0]["pname"].ToString();
            return res;
        }
        private void FreshCList()
        {
            listBox1.Items.Clear();
            DataTable dt = new DataTable();
            dt = Fill("select * from reservationInfo where reservationInfo.did='" + doc.id + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime time = DateTime.Now;
                if(time<=new DateTime(Convert.ToInt32(dt.Rows[i]["year"].ToString()),Convert.ToInt32(dt.Rows[i]["month"].ToString()),Convert.ToInt32(dt.Rows[i]["day"].ToString())))
                {
                    if (dt.Rows[i]["ampm"].ToString().Equals("am"))
                    {
                        listBox1.Items.Add("患者ID:" + dt.Rows[i]["pid"].ToString() +
                                          "  患者姓名:" + GetPname(dt.Rows[i]["pid"].ToString()) +
                                          "  预约号:" + dt.Rows[i]["rid"].ToString() +
                                          "  时间:" + dt.Rows[i]["year"].ToString() + "年" + dt.Rows[i]["month"].ToString() + "月" + dt.Rows[i]["day"].ToString() + "日 上午");

                    }
                    else
                    {
                        listBox1.Items.Add("患者ID:" + dt.Rows[i]["pid"].ToString() +
                                     "  患者姓名:" + GetPname(dt.Rows[i]["pid"].ToString()) +
                                     "  预约号:" + dt.Rows[i]["rid"].ToString() +
                                     "  时间:" + dt.Rows[i]["year"].ToString() + "年" + dt.Rows[i]["month"].ToString() + "月" + dt.Rows[i]["day"].ToString() + "日 下午");


                    }
                }

            }
        }
    }
}
