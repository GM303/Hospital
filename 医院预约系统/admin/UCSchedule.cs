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
    public partial class UCschedule : UCBase
    {
        CheckBox[] CB = new CheckBox[60];
        Label[] LB = new Label[7];
        string sid;
        string[] week = { "monday", "tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        string[] weekChinese = { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日" };
        static DateTime time = DateTime.Now.AddDays(1);
        string DayOfWeek = time.DayOfWeek.ToString();
        public Boolean modifyPermission = true;//修改排班的权限
        public UCschedule(Boolean modifyPermission)
        {
            InitializeComponent();
            FreshTreeview();
            CreatCButton();
            button1.Visible = modifyPermission;
            this.modifyPermission = modifyPermission;
            //CreatCbButton();
        }
        private void FreshTreeview()
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
                dt = Fill("select * from doctorInfo,departmentInfo where doctorInfo.deptid=departmentInfo.deptid and departmentInfo.deptname='" + tn.Text + "'");
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
        public int GetCButtonStratLocation(string Week)
        {
            //MessageBox.Show(Week);
            int j = 0;
            for(int i=0;i<7;i++)
            {
                if(Week.Equals(week[i]))
                {
                    j=i;
                }
            }
            return j;
        }
        public void CreatLabel()
        {
            
           for(int i=0;i<7;i++)
           {
                LB[i] = new Label();
                LB[i].Text = weekChinese[i];
                LB[i].Font = new Font("宋体", 15);
                LB[i].Location = new Point(treeView1.Location.X + treeView1.Width + i*120, treeView1.Location.Y);
                LB[i].Visible = true;
                this.Controls.Add(LB[i]);
           }
            
        }
        public void CreatCButton()
        {
            int startLocation = GetCButtonStratLocation(DayOfWeek);
            Point startP = new Point(treeView1.Location.X + treeView1.Width + (startLocation%7)*120, treeView1.Location.Y+50);
            Point P = startP;
            string[] AP = { "上午", "下午" };
            for (int i = 0; i < 60; ++i)
            {
                for (int j = 0; j < 2; j++)
                {
                    CB[i + j] = new CheckBox();
                    CB[i + j].Font = new Font("宋体", 9);
                    CB[i + j].Visible = false;
                    CB[i + j].AutoSize = true;
                    CB[i + j].Text = time.Year.ToString() + "-" + time.Month.ToString() + "-" + time.Day.ToString() + "-" + AP[j];
                    P.Y = P.Y +j*20;
                    CB[i + j].Location = P;
                    if(j==1)
                    {
                        CB[i+j].ForeColor = Color.Red;
                    }
                    this.Controls.Add(CB[i+j]);
                    
                }
                i++;
                P.X += 120;
                P.Y -= 20;
                if (P.X >= treeView1.Location.X + treeView1.Width + 820)
                {
                    P.X = treeView1.Location.X + treeView1.Width;
                    P.Y += 100;
                }
                time = time.AddDays(1);
            }
        }
        public void FreshCButton()
        {
            dt = Fill(@"Select * from scheduleInfo where scheduleInfo.did= '"+id+"'");
            for(int i=0;i<60;i++)
            {
                CB[i].Visible = true;
                CB[i].Checked = false;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    string[] date = Regex.Split(CB[j].Text, "-");//checkbox.Text的日期
                   
                    if (date[3].Equals("上午"))
                    {
                        ampm = "0";
                    }
                    else
                    {
                        ampm = "1";
                    }
                    if (dt.Rows[i]["year"].ToString().Equals(date[0]) && dt.Rows[i]["month"].ToString().Equals(date[1]) && dt.Rows[i]["day"].ToString().Equals(date[2]) && dt.Rows[i]["ampm"].ToString().Equals(ampm))
                    {
                        CB[j].Checked = true;
                        break;
                    }

                }
            }
        }
        public string CreatSid(string did,string deptid,string year,string month,string day,string ampm)
        {
            return did + deptid + year + month + day + ampm+"0";//排班状态默认为0，即医生在岗允许发号
        }
        public string GetDeptid(string did)
        {
            dt = Fill("select * from doctorInfo where did='" + id+"'");
            return dt.Rows[0]["deptid"].ToString();
        }
        public void UpadteStatus()//更新排班
        {
            string[] date = new string[4];
            for (int i = 0; i < 60; i++)
            {
                //分割checkbox.Text（日期）
                date = Regex.Split(CB[i].Text, "-");
                if (date[3].Equals("上午"))
                {
                    ampm = "0";
                }
                else
                {
                    ampm = "1";
                }
                if (CB[i].Checked == true)//添加排班信息
                {
                    sid = CreatSid(id, deptid, date[0], date[1], date[2],ampm);
                    dt = Fill("select * from scheduleInfo where sid='"+sid+"'");
                    if(dt.Rows.Count==0)
                    {
                        int res = NonQuery("insert into scheduleInfo values('"+sid+ "','" + id + "','" + deptid + "','" + date[0] + "','" + date[1] + "','" + date[2] + "','" + ampm + "','0')");
                    }
                }
                else//删除排班信息
                {
                    int res = NonQuery("delete from scheduleInfo where did='"+id+"' and year='"+date[0]+"' and month='"+date[1]+"' and day='"+date[2]+"' and ampm='"+ampm+"'");
                    //MessageBox.Show(res.ToString());
                }
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            id = e.Node.Name;
            if (e.Node.Level == 1)
            {
                deptid = GetDeptid(id);
                //MessageBox.Show(deptid);
                FreshCButton();
                CreatLabel();
                //FreshCbButton();
                //CreatLable();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            UpadteStatus();
           // UpdateNumsource();
            MessageBox.Show("提交成功");
            FreshCButton();
           // FreshCbButton();
           // AutoUpdateNumberSource.run(doc.id);
        }
    }
}
