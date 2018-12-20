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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string leftStartTime ="";
            string leftEndTime = "";
            DateTime now = new DateTime(2018,1,1);
            string reason = textBox1.Text;
           // now = DateTime.Now;
            if ((dateTimePicker1.Value < now)||(dateTimePicker2.Value < dateTimePicker1.Value))
            {
                MessageBox.Show("请输入正确的请假时间！");
                dateTimePicker1.Value = now;
                dateTimePicker2.Value=dateTimePicker1.Value;
            }
            else
            {
                leftStartTime = dateTimePicker1.Value.Year.ToString() + "-" + dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Day.ToString();
                leftEndTime = dateTimePicker2.Value.Year.ToString() + "-" + dateTimePicker2.Value.Month.ToString() + "-" + dateTimePicker2.Value.Day.ToString();
                vacationinfo vctinfo = new vacationinfo(id,name,leftStartTime,leftEndTime,reason);
                vctinfo.ShowDialog();
            }
               
        }

    }
}
