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
namespace CSPSS.ABNORMAL_MANAGE
{
    public partial class BATCH_REMOVE : Form
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
        private decimal _BATCH_COUNT;
        public decimal BATCH_COUNT
        {
            set { _BATCH_COUNT = value; }
            get { return _BATCH_COUNT; }

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
        private decimal _OK_COUNT;
        public decimal OK_COUNT
        {
            set { _OK_COUNT = value; }
            get { return _OK_COUNT; }

        }

        private decimal _REJUDGE_COUNT;
        public decimal REJUDGE_COUNT
        {
            set { _REJUDGE_COUNT = value; }
            get { return _REJUDGE_COUNT; }

        }
        private decimal _RE_PROCESSING_COUNT;
        public decimal RE_PROCESSING_COUNT
        {
            set { _RE_PROCESSING_COUNT = value; }
            get { return _RE_PROCESSING_COUNT; }

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
        CBATCH_REMOVE cbatch_remove = new CBATCH_REMOVE();
        public BATCH_REMOVE()
        {
            InitializeComponent();
        }
    
        private void BATCH_REMOVE_Load(object sender, EventArgs e)
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
            comboBox1.Focus();
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;
            textBox4.BackColor = Color.Yellow;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            comboBox1.Items.Clear();
            dt1 = bc.getdt("SELECT * FROM BATCH_DET WHERE STATUS NOT IN ('COMPLETE','SCRAP','HOLD')");
            AutoCompleteStringCollection inputInfoSource = new AutoCompleteStringCollection();
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {

                    string suggestWord = dr["BATCHID"].ToString();
                    comboBox1.Items.Add(dr["BATCHID"].ToString());
                    inputInfoSource.Add(suggestWord);
                }
            }
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox1.AutoCompleteCustomSource = inputInfoSource;
            comboBox1.BackColor = Color.Yellow;
            this.Text = "拆批作业";
            groupBox1.Text = "批号信息";
            textBox5.BackColor = CCOLOR.qmhs;
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
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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
        private void add()
        {
            ClearText();
            bind();
            ADD_OR_UPDATE = "ADD";
        }

        private bool judge()
        {
      
            hint.Text = "";
            bool b = false;
            if (bc.JUAGE_BATCHID(comboBox1.Text))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
           }
            else if (bc.getOnlyString (string.Format ("SELECT STATUS FROM BATCH_DET WHERE BATCHID='{0}'",comboBox1 .Text ))=="COMPLETE")
           {
               hint.Text = string.Format("批号 {0} 状态为完工不能拆批",comboBox1 .Text );
               b = true;
           }
            else if (bc.getOnlyString(string.Format("SELECT STATUS FROM BATCH_DET WHERE BATCHID='{0}'", comboBox1.Text)) == "SCRAP")
            {
                hint.Text = string.Format("批号 {0} 状态为报废不能拆批",comboBox1 .Text );
                b = true;
            }
            else if (bc.getOnlyString(string.Format("SELECT STATUS FROM BATCH_DET WHERE BATCHID='{0}'", comboBox1.Text)) == "HOLD")
            {
                hint.Text = string.Format("批号 {0} 状态为中断不能拆批",comboBox1 .Text );
                b = true;
            }
           else if (textBox4.Text == "")
           {
               hint.Text = "批号数量不能为空！";
               b = true;
           }
           else if (bc.yesno (textBox4 .Text )==0)
           {
               hint.Text = "批号数量只能为数字！";
               b = true;
           }
            else if (decimal.Parse(textBox4.Text) >= BATCH_COUNT )
            {
                hint.Text = string.Format("拆批后的数量 {0} 不能大于或等于原批号数量 {1}", textBox4.Text, BATCH_COUNT);
                b = true;

            }
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
        private void btnGenerate_bath_Click(object sender, EventArgs e)
        {

            if (judge())
            {
               
            }
            else
            {
                cbatch_remove.BEID = cbatch_remove.GETID();
                cbatch_remove.OK_COUNT = OK_COUNT;
                cbatch_remove.REJUDGE_COUNT = REJUDGE_COUNT;
                cbatch_remove.RE_PROCESSING_COUNT = RE_PROCESSING_COUNT;
                cbatch_remove.MAKERID = LOGIN.EMID;
                cbatch_remove.BATCHID = comboBox1.Text;
                dt = bc.getdt(string.Format("SELECT * FROM BATCH_DET WHERE BATCHID='{0}'", comboBox1.Text));
                if (dt.Rows.Count > 0)
                {
                    cbatch_remove.WOID = dt.Rows[0]["WOID"].ToString();
                    cbatch_remove.UNIT_LOT = dt.Rows[0]["UNIT_LOT"].ToString();
                    cbatch_remove.FCID  = dt.Rows[0]["FCID"].ToString();
                    cbatch_remove.FLOW_CHART_EDITION = dt.Rows[0]["FLOW_CHART_EDITION"].ToString();
                    cbatch_remove.CURRENT_STID = dt.Rows[0]["CURRENT_STID"].ToString();
                    cbatch_remove.STATUS = dt.Rows[0]["STATUS"].ToString();
                    cbatch_remove.ACTION_RULE = dt.Rows[0]["ACTION_RULE"].ToString();
                    
                }
                cbatch_remove.BATCH_REMOVE_COUNT = BATCH_COUNT - decimal.Parse(textBox4.Text);
                cbatch_remove.save();
                textBox5.Text = cbatch_remove.NEW_BATCHID;
                textBox6.Text = cbatch_remove.BATCH_REMOVE_COUNT.ToString();
                textBox3.Text = textBox4.Text;
                if (cbatch_remove.IFExecution_SUCCESS == true)
                {
                    
                    IFExecution_SUCCESS = true;
                    bind();
                }
                btnGenerate_bath.Enabled = false;
            }

        }
        public void  emptydatatable_PRINT()
        {
          
            dt1.Columns.Add("批号", typeof(string));
            dt1.Columns.Add("项次", typeof(string));
            dt1.Columns.Add("工单号", typeof(string));
            /*dt1.Columns.Add("工单数量", typeof(decimal));*/
            dt1.Columns.Add("单位批号量", typeof(decimal));
            /*dt1.Columns.Add("物料编号", typeof(string));
            dt1.Columns.Add("料号", typeof(string));
            dt1.Columns.Add("品名", typeof(string));
            dt1.Columns.Add("制单人", typeof(string));
            dt1.Columns.Add("制单日期", typeof(string));*/
        

        }
   
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            DataTable dtx = bc.getdt(@"
SELECT 
A.OK_COUNT,
A.REJUDGE_COUNT,
A.RE_PROCESSING_COUNT,
C.CO_WAREID,
C.WNAME
FROM BATCH_DET  A 
LEFT JOIN WORKORDER_MST B ON A.WOID=B.WOID
LEFT JOIN WAREINFO C ON B.WAREID=C.WAREID
WHERE BATCHID='" + comboBox1.Text + "'");
            if (dtx.Rows.Count > 0)
            {
                hint.Text = "";
                 OK_COUNT = decimal.Parse(dtx.Rows[0]["OK_COUNT"].ToString());
                 REJUDGE_COUNT  = decimal.Parse(dtx.Rows[0]["REJUDGE_COUNT"].ToString());
                 RE_PROCESSING_COUNT = decimal.Parse(dtx.Rows[0]["RE_PROCESSING_COUNT"].ToString());
                if (OK_COUNT  > 0)
                {
                    BATCH_COUNT = OK_COUNT ;
                }
                else if (REJUDGE_COUNT > 0)
                {
                    BATCH_COUNT = REJUDGE_COUNT ;
                }
                else if (RE_PROCESSING_COUNT  > 0)
                {
                    BATCH_COUNT =RE_PROCESSING_COUNT ;
                }
                textBox1.Text = dtx.Rows[0]["CO_WAREID"].ToString();
                textBox2.Text = dtx.Rows[0]["WNAME"].ToString();
                textBox3.Text = BATCH_COUNT.ToString();
                textBox4.Focus();
            }
            else
            {
                textBox4.Text = "";
                hint.Text = "批号不存在或状态为完工或报废或中断";
            }
        }
    }
}
