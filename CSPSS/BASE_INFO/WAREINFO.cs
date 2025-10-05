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
    public partial class WAREINFO : Form
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
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _CO_WAREID;
        public string CO_WAREID
        {
            set { _CO_WAREID = value; }
            get { return _CO_WAREID; }
        }
        private  string _MATERIEL_TYPE;//MATERIEL 物料 MATERIAL 材料 161015
        public   string MATERIEL_TYPE
        {
            set { _MATERIEL_TYPE = value; }
            get { return _MATERIEL_TYPE; }
        }
        private string _WNAME;
        public string WNAME
        {
            set { _WNAME = value; }
            get { return _WNAME; }

        }
        basec bc = new basec();
        CWARE_INFO cware_info = new CWARE_INFO();

        protected int M_int_judge, i;
        protected int select;
        public WAREINFO()
        {
            InitializeComponent();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
       
        }
        #region only read
        public void WORKORDER_USE()
        {
            dataGridView1.Enabled = true;
            select = 4;

        }
        public void FLOW_CHART_USE()
        {
            dataGridView1.Enabled = true;
            select = 1;
        }
        public void UNIT_LOT_USE()
        {
            dataGridView1.Enabled = true;
            select = 2;
        }
        public void STEP_WAREID_USE()
        {
            dataGridView1.Enabled = true;
            select = 3;
        }
        #endregion
        private void WAREINFO_Load(object sender, EventArgs e)
        {

            Bind();

        }
        private void Bind()
        {
            textBox1.Text = IDO;
            StringBuilder sqb = new StringBuilder();
            sqb.Append(cware_info.sql);
            sqb.Append(" WHERE DateDiff(day,A.DATE,getdate()) >-1 and DateDiff(day,A.DATE,getdate()) <+7");
            if (MATERIEL_TYPE == "P")
            {
                sqb.Append(" AND SUBSTRING(A.WAREID,1,1)=9");
            }
            else if (MATERIEL_TYPE == "SEM")
            {
                sqb.Append(" AND SUBSTRING(A.WAREID,1,1)!=9");
            }
            dt = basec.getdts(sqb.ToString ());
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            textBox3.Focus();
            textBox3.BackColor = Color.Yellow;
            dgvStateControl();
            hint.Location = new Point(400,100);
            hint.ForeColor = Color.Red;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(cware_info.IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(cware_info.IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DataSource = bc.RETURN_ADD_EMPTY_COLUMN("SPEC", "SPEC");
            comboBox1.DisplayMember = "SPEC";

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DataSource = bc.RETURN_ADD_EMPTY_COLUMN("UNIT", "UNIT");
            comboBox2.DisplayMember = "UNIT";
            comboBox3.Text = "正常";
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            
            groupBox1.Text = "物料信息";
            label1.Text = "物料编号";
            label2.Text = "料号";
            this.Text = "物料信息";
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
            dataGridView1.Columns["单位"].Width = 40;
            dataGridView1.Columns["品名"].Width = 200;
            dataGridView1.Columns["制单日期"].Width = 120;
            dataGridView1.Columns["规格"].Width = 80;
            dataGridView1.Columns["料号"].Width = 80;
            dataGridView1.Columns["物料编号"].Width = 70;
        }
        #endregion
    
       
        #region juage()
        private bool juage()
        {


            bool b = false;
            if (textBox1.Text == "")
            {
                b = true;

                hint.Text = "ID不能为空！";
             
            }
            else if (textBox3.Text == "")
            {
                b = true;

                hint.Text = "品名不能为空！";

            }
       
            return b;

        }
        #endregion
        public void ClearText()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox1.Text = "";
            hint.Text = "";
        
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            add();
        }
        private void add()
        {

            IDO  = cware_info.GETID("9");
            ClearText();
            textBox3.Focus();

        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (juage())
            {

            }
            else
            {
                save();
              
                
            }
        }
        #region save
        private void save()
        {

            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss");

            cware_info.WAREID = textBox1.Text;
            cware_info.CO_WAREID = textBox2.Text;
            cware_info.WNAME = textBox3.Text;
            cware_info.SPEC = comboBox1.Text;
            cware_info.UNIT = comboBox2.Text;
            cware_info.MAKERID = LOGIN.EMID;
            if (comboBox3.Text == "正常")
            {
                cware_info.ACTIVE = "Y";
            }
            else if (comboBox3.Text == "暂停")
            {
                cware_info.ACTIVE = "HOLD";
            }
            else
            {
                cware_info.ACTIVE = "N";
            }

            cware_info.save();
            if (cware_info.IFExecution_SUCCESS)
            {
                add();
                Bind();
            }
            else
            {
                hint.Text = cware_info.ErrowInfo;
            }
           
        }
        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {

            StringBuilder sqb = new StringBuilder();
            sqb.Append(cware_info.sql);
            sqb.Append(" WHERE A.WAREID LIKE '%" + textBox1.Text +"%'");
            sqb.Append(" AND A.CO_WAREID LIKE '%" + textBox2.Text + "%'");
            sqb.Append(" AND A.WNAME LIKE '%" + textBox3.Text + "%'");
            sqb.Append(" AND A.SPEC LIKE '%" + comboBox1 .Text  + "%'");
            sqb.Append(" AND A.UNIT LIKE '%" + comboBox2.Text + "%'");
            if (MATERIEL_TYPE == "P")
            {
                sqb.Append(" AND SUBSTRING(A.WAREID,1,1)=9 ");
            }
            else if (MATERIEL_TYPE == "SEM")
            {
                sqb.Append(" AND SUBSTRING(A.WAREID,1,1)!=9 ");
            }
            if (comboBox3.Text == "正常")
            {
                sqb.Append(" AND A.ACTIVE LIKE '%Y%'");
            }
            else if(comboBox3 .Text =="暂停")
            {
                sqb.Append(" AND A.ACTIVE LIKE '%HOLD%'");
            }
            else 
            {
                sqb.Append(" AND A.ACTIVE LIKE '%N%'");
            }
         
            dt = basec.getdts(sqb.ToString());
          
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
            try
            {


              
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (bc.JuageIfAllowDeleteWareID(id))
            {
                hint.Text = bc.ErrowInfo;
            }
            else
            {
                IFExecution_SUCCESS = false;
                string strSql = "DELETE FROM WAREINFO WHERE WAREID='" + id + "'";
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
      
            if (select != 0)
            {
                if (dataGridView1.Enabled == true)
                {
                    int indexNumber = dataGridView1.CurrentCell.RowIndex;
                    WAREID = dataGridView1.Rows[indexNumber].Cells[0].Value.ToString().Trim();
                    CO_WAREID = dataGridView1.Rows[indexNumber].Cells[1].Value.ToString().Trim();
                    WNAME = dataGridView1.Rows[indexNumber].Cells[2].Value.ToString().Trim();

                    if (select == 4)
                    {

                        CSPSS.WORKORDER_MANAGE.WORKORDERT.WAREID = WAREID;
                        CSPSS.WORKORDER_MANAGE.WORKORDERT.CO_WAREID = CO_WAREID;
                        CSPSS.WORKORDER_MANAGE.WORKORDERT.WNAME = WNAME;
                        CSPSS.WORKORDER_MANAGE.WORKORDERT.IF_DOUBLE_CLICK = true;
                    }
                    if (select == 1)
                    {
                        CSPSS.PRODUCTION_MANAGE.FLOW_CHARTT.WAREID = WAREID;
                        CSPSS.PRODUCTION_MANAGE.FLOW_CHARTT.CO_WAREID = CO_WAREID;
                        CSPSS.PRODUCTION_MANAGE.FLOW_CHARTT.WNAME = WNAME;
                        CSPSS.PRODUCTION_MANAGE.FLOW_CHARTT.IF_DOUBLE_CLICK = true;
                    }
                    if (select == 2)
                    {
                        CSPSS.WORKORDER_MANAGE.UNIT_LOT.WAREID = WAREID;
                        CSPSS.WORKORDER_MANAGE.UNIT_LOT.CO_WAREID = CO_WAREID;
                        CSPSS.WORKORDER_MANAGE.UNIT_LOT.WNAME = WNAME;
                        CSPSS.WORKORDER_MANAGE.UNIT_LOT.IF_DOUBLE_CLICK = true;
                    }
                    if (select == 3)
                    {
                        CSPSS.PRODUCTION_MANAGE.STEP_WAREIDT.WAREID = WAREID;
                        CSPSS.PRODUCTION_MANAGE.STEP_WAREIDT.CO_WAREID = CO_WAREID;
                        CSPSS.PRODUCTION_MANAGE.STEP_WAREIDT.WNAME = WNAME;
                        CSPSS.PRODUCTION_MANAGE.STEP_WAREIDT.IF_DOUBLE_CLICK = true;
                    }
                    this.Close();
                }
            }
            else
            {
                string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                if (v1 != "")
                {
                    textBox1.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    textBox2.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    textBox3.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    comboBox1.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    comboBox2.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    comboBox3.Text = Convert.ToString(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                }
            }
        }

   

    }
}
