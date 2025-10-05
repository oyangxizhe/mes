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
    public partial class WIP_INTERRUPT : Form
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
        CWIP_INTERRUPT cWIP_INTERRUPT = new CWIP_INTERRUPT();
        public WIP_INTERRUPT()
        {
            InitializeComponent();
        }
    
        private void WIP_INTERRUPT_Load(object sender, EventArgs e)
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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
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
            this.Text = "在制品中断作业";
            groupBox1.Text = "批号信息";
            textBox3.Focus();
          
        }
        #endregion
        public void ClearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    
        private bool judge_if_exists_select_context()
        {
            hint.Text = "";
            bool b = false;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["复选框"].ToString() == "True")
                        b = true;
                      break;
                }
            }
            return b;
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
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i == 0)
                {
                    dataGridView1.Columns[i].ReadOnly = false;
                }
                else
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            dataGridView1.Columns["复选框"].Width = 50;
            dataGridView1.Columns["序号"].Width = 40;
            dataGridView1.Columns["工单号"].Width = 70;
            dataGridView1.Columns["料号"].Width = 80;
            dataGridView1.Columns["品名"].Width = 80;
            dataGridView1.Columns["工单数量"].Width = 80;
            dataGridView1.Columns["途程代码"].Width = 80;
            dataGridView1.Columns["途程名称"].Width = 80;
            dataGridView1.Columns["途程版本"].Width = 80;
            dataGridView1.Columns["批号"].Width = 200;
            dataGridView1.Columns["当前站别代码"].Width = 90;
            dataGridView1.Columns["当前站别名称"].Width = 90;
            dataGridView1.Columns["当前执行规则"].Width = 90;
            dataGridView1.Columns["状态"].Width = 80;
            dataGridView1.Columns["单位批号量"].Width = 80;
            dataGridView1.Columns["OK数量"].Width = 60;
            dataGridView1.Columns["复判数量"].Width = 60;
            dataGridView1.Columns["重工数量"].Width = 60;
            dataGridView1.Columns["报废数量"].Width = 60;
            dataGridView1.Columns["制单人"].Width = 80;
            dataGridView1.Columns["制单日期"].Width = 120;
        }
        #endregion
        private void dataGridView1_Click(object sender, EventArgs e)
        {
         
        }

        private void btnGenerate_bath_Click(object sender, EventArgs e)
        {

            if (judge_if_exists_select_context())
            {
                action();
            }
            else
            {

                hint.Text = "没有选中项";
            }

        }
        private void action()
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["复选框"].ToString() == "True")
                    {
                        cWIP_INTERRUPT.WIID = cWIP_INTERRUPT.GETID();
                        cWIP_INTERRUPT.BATCHID = dr["批号"].ToString();
                        cWIP_INTERRUPT.MAKERID = LOGIN.EMID;
                        cWIP_INTERRUPT.save();
                    }
                }
                if (cWIP_INTERRUPT.IFExecution_SUCCESS == true)
                {
                    IFExecution_SUCCESS = true;
                    search();
                    bind();
                }
            }
            else
            {
                hint.Text = "无数据可作业";

            }
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
          
            DataTable dtx = bc.getdt(@"
SELECT 
A.WOID,
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
                textBox1.Text = dtx.Rows[0]["CO_WAREID"].ToString();
                textBox2.Text = dtx.Rows[0]["WNAME"].ToString();
                textBox3.Text = dtx.Rows[0]["WOID"].ToString();
           
            }
            else
            {
             
                hint.Text = "批号不存在或状态为完工或报废";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            hint.Text = "";
            search();
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        #region search()
        public void search()
        {
            dataGridView1.AllowUserToAddRows = false;
            string v1 = dateTimePicker1.Value.ToString("yyyy/MM/dd 00:00:00").Replace("-", "/");
            string v2 = dateTimePicker2.Value.ToString("yyyy/MM/dd 23:59:59").Replace("-", "/");
            string v3 = dateTimePicker1.Value.ToString("yyyy/MM/dd").Replace("-", "/");
            string v4 = dateTimePicker2.Value.ToString("yyyy/MM/dd").Replace("-", "/");
            StringBuilder sqb = new StringBuilder();
            sqb.AppendFormat(cWIP_INTERRUPT .sql );
            sqb.AppendFormat(" WHERE A.WOID LIKE '%{0}%' AND C.CO_WAREID LIKE '%{1}%'", textBox3.Text, textBox1.Text);
            sqb.AppendFormat(" AND C.WNAME LIKE '%{0}%' AND A.BATCHID LIKE '%{1}%'", textBox2.Text,  comboBox1.Text);
            sqb.AppendFormat(" AND A.STATUS NOT IN ('SCRAP','COMPLETE','HOLD')");
            if (checkBox1.Checked)
            {
                sqb.AppendFormat(" AND G.DATE BETWEEN '{0}' AND '{1}'", v1, v2);

            }
            sqb.AppendFormat("  ORDER BY A.BATCHID ASC ");
            search_o(sqb.ToString());

        }
        #endregion
        #region search_o()
        public void search_o(string sql)
        {

            string v7 = bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + LOGIN.USID + "'");
            v7 = "Y";
            if (v7 == "Y")
            {

                dt = bc.getdt(sql);

            }
            else if (v7 == "GROUP")
            {

                dt = bc.getdt(sql + @" AND B.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'))");
            }
            else
            {
                dt = bc.getdt(sql + " AND B.MAKERID='" + LOGIN.EMID + "'");

            }
            dt =cWIP_INTERRUPT . RETURN_HAVE_ID_DT(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dgvStateControl();
            }
            else
            {


                hint.Text = "找不到所要搜索项！";
                dataGridView1.DataSource = dt;

            }

        }
        #endregion
        private void btndgvInfoCopy_Click(object sender, EventArgs e)
        {

            dgvCopy(ref dataGridView1);

        }
        private void dgvCopy(ref DataGridView  dgv)
        {
            if (dgv.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(dgv.GetClipboardContent());
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Right) //判断是不是右键
            {
                Control control = new Control();
                Point ClickPoint = new Point(e.X, e.Y);
                control.GetChildAtPoint(ClickPoint);
                if (dataGridView1.HitTest(e.X, e.Y).RowIndex >= 0 && dataGridView1.HitTest(e.X, e.Y).ColumnIndex >= 0)//判断你点的是不是一个信息行里
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].Cells[dataGridView1.HitTest(e.X, e.Y).ColumnIndex];
                    ContextMenu con = new ContextMenu();
                    MenuItem menuDeleteknowledge = new MenuItem("复制");
                    menuDeleteknowledge.Click += new EventHandler(btndgvInfoCopy_Click);
                    con.MenuItems.Add(menuDeleteknowledge);
                    this.dataGridView1.ContextMenu = con;
                    con.Show(dataGridView1, new Point(e.X + 10, e.Y));
                }

            }
        }

   
    }
}
