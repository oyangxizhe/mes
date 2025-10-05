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
    public partial class BAD_PHENOMENON_SEARCH : Form
    {
        DataTable dt = new DataTable();
        basec bc=new basec ();
        CBAD_PHENOMENON cBAD_PHENOMENON = new CBAD_PHENOMENON();
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
        public BAD_PHENOMENON_SEARCH()
        {
            InitializeComponent();
        }
        public void ClearText()
        {
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        
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
            this.dataGridView1.MergeColumnNames.Add("批号");
            this.dataGridView1.MergeColumnNames.Add("站别代码");
            this.dataGridView1.MergeColumnNames.Add("站别名称");
            this.dataGridView1.MergeColumnNames.Add("机台群组代码");
            this.dataGridView1.MergeColumnNames.Add("机台群组名称");
            this.dataGridView1.MergeColumnNames.Add("机台代码");
            this.dataGridView1.MergeColumnNames.Add("机台名称");
            this.dataGridView1.MergeColumnNames.Add("不良现象群组代码");
            this.dataGridView1.MergeColumnNames.Add("不良现象群组名称");
            this.dataGridView1.MergeColumnNames.Add("不良现象代码");
            this.dataGridView1.MergeColumnNames.Add("不良现象名称");
            this.dataGridView1.MergeColumnNames.Add("不良原因代码");
            this.dataGridView1.MergeColumnNames.Add("不良原因名称");
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
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
     
                i = i + 1;
               
            }
            dataGridView1.Columns["序号"].Width = 40;
            dataGridView1.Columns["工单号"].Width = 80;
            dataGridView1.Columns["料号"].Width = 80;
            dataGridView1.Columns["品名"].Width = 80;
            dataGridView1.Columns["批号"].Width = 200;
            dataGridView1.Columns["站别代码"].Width = 80;
            dataGridView1.Columns["站别名称"].Width = 80;
            dataGridView1.Columns["机台群组代码"].Width = 90;
            dataGridView1.Columns["机台群组名称"].Width = 120;
            dataGridView1.Columns["机台代码"].Width = 90;
            dataGridView1.Columns["机台名称"].Width = 120;
            dataGridView1.Columns["不良现象群组代码"].Width = 120;
            dataGridView1.Columns["不良现象群组名称"].Width = 140;
            dataGridView1.Columns["不良现象代码"].Width = 90;
            dataGridView1.Columns["不良现象名称"].Width = 120;
            dataGridView1.Columns["不良原因代码"].Width = 90;
            dataGridView1.Columns["不良原因名称"].Width = 120;
            dataGridView1.Columns["报废数量"].Width = 80;
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
            sqb.AppendFormat(cBAD_PHENOMENON .sqlf);
            sqb.AppendFormat(" WHERE C.WOID LIKE '%{0}%' AND D.CO_WAREID LIKE '%{1}%'", comboBox1.Text, comboBox2.Text);
            sqb.AppendFormat(" AND D.WNAME LIKE '%{0}%' AND A.BATCHID LIKE '%{1}%'", textBox1.Text, textBox2.Text);
            if (checkBox1.Checked)
            {
                sqb.AppendFormat(" AND B.DATE BETWEEN '{0}' AND '{1}'", v1, v2);
               
            }
            sqb.AppendFormat(@" 
ORDER BY 
C.WareID,
A.BATCHID  
ASC 
");
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
            dt = cBAD_PHENOMENON.RETURN_HAVE_ID_DT(dt);
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

        private void BAD_PHENOMENON_SEARCH_Load(object sender, EventArgs e)
        {
            hint.Text = "";
            this.Icon = Resource1.xz_200X200;
            //dataGridView1.Size = new Size(936, 356);
            dataGridView1.Location = new Point(3, 258);
            dataGridView1.Anchor = AnchorStyles.Right;
            this.Text = "查询不良数量";
            this.groupBox1.Text = "查询条件";
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dataGridView1.BackgroundColor = Color.FromArgb(238, 245, 255);
            DataTable dtx = bc.getdt(cBAD_PHENOMENON.sqlfi );
            AutoCompleteStringCollection inputInfoSource = new AutoCompleteStringCollection();
            comboBox1.Items.Clear();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr in dtx.Rows)
                {

                    string suggestWord = dr["工单号"].ToString();
                    comboBox1.Items.Add(dr["工单号"].ToString());
                    inputInfoSource.Add(suggestWord);
                }
            }
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox1.AutoCompleteCustomSource = inputInfoSource;


            dtx =bc.getdt(cBAD_PHENOMENON.sqlfi);
            AutoCompleteStringCollection inputInfoSource2 = new AutoCompleteStringCollection();
            comboBox2.Items.Clear();
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr1 in dtx.Rows)
                {

                    string suggestWord = dr1["料号"].ToString();
                    comboBox2.Items.Add(dr1["料号"].ToString());
                    inputInfoSource2.Add(suggestWord);
                }
            }
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox2.AutoCompleteCustomSource = inputInfoSource2;



        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {

                bc.dgvtoExcel(dataGridView1, "不良数量");

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
