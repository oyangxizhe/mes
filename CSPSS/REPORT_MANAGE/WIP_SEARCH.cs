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

namespace CSPSS.REPORT_MANAGE
{
    public partial class WIP_SEARCH : Form
    {
        DataTable dt = new DataTable();
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
        private string _COPYINFO;
        public string COPYINFO
        {
            set { _COPYINFO = value; }
            get { return _COPYINFO; }

        }
        private static string _FLOW_CHART_ID;
        public static string FLOW_CHART_ID
        {
            set { _FLOW_CHART_ID = value; }
            get { return _FLOW_CHART_ID; }

        }
        private static string _FCNAME;
        public static string FCNAME
        {
            set { _FCNAME = value; }
            get { return _FCNAME; }

        }
        private static string _FLOW_CHART_EDITION;
        public static string FLOW_CHART_EDITION
        {
            set { _FLOW_CHART_EDITION = value; }
            get { return _FLOW_CHART_EDITION; }

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
        private  delegate bool dele(string a1,string a2);
        private delegate void delex();
      
        protected int M_int_judge, i;
        protected int select;
        CBATCH cbatch = new CBATCH();
        CPOSTING cposting = new CPOSTING();
        CWIP_SEARCH cwip_search = new CWIP_SEARCH();
        public WIP_SEARCH()
        {
            InitializeComponent();
        }
    
        private void WIP_SEARCH_Load(object sender, EventArgs e)
        {
            hint.Text = "";
            //dataGridView1.Size = new Size(936, 356);
            dataGridView1.Location = new Point(3, 258);
            dataGridView1.Anchor = AnchorStyles.Right;
            this.Text = "查询在制品清单";
            this.groupBox1.Text = "查询条件";
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dataGridView1.BackgroundColor = Color.FromArgb(238, 245, 255);
            DataTable dtx = bc.getdt("SELECT DISTINCT(WOID) FROM BATCH_DET");
            AutoCompleteStringCollection inputInfoSource = new AutoCompleteStringCollection();
            this.Icon = Resource1.xz_200X200;
            comboBox1.Items.Clear();
            if (dtx.Rows.Count > 0)
            { 
                foreach (DataRow dr in dtx.Rows)
                {

                    string suggestWord = dr["WOID"].ToString();
                    comboBox1.Items.Add(dr["WOID"].ToString());
                    inputInfoSource.Add(suggestWord);
                }
            }
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox1.AutoCompleteCustomSource = inputInfoSource;


            dtx = bc.getdt(@"
SELECT DISTINCT(C.CO_WAREID) AS CO_WAREID
FROM BATCH_DET A
LEFT JOIN WORKORDER_MST B ON A.WOID=B.WOID 
LEFT JOIN WareInfo C ON B.WAREID =C.WareID ");
            AutoCompleteStringCollection inputInfoSource2 = new AutoCompleteStringCollection();
            comboBox2.Items.Clear();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtx.Rows)
                {

                    string suggestWord = dr1["CO_WAREID"].ToString();
                    comboBox2.Items.Add(dr1["CO_WAREID"].ToString());
                    inputInfoSource2.Add(suggestWord);
                }
            }
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox2.AutoCompleteCustomSource = inputInfoSource2;

                        dtx = bc.getdt(@"
SELECT
DISTINCT(B.STEP_ID) AS STEP_ID,
B.STEP AS STEP
FROM BATCH_DET  A
LEFT JOIN STEP  B ON A.CURRENT_STID =B.STID  ");
            AutoCompleteStringCollection inputInfoSource3 = new AutoCompleteStringCollection();
            comboBox3.Items.Clear();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr in dtx.Rows)
                {

                    string suggestWord = dr["STEP_ID"].ToString();
                    comboBox3.Items.Add(dr["STEP_ID"].ToString() + "-" + dr["STEP"].ToString());
                    inputInfoSource3.Add(suggestWord);
                }
            }
            this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox3.AutoCompleteCustomSource = inputInfoSource3;

            dtx = bc.getdt(@"
SELECT 
DISTINCT(CASE WHEN ACTION_RULE='TRACK IN ' THEN '入账'
WHEN ACTION_RULE='TRACK OUT' THEN '出账'
WHEN ACTION_RULE='COMPLETE' THEN '完工'
END )
AS ACTION_RULE
FROM BATCH_DET  A  ");
            AutoCompleteStringCollection inputInfoSource4 = new AutoCompleteStringCollection();
            comboBox4.Items.Clear();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr in dtx.Rows)
                {

                    string suggestWord = dr["ACTION_RULE"].ToString();
                    comboBox4.Items.Add(dr["ACTION_RULE"].ToString());
                    inputInfoSource4.Add(suggestWord);
                }
            }
            this.comboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox4.AutoCompleteCustomSource = inputInfoSource4;
            dtx = bc.getdt(@"
SELECT 
DISTINCT(CASE WHEN STATUS='WAIT' THEN '等待'
WHEN STATUS='PROCESS' THEN '生产中'
WHEN STATUS='REJUDGE' THEN '复判'
WHEN STATUS='RE_PROCESSING' THEN '重工'
WHEN STATUS='SCRAP' THEN '报废'
WHEN STATUS='HOLD' THEN '中断'
WHEN STATUS='COMPLETE' THEN '完工'
END )
AS STATUS
FROM BATCH_DET  A  ");
            AutoCompleteStringCollection inputInfoSource5 = new AutoCompleteStringCollection();
            comboBox5.Items.Clear();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr in dtx.Rows)
                {

                    string suggestWord = dr["STATUS"].ToString();
                    comboBox5.Items.Add(dr["STATUS"].ToString());
                    inputInfoSource5.Add(suggestWord);
                }
            }
            this.comboBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox5.AutoCompleteCustomSource = inputInfoSource5;

        }


        public void ClearText()
        {
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy/MM/dd");
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //this.dataGridView1.MergeColumnNames.Add("序号");
            this.dataGridView1.MergeColumnNames.Add("工单号");
            this.dataGridView1.MergeColumnNames.Add("料号");
            this.dataGridView1.MergeColumnNames.Add("品名");
            this.dataGridView1.MergeColumnNames.Add("工单数量");
            this.dataGridView1.MergeColumnNames.Add("途程代码");
            this.dataGridView1.MergeColumnNames.Add("途程名称");
            this.dataGridView1.MergeColumnNames.Add("途程版本");
            this.dataGridView1.MergeColumnNames.Add("批号");
            this.dataGridView1.MergeColumnNames.Add("当前站别代码");
            this.dataGridView1.MergeColumnNames.Add("当前站别名称");
            this.dataGridView1.MergeColumnNames.Add("当前执行规则");
            this.dataGridView1.MergeColumnNames.Add("状态");
            this.dataGridView1.MergeColumnNames.Add("单位批号量");
            //this.dataGridView1.MergeColumnNames.Add("OK数量");
            //this.dataGridView1.MergeColumnNames.Add("复判数量");
            //this.dataGridView1.MergeColumnNames.Add("重工数量");
            //this.dataGridView1.MergeColumnNames.Add("报废数量");
            this.dataGridView1.MergeColumnNames.Add("制单人");
            this.dataGridView1.MergeColumnNames.Add("制单日期");

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
                if (dataGridView1.Columns[i].DataPropertyName == "批号")
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
     
                i = i + 1;
               
            }
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
            dataGridView1.Columns["内箱号"].Width = 80;
            dataGridView1.Columns["制单人"].Width = 80;
            dataGridView1.Columns["制单日期"].Width = 120;
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
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
        
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
            sqb.AppendFormat(cwip_search .sql );
            sqb.AppendFormat(" WHERE A.WOID LIKE '%{0}%' AND D.CO_WAREID LIKE '%{1}%'", comboBox1.Text, comboBox2.Text);
            sqb.AppendFormat(" AND D.WNAME LIKE '%{0}%' AND A.BATCHID LIKE '%{1}%'", textBox1.Text, textBox2.Text);
            sqb.AppendFormat(" AND F.STEP_ID LIKE '%{0}%' AND F.STEP LIKE '%{1}%'", bc.REMOVE_NAME(comboBox3.Text, '-'), textBox3.Text);
            sqb.AppendFormat(" AND A.ACTION_RULE LIKE '%{0}%'", cposting.RETURN_DB_ACTION_RULE(comboBox4.Text));
            sqb.AppendFormat(" AND A.STATUS LIKE '%{0}%'", cposting.RETURN_DB_STATUS(comboBox5.Text));
            if (checkBox1.Checked)
            {
                sqb.AppendFormat(" AND B.DATE BETWEEN '{0}' AND '{1}'", v1, v2);
               
            }
            sqb.AppendFormat("  ORDER BY A.WOID,A.BATCHID ASC");
           
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
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'))" );
            }
            else
            {
                dt = bc.getdt(sql + " AND B.MAKERID='" + LOGIN.EMID + "'");

            }
            dt = cbatch.RETURN_HAVE_ID_DT(dt);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void btndgvInfoCopy_Click(object sender, EventArgs e)
        {

            dgvCopy(ref dataGridView1 );
          
        }
        private void dgvCopy(ref dgvInfo  dgv)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {

                bc.dgvtoExcel(dataGridView1, "在制品清单");

            }
            else
            {
                MessageBox.Show("没有数据可导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
