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

namespace CSPSS.PRODUCTION_MANAGE
{
    public partial class FLOW_CHARTT : Form
    {
        DataTable dt = new DataTable();
        basec bc=new basec ();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
     
        private string _ADD_OR_UPDATE;
        public string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }
        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }

        }
        private static string _WAREID;
        public static string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private static string _CO_WAREID;
        public static string CO_WAREID
        {
            set { _CO_WAREID = value; }
            get { return _CO_WAREID; }

        }
        private static string _WNAME;
        public static string WNAME
        {
            set { _WNAME = value; }
            get { return _WNAME; }

        }
        private static string _STID;
        public static string STID
        {
            set { _STID = value; }
            get { return _STID; }

        }
        private static string _STEP_ID;
        public static string STEP_ID
        {
            set { _STEP_ID = value; }
            get { return _STEP_ID; }

        }
        private static string _STEP;
        public static string STEP
        {
            set { _STEP = value; }
            get { return _STEP; }

        }
        private  delegate bool dele(string a1,string a2);
        private delegate void delex();
        FLOW_CHART F1 = new FLOW_CHART();
        protected int M_int_judge, i;
        protected int select;
        CFLOW_CHART cFLOW_CHART = new CFLOW_CHART();
       
        public FLOW_CHARTT()
        {
            InitializeComponent();
        }
        public FLOW_CHARTT(FLOW_CHART FRM)
        {
            InitializeComponent();
            F1 = FRM;

        }
        private void FLOW_CHARTT_Load(object sender, EventArgs e)
        {
            textBox1.Text = IDO;
            bind();


        }
        #region total1
        private DataTable total1()
        {
            DataTable dtt2 = cFLOW_CHART.GetTableInfo();
            for (i = 1; i <= 6; i++)
            {
                DataRow dr = dtt2.NewRow();
                dr["项次"] = i;
                dtt2.Rows.Add(dr);
            }
            return dtt2;
        }
        #endregion
 
      
        public void a1()
        {
            dataGridView1.ReadOnly = true;
            select = 0;
        }
        public void a2()
        {
            dataGridView1.ReadOnly = true;
            select = 1;
        }

 

        public void ClearText()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "N";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
            try
            {
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #region bind
        private void bind()
        {

            this.Icon = Resource1.xz_200X200;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            textBox2.Focus();
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;
            textBox2.BackColor = Color.Yellow;
            textBox3.BackColor = Color.Yellow;
            textBox6.BackColor = Color.Yellow;
            comboBox1.BackColor = Color.Yellow;
            comboBox2.BackColor = Color.Yellow;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {

                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            DataTable dtx = basec.getdts(cFLOW_CHART.sql + " where A.FCID='" + textBox1.Text + "' ORDER BY  B.FCID ASC ");
            if (dtx.Rows.Count > 0)
            {
               
                dt = cFLOW_CHART.GetTableInfo();
                textBox2.Text = dtx.Rows[0]["途程代码"].ToString();
                textBox3.Text = dtx.Rows[0]["途程名称"].ToString();
                comboBox1 .Text  = dtx.Rows[0]["物料编号"].ToString();
                textBox4.Text = dtx.Rows[0]["料号"].ToString();
                textBox5.Text = dtx.Rows[0]["品名"].ToString();
                textBox6.Text = dtx.Rows[0]["版本号"].ToString();
                if (dtx.Rows[0]["生效否"].ToString() == "已生效")
                {
                    comboBox2.Text = "Y";
                }
                else
                {
                    comboBox2.Text = "N";
                }
        
                foreach (DataRow dr1 in dtx.Rows)
                {
           
                    DataRow dr = dt.NewRow();
                    dr["项次"] = dr1["项次"].ToString();
                    dr["站别代码"] = dr1["站别代码"].ToString();
                    dr["站别名称"] = dr1["站别名称"].ToString();
                    dt.Rows.Add(dr);
                 
                }

                if (dt.Rows.Count > 0 && dt.Rows.Count < 6)
                {
                    int n = 6 - dt.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {

                        DataRow dr = dt.NewRow();
                        int b1 = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["项次"].ToString());
                        dr["项次"] = Convert.ToString(b1 + 1);
                        dt.Rows.Add(dr);
                    }
                }
                
            }
            else
            {
                comboBox2.Text = "N";
                dt = total1();

            }
            dataGridView1.DataSource = dt;
            dgvStateControl();
            this.Text = "途程信息";
        

        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Focus();
            if (juage())
            {
                IFExecution_SUCCESS = false;
            }
            else
            {
           
                save();
                if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
                {
                    add();
                }
             
                F1.load();
            }
            try
            {
          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            }
        }
        private void add()
        {
            ClearText();
            textBox1.Text = cFLOW_CHART.GETID();
        
            bind();
         
            ADD_OR_UPDATE = "ADD";
           

        }
        private void save()
        {

            btnSave.Focus();
            //dgvfoucs();
            if (dt.Rows.Count > 0)
            {
                DataTable dtx = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "站别代码 IS NOT NULL");
                if (dtx.Rows.Count > 0)
                {

                    cFLOW_CHART.EMID = LOGIN.EMID;
                    cFLOW_CHART.FCID = textBox1.Text;
                    cFLOW_CHART.FLOW_CHART_ID = textBox2.Text;
                    cFLOW_CHART.FLOW_CHART  = textBox3.Text;
                    cFLOW_CHART.WAREID = comboBox1.Text;
                    cFLOW_CHART.FLOW_CHART_EDITION = textBox6.Text;
                    cFLOW_CHART.ACTIVE = comboBox2.Text;
                    cFLOW_CHART.save(dtx);
                    IFExecution_SUCCESS = cFLOW_CHART.IFExecution_SUCCESS;
                    hint.Text = cFLOW_CHART.ErrowInfo;
                    if (IFExecution_SUCCESS)
                    {
                      
                        bind();
                    }
                    /*F1.Bind();
                    F1.search();*/

                }
                else
                {
                
                    hint.Text = "至少有一项站别编号才能保存！";

                }
            }
           
            try
            {
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        private bool juage()
        {
            
            bool b = false;
            if (textBox1.Text == "")
            {
                hint.Text = "途程编号不能为空！";
                b = true;
            }
            else if (textBox2.Text == "")
            {
                hint.Text = "途程代码不能为空！";
                b = true;
            }
           else if (textBox3 .Text  == "")
            {
                hint.Text = "途程名称不能为空！";
                b = true;
            }
            else if (bc.DELEGATE_JUAGE_T(comboBox1 .Text ,bc.JUAGE_WAREID))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (textBox6.Text == "")
            {
                hint.Text = "版本号不能为空！";
                b = true;
            }
           else if(juage2())
           {
            
               b = true;
            }
            else if (bc.exists (string.Format ("SELECT * FROM WORKORDER_MST WHERE FCID='{0}'",bc.RETURN_FCID(textBox2 .Text ))))
            {
                hint.Text = string.Format("途程 {0} 已经在工单中使用不允许修改", textBox2 .Text );
                b = true;
            }
            return b;
        }
        #region juage2()
  
        private bool juage2()
        {
            bool b = false;
          
            DataTable dtx = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "站别代码 IS NOT NULL");
            foreach (DataRow dr in dtx.Rows)
            {
                string v1 =dr["站别代码"].ToString();
                if (bc.DELEGATE_JUAGE(v1, dr["项次"].ToString(),bc.JUDGE_STEP_ID))
                {
                    hint.Text = bc.ErrowInfo;
                    b = true;
                    break;
                }
      
               /* if (bc.checkphone(v1) == false)
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " 电话号码只能输入数字！";

                }
                /*else if (v1 != "" && bc.exists("SELECT * FROM FLOW_CHART_DET WHERE PHONE='" + v1 + "' AND FCID!='" + textBox1.Text + "'"))
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " 电话号码已经存在！";

                }*/
               /* else if (bc.checkphone(v5) == false)
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " QQ号只能输入数字！";

                }
               /* else if (v5!="" && bc.exists("SELECT * FROM FLOW_CHART_DET WHERE QQ='" + v5 + "' AND FCID!='"+ textBox1 .Text +"'"))
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " QQ号码已经存在！";

                }*/
         
                /*else if (bc.checkphone(v2) == false)
                {
                    b = true;
                    hint.Text = "项次" + dr["项次"].ToString() + " 传真号码只能输入数字！";

                }
                else if (bc.checkphone(v3) == false)
                {
                    b = true;
                    hint.Text ="项次" + dr["项次"].ToString() + " 邮编只能输入数字！";

                }
                */
                /*if (v4 == "")
                {
                 
                    hint.Text = "项次" + dr["项次"].ToString() + " 公司地址不能为空";
                    b = true;
                }*/
            }
            return b;
        }
        #endregion
     
        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (bc.exists(string.Format("SELECT * FROM WORKORDER_MST WHERE FCID='{0}'", bc.RETURN_FCID(textBox2.Text))))
            {
                hint.Text = string.Format("途程 {0} 已经在工单中使用不允许删除", textBox2.Text);
             
            }
            else
            {
                basec.getcoms("DELETE FLOW_CHART_MST WHERE FCID='" + textBox1.Text + "'");
                basec.getcoms("DELETE FLOW_CHART_DET WHERE FCID='" + textBox1.Text + "'");
                bind();
                ClearText();
                textBox1.Text = "";
                F1.load();
            }
            try
            {
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region override enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ((!(ActiveControl is System.Windows.Forms.TextBox) ||
                !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn)))
            {
                SendKeys.SendWait("{Tab}");
                return true;
            }
            if (keyData == (Keys.Enter | Keys.Shift))
            {
                SendKeys.SendWait("+{Tab}");

                return true;
            }
            if (keyData == (Keys.F7))
            {

                //double_info();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
       
            int numCols1 = dataGridView1.Columns.Count;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            dataGridView1.Columns["项次"].Width = 40;
            dataGridView1.Columns["站别代码"].Width = 80;
            dataGridView1.Columns["站别名称"].Width =80;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
   
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }


       
            dataGridView1.Columns["站别代码"].DefaultCellStyle.BackColor = Color.Yellow;

            dataGridView1.Columns["项次"].ReadOnly = true;
           
            dataGridView1.Columns["项次"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

   

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            int a = dataGridView1.CurrentCell.ColumnIndex;
            int b = dataGridView1.CurrentCell.RowIndex;
            int c = dataGridView1.Columns.Count - 1;
            int d = dataGridView1.Rows.Count - 1;


            if (a == c && b == d)
            {
                if (dt.Rows.Count >= 6)
                {

                    DataRow dr = dt.NewRow();
                    int b1 = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["项次"].ToString());
                    dr["项次"] = Convert.ToString(b1 + 1);
                    dt.Rows.Add(dr);
                }

            }
            //dgvfoucs();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
       
        }

        private void 删除此项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string v1 = dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString();
            string sql2 = "DELETE FROM FLOW_CHART_DET WHERE FCID='" + textBox1.Text + "' AND SN='" + v1 + "'";
            if (dt.Rows.Count > 0)
            {

                if (MessageBox.Show("确定要删除该条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!bc.exists("SELECT * FROM FLOW_CHART_DET WHERE FCID='" + textBox1.Text + "' AND SN='"+v1+"'"))
                    {
                        hint.Text = "此条记录还未写入数据库";
                    }
                    else  if (bc.juageOne("SELECT * FROM FLOW_CHART_DET WHERE FCID='" + textBox1.Text + "'"))
                    {

                        basec.getcoms(sql2);
                        string sql3 = "DELETE FLOW_CHART_MST WHERE FCID='" + textBox1.Text + "'";
                        basec.getcoms(sql3);
                        basec.getcoms("DELETE REMARK WHERE FCID='" + textBox1.Text + "'");
                        IFExecution_SUCCESS = false;
                        bind();
                    }
                    else
                    {

                        basec.getcoms(sql2);
                      
                        IFExecution_SUCCESS = false;
                        bind();
                    }
                }
             
             
            }
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            BASE_INFO.WAREINFO FRM = new CSPSS.BASE_INFO.WAREINFO();
            FRM.FLOW_CHART_USE();
            FRM.ShowDialog();
            this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox1.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox1.Text = WAREID;
                textBox4.Text = CO_WAREID;
                textBox5.Text = WNAME;
            }
            textBox6.Focus();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            IF_DOUBLE_CLICK = false;
            int intC = this.dataGridView1.CurrentCell.RowIndex;
            if (select == 0)
            {
                PRODUCTION_MANAGE.STEP step = new STEP();
                step.FLOW_CHART_USE();
                step.ShowDialog();
                if (IF_DOUBLE_CLICK)
                {
                    dt.Rows[intC]["站别代码"] = STEP_ID;
                    dt.Rows[intC]["站别名称"] = STEP;
                    dataGridView1.CurrentCell = dataGridView1[2, intC];
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

   

  

     
   
    }
}
