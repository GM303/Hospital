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
    public partial class UCappointment : UCBase
    {
        string did;
        int row, column;
        RadioButton[] rb = new RadioButton[22];
        patient pa;
        public UCappointment()
        {
            InitializeComponent();
            MyInit();
        }
        public UCappointment(patient pa)
        {
            InitializeComponent();
            MyInit();
            this.pa = pa;
        }
        private void MyInit()
        {
            for (int i = 0; i < 22; i++)
            {
                rb[i] = new RadioButton();
            }
            FreshTreeView();
        }
        private void FreshTreeView()
        {
            treeView1.Nodes.Clear();
            DataTable dt = new DataTable();
            dt = Fill("select deptname from departmentInfo");
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                treeView1.Nodes.Add(dt.Rows[i]["deptname"].ToString().Trim());
            }
            foreach (TreeNode tn in treeView1.Nodes)
            {
                dt = Fill("select * from doctorInfoview,departmentInfo where doctorInfoview.deptid=departmentInfo.deptid and departmentInfo.deptname='" + tn.Text + "'");
                if (dt == null)
                {
                    MessageBox.Show("null");
                    break;
                }
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    tn.Nodes.Add(dt.Rows[i]["did"].ToString(), dt.Rows[i]["dname"].ToString().Trim());
                }
            }
        }
        private int GetNumRest(string s)//查询剩余号码
        {
            //     MessageBox.Show(s + "!" + s.Length);
            if (s.Length == 0) return -1;
            int res = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '0') ++res;
            }
            return res;
        }
        private int GetNextNum(string s)//查询下一个号码 0:无号码 
        {
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '0')
                    return i + 1;
            }
            return 0;
        }
        private string UpdateNextNum(string s)//将状态s更改为预约一个号码后的状态
        {
            char[] res = new char[s.Length];
            for (int i = 0; i < s.Length; ++i)
            {
                res[i] = s[i];
                if (res[i] == '0')
                {
                    res[i] = '1';
                    break;
                }
            }
            return res.ToString();
        }
        private string GetStatus(string year, string month, string day, string ampm, string did)
        {
            DataTable dt = new DataTable();
            dt = Fill(@"select status from numSourceInfo where numSourceInfo.year='" + year + "' and numSourceInfo.month='" + month + "' and numSourceInfo.day='" + day + "' and numSourceInfo.ampm='" + ampm + "' and numSourceInfo.did='" + did + "'");

            if (dt.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0]["status"].ToString();
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            did = e.Node.Name;//给选择号源时段使用
            if (e.Node.Level == 1)
            {
                label1.Text = e.Node.Name;
                label2.Text = e.Node.Text;
                FreshDataGridView(label1.Text);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            column = e.ColumnIndex;
            if (row < 0) return;
            FreshRButton();
        }
        private void FreshDataGridView(string did)
        {
            // did = e.Node.Name;//给选择号源时段使用
            DataSet ds = new DataSet("days");
            DataTable dt = new DataTable("num");
            ds.Tables.Add(dt);
            dt.Columns.Add("Monday", typeof(System.String));
            dt.Columns.Add("Tuesday", typeof(System.String));
            dt.Columns.Add("Wednesday", typeof(System.String));
            dt.Columns.Add("Thursday", typeof(System.String));
            dt.Columns.Add("Friday", typeof(System.String));
            dt.Columns.Add("Saturday", typeof(System.String));
            dt.Columns.Add("Sunday", typeof(System.String));
            DateTime now;
            for (int i = 0; i < 2; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }

            //修改单元格
            now = dateTimePicker1.Value;
            for (int i = 0; i < 7; ++i)
            {
                now = now.AddDays(1);
                int restAM = GetNumRest(GetStatus(now.Year.ToString(), now.Month.ToString(), now.Day.ToString(), "am", label1.Text));
                int restPM = GetNumRest(GetStatus(now.Year.ToString(), now.Month.ToString(), now.Day.ToString(), "pm", label1.Text));
                if (restAM >= 0)
                {
                    dt.Rows[0][now.DayOfWeek.ToString()] = "剩余" + restAM + "个号";
                }
                else
                {
                    dt.Rows[0][now.DayOfWeek.ToString()] = "";
                }
                if (restPM >= 0)
                {
                    dt.Rows[1][now.DayOfWeek.ToString()] = "剩余" + restPM + "个号";
                }
                else
                {
                    dt.Rows[1][now.DayOfWeek.ToString()] = "";
                }

            }
            dataGridView1.DataSource = ds.Tables["num"];           
            //修改标题
            now = dateTimePicker1.Value;
            for (int i = 0; i < 7; ++i)
            {
                now = now.AddDays(1);
                dataGridView1.Columns[now.DayOfWeek.ToString()].HeaderCell.Value = now.Year.ToString() + "-" + now.Month.ToString() + "-" + now.Day.ToString() + System.Environment.NewLine + now.DayOfWeek.ToString();
            }
            dataGridView1.Rows[0].HeaderCell.Value = "上午";
            dataGridView1.Rows[1].HeaderCell.Value = "下午";
            //修改单元格大小
            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Columns[i].Width = (dataGridView1.Width - dataGridView1.RowHeadersWidth) / 7;
            }
            for (int i = 0; i < 2; i++)
            {
                dataGridView1.Rows[i].Height = (dataGridView1.Height - dataGridView1.ColumnHeadersHeight) / 2 - 1 * dataGridView1.Rows.Count ;
            }      
        }
        private void FreshRButton()
        {
            DateTime time = new DateTime(2018, 12, 6, 8, 00, 00);
            string tmp = dataGridView1.Columns[column].HeaderText;
            string[] headtime = Regex.Split(tmp, System.Environment.NewLine);
            string[] now = Regex.Split(headtime[0], "-");
            if (row == 1)
            {
                time = time.AddHours(6);
            }
            Point startP = new Point(dataGridView1.Location.X + dataGridView1.Width + 10, dataGridView1.Location.Y);
            Point nowP = startP;
            for (int i = 0; i < 22; i++)
            {
                if (i != 0 && i % 2 == 0)
                {
                    nowP.Y += 40;
                    nowP.X -= 220;
                }
                rb[i].Name = "rb" + i.ToString();
                rb[i].Location = nowP;
                rb[i].Text = (i + 1).ToString() + "号 " + time.Hour.ToString() + " : " + time.Minute.ToString();
                if (time.Minute == 0) rb[i].Text += "0";
                rb[i].Checked = false;
                this.Controls.Add(rb[i]);
                nowP.X += 110;
                time = time.AddMinutes(10);
            }

            //查询已预约时段，并对已预约时段进行取消显示
            DataTable dt = new DataTable();
            //将datagridview的列标题时间传入全局变量
            year = now[0];
            month = now[1];
            day = now[2];
            string status;
            if (row == 0)
            {
                ampm = "am";
            }
            else
            {
                ampm = "pm";
            }
            dt = Fill(@"select * from numSourceInfo where numSourceInfo.year=" + year + " and numSourceInfo.month=" + month
                     + "and numSourceInfo.day=" + day + "and numSourceInfo.ampm='" + ampm + "'and numSourceInfo.did=" + did);
            //     MessageBox.Show(year + "-" + month + "-" + day + "-" + ampm + "-" + did);
            status = dt.Rows[0]["status"].ToString();

            for (int i = 0; i < 22; i++)
            {
                if (status[i] == '1')
                    rb[i].Enabled = false;
                else
                    rb[i].Enabled = true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            string nid = "";
            for (int i = 0; i < 22; i++)
            {
                if (rb[i].Checked == true)
                {
                    nid = (i + 1).ToString();
                }
            }
            MessageBox.Show(name+id);
            appointmentInfo appinfo = new appointmentInfo(pa.name, pa.id, label1.Text, label2.Text, account, dt, ampm, nid);
            appinfo.ShowDialog();
            FreshRButton();
            FreshDataGridView(label1.Text);
        }
    }
}
