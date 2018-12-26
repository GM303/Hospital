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
        string lstarttime, lendtime;
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
            string isApprova;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "button")
            {
                row = e.RowIndex;
                id = dataGridView1.Rows[row].Cells[0].Value.ToString();
                name = dataGridView1.Rows[row].Cells[1].Value.ToString();
                lstarttime = dataGridView1.Rows[row].Cells[2].Value.ToString();
                lendtime = dataGridView1.Rows[row].Cells[3].Value.ToString();
                dt = Fill("select * from vacationInfo where  did='" + id + "'and lstarttime='" + lstarttime + "'and lendtime='" + lendtime + "'");
                isApprova = dt.Rows[0]["lstatus"].ToString();
                ChangeShiftApprovalInfo V = new ChangeShiftApprovalInfo(id, name, lstarttime, lendtime, isApprova);
                V.ShowDialog();
                int res = NonQuery("update vacationInfo set lstatus='" + V.status + "' where  did='" + id + "'and lstarttime='" + lstarttime + "'and lendtime='" + lendtime + "'");
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
            dataGridView1.Columns.Add("2", "请假开始时间");
            dataGridView1.Columns.Add("3", "请假结束时间");
            dataGridView1.Columns.Add("4", "请假原因");
            dataGridView1.Columns.Add("5", "请假申请状态");
            dataGridView1.Columns.Add(button);
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 235;
            dataGridView1.Columns[5].Width = 133;
            dt = Fill(@"select * from vacationInfo");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((dt.Rows[i]["lstatus"].ToString()).CompareTo("0") == 0)
                {
                    status = "待通过";
                }
                else if ((dt.Rows[i]["lstatus"].ToString()).CompareTo("1") == 0)
                {
                    status = "通过";
                }
                else if ((dt.Rows[i]["lstatus"].ToString()).CompareTo("2") == 0)
                {
                    status = "不通过";
                }
                // MessageBox.Show(dt.Rows[i]["did"].ToString()+"  "+i.ToString());
                dataGridView1.Rows.Add(dt.Rows[i]["did"], GetDname(dt.Rows[i]["did"].ToString()), dt.Rows[i]["lstarttime"], dt.Rows[i]["lendtime"], dt.Rows[i]["reason"], status.ToString());
            }
        }


    }
}
