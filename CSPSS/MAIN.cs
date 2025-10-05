using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using XizheC;
using System.IO;
using System.Threading;


namespace CSPSS
{
    public partial class MAIN : Form
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        basec bc = new basec();
        CUSER cuser = new CUSER();
        CEMPLOYEE_INFO cemplyee_info = new CEMPLOYEE_INFO();
        Color c2 = System.Drawing.ColorTranslator.FromHtml("#4a7bb8");
        Color c3 = System.Drawing.ColorTranslator.FromHtml("#24ade5");
        CDEPART cdepart = new CDEPART();
        CPOSITION cposition = new CPOSITION();
        CUSER_GROUP cuser_group = new CUSER_GROUP();
        CWARE_INFO cware_info = new CWARE_INFO();
        CSPEC cspec = new CSPEC();
        CUNIT cunit = new CUNIT();
        CWORKORDER cworkorder = new CWORKORDER();
        CBILL_NATURE cbill_nature = new CBILL_NATURE();
        CSTEP cstep = new CSTEP();
        CFLOW_CHART cflow_chart = new CFLOW_CHART();
        CUNIT_LOT cunit_lot = new CUNIT_LOT();
        CMACHINE cmachine = new CMACHINE();
        CMACHINE_GROUP cmachine_group = new CMACHINE_GROUP();
        CBAD_PHENOMENON cbad_phenomenon = new CBAD_PHENOMENON();
        CBAD_PHENOMENON_GROUP cbad_phenomenon_group = new CBAD_PHENOMENON_GROUP();
        CBAD_PHENOMENON_AND_GROUP cbad_phenomen_and_group = new CBAD_PHENOMENON_AND_GROUP();
        CBAD_PHENOMENON_BECAUSE cbad_phenomenon_because = new CBAD_PHENOMENON_BECAUSE();
        StringBuilder sqb = new StringBuilder();
        public MAIN()
        {
            InitializeComponent();
        }
     

        #region load
        private void MAIN_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = Resource1.xz_200X200;
                timer1.Enabled = true;
                timer1.Interval = 600;
                pictureBox1.BackColor = c2;
                notifyIcon1.Icon = Resource1.xz_200X200;
                notifyIcon1.Text = "制造执行系统";
                pictureBox1.Image = Resource1.mes;
                //pictureBox2.Image = Image.FromFile("Image/logo3.jpg");
                sqb = new StringBuilder();
                sqb.AppendFormat("制造执行系统 ");
                //sqb.AppendFormat("项目管理系统 ");
                sqb.AppendFormat("Version 20161019 ");
                string v5 = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Version.xml";
                //sqb.AppendFormat("当前版本更新日期：{0}", cfileinfo.GetTheLastUpdateTime(v5).ToString("yyyy/MM/dd HH:mm"));
                this.Text = sqb.ToString();
                dt = bc.getdt("SELECT * from RightList where USID = '" + LOGIN.USID + "'");
                SHOW_TREEVIEW(dt);
                menuStrip1.Font = new Font("宋体", 9);
                this.WindowState = FormWindowState.Maximized;
                toolStripStatusLabel1.Text = "||当前用户：" + LOGIN.UNAME;
                toolStripStatusLabel2.Text = "||所属部门：" + LOGIN.DEPART;
                toolStripStatusLabel3.Text = "||登录时间：" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() ;
                listView1.BackColor = c2;
                //this.BackColor = c2;


                listView1.ForeColor = Color.White;
                listView1.Font = new Font("新宋体", 11);

                //listView1.Location = new Point(1, 75);
                listView2.BorderStyle = BorderStyle.None;
                //listView1.BorderStyle = BorderStyle.None;
                // listView2.Location = new Point(195, 75);

                //listView1.Height = 660;
                //listView2.Height = 660;
                //listView1.Width = 194;
                //listView1 .BackgroundImage  = Image.FromFile(System .IO.Path.GetFullPath("Image/1.png"));
                //groupBox1.Height = 675;

                imageList1.Images.Add(CSPSS.Resource1._1);
                imageList1.Images.Add(CSPSS.Resource1._2);
                imageList1.Images.Add(CSPSS.Resource1._3);
                imageList1.Images.Add(CSPSS.Resource1._4);
                imageList1.Images.Add(CSPSS.Resource1._5);
                imageList1.Images.Add(CSPSS.Resource1._6);
                imageList1.Images.Add(CSPSS.Resource1._7);
                imageList1.Images.Add(CSPSS.Resource1._8);
                imageList1.Images.Add(CSPSS.Resource1._9);
                imageList1.Images.Add(CSPSS.Resource1._10);
                imageList1.Images.Add(CSPSS.Resource1._11);
                imageList1.Images.Add(CSPSS.Resource1._12);
                imageList1.Images.Add(CSPSS.Resource1._13);
                imageList1.Images.Add(CSPSS.Resource1._14);
                imageList1.Images.Add(CSPSS.Resource1._15);
                imageList1.Images.Add(CSPSS.Resource1._16);
                imageList1.Images.Add(CSPSS.Resource1._17);
                imageList1.Images.Add(CSPSS.Resource1._18);
                imageList1.Images.Add(CSPSS.Resource1._19);
                imageList1.Images.Add(CSPSS.Resource1._20);
                imageList1.Images.Add(CSPSS.Resource1._21);
                imageList1.Images.Add(CSPSS.Resource1._22);
                imageList1.Images.Add(CSPSS.Resource1._23);
                imageList1.Images.Add(CSPSS.Resource1._24);
                imageList1.Images.Add(CSPSS.Resource1._25);
                imageList1.Images.Add(CSPSS.Resource1._26);
                imageList1.Images.Add(CSPSS.Resource1._27);
                imageList1.Images.Add(CSPSS.Resource1._28);
                imageList1.Images.Add(CSPSS.Resource1._29);
                imageList1.Images.Add(CSPSS.Resource1._30);
                imageList1.Images.Add(CSPSS.Resource1._31);
                imageList1.Images.Add(CSPSS.Resource1._32);
                imageList1.Images.Add(CSPSS.Resource1._33);
                imageList1.Images.Add(CSPSS.Resource1._34);
                imageList1.Images.Add(CSPSS.Resource1._35);
                imageList1.Images.Add(CSPSS.Resource1._36);
                imageList1.Images.Add(CSPSS.Resource1._37);
                imageList1.Images.Add(CSPSS.Resource1._38);
                imageList1.Images.Add(CSPSS.Resource1._39);
                imageList1.Images.Add(CSPSS.Resource1._40);
                imageList1.Images.Add(CSPSS.Resource1._41);
                imageList1.Images.Add(CSPSS.Resource1._42);
                imageList1.Images.Add(CSPSS.Resource1._43);
                imageList1.Images.Add(CSPSS.Resource1._44);
                imageList1.Images.Add(CSPSS.Resource1._45);
                imageList1.Images.Add(CSPSS.Resource1._46);
                imageList1.Images.Add(CSPSS.Resource1._47);
                imageList1.Images.Add(CSPSS.Resource1._48);
                imageList1.Images.Add(CSPSS.Resource1._49);
                imageList1.Images.Add(CSPSS.Resource1._50);
                imageList1.Images.Add(CSPSS.Resource1._51);
                imageList1.Images.Add(CSPSS.Resource1._52);
                imageList1.Images.Add(CSPSS.Resource1._53);
                imageList1.Images.Add(CSPSS.Resource1._54);
                imageList1.Images.Add(CSPSS.Resource1._55);
                imageList1.Images.Add(CSPSS.Resource1._56);

                /*imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/41.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/42.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/43.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/44.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/45.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/46.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/47.png")));

                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/48.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/49.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/50.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/51.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/52.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/53.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/54.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/55.png")));
                imageList1.Images.Add(Image.FromFile(System.IO.Path.GetFullPath("Image/56.png")));*/
                imageList1.ColorDepth = ColorDepth.Depth32Bit;/*防止图片失真*/
                listView1.View = View.SmallIcon;
                listView2.View = View.LargeIcon;
                imageList1.ImageSize = new Size(48, 48);/*set imglist size*/
                listView1.SmallImageList = imageList1;
                listView2.LargeImageList = imageList1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        #endregion
        #region show_treeview
        private void SHOW_TREEVIEW(DataTable dt)
        {
            dt = bc.GET_DT_TO_DV_TO_DT(dt, "NODEID ASC", "PARENT_NODEID=0");
            if (dt.Rows.Count > 0)
            {
                for(int i=0;i<dt.Rows.Count ;i++)
                {
                    ListViewItem lvi = listView1.Items.Add(dt.Rows[i]["NODE_NAME"].ToString());
                    lvi.ImageIndex = Convert.ToInt32(dt.Rows[i]["NODEID"].ToString()) - 1;/*NEED THIS SO CAN SHOW*/
                }
                DataTable  dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", "NODE_NAME='生产管理'");
                if (dtx.Rows.Count > 0)
                {
                    click(dtx.Rows[0]["NODE_NAME"].ToString());
                    if(listView1.Items.Count ==1)
                    {
                        listView1.Items[0].BackColor = c3;//只有一项160219
                    }
                    else if (listView1.Items.Count == 2)//有两项时 160219
                    {
                        listView1.Items[1].BackColor = c3;
                    }
                    else
                    {
                        listView1.Items[2].BackColor = c3;//超过两项时 160219
                    }
                }
                else
                {
                    click(dt.Rows[0]["NODE_NAME"].ToString());
                    listView1.Items[0].BackColor = c3;
                }
            }
        }
        #endregion

        #region show_treeview_O
        private void SHOW_TREEVIEW_O(string NODEID)
        {
            dt2 = bc.getdt("SELECT * FROM RIGHTLIST WHERE PARENT_NODEID='" + NODEID  + "'AND  USID = '" + LOGIN.USID + "' ORDER BY NODEID ASC");
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    ListViewItem lvi = listView2.Items.Add(dt2.Rows[i]["NODE_NAME"].ToString());
                    lvi.ImageIndex = Convert.ToInt32(dt2.Rows[i]["NODEID"].ToString()) - 1;/*NEED THIS SO CAN SHOW*/
                }
            }
            else
            {
                MessageBox.Show(NODEID +","+LOGIN.USID );

            }
        }
        #endregion

         private void 退出系统ToolStripMenuItem1_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("确定要退出本系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
             {
                 EXIT();
             }
             else
             {
                 
             }
         }
         private void listView1_Click(object sender, EventArgs e)
         {
             try
             {
                 string v1 = listView1.SelectedItems[0].SubItems[0].Text.ToString();/*get selectitem value*/
                 click(v1);
             }
             catch (Exception)
             {


             }
            
         }
         private void click(string NODE_NAME)
         {
            
             listView2.Items.Clear();
             string id = bc.getOnlyString("SELECT NODEID FROM RIGHTLIST WHERE NODE_NAME='" + NODE_NAME + "'");
             SHOW_TREEVIEW_O(id);

             foreach (ListViewItem lvi in listView1.Items)
             {
                 if (lvi.Selected)
                 {
                     lvi.BackColor = c3;
                     pictureBox1.Focus();/*SELECTED AFTER MOVE FOCUS*/
                 }
                 else
                 {
                     lvi.BackColor = c2;
                 }

             }

         }
         private void listView2_Click(object sender, EventArgs e)
         {
             string v1 = listView2.SelectedItems[0].SubItems[0].Text.ToString();/*get selectitem value*/

             #region v1
             if (v1 == "员工信息维护")
             {
                 CSPSS.BASE_INFO.EMPLOYEE_INFO FRM = new CSPSS.BASE_INFO.EMPLOYEE_INFO();
                 FRM.IDO = cemplyee_info.GETID();
                 FRM.Show();

             }
             else if (v1 == "批号-产品条码")
             {
                 CSPSS.PRODUCTION_MANAGE.BATCH_TO_PRODUCT FRM = new CSPSS.PRODUCTION_MANAGE.BATCH_TO_PRODUCT();
                 FRM.Show();
             }
             else if (v1 == "站别-绑定物料")
             {
                 CSPSS.PRODUCTION_MANAGE.STEP_WAREID FRM = new CSPSS.PRODUCTION_MANAGE.STEP_WAREID();
                 FRM.Show();
             }
             else if (v1 == "在制品中断作业")
             {
                 ABNORMAL_MANAGE.WIP_INTERRUPT FRM = new CSPSS.ABNORMAL_MANAGE.WIP_INTERRUPT();
                 FRM.Show();
             }
             else if (v1 == "Run Card补印")
             {
                 WORKORDER_MANAGE.PRINT_AGAIN FRM = new CSPSS.WORKORDER_MANAGE.PRINT_AGAIN();
                 FRM.Show();

             }
             else if (v1 == "查询拆批履历")
             {
                 REPORT_MANAGE.BATCH_REMOVE_SEARCH FRM = new CSPSS.REPORT_MANAGE.BATCH_REMOVE_SEARCH();
                 FRM.Show();

             }
             else if (v1 == "查询不良数量")
             {
                 REPORT_MANAGE.BAD_PHENOMENON_SEARCH FRM = new CSPSS.REPORT_MANAGE.BAD_PHENOMENON_SEARCH();
                 FRM.Show();

             }
             else if (v1 == "拆批作业")
             {
                 ABNORMAL_MANAGE.BATCH_REMOVE FRM = new CSPSS.ABNORMAL_MANAGE.BATCH_REMOVE();
                 FRM.Show();
             }
             else if (v1 == "查询生产履历")
             {
                 REPORT_MANAGE.RESUME_SEARCH FRM = new CSPSS.REPORT_MANAGE.RESUME_SEARCH();
                 FRM.Show();

             }
             else if (v1 == "电子看板-机台")
             {
                 REPORT_MANAGE.ELECTRONIC_KANBAN FRM = new CSPSS.REPORT_MANAGE.ELECTRONIC_KANBAN();
                 FRM.Show();

             }
             else if (v1 == "电子看板-站别")
             {
                 REPORT_MANAGE.ELECTRONIC_KB_FOR_STEP FRM = new CSPSS.REPORT_MANAGE.ELECTRONIC_KB_FOR_STEP();
                 FRM.Show();

             }
             else if (v1 == "查询在制品清单")
             {
                 REPORT_MANAGE.WIP_SEARCH FRM = new CSPSS.REPORT_MANAGE.WIP_SEARCH();
                 FRM.Show();
             }
             else if (v1 == "查询批号良率")
             {
                 REPORT_MANAGE.BATCH_YIELD_SEARCH FRM = new CSPSS.REPORT_MANAGE.BATCH_YIELD_SEARCH();
                 FRM.Show();

             }
             else if (v1 == "查询站别良率")
             {
                 REPORT_MANAGE.STEP_YIELD_SEARCH FRM = new CSPSS.REPORT_MANAGE.STEP_YIELD_SEARCH();
                 FRM.Show();
             }
             else if (v1 == "生产过账")
             {
                 CSPSS.PRODUCTION_MANAGE.POSTINGT FRM = new CSPSS.PRODUCTION_MANAGE.POSTINGT();
                 FRM.Show();
             }
             else if (v1 == "现象对应群组")
             {
                 CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_AND_GROUP FRM = new CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_AND_GROUP();
                 FRM.Show();
             }
             else if (v1 == "不良群组")
             {
                 CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_GROUP FRM = new CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_GROUP();
                 FRM.IDO = cbad_phenomenon_group.GETID();
                 FRM.Show();

             }
             else if (v1 == "不良现象")
             {
                 CSPSS.QUALITY_MANAGE.BAD_PHENOMENON FRM = new CSPSS.QUALITY_MANAGE.BAD_PHENOMENON();
                 FRM.IDO = cbad_phenomenon.GETID();
                 FRM.Show();

             }
             else if (v1 == "不良原因")
             {
                 CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_BECAUSE FRM = new CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_BECAUSE();
                 FRM.IDO = cbad_phenomenon_because.GETID();
                 FRM.Show();
             }
             else if (v1 == "机台信息")
             {
                 CSPSS.MACHINE_MANAGE.MACHINE FRM = new CSPSS.MACHINE_MANAGE.MACHINE();
                 FRM.IDO = cmachine.GETID();
                 FRM.Show();

             }
             else if (v1 == "机台对应群组")
             {
                 CSPSS.MACHINE_MANAGE.MACHINE_AND_GROUP FRM = new CSPSS.MACHINE_MANAGE.MACHINE_AND_GROUP();
                 FRM.Show();

             }
             else if (v1 == "机台群组")
             {
                 CSPSS.MACHINE_MANAGE.MACHINE_GROUP FRM = new CSPSS.MACHINE_MANAGE.MACHINE_GROUP();
                 FRM.IDO = cmachine_group.GETID();
                 FRM.Show();

             }
             else if (v1 == "Run Card")
             {
                 CSPSS.WORKORDER_MANAGE.BATCHT FRM = new CSPSS.WORKORDER_MANAGE.BATCHT();
                 FRM.Show();

             }
             else if (v1 == "Run Card补印")
             {
                 MessageBox.Show("该作业未启用");

             }
             else if (v1 == "单位批号量")
             {
                 CSPSS.WORKORDER_MANAGE.UNIT_LOT FRM = new CSPSS.WORKORDER_MANAGE.UNIT_LOT();
                 FRM.IDO = cunit_lot.GETID();
                 FRM.Show();

             }
             else if (v1 == "站别信息")
             {
                 CSPSS.PRODUCTION_MANAGE.STEP FRM = new PRODUCTION_MANAGE.STEP();
                 FRM.IDO = cstep.GETID();
                 FRM.Show();

             }
             else if (v1 == "途程图")
             {
                 CSPSS.PRODUCTION_MANAGE.FLOW_CHART FRM = new PRODUCTION_MANAGE.FLOW_CHART();
                 FRM.IDO = cflow_chart.GETID();
                 FRM.Show();

             }
             else if (v1 == "工单作业")
             {
                 CSPSS.WORKORDER_MANAGE.WORKORDERT FRM = new WORKORDER_MANAGE.WORKORDERT();
                 FRM.IDO = cworkorder.GETID();
                 FRM.Show();

             }
             else if (v1 == "单据性质")
             {
                 CSPSS.WORKORDER_MANAGE.BILL_NATURE FRM = new WORKORDER_MANAGE.BILL_NATURE();
                 FRM.IDO = cbill_nature.GETID();
                 FRM.Show();

             }
             else if (v1 == "部门信息维护")
             {
                 CSPSS.BASE_INFO.DEPART FRM = new CSPSS.BASE_INFO.DEPART();
                 FRM.IDO = cdepart.GETID();
                 FRM.Show();

             }
             else if (v1 == "规格信息")
             {
                 CSPSS.BASE_INFO.SPEC FRM = new CSPSS.BASE_INFO.SPEC();
                 FRM.IDO = cspec.GETID();
                 FRM.Show();

             }
             else if (v1 == "单位信息")
             {
                 CSPSS.BASE_INFO.UNIT FRM = new CSPSS.BASE_INFO.UNIT();
                 FRM.IDO = cunit.GETID();
                 FRM.Show();

             }
             else if (v1 == "材料信息")
             {
                 CSPSS.BASE_INFO.MATERIALS FRM = new BASE_INFO.MATERIALS();
                 FRM.IDO = cware_info.GETID("5");
                 FRM.Show();

             }
             else if (v1 == "半成品信息")
             {
                 CSPSS.BASE_INFO.SEMI_FINISHED FRM = new BASE_INFO.SEMI_FINISHED();
                 FRM.IDO = cware_info.GETID("8");
                 FRM.Show();

             }
             else if (v1 == "成品信息")
             {
                 CSPSS.BASE_INFO.PRODUCT FRM = new BASE_INFO.PRODUCT();
                 FRM.IDO = cware_info.GETID("9");
                 FRM.Show();

             }
             else if (v1 == "物料信息")
             {
                 CSPSS.BASE_INFO.WAREINFO FRM = new BASE_INFO.WAREINFO();
                 //FRM.IDO = cware_info.GETID("9");
                 FRM.Show();

             }
             else if (v1 == "职务信息维护")
             {
                 CSPSS.BASE_INFO.POSITION FRM = new CSPSS.BASE_INFO.POSITION();
                 FRM.IDO = cposition.GETID();
                 FRM.Show();

             }
             else if (v1 == "服务器IP")
             {
                 CSPSS.BASE_INFO.UPLOADFILE_DOMAIN FRM = new CSPSS.BASE_INFO.UPLOADFILE_DOMAIN();

                 FRM.Show();

             }

             else if (v1 == "用户帐户")
             {
                 CSPSS.USER_MANAGE.USER_INFO FRM = new CSPSS.USER_MANAGE.USER_INFO();
                 FRM.IDO = cuser.GETID();
                 FRM.ADD_OR_UPDATE = "ADD";
                 FRM.Show();

             }
             else if (v1 == "更改密码")
             {
                 CSPSS.USER_MANAGE.EDIT_PWD FRM = new CSPSS.USER_MANAGE.EDIT_PWD();
                 FRM.Show();

             }
             else if (v1 == "权限管理")
             {
                 CSPSS.USER_MANAGE.EDIT_RIGHT FRM = new CSPSS.USER_MANAGE.EDIT_RIGHT();
                 FRM.Show();

             }
             else if (v1 == "用户组信息")
             {
                 CSPSS.USER_MANAGE.USER_GROUP FRM = new CSPSS.USER_MANAGE.USER_GROUP();
                 FRM.IDO = cuser_group.GETID();
                 FRM.Show();

             }
             #endregion
         }

         private void notifyIcon1_Click(object sender, EventArgs e)
         {
             click();
  
         }
         private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
         {
             click();
         }
         private void click()
         {
             //basec.getcoms("UPDATE REMIND SET RECEIVE_STATUS='Y', NOTICE_MAKERID='" + LOGIN.EMID + "' WHERE RIID='" + SRID + "'");
             timer2.Enabled = false;
             this.WindowState = FormWindowState.Maximized;
             ContextMenu c = new ContextMenu();
             MenuItem s = new MenuItem("退出");
             c.MenuItems.Add(s);
             notifyIcon1.ContextMenu = c;
             notifyIcon1.Icon = new Icon(System.IO.Path.GetFullPath("Image/xz 200X200.ico"));
             s.Click += new EventHandler(notify_Click);
             this.Show();

         }
         private void notify_Click(object sender, EventArgs e)
         {
             EXIT();
         }
         private void EXIT()
         {
             this.Dispose();
             notifyIcon1.Dispose();
             Application.Exit();
         }
  
         private void MAIN_FormClosing(object sender, FormClosingEventArgs e)
         {
             e.Cancel = true;
             this.Hide();
         }

         private void MAIN_FormClosed(object sender, FormClosedEventArgs e)
         {
          

         }
   
         private void groupBox1_Paint(object sender, PaintEventArgs e)
         {
             e.Graphics.Clear(this.c2);
         }

    

      

       
    }
}
