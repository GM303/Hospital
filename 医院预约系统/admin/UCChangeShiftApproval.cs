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
    public partial class UCChangeShiftApproval : UCBase
    {
        int row;
        public UCChangeShiftApproval()
        {
            InitializeComponent();
            FreshDataGridView();
        }
        public string GetDname(string did)
        {
            string res;
            DataTable dt = new DataTable();
            dt = Fill(@"select * from doctorinfo where doctorinfo.did='" + did + "'");
            res = dt.Rows[0]["dname"].ToString();
            return res;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "button")
            {
                row = e.RowIndex;
                id = dataGridView1.Rows[row].Cells[0].Value.ToString();
                int status = Convert.ToInt32(dt.Rows[row]["status"]);
                year = dt.Rows[row]["year"].ToString();
                month = dt.Rows[row]["month"].ToString();
                day = dt.Rows[row]["day"].ToString();
                ampm = dt.Rows[row]["ampm"].ToString();
                VacationApprovalInfo V = new VacationApprovalInfo();
                V.status = status;
                V.ShowDialog();
                int res = NonQuery("update vacationInfo set status=" + V.status + " where  did='" + id + "'and year='" + year + "'and month='" + month + "' and day='" + day + "' and ampm='" + ampm + "'");
                FreshDataGridView();
            }
        }
        public void FreshDataGridView()
        {
            dataGridView1.Columns.Clear();
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.HeaderText = "";
            button.Text = "审批";
            button.Name = "button";
            dataGridView1.ReadOnly = true;
            button.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add("0", "医生ID");
            dataGridView1.Columns.Add("1", "医生姓名");
            dataGridView1.Columns.Add("2", "调班前时间");
            dataGridView1.Columns.Add("3", "调班后时间");
            dataGridView1.Columns.Add("4", "调班原因");
            dataGridView1.Columns.Add("5", "调班申请状态");
            dataGridView1.Columns.Add(button);
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 235;
            dataGridView1.Columns[5].Width = 133;
            dt = Fill(@"select * from changeSheduleInfo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (Convert.ToInt32(dt.Rows[i]["status"]) == 0)
                {
                    status = "待通过";
                }
                else if (Convert.ToInt32(dt.Rows[i]["status"]) == 1)
                {
                    status = "通过";
                }
                else if (Convert.ToInt32(dt.Rows[i]["status"]) == 2)
                {
                    status = "不通过";
                }
                string starttime = dt.Rows[i]["year"].ToString() + "-" + dt.Rows[i]["month"].ToString() + "-" + dt.Rows[i]["day"].ToString() + dt.Rows[i]["ampm"].ToString();
                string endtime = dt.Rows[i]["year1"].ToString() + "-" + dt.Rows[i]["month1"].ToString() + "-" + dt.Rows[i]["day1"].ToString() + dt.Rows[i]["ampm1"].ToString();
                dataGridView1.Rows.Add(dt.Rows[i]["did"], GetDname(dt.Rows[i]["did"].ToString()), starttime, endtime, dt.Rows[i]["reason"], status.ToString());
            }
        }
    }
}
