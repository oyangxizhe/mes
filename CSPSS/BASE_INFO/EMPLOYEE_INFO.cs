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
    public partial class EMPLOYEE_INFO : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
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
        CEMPLOYEE_INFO cemployee_info = new CEMPLOYEE_INFO();
        protected string sql = @"
SELECT 
A.EMID AS 工号,
A.ENAME AS 姓名,
A.DEPART AS 部门,
A.POSITION AS 职务,
A.PHONE AS 电话,
(SELECT ENAME FROM EMPLOYEEINFO 
WHERE EMID=A.MAKERID ) AS 制单人,
A.DATE AS 制单日期
FROM
EMPLOYEEINFO A ";
   
        protected int M_int_judge, i;
        protected int select;
        public EMPLOYEE_INFO()
        {
            InitializeComponent();
        }
        #region double_click
        private void dgvEmployeeInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Enabled == true)
            {
                int indexNumber = dataGridView1.CurrentCell.RowIndex;
                string id = dataGridView1.Rows[indexNumber].Cells[0].Value.ToString().Trim();
                string sendEName = dataGridView1.Rows[indexNumber].Cells[1].Value.ToString().Trim();
                string sendDepart = dataGridView1.Rows[indexNumber].Cells[2].Value.ToString().Trim();
                string[] inputarry = new string[] { sendEName, sendDepart,id};
                if (select == 0)
                {
                    //CSPSS.SellManage.FrmOrders.inputgetOEName[0] = inputarry[0]; 
                }
                if (select == 1)
                {
                  
                }
                if (select == 2)
                {

                }
             
                if (select == 16)
                {
                    CSPSS.USER_MANAGE.USER_INFO.EMID = inputarry[2];
                    CSPSS.USER_MANAGE.USER_INFO.ENAME= inputarry[0];
                    CSPSS.USER_MANAGE.USER_INFO.DEPART = inputarry[1];
                    CSPSS.USER_MANAGE.USER_INFO.IF_DOUBLE_CLICK = true;
                }
          
                if (select == 19)
                {
                   
                }
                this.Close();
            }

        }
        #endregion
        #region only read
        public void dgvReadOnlyOrders()
        {
            dataGridView1.Enabled = true;
            select = 0;

        }
        public void dgvReadOnlyStock()
        {
            dataGridView1.Enabled = true;
            select = 1;
        }
        public void SellTable()
        {
            dataGridView1.Enabled = true;
            select = 2;
        }
        public void dgvReadOnlyPur()
        {
            dataGridView1.Enabled = true;
            select = 3;
        }
        public void GodE()
        {
            dataGridView1.Enabled = true;
            select = 4;
        }
        public void dgvReadOnlyOrdersT()
        {
            dataGridView1.Enabled = true;
            select = 5;

        }
        public void dgvReadOnlyStockT()
        {
            dataGridView1.Enabled = true;
            select = 6;
        }
        public void dgvReadOnlyPurT()
        {
            dataGridView1.Enabled = true;
            select = 7;
        }
        public void SellTableT()
        {
            dataGridView1.Enabled = true;
            select = 8;
        }
        public void ReturnT()
        {
            dataGridView1.Enabled = true;
            select = 9;
        }
        public void Return()
        {
            dataGridView1.Enabled = true;
            select = 10;
        }
        public void SellReT()
        {
            dataGridView1.Enabled = true;
            select = 11;
        }
        public void SellRe()
        {
            dataGridView1.Enabled = true;
            select = 12;
        }
        public void MateReT()
        {
            dataGridView1.Enabled = true;
            select = 13;
        }
        public void MateRe()
        {
            dataGridView1.Enabled = true;
            select = 14;
        }
        public void GodET()
        {
            dataGridView1.Enabled = true;
            select = 15;
        }
        public void USER_INFO_USE()
        {
            dataGridView1.Enabled = true;
            select = 16;
        }
        public void CUSTOMERINFO_USE()
        {
            dataGridView1.Enabled = true;
            select = 17;

        }
        public void VOUCHER_USE()
        {
            dataGridView1.Enabled = true;
            select = 18;

        }
        public void a3()
        {
            dataGridView1.Enabled = true;
            select = 19;

        }
  
        #endregion
        private void EMPLOYEE_INFO_Load(object sender, EventArgs e)
        {

            Bind();

        }
        private void Bind()
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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DataSource = bc.RETURN_ADD_EMPTY_COLUMN("DEPART", "DEPART");
            comboBox1.DisplayMember = "DEPART";

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DataSource = bc.RETURN_ADD_EMPTY_COLUMN("POSITION", "POSITION");
            comboBox2.DisplayMember = "POSITION";

        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i == 1)
                {
                    dataGridView1.Columns[i].Width = 70;

                }
                else if (i == 6)
                {
                    dataGridView1.Columns[i].Width = 120;

                }
                else if (i == 4)
                {
                    dataGridView1.Columns[i].Width = 90;

                }
                else
                {
                    dataGridView1.Columns[i].Width = 60;

                }
            
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
            if (!bc.exists("SELECT EMID FROM EMPLOYEEINFO WHERE EMID='" + textBox1 .Text + "'"))
            {

                basec.getcoms(@"INSERT INTO EMPLOYEEINFO(EMID,ENAME,DEPART,POSITION,MAKERID,DATE,YEAR,
                                   MONTH,PHONE) VALUES ('" + textBox1.Text + "','" + textBox2.Text +
                 "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + varMakerID + "','" + varDate +
                 "','" + year + "','" + month + "','" + textBox3.Text + "')");
                IFExecution_SUCCESS = true;

            }
            else
            {
                basec.getcoms(@"UPDATE EMPLOYEEINFO SET ENAME='" + textBox2.Text + "',DEPART='" + comboBox1.Text +
                      "',POSITION='" + comboBox2.Text + "',MAKERID='" + varMakerID +
                      "',DATE='" + varDate + "',PHONE='" + textBox3.Text + "' WHERE EMID='" + textBox1.Text + "'");
                IFExecution_SUCCESS = true;
            }
            Bind();
        }
        #endregion
        #region juage()
        private bool juage()
        {


            bool b = false;
            if (textBox2.Text == "")
            {
                b = true;

                hint.Text = "姓名不能为空！";
             
            }
     
            else if (bc.checkphone(textBox3 .Text ) == false)
            {
                b = true;
                hint.Text = "电话号码只能输入数字！";

            }
            return b;

        }
        #endregion
        public void ClearText()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        
        }

        private void dgvEmployeeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (v1 != "")
            {
                textBox1.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox2.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                comboBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                comboBox2.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox3.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            add();
        }
        private void add()
        {

            textBox1.Text = cemployee_info.GETID();
            ClearText();
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


                dt = bc.getdt(sql+" WHERE A.EMID LIKE '%"+textBox4.Text +"%' AND A.ENAME LIKE '%"+textBox5 .Text +"%'");
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
            if (bc.JuageIfAllowDeleteEMID(id))
            {
                hint.Text = bc.ErrowInfo;
            }
            else
            {
                IFExecution_SUCCESS = false;
                string strSql = "DELETE FROM EMPLOYEEINFO WHERE EMID='" + id + "'";
                basec.getcoms(strSql);

                Bind();
                ClearText();
            }
            try
            {
            
            }
            catch (Exception)
            {


            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
