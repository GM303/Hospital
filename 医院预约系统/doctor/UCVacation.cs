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
    public partial class UCVacation : UCBase
    {
        public string year, month, day, year1, month1, day1,ampm, ampm1,reason;
        doctor D;
        public UCVacation()
        {
            InitializeComponent();
        }
        public UCVacation(doctor D)
        {
            InitializeComponent();
            this.D = D;
            this.id = D.id;
            this.name = D.name;
            comboBox1.Text = "上午";
            comboBox2.Text = "上午";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string leftStartTime ="";
            string leftEndTime = "";
            DateTime now = DateTime.Today;
            reason = textBox1.Text;
           // now = DateTime.Now;
            if ((dateTimePicker1.Value.Date >= now)&&(dateTimePicker2.Value.Date >= dateTimePicker1.Value.Date))
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
                leftStartTime = dateTimePicker1.Value.Year.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString();
                leftEndTime = dateTimePicker2.Value.Year.ToString() + "-" + dateTimePicker2.Value.Month.ToString() + "-" + dateTimePicker2.Value.Day.ToString();
                vacationinfo vctinfo = new vacationinfo(this);
                vctinfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("请输入正确的请假时间！");
                dateTimePicker1.Value = now;
                dateTimePicker2.Value = dateTimePicker1.Value;
            }

        }

    }
}
