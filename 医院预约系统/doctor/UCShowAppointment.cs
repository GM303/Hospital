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
        int row, column;
        public UCShowAppointment()
        {
            InitializeComponent();
        }
        public UCShowAppointment(doctor doc)
        {
            InitializeComponent();
            this.doc = doc;
            FreshDataGridView();
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            column = e.ColumnIndex;

        }
    }
}
