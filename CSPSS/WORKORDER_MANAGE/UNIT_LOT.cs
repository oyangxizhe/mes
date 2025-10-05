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

namespace CSPSS.WORKORDER_MANAGE
{
    public partial class UNIT_LOT : Form
    {
        DataTable dt = new DataTable();
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
        basec bc = new basec();
        CUNIT_LOT cUNIT_LOT = new CUNIT_LOT();

   
        protected int M_int_judge, i;
        protected int select;
        public UNIT_LOT()
        {
            InitializeComponent();
        }
     

        private void DEPAET_Load(object sender, EventArgs e)
        {
            bind();
        }

        private void bind()
        {
            textBox1.Text = IDO;
            dt = basec.getdts(cUNIT_LOT .sql);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            textBox2.Focus();
            textBox4.BackColor = Color.Yellow;
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
            label12.Text = "编号";
            label14.Text = "批号量";
            groupBox1.Text = "批号量信息";
            label1.Text = "编号";
            label2.Text = "批号量";
            this.Text = "批号量信息";
            comboBox1.BackColor = Color.Yellow;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Text = "N";
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
                dataGridView1.Columns["编号"].Width = 70;
                dataGridView1.Columns["批号量"].Width = 120;
                dataGridView1.Columns["制单人"].Width = 80;
                dataGridView1.Columns["制单日期"].Width = 120;
                dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
        
                dataGridView1.Columns["批号量"].Width = 70;
                dataGridView1.Columns["物料编号"].Width = 70;

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
            cUNIT_LOT.MAKERID = "WS";
            cUNIT_LOT.ULID = textBox1.Text;
            cUNIT_LOT.WAREID = comboBox1.Text;
            cUNIT_LOT.UNIT_LOT = textBox4.Text;
            cUNIT_LOT.ACTIVE = comboBox2.Text;
            cUNIT_LOT.save();
            IFExecution_SUCCESS = cUNIT_LOT.IFExecution_SUCCESS;
            hint.Text = cUNIT_LOT.ErrowInfo;
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
            if (bc.DELEGATE_JUAGE_T(comboBox1 .Text ,bc.JUAGE_WAREID))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (textBox4.Text == "")
            {
                b = true;

                hint.Text = "批号量不能为空！";
             
            }
            else if (bc.yesno (textBox4 .Text )==0)
            {
                b = true;

                hint.Text = "批号量只能输入数字！";

            }
       
            return b;

        }
        #endregion
        public void ClearText()
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "N";
        }
     
        private void add()
        {
            ClearText();
            textBox1.Text = cUNIT_LOT.GETID();
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


                dt = bc.getdt(cUNIT_LOT .sql+" WHERE A.ULID LIKE '%"+textBox5.Text +"%' AND A.UNIT_LOT LIKE '%"+textBox6 .Text +"%'");
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
                string strSql = "DELETE FROM UNIT_LOT WHERE ULID='" + id + "'";
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

                //double_info();

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
                comboBox1.Text  = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox2.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox3.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox4.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                comboBox2.Text = Convert.ToString(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                string v2 = Convert.ToString(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                if (v2 == "已生效")
                {
                    comboBox2.Text = "Y";
                }
                else
                {
                    comboBox2.Text = "N";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            BASE_INFO.WAREINFO FRM = new CSPSS.BASE_INFO.WAREINFO();
            FRM.UNIT_LOT_USE();
            FRM.ShowDialog();
            this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox1.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox1.Text = WAREID;
                textBox2.Text = CO_WAREID;
                textBox3.Text = WNAME;
            }
            textBox3.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }
    }
}
