using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Hospital
{
    public partial class UCShowAppointment : UCBase
    {
        doctor doc;
        int row, column;
        string pid,rid;
        string status;
        public UCShowAppointment()
        {
            InitializeComponent();
        }
        public UCShowAppointment(doctor doc)
        {
            InitializeComponent();
            this.doc = doc;
            FreshDataGridView();
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            button1.Enabled = false;
        }
        public string GetPname(string pid)
        {
            string res;
            DataTable dt = new DataTable();
            dt = Fill(@"select * from patientinfo where pid='" + pid + "'");
            res = dt.Rows[0]["pname"].ToString();
            return res;
        }
        public string GetDname(string did)
        {
            string res;
            DataTable dt = new DataTable();
            dt = Fill(@"select * from doctorinfo where doctorinfo.did='" + did + "'");
            res = dt.Rows[0]["dname"].ToString();
            return res;
        }
        private void FreshDataGridView()
        {
            DataTable dt = new DataTable();
            dataGridView1.Columns.Clear();
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns.Add("0", "患者ID");
            dataGridView1.Columns.Add("1", "患者姓名");
            dataGridView1.Columns.Add("2", "预约医生编号");
            dataGridView1.Columns.Add("3", "预约医生姓名");
            dataGridView1.Columns.Add("4", "预约时间");
            dataGridView1.Columns.Add("5", "预约号");
            dataGridView1.Columns.Add("6", "预约状态");
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 235;
            dataGridView1.Columns[5].Width = 133;
            dt = Fill("select * from reservationInfo where reservationInfo.did='" + doc.id + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((dt.Rows[i]["status"].ToString()).CompareTo("0") == 0)
                {
                    status = "待就诊";
                }
                else if ((dt.Rows[i]["status"].ToString()).CompareTo("1") == 0)
                {
                    status = "已就诊";
                }
                else if ((dt.Rows[i]["status"].ToString()).CompareTo("2") == 0)
                {
                    status = "未就诊";
                }
                string time = dt.Rows[i]["year"].ToString() + "-" + dt.Rows[i]["month"].ToString() + "-" + dt.Rows[i]["day"].ToString() + "-" + dt.Rows[i]["ampm"].ToString();
                dataGridView1.Rows.Add(dt.Rows[i]["pid"], GetPname(dt.Rows[i]["pid"].ToString()), dt.Rows[i]["did"], GetDname(dt.Rows[i]["did"].ToString()), time, dt.Rows[i]["rid"], status.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals("已就诊"))
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }




        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = "";
            row = e.RowIndex;
            column = e.ColumnIndex;
            string status;
            pid = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string TotalTime = dataGridView1.Rows[row].Cells[4].Value.ToString();
            rid = dataGridView1.Rows[row].Cells[5].Value.ToString();
            string[] time = Regex.Split(TotalTime, "-");
            year = time[0];
            month = time[1];
            day = time[2];
            ampm = time[3];
 
            comboBox1.Enabled = true;
            button1.Enabled = true;
            status = dataGridView1.Rows[row].Cells[6].Value.ToString();
            //MessageBox.Show(pid+" "+day);
                
            comboBox1.Text = status;
            if (status.Equals("已就诊"))
            {
                dt = Fill("select * from reservationInfo where reservationInfo.did='" + doc.id + "'and reservationInfo.pid='" + pid + "'and reservationInfo.rid='" + rid + "'and reservationInfo.year='" + year + "'and reservationInfo.month='" + month + "'and reservationInfo.day='" + day + "'and reservationInfo.ampm='" + ampm + "'");
                if (dt.Rows.Count == 0)
                {
                    textBox1.Text = "无";
                }
                else
                {
                    textBox1.Text = dt.Rows[0]["dAdvice"].ToString();
                }
                textBox1.Enabled = true;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string status1 = comboBox1.Text;
            string dAdvice = textBox1.Text;
            if(status1.Equals("已就诊"))
            {
                status1 = "1";
            }
            if (status1.Equals("未就诊"))
            {
                status1 = "2";
            }
            if (status1.Equals("未就诊"))
            {
                status1 = "0";
            }
            int res=NonQuery("update reservationInfo set status='"+status1+"',dAdvice='"+dAdvice+"' where reservationInfo.did='" + doc.id + "'and reservationInfo.pid='" + pid + "'and reservationInfo.rid='" + rid + "'and reservationInfo.year='" + year + "'and reservationInfo.month='" + month + "'and reservationInfo.day='" + day + "'and reservationInfo.ampm='" + ampm + "'");
            MessageBox.Show("保存成功");
            FreshDataGridView();
        }
    }
}
