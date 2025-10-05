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
    public partial class MACHINE_AND_GROUP : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private string _MAID;
        public string MAID
        {
            set { _MAID = value; }
            get { return _MAID; }

        }
        private string _MACHINE_ID;
        public string MACHINE_ID
        {
            set { _MACHINE_ID = value; }
            get { return _MACHINE_ID; }

        }
        private string _MACHINE_GROUP_ID;
        public string MACHINE_GROUP_ID
        {
            set { _MACHINE_GROUP_ID = value; }
            get { return _MACHINE_GROUP_ID; }

        }
        private int _INDEX;
        public int INDEX
        {
            set { _INDEX = value; }
            get { return _INDEX; }

        }
        private string _MRID;
        public string MRID
        {
            set { _MRID = value; }
            get { return _MRID; }

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
        CMACHINE_AND_GROUP cMACHINE_AND_GROUP = new CMACHINE_AND_GROUP();
   
        protected int M_int_judge, i;
        protected int select;
        public MACHINE_AND_GROUP()
        {
            InitializeComponent();
        }
     

        private void DEPAET_Load(object sender, EventArgs e)
        {
            bind();
            
        }

        private void bind()
        {
            dt = basec.getdts(cMACHINE_AND_GROUP.sql+" WHERE A.MAID NOT IN (SELECT MAID FROM MACHINE_AND_GROUP)");
            dataGridView1.DataSource = dt;
            dt1 = basec.getdts(cMACHINE_AND_GROUP.sqlo);
            dataGridView2.DataSource = dt1;
            if ( MACHINE_GROUP_ID  == null)
            {
                DataTable dtx = basec.getdts(cMACHINE_AND_GROUP.sqlo);
                if (dtx.Rows.Count > 0)
                {
                    dt2 = basec.getdts(string.Format(cMACHINE_AND_GROUP.sqlf + " WHERE C.MACHINE_GROUP_ID='{0}'",dtx.Rows [0]["机台群组代码"].ToString ()));
                    MACHINE_GROUP_ID = dtx.Rows[0]["机台群组代码"].ToString();
                }
             
            }
            else
            {
                dt2 = basec.getdts(string.Format(cMACHINE_AND_GROUP.sqlf + " WHERE C. MACHINE_GROUP_ID='{0}'", MACHINE_GROUP_ID));
            }
            dataGridView2.ClearSelection();//取消默认选中列
          
            dataGridView2.Rows[INDEX].Selected = true;
            
         
        
            dataGridView3.DataSource = dt2;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            dgvStateControl();
            dgvStateControl_t();
            dgvStateControl_th();
            hint.Location = new Point(400,100);
            hint.ForeColor = Color.Red;
        
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(cMACHINE_AND_GROUP.IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(cMACHINE_AND_GROUP.IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            label12.Text = "机台代码";
            label14.Text = "机台名称";
            this.Text = "机台群组对应机台信息";
           
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
                dataGridView1.Columns["复选框"].Width = 50;
                dataGridView1.Columns["机台代码"].Width = 70;
                dataGridView1.Columns["机台名称"].Width = 120;
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
                if (i == 0)
                {
                }
                else
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }

            }
            dataGridView1.Columns["制单人"].Width = 70;
        }
        #endregion
        #region dgvStateControl_t
        private void dgvStateControl_t()
        {
            int i;
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView2.Columns.Count;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
               
                dataGridView2.Columns["机台群组代码"].Width = 90;
                dataGridView2.Columns["机台群组名称"].Width = 120;
                dataGridView2.Columns["制单人"].Width = 70;
                dataGridView2.Columns["制单日期"].Width = 120;
                dataGridView2.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].ReadOnly = true;

            }
            dataGridView2.Columns["制单人"].Width = 70;
        }
        #endregion
        #region dgvStateControl_th
        private void dgvStateControl_th()
        {
            int i;
            dataGridView3.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView3.Columns.Count;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns["复选框"].Width = 50;
                dataGridView3.Columns["机台代码"].Width = 90;
                dataGridView3.Columns["机台名称"].Width = 120;
                dataGridView3.Columns["制单人"].Width = 70;
                dataGridView3.Columns["制单日期"].Width = 120;
                dataGridView3.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView3.EnableHeadersVisualStyles = false;
                dataGridView3.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
            for (i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView3.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            for (i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i == 0)
                {

                }
                else
                {

                    dataGridView3.Columns[i].ReadOnly = true;
                }

            }
            dataGridView3.Columns["制单人"].Width = 70;
        }
        #endregion
  
        #region juage()
        private bool juage()
        {


            bool b = false;
         
            return b;

        }
        #endregion
        public void ClearText()
        {
          
        }
    
        private void add()
        {
            ClearText();
         

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

                StringBuilder sqb = new StringBuilder();
                sqb.Append(cMACHINE_AND_GROUP.sql);
                sqb.AppendFormat (" WHERE A.MACHINE_ID LIKE '%{0}%'",textBox4 .Text );
                sqb.AppendFormat(" AND A.MACHINE LIKE '%{0}%'",textBox5.Text );
                sqb.Append(" AND A.MAID NOT IN (SELECT MAID FROM MACHINE_AND_GROUP)");
                dt = bc.getdt(sqb.ToString ());
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
                
                }
      
                this.Close();
            }
        }
        public void MACHINE_AND_GROUP_USE()
        {
            select = 0;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }
        #region save
        private void save()
        {
            foreach (DataRow dr in dt.Rows)
            {

                if (dr["复选框"].ToString() == "True")
                {
                    cMACHINE_AND_GROUP.MAKERID = LOGIN.EMID;
                    cMACHINE_AND_GROUP.MAID = bc.getOnlyString (string.Format ("SELECT MAID FROM MACHINE WHERE MACHINE_ID='{0}'",dr["机台代码"].ToString()));
                    cMACHINE_AND_GROUP.MRID = bc.getOnlyString(string.Format("SELECT MRID FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='{0}'", MACHINE_GROUP_ID ));
                    cMACHINE_AND_GROUP.save();
               
                }
            }
            IFExecution_SUCCESS = cMACHINE_AND_GROUP.IFExecution_SUCCESS;
            hint.Text = cMACHINE_AND_GROUP.ErrowInfo;
            if (IFExecution_SUCCESS)
            {

                bind();
            }
        }
        #endregion
        #region save_t
        private void save_t()
        {
            foreach (DataRow dr in dt2.Rows)
            {

                if (dr["复选框"].ToString() == "True")
                {
                    cMACHINE_AND_GROUP.MAKERID = LOGIN.EMID;
                    cMACHINE_AND_GROUP.MAID = bc.getOnlyString(string.Format("SELECT MAID FROM MACHINE WHERE MACHINE_ID='{0}'", dr["机台代码"].ToString()));
                    cMACHINE_AND_GROUP.save_t();

                }
            }
            IFExecution_SUCCESS = cMACHINE_AND_GROUP.IFExecution_SUCCESS;
            hint.Text = cMACHINE_AND_GROUP.ErrowInfo;
            if (IFExecution_SUCCESS)
            {

                bind();
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (dt1.Rows.Count > 0)
                {
                    save();
                }
                else
                {

                    hint.Text = "无机台群组信息";
                }
            
            }
            else
            {
                hint.Text = "无可移动的机台信息";

            }
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (dt2.Rows.Count > 0)
            {

                save_t();
            }
            else
            {
                hint.Text = "无可移动的机台信息";

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hint.Text = "";
            string v1 = Convert.ToString(dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value).Trim();
            if (v1 != "")
            {
                MRID = bc.getOnlyString(string.Format("SELECT MRID FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='{0}'", v1));
                MACHINE_GROUP_ID = v1;
            }
            INDEX = dataGridView2.CurrentCell.RowIndex;
            dt2 = basec.getdts(string.Format(cMACHINE_AND_GROUP.sqlf + " WHERE A.MRID='{0}'", MRID));
            dataGridView3.DataSource = dt2;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

   
     
   
    }
}
