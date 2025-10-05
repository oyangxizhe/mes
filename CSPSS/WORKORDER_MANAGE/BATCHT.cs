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
using System.Text.RegularExpressions;/*正则表达式类*/
using System.Configuration;

namespace CSPSS.WORKORDER_MANAGE
{
    public partial class BATCHT : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtx = new DataTable();
        basec bc=new basec ();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

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
        private static string _FCID;
        public static string FCID
        {
            set { _FCID = value; }
            get { return _FCID; }

        }
        private string _BATCHID;
        public string BATCHID
        {

            set { _BATCHID = value; }
            get { return _BATCHID; }

        }
        private static string _BATCH_ID;
        public static string BATCH_ID
        {
            set { _BATCH_ID = value; }
            get { return _BATCH_ID; }

        }
        private string _BAKEY;
        public string BAKEY
        {
            set { _BAKEY = value; }
            get { return _BAKEY; }

        }
        private static string _FCNAME;
        public static string FCNAME
        {
            set { _FCNAME = value; }
            get { return _FCNAME; }

        }
        private  static  string _WOID;
        public static string WOID
        {
            set { _WOID = value; }
            get { return _WOID; }

        }
        private static string _WO_COUNT;
        public static string WO_COUNT
        {
            set { _WO_COUNT = value; }
            get { return _WO_COUNT; }

        }
        private int _CYCLE;
        public int CYCLE
        {
            set { _CYCLE = value; }
            get { return _CYCLE; }

        }
        private static string _BATCH_EDITION;
        public static string BATCH_EDITION
        {
            set { _BATCH_EDITION = value; }
            get { return _BATCH_EDITION; }

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
        private string _BAID;
        public string BAID
        {
            set { _BAID = value; }
            get { return _BAID; }

        }
        private string _SN;
        public string SN
        {
            set { _SN = value; }
            get { return _SN; }

        }
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }

        }
     
      
        protected int M_int_judge, i;
        protected int select;
        CBATCH cBATCH = new CBATCH();
       
        public BATCHT()
        {
            InitializeComponent();
        }
    
        private void BATCHT_Load(object sender, EventArgs e)
        {
         
            bind();
        }
        #region bind
        private void bind()
        {
            this.Icon = Resource1.xz_200X200;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            textBox3.Focus();
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
           /* DataTable dtx = basec.getdts(string.Format(cBATCH.sql + " WHERE A.WOID='{0}' ORDER BY  A.WOID ASC ", comboBox1.Text));
            if (dtx.Rows.Count > 0)
            {
                textBox3.Text = dtx.Rows[0]["工单号"].ToString();
            }*/


            comboBox1.BackColor = Color.Yellow;
            textBox9.BackColor = Color.Yellow;
            this.Text = "批号产生作业";
            hint.Text = "";
            groupBox1.Text = "批号信息";
          
            dtx = bc.GET_DT_TO_DV_TO_DT(bc.getdt(cBATCH.sqlf), "", string.Format("工单号='{0}'", comboBox1.Text));
            if (dtx.Rows.Count > 0)
            {
                textBox7.Text = dtx.Rows[0]["已投产数量"].ToString();
                textBox8.Text = dtx.Rows[0]["未投产数量"].ToString();
                //textBox10.Text = dtx.Rows[0]["投产批数"].ToString();
            }
        }
        #endregion
        private void dgvClientInfo_DoubleClick(object sender, EventArgs e)
        {
            /*int intCurrentRowNumber = this.dataGridView1.CurrentCell.RowIndex;
            string s1 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[0].Value.ToString().Trim();
            string s2 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[1].Value.ToString().Trim();
            string s3 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[2].Value.ToString().Trim();
            string s4 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[5].Value.ToString().Trim();
            if (select == 0)
            {

              

            }
            if (select == 1)
            {

             

            }
            this.Close();*/
        }
      
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
           
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
         
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
       
          
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
    
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

  

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (judge())
            {
                IFExecution_SUCCESS = false;
            }
            else
            {
           
                //save();
                if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
                {
                    add();
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
        private void add()
        {
            ClearText();
           
         
            bind();
         
            ADD_OR_UPDATE = "ADD";
           

        }

        private bool judge()
        {
            dtx = bc.GET_DT_TO_DV_TO_DT(bc.getdt(cBATCH.sqlf), "", string.Format("工单号='{0}'", comboBox1.Text));
            if (dtx.Rows.Count > 0)
            {
                textBox7.Text = dtx.Rows[0]["已投产数量"].ToString();
                textBox8.Text = dtx.Rows[0]["未投产数量"].ToString();
            }
            hint.Text = "";
            bool b = false;
         
            if (bc.DELEGATE_JUAGE_T(comboBox1 .Text ,bc.JUAGE_WOID))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
          
           else if (textBox9.Text == "")
           {
               hint.Text = "投产数量不能为空！";
               b = true;
           }
           else if (bc.yesno (textBox9 .Text )==0)
           {
               hint.Text = "投产数量只能为数字！";
               b = true;
           }
            else if (!bc.exists ("SELECT UNIT_LOT FROM UNIT_LOT WHERE WAREID='" + textBox2.Text + "' AND ACTIVE='Y'"))
            {
                hint.Text = "此物料编号不存在单位批号量或没有生效";
                b = true;

            }
           else if(bc.getOnlyString ("SELECT UNIT_LOT FROM UNIT_LOT WHERE WAREID='" +textBox2.Text  + "' AND ACTIVE='Y'")!=textBox6 .Text )
           {
               hint.Text = "此单位批号量不等于此物料编号生效的单位批号量";
               b = true;

           }
            else if (decimal.Parse(textBox9.Text) > decimal.Parse(textBox8.Text))
            {
                hint.Text = "投产数量不能大于未投产数量";
                b = true;

            }
         
            else if (!IsNumberic (Convert.ToString(decimal.Parse(textBox9.Text) / decimal.Parse(textBox6.Text))))
            {
              
                hint.Text = string.Format(@"投产数量：{0}除于单位批号量{1}的值={2}不为整数
                ", textBox9.Text, textBox6.Text, decimal.Parse(textBox9.Text) / decimal.Parse(textBox6.Text));
                b = true;
            }
            else if (bc.getOnlyString("SELECT STATUS FROM WORKORDER_MST WHERE WOID='" +comboBox1 .Text  + "'") =="SCRAP")
            {
                hint.Text = string.Format("此工单号：" + "{0}" + " 状态为报废不允许产生批号", comboBox1 .Text );
                b = true;
            }
          /* else if (judge3()==0)
           {
               hint.Text = "需点选一个默认联系人！";
               b = true;
           }
           else if (judge3()>1)
           {
               hint.Text = "默认联系人只能选择一个！";
               b = true;
           }*/
            return b;
        }
   
        private void btnDel_Click(object sender, EventArgs e)
        {
            
        }
        private bool IsNumberic(string val)
        {
            try
            {
                int var1 = Convert.ToInt32(val);/*判断值是否为整数*/
                return true;
            }
            catch
            {
                return false;
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
            for (i = 0; i < numCols1; i++)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                dataGridView1.Columns[i].ReadOnly = true;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
     
                i = i + 1;
               
            }
  
            dataGridView1.Columns["批号"].Width = 120;
            dataGridView1.Columns["项次"].Width = 40;
            dataGridView1.Columns["工单号"].Width = 70;
            /*dataGridView1.Columns["制单人"].Width = 70;
            dataGridView1.Columns["制单日期"].Width = 120;
            dataGridView1.Columns["工单数量"].Width = 70;
            dataGridView1.Columns["物料编号"].Width = 70;*/
            dataGridView1.Columns["单位批号量"].Width = 80;
          
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

        private void comboBox2_DropDown(object sender, EventArgs e)
        {

           /* PRODUCTION_MANAGE.BATCH FRM = new CSPSS.PRODUCTION_MANAGE.BATCH();
            FRM.BATCH_USE();
            FRM.ShowDialog();
            this.comboBox2.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox2.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox2.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox2.Text = FCID;
                textBox7.Text = BATCH_ID;
                textBox8.Text = FCNAME;
                textBox9.Text = BATCH_EDITION;
            }*/
        }
        private void btnGenerate_bath_Click(object sender, EventArgs e)
        {
            GENERAL_BATCH();
         

        }
        public void  emptydatatable_PRINT()
        {
            dt1.Columns.Add("批号", typeof(string));
            dt1.Columns.Add("项次", typeof(string));
            dt1.Columns.Add("工单号", typeof(string));
            dt1.Columns.Add("工单数量", typeof(decimal));
            dt1.Columns.Add("单位批号量", typeof(decimal));
            dt1.Columns.Add("料号", typeof(string));
            dt1.Columns.Add("品名", typeof(string));
            /*dt1.Columns.Add("制单人", typeof(string));
            dt1.Columns.Add("制单日期", typeof(string));*/
        }
        private void GENERAL_BATCH()
        {
            dt1 = new DataTable();
            emptydatatable_PRINT();
            if (judge())
            {

            }
            else
            {
                CYCLE = (int)(decimal.Parse(textBox9.Text) / decimal.Parse(textBox6.Text));
                textBox10.Text = CYCLE.ToString();
                BAID = cBATCH.GETID();
                for (int i = 0; i < CYCLE; i++)
                {
                    string v1 = bc.getOnlyString("SELECT COUNT(*) FROM BATCH_DET WHERE WOID='" + comboBox1.Text + "'");
                    int n = 0;
                    if (!string.IsNullOrEmpty(v1))
                    {
                        n = Convert.ToInt32(v1);
                    }
                    BAKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM BATCH_DET", "BAKEY", "BA");
                    StringBuilder sqb = new StringBuilder();
                    sqb.AppendFormat("SELECT * FROM BATCH_DET WHERE SUBSTRING(BATCHID,1,10)='{0}' AND LEN(BATCHID)=15",comboBox1 .Text );
                    BATCHID = bc.numNOYMD(15, 4, "0001", sqb.ToString (), "BATCHID", comboBox1.Text + "-");
                    SN = Convert.ToString(n + 1);
                    cBATCH.MAKERID = LOGIN.EMID;
                    cBATCH.BAKEY = BAKEY;
                    cBATCH.BAID = BAID;
                    cBATCH.BATCHID = BATCHID;
                    cBATCH.WOID = comboBox1.Text;
                    dtx = bc.getdt(string.Format(cBATCH.sql + " WHERE A.WOID='{0}' AND D.SN=1", comboBox1.Text));
                    if (dtx.Rows.Count > 0)
                    {
                        cBATCH.FCID = dtx.Rows[0]["途程编号"].ToString();
                        cBATCH.FLOW_CHART_EDITION = dtx.Rows[0]["途程版本"].ToString();
                        cBATCH.CURRENT_STID = bc.RETURN_STID(dtx.Rows[0]["站别代码"].ToString());
                        cBATCH.STATUS = "WAIT";
                        cBATCH.ACTION_RULE = "TRACK IN";
                    }
                    cBATCH.SN = SN;
                    cBATCH.UNIT_LOT = textBox6.Text;
                    cBATCH.OK_COUNT = textBox6.Text;
                    cBATCH.REJUDGE_COUNT = "0";
                    cBATCH.RE_PROCESSING_COUNT = "0";
                    cBATCH.SCRAP_COUNT = "0";
                    cBATCH.save();
                    DataRow dr = dt1.NewRow();
                    dr["批号"] = BATCHID;
                    dr["项次"] = SN;
                    dr["工单号"] = comboBox1.Text;
                    dr["单位批号量"] = textBox6.Text;
                    dt1.Rows.Add(dr);
                }
                basec.getcoms("UPDATE WORKORDER_MST SET STATUS='PROCESS' WHERE WOID='"+comboBox1 .Text +"'");
                if (cBATCH.IFExecution_SUCCESS == true)
                {
                    dtx = cBATCH.ACTION_DET();
                    if (dtx.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dtx;
                        textBox10.Text = dtx.Rows.Count.ToString();
                    }
                    dgvStateControl();
                    if (MessageBox.Show("要打印这些批号吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //MessageBox.Show(System.IO.Path.GetFullPath("Run Card.xls"));
                        cBATCH.ExcelPrintForEpplus(dtx, "打印Run Card", ConfigurationManager.AppSettings["run-card"].ToString ());
                     
                    }
                    bind();
                  
                }

            }

        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
         textBox10.Text = "";
         dataGridView1.DataSource = null;
         WORKORDER_MANAGE.WORKORDERT FRM = new WORKORDERT();
         FRM.BATCH_USE();
         FRM.ShowDialog();
         this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
         this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
         this.comboBox1.IntegralHeight = true;//恢复默认值
         if (IF_DOUBLE_CLICK)
         {
             comboBox1.Text = WOID;
             textBox2.Text = WAREID;
             textBox3.Text = CO_WAREID;
             textBox4.Text = WNAME;
             textBox5.Text = WO_COUNT;
         }
         DataTable dtx = bc.getdt("SELECT * FROM UNIT_LOT WHERE WAREID='" +textBox2 .Text  + "' AND ACTIVE='Y'");
         if (dtx.Rows.Count > 0)
         {
             hint.Text = "";
             textBox6.Text = dtx.Rows[0]["UNIT_LOT"].ToString();

         }
         else
         {
             textBox6.Text = "";
             hint.Text = "此物料编号不存在单位批号量或是没有生效需先维护";
         }
         dtx = bc.GET_DT_TO_DV_TO_DT(bc.getdt(cBATCH.sqlf), "",string .Format ("工单号='{0}'",comboBox1 .Text ));
         if (dtx.Rows.Count > 0)
         {
             textBox7.Text = dtx.Rows[0]["已投产数量"].ToString();
             textBox8.Text = dtx.Rows[0]["未投产数量"].ToString();
         }
         textBox9.Focus();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }



   

     
   

  

     
   
    }
}
