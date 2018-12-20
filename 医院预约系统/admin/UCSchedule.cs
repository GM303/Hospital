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
        CheckBox[] CB = new CheckBox[14];
        ComboBox[] CbB = new ComboBox[14];
        Label[] Lb = new Label[14];
        public UCschedule()
        {
            InitializeComponent();
            FreshTreeview();
            CreatCButton();
            CreatCbButton();
        }
        public void FreshTreeview()
        {
            treeView1.Nodes.Clear();
            dt = Fill("select * from departmentInfo");
            for(int i=0;i<dt.Rows.Count;++i)
            {
                treeView1.Nodes.Add(dt.Rows[i]["deptid"].ToString(), dt.Rows[i]["deptname"].ToString());
            }
            foreach (TreeNode tn in treeView1.Nodes)
            {
                dt = Fill("select * from doctorinfo where deptid='"+tn.Name+"'");
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    tn.Nodes.Add(dt.Rows[i]["did"].ToString(), dt.Rows[i]["dname"].ToString());
                }
            }
        }
        public void CreatCButton()
        {
            Point startP = new Point(treeView1.Location.X + treeView1.Width + 10, treeView1.Location.Y);
            Point P = startP;
            string[] week = { "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期天" };
            string[] AP = { "上午", "下午" };
            int DayOfWeek = 0;
            for (int i = 0; i < 14; ++i)
            {
                CB[i] = new CheckBox();
                CB[i].Font = new Font("宋体", 20);
                CB[i].Visible = false;
                CB[i].AutoSize = true;
                if (i % 2 == 0)
                {
                    CB[i].Text = week[DayOfWeek] + AP[0];
                    CB[i].Location = P;
                    this.Controls.Add(CB[i]);
                }
                else
                {
                    CB[i].Text = week[DayOfWeek] + AP[1];
                    DayOfWeek++;
                    P.X += 260;
                    CB[i].Location = P;
                    this.Controls.Add(CB[i]);
                    P.X -= 260;
                    P.Y += 80;
                }
            }
        }
        public void FreshCButton()
        {
            string status;
            dt = Fill(@"Select * from scheduleInfo where scheduleInfo.did= '"+id+"'");
            status = dt.Rows[0]["status"].ToString();
            for (int i = 0; i < 14; i++)
            {
                CB[i].Visible = true;
                if (status[i]=='1')
                {
                    CB[i].Checked = true;
                }
                else
                {
                    CB[i].Checked = false;
                }
            }
        }
        public void CreatCbButton()
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
        }
        public void CreatLable()
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
        }
        public void FreshCbButton()
        {
            dt = Fill(@"Select * from scheduleInfo where scheduleInfo.did= '" + id + "'");
            string tmp = dt.Rows[0]["maxnum"].ToString();
            string[] maxnum = Regex.Split(tmp, "-");
            for (int i = 0; i < 14; i++)
            {
                CbB[i].Visible = true;
                CbB[i].Text = maxnum[i];

            }
        }
        public void UpadteStatus()//更新排班
        {
            string status = "";
            for (int i = 0; i < 14; i++)
            {
                if (CB[i].Checked == true)
                    status += '1';
                else
                    status += '0';
            }
            int res = NonQuery("update scheduleInfo set status='"+status+ "' where scheduleInfo.did='"+id+"'");
            string maxnum="";
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
          //  AutoUpdateNumberSource.run(doc.id);

            for (int i = 0; i < 7; i++)
            {
                if (CB[i*2+1].Checked == false)
                {
                    DeleteNumberSource(i);
                }
            }

        }
        public void DeleteNumberSource(int i)
        {
            
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
                FreshCButton();
                FreshCbButton();
                CreatLable();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            UpadteStatus();
           // UpdateNumsource();
            MessageBox.Show("提交成功");
            FreshCButton();
            FreshCbButton();
       //     AutoUpdateNumberSource.run(doc.id);
        }
    }
}
