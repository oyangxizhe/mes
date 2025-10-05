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

namespace CSPSS.BASE_INFO
{
    public partial class UNIT : Form
    {
        DataTable dt = new DataTable();
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
        basec bc = new basec();
        CUNIT cUNIT = new CUNIT();
        protected string sql = @"
SELECT 
A.UNID AS 单位编号,
A.UNIT AS 单位名称,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS 制单人,
A.DATE AS 制单日期
FROM
UNIT A ";
   
        protected int M_int_judge, i;
        protected int select;
        public UNIT()
        {
            InitializeComponent();
        }
        #region double_click
        private void dgvEmployeeInfo_DoubleClick(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void DEPAET_Load(object sender, EventArgs e)
        {
            bind();

        }

        private void bind()
        {
            textBox1.Text = IDO;
            dt = basec.getdts(sql);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            textBox2.Focus();
            textBox2.BackColor = Color.Yellow;
            dgvStateControl();
            hint.Location = new Point(400,100);
            hint.ForeColor = Color.Red;
        
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            label12.Text = "单位编号";
            label14.Text = "单位名称";
            groupBox1.Text = "单位信息";
            label1.Text = "单位编号";
            label2.Text = "单位名称";
            this.Text = "单位信息";
        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
            for (i = 0; i < numCols1; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns["单位编号"].Width = 70;
                dataGridView1.Columns["单位名称"].Width = 120;
                dataGridView1.Columns["制单人"].Width = 80;
                dataGridView1.Columns["制单日期"].Width = 120;
            
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].ReadOnly = true;

            }
            dataGridView1.Columns["制单人"].Width = 70;
        }
        #endregion
    
        #region save
        private void save()
        {

            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss");

            string varMakerID = LOGIN.EMID;
            if (!bc.exists("SELECT UNID FROM UNIT WHERE UNID='" + textBox1 .Text + "'"))
            {

                if (bc.exists("SELECT * FROM UNIT WHERE UNIT='"+textBox2 .Text +"'"))
                {
                    hint.Text = "此单位已经存在";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    basec.getcoms(@"INSERT INTO UNIT(UNID,UNIT,MAKERID,DATE,YEAR,
                                   MONTH) VALUES ('" + textBox1.Text + "','" + textBox2.Text +
                     "','" + varMakerID + "','" + varDate +
                     "','" + year + "','" + month + "')");
                    IFExecution_SUCCESS = true;
                    bind();
                }

            }
            else
            {
                if (bc.exists("SELECT * FROM UNIT WHERE UNIT='" + textBox2.Text + "'"))
                {
                    hint.Text = "此单位已经存在";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    basec.getcoms(@"UPDATE UNIT SET UNIT='" + textBox2.Text + "',MAKERID='" + varMakerID +
                          "',DATE='" + varDate + "' WHERE UNID='" + textBox1.Text + "'");
                    IFExecution_SUCCESS = true;
                    bind();
                }
            }
           
        }
        #endregion
        #region juage()
        private bool juage()
        {


            bool b = false;
            if (textBox2.Text == "")
            {
                b = true;

                hint.Text = "单位不能为空！";
             
            }
            return b;

        }
        #endregion
        public void ClearText()
        {
            textBox2.Text = "";
        
        }

     
        private void btnAdd_Click(object sender, EventArgs e)
        {

            add();
        }
        private void add()
        {
            ClearText();
            textBox1.Text = cUNIT.GETID();
            textBox2.Focus();

        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (juage())
            {

            }
            else
            {
                save();
                if (IFExecution_SUCCESS)
                {
                  
                    add();
                }
         
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                dt = bc.getdt(sql+" WHERE A.UNID LIKE '%"+textBox4.Text +"%' AND A.UNIT LIKE '%"+textBox5 .Text +"%'");
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dgvStateControl();

                }
                else
                {

               
                    hint.Text = "没有找到相关信息！";
                    dataGridView1.DataSource = null;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
          
            
            try
            {
                IFExecution_SUCCESS = false;
                string strSql = "DELETE FROM UNIT WHERE UNID='" + id + "'";
                basec.getcoms(strSql);
                bind();
                ClearText();
            }
            catch (Exception)
            {


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

                dataGridView1.Focus();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (v1 != "")
            {
                textBox1.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox2.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();

            }
        }

     
   
    }
}
