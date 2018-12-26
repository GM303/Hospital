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
    public partial class UCChangeShifts : UCBase
    {
        string id;
        string year, month, day, year1, month1, day1;
        string ampm, ampm1;
        doctor doctor;
        public UCChangeShifts(doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
            id = doctor.id;
            comboBox1.Text = "上午";
            comboBox2.Text = "上午";
            label4.Text = "";
       //     button1.Enabled = false;
        }
        private void ValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("上午"))
            {
                ampm = "am";
            }
            else
            {
                ampm = "pm";
            }
            if (comboBox2.Text.Equals("上午"))
            {
                ampm1 = "am";
            }
            else
            {
                ampm1 = "pm";
            }
            year = dateTimePicker1.Value.Year.ToString();
            year1 = dateTimePicker2.Value.Year.ToString();
            month = dateTimePicker1.Value.Month.ToString();
            month1 = dateTimePicker2.Value.Month.ToString();
            day = dateTimePicker1.Value.Day.ToString();
            day1 = dateTimePicker2.Value.Day.ToString();
            if (dateTimePicker1.Value.Equals(dateTimePicker2.Value) && ampm.Equals(ampm1))
            {
                label4.Text = "调班前后时间不能一样";
                button1.Enabled = false;
                return;
            }

            dt = Fill("select * from ScheduleInfoView where did='" + id + "' and year='" + year + "' and month='" + month + "' and day='" + day + "' and ampm='" + ampm + "'");
            if (dt.Rows.Count == 0)
            {
                label4.Text = "调班前的时间段没有排班";
                button1.Enabled = false;
                return;
            }
            dt = Fill("select * from ScheduleInfoView where did='" + id + "' and year='" + year1 + "' and month='" + month1 + "' and day='" + day1 + "' and ampm='" + ampm1 + "'");
            if (dt.Rows.Count > 0)
            {
                label4.Text = "调班后的时间段有排班";
                button1.Enabled = false;
                return;
            }
            label4.Text = "";
            button1.Enabled = true;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            NonQuery("insert into changeSheduleInfo(did,year,month,day,ampm,year1,month1,day1,ampm1) values('" + id+"','"+year+"','"+month+"','"+day+"','"+ampm+"','"+year1+"','"+month1+"','"+day1+"','"+ampm1+"')");
            MessageBox.Show("提交成功");
        }

    }
}
