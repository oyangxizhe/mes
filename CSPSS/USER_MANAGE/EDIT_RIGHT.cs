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
namespace CSPSS.USER_MANAGE
{
    public partial class EDIT_RIGHT : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        basec bc = new basec();
        CUSER cuser = new CUSER();
        CEDIT_RIGHT cedit_right = new CEDIT_RIGHT();
        private static string _UNAME;
        public static string UNAME
        {
            set { _UNAME = value; }
            get { return _UNAME; }

        }
        private static string _ENAME;
        public static string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }

        }

        protected int M_int_judge, i,j;
        public bool blInitial = true;
        Color c1 = System.Drawing.ColorTranslator.FromHtml("#c0c0c0");
        Color c2 = System.Drawing.ColorTranslator.FromHtml("#990033");
        public EDIT_RIGHT()
        {
            InitializeComponent();
      
        }

        private void EDIT_RIGHT_Load(object sender, EventArgs e)
        {
      
            Bind(LOGIN .USID );
            label1.Text = "(1.背景色为浅灰色的复选框无需点选为不可用)";
            label1.ForeColor = c2;
            label4.Text = "(2.授权范围指该用户名只能查看自己做的凭证还是可以查看所有用户做的凭证)";
            label4.ForeColor = c2;
          
        }
        #region GetTableInfo
        public DataTable GetTableInfo(DataTable dtx)
        {
            dt = GetTableInfo();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtx.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["复选框"] = false;
                    dr["作业名称"] = dr1["NODE_NAME"].ToString();
                    dr["查询"] = false;
                    dr["新增"] = false;
                    dr["修改"] = false;
                    dr["删除"] = false;
                    dr["经理审核"] = false;
                    dr["财务审核"] = false;
                    dr["总经理审核"] = false;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        #endregion
        #region GetTableInfo
        public DataTable GetTableInfo()
        {
            dt = new DataTable();
            dt.Columns.Add("复选框", typeof(bool));
            dt.Columns.Add("作业名称", typeof(string));
            dt.Columns.Add("查询", typeof(bool));
            dt.Columns.Add("新增", typeof(bool));
            dt.Columns.Add("修改", typeof(bool));
            dt.Columns.Add("删除", typeof(bool));
            dt.Columns.Add("经理审核", typeof(bool));
            dt.Columns.Add("财务审核", typeof(bool));
            dt.Columns.Add("总经理审核", typeof(bool));
            return dt;
        }
        #endregion
        #region bind
        private void Bind(string USID)
        {
       
            try
            {
                DataTable dty = bc.getdt("SELECT * FROM RIGHTLIST WHERE USID='" + USID + "'");
                dt = bc.getdt("SELECT * FROM RIGHTNAME");
                dt = GetTableInfo(dt);
                radioButton3.Checked = true;
                if (dty.Rows.Count > 0)
                {

                    foreach (DataRow dr1 in dty.Rows)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            if (dr1["NODE_NAME"].ToString() == dr["作业名称"].ToString())
                            {
                                if (dr1["NODE_NAME"].ToString() == "录入凭证作业")
                                {
                                    if (dr1["ADD_NEW"].ToString() == "Y")
                                    {
                                        dr["新增"] = true;
                                    }
                                    if (dr1["EDIT"].ToString() == "Y")
                                    {
                                        dr["修改"] = true;
                                    }
                                    if (dr1["DEL"].ToString() == "Y")
                                    {
                                        dr["删除"] = true;
                                    }

                                    if (dr1["MANAGE"].ToString() == "Y")
                                    {
                                        dr["经理审核"] = true;
                                    }

                                    if (dr1["FINANCIAL"].ToString() == "Y")
                                    {
                                        dr["财务审核"] = true;
                                    }

                                    if (dr1["GENERAL_MANAGE"].ToString() == "Y")
                                    {
                                        dr["总经理审核"] = true;
                                    }
                                }
                                else
                                {
                                    if (dr1["OPERATE"].ToString() == "Y")
                                    {
                                        dr["复选框"] = true;
                                    }

                                }
                                break;
                            }

                        }
                    }
                    if (bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USID + "'") == "Y")
                    {
                        radioButton1.Checked = true;

                    }
                    else if (bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + USID + "'") == "GROUP")
                    {
                        radioButton2.Checked = true;
                    }
                    else
                    {

                        radioButton3.Checked = true;
                    }
                }

                dataGridView1.DataSource = dt;
                this.WindowState = FormWindowState.Maximized;
                string a = bc.getOnlyString("SELECT UNAME FROM USERINFO WHERE USID='" + USID + "'");
                hint.ForeColor = Color.Red;
                hint.Location = new Point(400, 100);
                hint.Text = "";
                dt1 = bc.getdt(cedit_right.sql + " WHERE A.UNAME='" + a + "'");
                if (dt1.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt1;
                    dgvStateControl();
                    LENAME.Text = dt1.Rows[0]["姓名"].ToString();
                }
                comboBox1.Text = a;

                IF_DOUBLE_CLICK = false;
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region bind1
        private void Bind1()
        {
            try
            {
                hint.ForeColor = Color.Red;
                hint.Location = new Point(400, 100);
                hint.Text = "";
                dt1 = bc.getdt(cedit_right .sql  + " WHERE A.UNAME='" + comboBox1.Text + "'");
                dataGridView2.DataSource = dt1;
               
                IF_DOUBLE_CLICK = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
 
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
            int numCols2 = dataGridView2.Columns.Count;
            int rows1=dataGridView1 .Rows .Count ;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                //dataGridView1.Columns[i].ReadOnly = true;
                //dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.Red;
            }
            for (i = 0; i < rows1; i++)
            {

                if (i==return_Voucher_rows (dt))
                {
                    dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                    dataGridView1.Rows[i].Cells[1].ReadOnly = true;
                    dataGridView1.Rows[i].Cells[2].ReadOnly = true;
                    dataGridView1.Rows[i].Cells[0].Style.BackColor = c1;
                    dataGridView1.Rows[i].Cells[2].Style.BackColor = c1;
                }
                else
                {
                    for (j = 0; j < numCols1; j++)
                    {
                        if (j == 0)
                        {
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                        }
                        if (j==0 || j == 1)
                        {
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = c1;

                        }
                    }
                }
            }

            dataGridView2.Columns["作业名称"].Width = 80;
            dataGridView2.Columns["用户名"].Width = 70;
            dataGridView2.Columns["姓名"].Width = 70;
            dataGridView2.Columns["操作权限"].Width = 60;
            dataGridView2.Columns["查询权限"].Width = 60;
            dataGridView2.Columns["新增权限"].Width = 60;
            dataGridView2.Columns["修改权限"].Width = 60;
            dataGridView2.Columns["删除权限"].Width = 60;
            dataGridView2.Columns["经理审核"].Width = 60;
            dataGridView2.Columns["财务审核"].Width = 60;
            dataGridView2.Columns["总经理审核"].Width = 80;
            dataGridView2.Columns["授权范围"].Width = 60;
            dataGridView2.Columns["制单人"].Width = 70;
            dataGridView2.Columns["制单日期"].Width = 120;
            for (i = 0; i < numCols2; i++)
            {

                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                dataGridView2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].ReadOnly = true;

            }

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["复选框"].Width = 50;
            dataGridView1.Columns["查询"].Width = 40;
            dataGridView1.Columns["新增"].Width = 40;
            dataGridView1.Columns["修改"].Width = 40;
            dataGridView1.Columns["删除"].Width = 40;
            dataGridView1.Columns["经理审核"].Width = 70;
            dataGridView1.Columns["财务审核"].Width = 70;
            dataGridView1.Columns["总经理审核"].Width = 80;
        }
        #endregion
        private int return_Voucher_rows(DataTable dt)
        {
            int r = 0;
            bool b = false;
            for (i = 0; i <dt.Rows .Count ; i++)
            {
                if (b == true)
                {
                    break;
                }
                for (j = 0; j < dt.Columns .Count ; j++)
                {
                    if (dt.Rows[i][j].ToString() == "录入凭证作业")
                    {
                        
                        r = i;
                        b = true;
                        break;
                    }
                }
            }
            return r;
        }

        private int return_Voucher_rows_o()
        {
            int r = 0;
            bool b = false;
            for (i = 0; i <dataGridView1 .Rows .Count ; i++)
            {
                if (b == true)
                {
                    break;
                }
                for (j = 0; j < dataGridView1 .Columns .Count ; j++)
                {
                    if (dataGridView1[j,i].Value.ToString ()== "录入凭证作业")
                    {
                       

                        r = i;
                        b = true;
                        break;
                    }
                }
            }
            return r;
        }
    
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void Clear()
        {

            comboBox1.Text = "";
            LENAME.Text = "";
            dataGridView1.DataSource = null;

        }
        #region save_click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!juage1())
                {

                }
                else
                {
                    string USID = bc.getOnlyString("SELECT USID FROM USERINFO WHERE  UNAME='" + comboBox1.Text + "'");
                    bc.getcom("DELETE RIGHTLIST WHERE USID='" + USID + "'");
                    bc.getcom("DELETE SCOPE_OF_AUTHORIZATION WHERE USID='"+USID +"'");
                    if (juage_if_noall_select())
                    {

                    }
                    else
                    {
                        save();
                        if (radioButton1.Checked == true)
                        {
                            bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('"+USID +"','Y')");
                        }
                        else if (radioButton2.Checked == true)
                        {
                            bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USID + "','GROUP')");
                        }
                        else
                        {
                            bc.getcom("INSERT INTO SCOPE_OF_AUTHORIZATION(USID,SCOPE) VALUES ('" + USID + "','N')");
                        }
                    }
                    Bind1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }

        }
        #endregion
        #region save
        private void save()
        {
         string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
         string USID = bc.getOnlyString("SELECT USID FROM USERINFO WHERE  UNAME='" +comboBox1 .Text  + "'");
         string v1, v2, v3, v4, v5, v6,v7,v8;
         for (int i = 0; i < dataGridView1.Rows.Count; i++)
         {

             if (i == return_Voucher_rows_o())
             {


                 if (dataGridView1.Rows[i].Cells["查询"].EditedFormattedValue.ToString() == "False")
                 {

                     v2 = "N";
                 }
                 else
                 {
                     v2 = "Y";

                 }
                     if (dataGridView1.Rows[i].Cells["新增"].EditedFormattedValue.ToString() == "False")
                     {

                         v3= "N";
                     }
                     else
                     {
                         v3 = "Y";

                     }
                     if (dataGridView1.Rows[i].Cells["修改"].EditedFormattedValue.ToString() == "False")
                     {

                         v4 = "N";
                     }
                     else
                     {
                         v4 = "Y";

                     }
                     if (dataGridView1.Rows[i].Cells["删除"].EditedFormattedValue.ToString() == "False")
                     {

                         v5= "N";
                     }
                     else
                     {
                         v5 = "Y";

                     }
                     if (dataGridView1.Rows[i].Cells["经理审核"].EditedFormattedValue.ToString() == "False")
                     {

                         v6 = "N";
                     }
                     else
                     {
                         v6 = "Y";

                     }
                     if (dataGridView1.Rows[i].Cells["财务审核"].EditedFormattedValue.ToString() == "False")
                     {

                         v7 = "N";
                     }
                     else
                     {
                         v7 = "Y";

                     }
                     if (dataGridView1.Rows[i].Cells["总经理审核"].EditedFormattedValue.ToString() == "False")
                     {

                         v8 = "N";
                     }
                     else
                     {
                         v8 = "Y";

                     }
                     if (v2 == "N" && v3 == "N" && v4 == "N" && v5 == "N" && v6 == "N" && v7 == "N" && v8 == "N")
                     {

                     }
                     else
                     {
                         //MessageBox.Show(dataGridView1.Rows[i].Cells[1].Value.ToString() +" "+dataGridView1 .Columns [j].Name .ToString ()+ dataGridView1.Rows[i].Cells[j].Value.ToString()+ " "+v1);
                         cedit_right.USID = USID;
                         cedit_right.NODEID = bc.getOnlyString("SELECT NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'");
                         cedit_right.PARENT_NODEID = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'");
                         cedit_right.NODE_NAME = dataGridView1.Rows[i].Cells[1].Value.ToString();
                         cedit_right.OPERATE = "N";
                         cedit_right.SEARCH = v2;
                         cedit_right.ADD_NEW = v3;
                         cedit_right.EDIT = v4;
                         cedit_right.DEL = v5;
                         cedit_right.MANAGE = v6;
                         cedit_right.FINANCIAL = v7;
                         cedit_right.GENERAL_MANAGE = v8;
                         cedit_right.EMID = LOGIN.EMID;
                         cedit_right.SQlcommandE();
                     }
             }
             else
             {

                 if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                 {
                     v1 = "N";


                 }
                 else
                 {
                     v1 = "Y";

                 }
                 //MessageBox.Show(dataGridView1.Rows[i].Cells[1].Value.ToString() + v1);
                 if (v1 == "Y")
                 {
              
             
                 cedit_right.USID = USID;
                 cedit_right.NODEID = bc.getOnlyString("SELECT NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'");
                 cedit_right.PARENT_NODEID = bc.getOnlyString("SELECT PARENT_NODEID FROM RIGHTNAME WHERE NODE_NAME='" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'");
                 cedit_right.NODE_NAME = dataGridView1.Rows[i].Cells[1].Value.ToString();
                 cedit_right.OPERATE = v1;
                 cedit_right.SEARCH = "N";
                 cedit_right.ADD_NEW = "N";
                 cedit_right.EDIT = "N";
                 cedit_right.DEL = "N";
                 cedit_right.MANAGE = "N";
                 cedit_right.FINANCIAL = "N";
                 cedit_right.GENERAL_MANAGE = "N";
                 cedit_right.EMID = LOGIN.EMID;
                 cedit_right.SQlcommandE();
                 }
             }
         }
       
        }
        #endregion
        #region juage1()
        private bool juage1()
        {

            bool ju = true;
            if (comboBox1 .Text == "")
            {
                ju = false;
                hint.Text = "用户名不能为空！";

            }
            else if (!bc.exists("SELECT * FROM USERINFO WHERE UNAME='" + comboBox1 .Text + "'"))
            {
                ju = false;
                hint.Text = "用户名在系统中不存在！";

            }

            return ju;

        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            dt = bc.getdt(cedit_right .sql + " WHERE A.UNAME='"+v1+"'");
            if (dt.Rows.Count > 0)
            {
              
              
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            CSPSS.USER_MANAGE.USER_INFO FRM = new USER_INFO();
            FRM.IDO = cuser.GETID();
            FRM.EditRight();
            FRM.ShowDialog();
            this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox1.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox1.Text = UNAME;
                LENAME.Text = ENAME;
                search();
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            
            }
        }
 

        #region juage_if_all_select
        private bool juage_if_all_select()
        {
            bool b = true;
            bool b1 = false;
        
            for (int i = 0; i <dataGridView1.Rows.Count ; i++)
            {
               
                if (b1 == true)
                    break;
                if (i == return_Voucher_rows_o())
                {
                    for (int j = 3; j < dataGridView1.Columns .Count ; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() == "False")
                        {
                            b = false;
                            b1 = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                    {
                    
                        b = false;
                        break;
                    }
                  
                }
           
            }
            return b;
        }
        #endregion
        #region juage_if_noall_select
        private bool juage_if_noall_select()
        {
            bool b = true;
            bool b1 = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if (b1 == true)
                    break;
                if (i == return_Voucher_rows_o())
                {
                    for (int j = 2; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() == "True")
                        {
                            b = false;
                            b1 = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                    {

                        b = false;
                        break;
                    }

                }

            }
            return b;
        }
        #endregion
        #region checkBox1_CheckedChanged
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

                if (juage_if_all_select())
                {
                  
                    select(1);
                }
                else
                {
                   
                    select(0);
                }
        }
        #endregion
        #region checkBox2_CheckedChanged
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if (i == return_Voucher_rows_o())
                {
                    for (int j = 3; j <dataGridView1 .Columns .Count ; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() == "False")
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "True";
                      
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "False";

                        }
                    }

                }
                else
                {

                    if (dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString() == "False")
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "True";
                       

                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "False";

                    }

                }
            }
         
        }
        #endregion
        #region select
        private void select(int n)
        {

            for (int i = 0; i < dataGridView1.Rows .Count ; i++)
            {
                
                if (i == return_Voucher_rows_o())
                {
                    for (int j = 3; j < dataGridView1 .Columns .Count ; j++)
                    {
                        if (n == 0)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "True";
                           
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Value = "False";
                       

                        }
                    }
                 
                }
                else
                {
                    if (n == 0)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "True";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "False";

                    }

                }
            }

        }
        #endregion
        private void treeView1_Click(object sender, EventArgs e)
        {

        }
        #region search
        private void search()
        {
         
            try
            {
          
                dt1 = bc.getdt(cedit_right.sql + " WHERE  A.UNAME LIKE '%" + comboBox1.Text + "%'");
                if (dt1.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt1;
                    dgvStateControl();

                }
                else
                {

                   
                    hint.Text = "没有找到相关信息！";
                    dataGridView2.DataSource = dt1;
                }
                if (bc.exists("SELECT * FROM USERINFO WHERE UNAME='" + comboBox1.Text + "'"))
                {
                    Bind(bc.getOnlyString("SELECT USID FROM USERINFO WHERE UNAME='" + comboBox1.Text + "'"));
                }
                else
                {
                    LENAME.Text = "";
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    radioButton1.Checked = false;
                    radioButton3.Checked = false;

                    dt = bc.getdt("SELECT * FROM RIGHTNAME");
                    dt = GetTableInfo(dt);
                    dataGridView1.DataSource = dt;
                    dgvStateControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
