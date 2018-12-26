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
    public partial class vacationinfo : FormBase
    {
        string did,reason,year,month,day,year1,month1,day1,ampm,ampm1;
        UCVacation UCVacation;
        public vacationinfo(UCVacation UCVacation)
        {
            InitializeComponent();
            this.UCVacation = UCVacation;
            this.did = UCVacation.id;
            this.year = UCVacation.year;
            this.month = UCVacation.month;
            this.day = UCVacation.day;
            this.ampm = UCVacation.ampm;
            this.year1 = UCVacation.year1;
            this.month1 = UCVacation.month1;
            this.day1 = UCVacation.day1;
            this.ampm1 = UCVacation.ampm1;
            this.reason = UCVacation.reason;
            label1.Text =  "请假开始时间：" + year+"-"+month+"-"+day+"-"+ampm + System.Environment.NewLine + System.Environment.NewLine +
                          "请假结束时间：" + year1+"-"+month1+"-"+day1+"-"+ampm1 + System.Environment.NewLine + System.Environment.NewLine +
                          "请假原因：" + reason;

        }
        private void button1_Click(object sender, EventArgs e)
        {
        //    string s = "insert into vacationinfo(did,year,month,day,ampm,year1,month1,day1,ampm1,reason) values('" + id + "','" + year + "','" + month + "','" + day + "','" + ampm + "','" + year1 + "','" + month1 + "','" + day1 + "','" + ampm1 + "','" + reason + "')";
            int res1=NonQuery("insert into vacationinfo(did,year,month,day,ampm,year1,month1,day1,ampm1,reason) values('" + did + "','" + year + "','" + month + "','" + day + "','" + ampm + "','" + year1 + "','" + month1 + "','" + day1 + "','" + ampm1 +"','"+reason+ "')");
            MessageBox.Show("申请提交成功！");
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
