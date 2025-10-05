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
    public partial class STEP_WAREIDT : Form
    {
        DataTable dt = new DataTable();
        basec bc=new basec ();
        #region nature
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
        private static bool _IF_DOUBLE_CLICK;
        public static bool IF_DOUBLE_CLICK
        {
            set { _IF_DOUBLE_CLICK = value; }
            get { return _IF_DOUBLE_CLICK; }
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
        private static string _STID;
        public static string STID
        {
            set { _STID = value; }
            get { return _STID; }
        }
        private static string _STEP_ID;
        public static string STEP_ID
        {
            set { _STEP_ID = value; }
            get { return _STEP_ID; }
        }
        private static string _STEP;
        public static string STEP
        {
            set { _STEP = value; }
            get { return _STEP; }
        }
        #endregion
        private  delegate bool dele(string a1,string a2);
        private delegate void delex();
        STEP_WAREID F1 = new STEP_WAREID();
        protected int M_int_judge, i;
        protected int select;
        CSTEP_WAREID cSTEP_WAREID = new CSTEP_WAREID();
       
        public STEP_WAREIDT()
        {
            InitializeComponent();
        }
        public STEP_WAREIDT(STEP_WAREID FRM)
        {
            InitializeComponent();
            F1 = FRM;

        }
        private void STEP_WAREIDT_Load(object sender, EventArgs e)
        {
            //IDO = "SW16100001";
            this.Icon = Resource1.xz_200X200;
            try
            {
                bind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #region total1
        private DataTable total1()
        {
            DataTable dtt2 = cSTEP_WAREID.GetTableInfo();
            for (i = 1; i <= 6; i++)
            {
                DataRow dr = dtt2.NewRow();
                dr["项次"] = i;
                dtt2.Rows.Add(dr);
            }
            return dtt2;
        }
        #endregion
        public void a1()
        {
            dataGridView1.ReadOnly = true;
            select = 0;
        }
        public void a2()
        {
            dataGridView1.ReadOnly = true;
            select = 1;
        }

        public void ClearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
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
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;
            comboBox1.BackColor = CCOLOR.CUSTOMER_YELLOW;
            comboBox2.BackColor = CCOLOR.CUSTOMER_YELLOW;
            comboBox1.Focus();
            checkBox1.Checked = true;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            DataTable dtx = basec.getdts(cSTEP_WAREID.sql + " where A.SWID='" +IDO + "' ORDER BY  B.SWID ASC ");
            if (dtx.Rows.Count > 0)
            {
                dt = cSTEP_WAREID.GetTableInfo();
                comboBox1.Text = dtx.Rows[0]["站别代码"].ToString();
                textBox1.Text= dtx.Rows[0]["站别名称"].ToString();
                comboBox2.Text = dtx.Rows[0]["料号"].ToString();
                textBox2.Text = dtx.Rows[0]["品名"].ToString();
                if (dtx.Rows[0]["过帐是否检查物料"].ToString() == "是")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                foreach (DataRow dr1 in dtx.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["项次"] = dr1["项次"].ToString();
                    dr["料号"] = dr1["BOM料号"].ToString();
                    dr["品名"] = dr1["BOM品名"].ToString();
                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0 && dt.Rows.Count < 6)
                {
                    int n = 6 - dt.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {
                        DataRow dr = dt.NewRow();
                        int b1 = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["项次"].ToString());
                        dr["项次"] = Convert.ToString(b1 + 1);
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
             
                dt=total1();
              
            }
            dataGridView1.DataSource = dt;
            dgvStateControl();
        }
        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Focus();
            if (juage())
            {
                IFExecution_SUCCESS = false;
            }
            else
            {
                save();
                if (IFExecution_SUCCESS == true && ADD_OR_UPDATE == "ADD")
                {
                    add();
                }
             
                F1.load();
            }
            try
            {
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        private void add()
        {
            ClearText();
            IDO = cSTEP_WAREID.GETID();
            bind();
            ADD_OR_UPDATE = "ADD";
        }
        private void save()
        {
            btnSave.Focus();
            //dgvfoucs();
            if (dt.Rows.Count > 0)
            {
                DataTable dtx = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "料号 IS NOT NULL");
                cSTEP_WAREID.EMID = LOGIN.EMID;
                cSTEP_WAREID.SWID = IDO;
                cSTEP_WAREID.STID = bc.RETURN_STID(comboBox1.Text);
                cSTEP_WAREID.STEP_ID = comboBox1.Text;
                cSTEP_WAREID.WAREID = bc.RETURN_WAREID(comboBox2.Text);
                cSTEP_WAREID.DET_WAREID = comboBox2.Text;
                if (checkBox1.Checked)
                {
                    cSTEP_WAREID.IF_CHECK_WAREID = "Y";
                }
                else
                {
                    cSTEP_WAREID.IF_CHECK_WAREID = "N";
                }
                cSTEP_WAREID.save(dtx);
                IFExecution_SUCCESS = cSTEP_WAREID.IFExecution_SUCCESS;
                hint.Text = cSTEP_WAREID.ErrowInfo;
                if (IFExecution_SUCCESS)
                {
                    bind();
                }
            
            }
            try
            {
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        private bool juage()
        {
            bool b = false;
            if (string.IsNullOrEmpty(IDO))
            {
                hint.Text = "编号不能为空！";
                b = true;
            }
            else if (bc.JUDGE_STEP_ID(comboBox1 .Text ))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (bc.DELEGATE_JUAGE_T(comboBox2 .Text ,bc.JUAGE_CO_WAREID))
            {
                hint.Text = string.Format("单头料号 {0} 为空或不存在系统中", comboBox2.Text);
                b = true;
            }
           else if(juage2())
           {
               b = true;
            }
            return b;
        }
        #region juage2()
  
        private bool juage2()
        {
            bool b = false;
            DataTable dtx = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "料号 IS NOT NULL");
            if (dtx.Rows.Count > 0)
            {
                foreach (DataRow dr in dtx.Rows)
                {
                    string v1 = dr["料号"].ToString();
                    if (bc.DELEGATE_JUAGE(v1, dr["项次"].ToString(), bc.JUAGE_CO_WAREID))
                    {
                        hint.Text = bc.ErrowInfo;
                        b = true;
                        break;
                    }
                }
            }
            else
            {
                hint.Text = "单身至少有一项料号才能保存";
                b = true;
            }
            return b;
        }
        #endregion
     
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该笔单据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string id = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
          
                basec.getcoms(string.Format(@"DELETE STEP_WAREID_DET WHERE SWID IN (SELECT SWID FROM STEP_WAREID_MST WHERE STID='{0}' AND WAREID='{1}')",
                    bc.RETURN_STID(comboBox1.Text), bc.RETURN_WAREID(comboBox2.Text)));
                basec.getcoms(string.Format("DELETE STEP_WAREID_MST WHERE STID='{0}' AND WAREID='{1}'", bc.RETURN_STID(comboBox1.Text), bc.RETURN_WAREID(comboBox2.Text)));
                bind();
                ClearText();
                F1.load();
            }
            try
            {
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

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
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
            int numCols1 = dataGridView1.Columns.Count;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            dataGridView1.Columns["项次"].Width = 40;
            for (i = 0; i < numCols1; i++)
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            dataGridView1.Columns["料号"].DefaultCellStyle.BackColor = CCOLOR.CUSTOMER_YELLOW;
            dataGridView1.Columns["项次"].ReadOnly = true;
            dataGridView1.Columns["项次"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
       
        }

        private void 删除此项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string v1 = dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString();
            string sql2 = "DELETE FROM STEP_WAREID_DET WHERE SWID='" + textBox1.Text + "' AND SN='" + v1 + "'";
            if (dt.Rows.Count > 0)
            {

                if (MessageBox.Show("确定要删除该条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!bc.exists("SELECT * FROM STEP_WAREID_DET WHERE SWID='" + textBox1.Text + "' AND SN='"+v1+"'"))
                    {
                        hint.Text = "此条记录还未写入数据库";
                    }
                    else  if (bc.juageOne("SELECT * FROM STEP_WAREID_DET WHERE SWID='" + textBox1.Text + "'"))
                    {

                        basec.getcoms(sql2);
                        string sql3 = "DELETE STEP_WAREID_MST WHERE SWID='" + textBox1.Text + "'";
                        basec.getcoms(sql3);
                        basec.getcoms("DELETE REMARK WHERE SWID='" + textBox1.Text + "'");
                        IFExecution_SUCCESS = false;
                        bind();
                    }
                    else
                    {

                        basec.getcoms(sql2);
                      
                        IFExecution_SUCCESS = false;
                        bind();
                    }
                }
             
             
            }
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            PRODUCTION_MANAGE.STEP FRM = new PRODUCTION_MANAGE.STEP();
            FRM.STEP_WAREID_USE();
            FRM.ShowDialog();
            this.comboBox1.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox1.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox1.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox1.Text =STEP_ID;
                textBox1.Text = STEP;
                comboBox2.Focus();
            }
        }
        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            BASE_INFO.WAREINFO FRM = new CSPSS.BASE_INFO.WAREINFO();
            FRM.STEP_WAREID_USE();
            FRM.MATERIEL_TYPE = "P";
            FRM.ShowDialog();
            this.comboBox2.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox2.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox2.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox2.Text = CO_WAREID;
                textBox2.Text = WNAME;
            }
            //this.ActiveControl = this.dataGridView1;
            dataGridView1.Focus();
            dataGridView1.CurrentCell = dataGridView1[1, 0];
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            /*IF_DOUBLE_CLICK = false;
            int intC = this.dataGridView1.CurrentCell.RowIndex;
            if (select == 0)
            {
                BASE_INFO.WAREINFO FRM = new CSPSS.BASE_INFO.WAREINFO();
                FRM.STEP_WAREID_USE();
                FRM.MATERIEL_TYPE = "SEM";
                FRM.ShowDialog();
                if (IF_DOUBLE_CLICK)
                {
                    dt.Rows[intC]["料号"] = CO_WAREID;
                    dt.Rows[intC]["品名"] = WNAME;
                    dataGridView1.CurrentCell = dataGridView1[2, intC];
                }
            }*/
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0) //这里需要你具体的列索引 
            {
                DataGridViewComboBoxEditingControl editCtrl = e.Control as DataGridViewComboBoxEditingControl;
                editCtrl.DropDownStyle = ComboBoxStyle.DropDown; //变为这样的下拉风格 
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
