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
namespace CSPSS.PRODUCTION_MANAGE
{
    public partial class BATCH_TO_PRODUCT : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dtx = new DataTable();
        basec bc=new basec ();
        #region nature
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
        #endregion
        string sql = @"
SELECT 
ROW_NUMBER() OVER 
(ORDER BY A.PRODUCT_BARCODE ASC) AS 序号,
BATCHID AS 批号,
PRODUCT_BARCODE AS 产品条码,
(SELECT ENAME FROM EMPLOYEEINFO  WHERE EMID=A.MAKERID) AS 制单人,
DATE AS 制单日期
FROM BATCH_TO_PRODUCT A";
        protected int M_int_judge, i;
        protected int select;
        CBATCH cBATCH = new CBATCH();
   
        public BATCH_TO_PRODUCT()
        {
            InitializeComponent();
        }
    
        private void BATCH_TO_PRODUCT_Load(object sender, EventArgs e)
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
            hint.Location = new Point(400, 100);
            textBox4.Focus();
            hint.ForeColor = Color.Red;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            textBox4.BackColor = Color.Yellow;
            groupBox1.Text = "批号信息";
            textBox5.BackColor = CCOLOR.qmhs;
            dt = bc.getdt(sql + " WHERE BATCHID='" + textBox4.Text + "'");
            dataGridView1.DataSource = dt;
            dgvStateControl();
        }
        #endregion
        public void ClearText()
        {
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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
            BATCH_COUNT = 0;
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
WHERE BATCHID='" + textBox4.Text + "'");
            if (dtx.Rows.Count > 0)
            {
                hint.Text = "";
                OK_COUNT = decimal.Parse(dtx.Rows[0]["OK_COUNT"].ToString());
                REJUDGE_COUNT = decimal.Parse(dtx.Rows[0]["REJUDGE_COUNT"].ToString());
                RE_PROCESSING_COUNT = decimal.Parse(dtx.Rows[0]["RE_PROCESSING_COUNT"].ToString());
                if (OK_COUNT > 0)
                {
                    BATCH_COUNT = OK_COUNT;
                }
                else if (REJUDGE_COUNT > 0)
                {
                    BATCH_COUNT = REJUDGE_COUNT;
                }
                else if (RE_PROCESSING_COUNT > 0)
                {
                    BATCH_COUNT = RE_PROCESSING_COUNT;
                }
                textBox1.Text = dtx.Rows[0]["CO_WAREID"].ToString();
                textBox2.Text = dtx.Rows[0]["WNAME"].ToString();
                textBox3.Text = BATCH_COUNT.ToString();

            }
            dt = bc.getdt(sql+" WHERE BATCHID='"+textBox4.Text +"'");
      
            hint.Text = "";
            bool b = false;

            if (bc.JUAGE_BATCHID(textBox4 .Text ))
            {
                hint.Text = bc.ErrowInfo;
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
                !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn)) && ActiveControl .TabIndex !=70 
                && ActiveControl .TabIndex !=72)
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
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
        }
        #endregion
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (judge())
                {
                }
                else if (textBox4.Text != "" && textBox5.Text == "")
                {
                    hint.Text = string.Format("产品条码不能为空");
                   
                }
          
                else if (dt.Rows .Count == BATCH_COUNT)
                {
                    hint.Text = string.Format("产品条码数量不能大于批号数量");
                  
                }
                else if (bc.exists (sql+" WHERE PRODUCT_BARCODE='"+textBox5 .Text +"'"))
                {
                    hint.Text = string.Format("产品条码 {0} "+"已经存在系统中",textBox5 .Text );

                }
                else
                {  
                    string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
                    string makerid = LOGIN.EMID;
                    basec.getcoms(@"
INSERT INTO 
BATCH_TO_PRODUCT
(
PRODUCT_BARCODE,
BATCHID,
MAKERID,
DATE
) 
VALUES ('" + textBox5.Text +  "','" + textBox4.Text + "','"+makerid +"','"+varDate +"')");
                    IFExecution_SUCCESS = true;
                    bind();
                    textBox5.Text = "";
                    textBox5.Focus();

                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (judge())
                {
                }
                else
                {
                    bind();
                    textBox5.Focus();
                }
             
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (judge())
            {
            }
            else
            {
                bind();
                textBox5.Focus();
            }
        }
    }
}
