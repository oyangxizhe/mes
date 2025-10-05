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

namespace CSPSS.MACHINE_MANAGE
{
    public partial class MACHINE_GROUP : Form
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
        CMACHINE_GROUP cMACHINE_GROUP = new CMACHINE_GROUP();
   
        protected int M_int_judge, i;
        protected int select;
        public MACHINE_GROUP()
        {
            InitializeComponent();
        }
     

        private void DEPAET_Load(object sender, EventArgs e)
        {
            bind();

        }

        private void bind()
        {
            dt = basec.getdts(cMACHINE_GROUP.sql);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            textBox2.Focus();
            textBox2.BackColor = Color.Yellow;
            textBox3.BackColor = Color.Yellow;
            dgvStateControl();
            hint.Location = new Point(400,100);
            hint.ForeColor = Color.Red;
        
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(cMACHINE_GROUP.IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(cMACHINE_GROUP.IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            label12.Text = "机台群组代码";
            label14.Text = "机台群组名称";
            groupBox1.Text = "机台群组信息";
          
            label2.Text = "机台群组代码";
            this.Text = "机台群组信息";
            label3.Text = "机台群组名称";
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
                dataGridView1.Columns["机台群组名称"].Width = 120;
                dataGridView1.Columns["制单人"].Width = 70;
                dataGridView1.Columns["制单日期"].Width = 120;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            cMACHINE_GROUP.EMID = LOGIN.EMID;
            cMACHINE_GROUP.MRID = IDO;
            cMACHINE_GROUP .MACHINE_GROUP_ID =textBox2.Text ;
            cMACHINE_GROUP .MACHINE_GROUP =textBox3.Text ;
            cMACHINE_GROUP.save();
            IFExecution_SUCCESS = cMACHINE_GROUP.IFExecution_SUCCESS;
            hint.Text = cMACHINE_GROUP.ErrowInfo;
            if (IFExecution_SUCCESS)
            {

                bind();
            }
           
        }
        #endregion
        #region juage()
        private bool juage()
        {
            bool b = false;
            if (IDO== "")
            {
                b = true;
                hint.Text = "编号不能为空！";
            }
            else if (textBox2.Text == "")
            {
                b = true;
                hint.Text = "机台群组代码不能为空！";
            }
            else if (textBox3.Text == "")
            {
                b = true;
                hint.Text = "机台群组名称不能为空！";
            }
            return b;

        }
        #endregion
        public void ClearText()
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }
    
        private void add()
        {
            ClearText();
            IDO = cMACHINE_GROUP.GETID();
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


                dt = bc.getdt(cMACHINE_GROUP.sql + " WHERE A.MACHINE_GROUP_ID LIKE '%" + textBox4.Text + "%' AND A.MACHINE_GROUP LIKE '%" + textBox5.Text + "%'");
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
            if (bc.exists(string.Format("SELECT * FROM POSTING_MST WHERE MRID='{0}'", bc.RETURN_MRID(id))))
            {
                hint.Text = string.Format("机台群组 {0} 已经存在过账记录不允许删除", id);
            }
            else
            {
                IFExecution_SUCCESS = false;
                string strSql = "DELETE FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='" + id + "'";
                basec.getcoms(strSql);
                bind();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hint.Text = "";
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (v1 != "")
            {
                IDO = bc.getOnlyString(string.Format("SELECT MRID FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='{0}'",v1));
                textBox2.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox3.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.Enabled == true)
            {
                int indexNumber = dataGridView1.CurrentCell.RowIndex;
                string v1= dataGridView1.Rows[indexNumber].Cells[0].Value.ToString().Trim();
                string v2= dataGridView1.Rows[indexNumber].Cells[1].Value.ToString().Trim();
                string v3 = dataGridView1.Rows[indexNumber].Cells[2].Value.ToString().Trim();
           
                if (select == 0)
                {
                    PRODUCTION_MANAGE.POSTINGT.MRID = v1;
                    PRODUCTION_MANAGE.POSTINGT.MACHINE_GROUP_ID = v2;
                    PRODUCTION_MANAGE.POSTINGT.MACHINE_GROUP = v3;
                    PRODUCTION_MANAGE.POSTINGT.IF_DOUBLE_CLICK = true;
                }
      
                this.Close();
            }
        }
        public void POSTING_USE()
        {
            select = 0;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

   
     
   
    }
}
