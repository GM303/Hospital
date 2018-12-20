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
        CheckBox[] CB = new CheckBox[30];
        string sid;
        //ComboBox[] CbB = new ComboBox[14];
        //Label[] Lb = new Label[14];
        public UCschedule()
        {
            InitializeComponent();
            FreshTreeview();
            CreatCButton();
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

        
        public void CreatCButton()
        {
            Point startP = new Point(treeView1.Location.X + treeView1.Width + 10, treeView1.Location.Y);
            Point P = startP;
            DateTime time = DateTime.Now;

            //string[] week = { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期天" };
            string[] AP = { "上午", "下午" };
            //int DayOfWeek = 0;
            for (int i = 0; i < 30; ++i)
            {
                CB[i] = new CheckBox();
                CB[i].Font = new Font("宋体", 15);
                CB[i].Visible = false;
                CB[i].AutoSize = true;
                time=time.AddDays(1);
                //设置上下午
                if(i%1==1)
                {
                    //MessageBox.Show(time.ToString());
                    CB[i].Text =time.Year.ToString() +"-"+ time.Month.ToString()+"-" + time.Day.ToString() + "-"+ AP[0];
                }
                else
                {
                    //MessageBox.Show(time.ToString());
                    CB[i].Text = time.Year.ToString() + "-" + time.Month.ToString() + "-" + time.Day.ToString() + "-" + AP[1];
                }

                //设置位置

                if ((i % 4 == 0)&&(i!=0))
                {
                    P.X = treeView1.Location.X + treeView1.Width ;
                    P.Y += treeView1.Location.Y +70;
                   
                    CB[i].Location = P;
                    this.Controls.Add(CB[i]);
                }
                if(i%4!=0||i==0)
                {
                    P.X = treeView1.Location.X + treeView1.Width + (i%4)*189;
                    //MessageBox.Show(P.ToString());
                    CB[i].Location = P;
                    this.Controls.Add(CB[i]);
                }
            }
        }
        public void FreshCButton()
        {
            dt = Fill(@"Select * from scheduleInfo where scheduleInfo.did= '"+id+"'");
            for(int i=0;i<30;i++)
            {
                CB[i].Visible = true;
                CB[i].Checked = false;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    string[] date = Regex.Split(CB[i].Text, "-");//checkbox.Text的日期
                    if (date[3].Equals("上午"))
                    {
                        ampm = "0";
                    }
                    else
                    {
                        ampm = "1";
                    }
                    if (dt.Rows[i]["year"].ToString().Equals(date[0]) && dt.Rows[i]["month"].ToString().Equals(date[1]) && dt.Rows[i]["day"].ToString().Equals(date[2]))
                    {
                        CB[i].Checked = true;
                        break;
                    }
                    else
                    {
                        CB[i].Checked = false;
                    }
                }
            }
        }
        /* public void CreatCbButton()
        {
            Point startP = new Point(treeView1.Location.X + treeView1.Width + 100, treeView1.Location.Y+40);
            Point P = startP;
            for (int i=0;i<14;i++)
            {
                CbB[i] = new ComboBox();
                CbB[i].Visible = false;
                CbB[i].Font = new Font("宋体", 15);
                CbB[i].Text = "20";
                for(int j=0;j<=50;j++)
                {
                    CbB[i].Items.Insert(j,j);
                }
                if (i % 2 == 0)
                {
                    CbB[i].Location = P;
                    this.Controls.Add(CbB[i]);
                }
                else
                {
                    P.X += 260;
                    CbB[i].Location = P;
                    this.Controls.Add(CbB[i]);
                    P.X -= 260;
                    P.Y += 80;
                }
            }
        }*/
        /*public void CreatLable()
        {
            Point startP = new Point(treeView1.Location.X + treeView1.Width + 10, treeView1.Location.Y + 40);
            Point P = startP;
            for (int i = 0; i < 14; i++)
            {
                Lb[i] = new Label();
                Lb[i].Visible = false;
                Lb[i].Font = new Font("宋体", 15);
                Lb[i].Text = "分配号源";
                Lb[i].Visible = true;
                if (i % 2 == 0)
                {
                    Lb[i].Location = P;
                    this.Controls.Add(Lb[i]);
                }
                else
                {
                    P.X += 260;
                    Lb[i].Location = P;
                    this.Controls.Add(Lb[i]);
                    P.X -= 260;
                    P.Y += 80;
                }
            }
        }*/
        /*public void FreshCbButton()
        {
            dt = Fill(@"Select * from scheduleInfo where scheduleInfo.did= '" + id + "'");
            string tmp = dt.Rows[0]["maxnum"].ToString();
            string[] maxnum = Regex.Split(tmp, "-");
            for (int i = 0; i < 14; i++)
            {
                CbB[i].Visible = true;
                CbB[i].Text = maxnum[i];

            }
        }*/
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
            for (int i = 0; i < 30; i++)
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
            //int res = NonQuery("update scheduleInfo set status='"+status+ "' where scheduleInfo.did='"+id+"'");
            /*string maxnum="";
            for (int i = 0; i < 14; i++)
            {
                if (CB[i].Checked == true)
                    maxnum += CbB[i].Text;
                else
                    maxnum += '0';
                if(i<13)
                {
                    maxnum += '-';
                }
            }
            int res1 = NonQuery("update scheduleInfo set maxnum='" + maxnum + "' where scheduleInfo.did='" + id + "'");
            AutoUpdateNumberSource.run(doc.id);

            for (int i = 0; i < 7; i++)
            {
                if (CB[i*2+1].Checked == false)
                {
                    DeleteNumberSource(i);
                }
            }
            */
        }
       /* public void UpdateNumsource()//更新号源
        {
            int num;
            string AMPM,dayofweek;
            string[] week = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string numSource="";
            for(int i=0;i<14;i++)
            {
                dayofweek = week[i%7];
                if(i%2==0)
                {
                    AMPM = "am";
                }
                else
                {
                    AMPM = "pm";
                }
                if(CB[i].Checked==true)
                {
                    num = Convert.ToInt32(CbB[i].SelectedItem);
                    for(int j=0;j<num;j++)
                    {
                        numSource += "0";
                    }
                    dt = Fill("Select * from numSourceInfo where numSourceInfo.year='" + year+ "' and numSourceInfo.month='" + month+ "' and numSourceInfo.day='"+day+ "'and numSourceInfo.ampm='"+AMPM+ "' and numSourceInfo.did='"+id+"'");
                    if (dt.Rows.Count == 0)
                    {
                        int res = NonQuery("insert into numSourceInfo(year,month,day,ampm,did,status,dayofweek) values('2018','12','20','" + AMPM + "','" + id + "','" + numSource + "','" + dayofweek + "')");
                    }
                    else
                    {
                        int res1 = NonQuery("update numSourceInfo set status=");
                    }
                }
            }

        }*/
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            id = e.Node.Name;
            if (e.Node.Level == 1)
            {
                deptid = GetDeptid(id);
                //MessageBox.Show(deptid);
                FreshCButton();
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
