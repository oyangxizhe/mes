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
    public partial class FLOW_CHART : Form
    {
        DataTable dt = new DataTable();
        basec bc=new basec ();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private static string _EMID;
        public static string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private static string _ENAME;
        public static string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private int _GET_DATA_INT;
        public int GET_DATA_INT
        {
            set { _GET_DATA_INT = value; }
            get { return _GET_DATA_INT; }

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
        protected int M_int_judge, i;
        protected int select;
        CFLOW_CHART cFLOW_CHART = new CFLOW_CHART();
        public FLOW_CHART()
        {
            InitializeComponent();
        }
        private void FLOW_CHART_Load(object sender, EventArgs e)
        {
           textBox6.Focus();
           bind();
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
            if (bc.getOnlyString("SELECT UNAME FROM USERINFO WHERE USID='" + LOGIN.USID + "'") == "admin")
            {
                btnToExcel.Visible = true;
            }
            else
            {
                btnToExcel.Visible = false;
            }
            StringBuilder stb = new StringBuilder();
            stb.Append(cFLOW_CHART.sql);
            stb.Append(" WHERE A.FCID LIKE '%" + textBox1.Text + "%' ");
            stb.Append(" AND B.FLOW_CHART_ID LIKE '%" + textBox2.Text + "%'");
            stb.Append(" AND B.FLOW_CHART LIKE '%" + textBox3.Text + "%'");
            stb.Append(" AND B.WAREID LIKE '%" + comboBox1 .Text  + "%'");
            stb.Append(" AND D.CO_WAREID LIKE '%" + textBox4.Text + "%'");
            stb.Append(" AND D.WNAME LIKE '%" + textBox5.Text + "%'");
            stb.Append(" AND B.FLOW_CHART_EDITION LIKE '%" + textBox6.Text + "%'");
            stb.AppendFormat(" AND B.ACTIVE LIKE '%{0}%'",comboBox2 .Text );
            dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.ContextMenuStrip = contextMenuStrip1;
          
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
            search_o(stb.ToString());
   
         
            this.Text = "途程信息";
        }
        #endregion
        #region search_o()
        public void search_o(string sql)
        {
            string sqlo = " ORDER BY B.FCID ASC";
            string v7 = bc.getOnlyString("SELECT SCOPE FROM SCOPE_OF_AUTHORIZATION WHERE USID='" + LOGIN.USID + "'");
            //string v7 = "Y";
            if (v7 == "Y")
            {

                dt = bc.getdt(sql + sqlo);

            }
            else if (v7 == "GROUP")
            {

                dt = bc.getdt(sql + @" AND B.MAKERID IN (SELECT EMID FROM USERINFO A WHERE USER_GROUP IN 
 (SELECT USER_GROUP FROM USERINFO WHERE USID='" + LOGIN.USID + "'))" + sqlo);
            }
            else
            {
                dt = bc.getdt(sql + " AND B.MAKERID='" + LOGIN.EMID + "'" + sqlo);

            }
            if (v7 == "Y")
            {
               // btnToExcel.Visible = true;
            
            }
            else
            {
                //btnToExcel.Visible = false;
              
            }
            //dt = vou.GET_CALCULATE(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dgvStateControl();
            }
            else
            {
                hint.Text = "找不到所要搜索项！";
                dataGridView1.DataSource = null;

            }
        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IDO = cFLOW_CHART.GETID();
            FLOW_CHARTT FRM = new FLOW_CHARTT(this);
            FRM.IDO = cFLOW_CHART.GETID();
            FRM.ADD_OR_UPDATE = "ADD";
            FRM.Show();
          
        }
        public void load()
        {
            bind();
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
           
          
            dataGridView1.Columns["站别编号"].Width = 80;
            dataGridView1.Columns["制单人"].Width = 80;
            dataGridView1.Columns["制单日期"].Width = 120;
            dataGridView1.Columns["项次"].Width = 40;
            dataGridView1.Columns["途程编号"].Width = 70;
            dataGridView1.Columns["物料编号"].Width = 70;
            dataGridView1.Columns["生效否"].Width = 60;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
   
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                dataGridView1.Columns[i].ReadOnly = true;
                i = i + 1;
               
            }
        }
        #endregion

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
   

            if (select != 0)
            {
               
                    int intCurrentRowNumber = this.dataGridView1.CurrentCell.RowIndex;
                    string s1 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[0].Value.ToString().Trim();
                    string s2 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[1].Value.ToString().Trim();
                    string s3 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[2].Value.ToString().Trim();
                    string s4 = this.dataGridView1.Rows[intCurrentRowNumber].Cells[3].Value.ToString().Trim();
  
                    /*CSPSS.VOUCHER_MANAGE.FrmSellTableT.data4[0] = "doubleclick";
                    CSPSS.VOUCHER_MANAGE.FrmSellTableT.data1[0] = s1;
                    CSPSS.VOUCHER_MANAGE.FrmSellTableT.data1[1] = s2;
                    CSPSS.VOUCHER_MANAGE.FrmSellTableT.data1[2] = s3;
                    CSPSS.VOUCHER_MANAGE.FrmSellTableT.data1[3] = s4;
                    CSPSS.VOUCHER_MANAGE.FrmSellTableT.data1[4] = s5;*/
                    if (select == 1)
                    {
                        WORKORDER_MANAGE.WORKORDERT.FCID = s1;
                        WORKORDER_MANAGE.WORKORDERT.FLOW_CHART_ID  = s2;
                        WORKORDER_MANAGE.WORKORDERT.FCNAME = s3;
                        WORKORDER_MANAGE.WORKORDERT.FLOW_CHART_EDITION = s4;
                        WORKORDER_MANAGE.WORKORDERT.IF_DOUBLE_CLICK = true;
                    }
                    this.Close();
                

            }
            else
            {
                FLOW_CHARTT FRM = new FLOW_CHARTT(this);
                FRM.IDO = dt.Rows[dataGridView1.CurrentCell.RowIndex]["途程编号"].ToString();
                FRM.ADD_OR_UPDATE = "UPDATE";
                FRM.Show();
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {

                bc.dgvtoExcel(dataGridView1, "途程信息");

            }
            else
            {
                MessageBox.Show("没有数据可导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void WORKORDER_USE()
        {
            select = 1;

        }

   
    }
}
