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
    public partial class STEP : Form
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
        CSTEP cSTEP = new CSTEP();

        protected int M_int_judge, i;
        protected int select;
        public STEP()
        {
            InitializeComponent();
        }


        private void DEPAET_Load(object sender, EventArgs e)
        {
            bind();

        }

        private void bind()
        {
            dataGridView1.AllowUserToAddRows = false;
           
            checkBox1.Checked = true;
            dt = basec.getdts(cSTEP.sql);
            dataGridView1.DataSource = dt;
            textBox2.Focus();
            textBox2.BackColor = Color.Yellow;
            textBox3.BackColor = Color.Yellow;
            dgvStateControl();
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;

            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(cSTEP.IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(cSTEP.IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            label12.Text = "站别编号";
            label14.Text = "站别名称";
            groupBox1.Text = "站别信息";
       
            label2.Text = "站别代码";
            this.Text = "站别信息";
            label3.Text = "站别名称";
            label4.Text = "机台群组代码";
            label5.Text = "机台代码";
            comboBox1.Items.Clear();
            dt1 = bc.getdt("SELECT * FROM MACHINE_GROUP");
            AutoCompleteStringCollection inputInfoSource = new AutoCompleteStringCollection();
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {

                    string suggestWord = dr["MACHINE_GROUP_ID"].ToString() + "-" + dr["MACHINE_GROUP"].ToString();
                    comboBox1.Items.Add(dr["MACHINE_GROUP_ID"].ToString() + "-" + dr["MACHINE_GROUP"].ToString());
                    inputInfoSource.Add(suggestWord);
                }
            }
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox1.AutoCompleteCustomSource = inputInfoSource;
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
                dataGridView1.Columns["过账是否需要机台"].Width = 110;
                dataGridView1.Columns["站别名称"].Width = 120;
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
            cSTEP.EMID = LOGIN.EMID;
            cSTEP.STID = IDO;
            cSTEP.STEP_ID = textBox2.Text;
            cSTEP.STEP = textBox3.Text;
            if (checkBox1.Checked)
            {
                cSTEP.IF_NEED_MACHINE = "Y";
            }
            else
            {
                cSTEP.IF_NEED_MACHINE = "N";
            }
            cSTEP.MRID = bc.RETURN_MRID(comboBox1.Text);
            cSTEP.MAID = bc.RETURN_MAID(comboBox2.Text);
            cSTEP.save();
            IFExecution_SUCCESS = cSTEP.IFExecution_SUCCESS;
            hint.Text = cSTEP.ErrowInfo;
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
            if (IDO == "")
            {
                b = true;

                hint.Text = "编号不能为空！";

            }
            else if (textBox2.Text == "")
            {
                b = true;
                hint.Text = "站别代码不能为空！";
            }
            else if (textBox3.Text == "")
            {
                b = true;
                hint.Text = "站别名称不能为空！";
            }
            else if (checkBox1 .Checked && bc.JUDGE_MACHINE_GROUP (bc.REMOVE_NAME (comboBox1 .Text ,'-')))
            {
                b = true;
                hint.Text = "过账需要机台时！" + bc.ErrowInfo;
            }
            else if (checkBox1.Checked && bc.JUDGE_MACHINE(bc.REMOVE_NAME(comboBox2.Text, '-')))
            {
                b = true;
                hint.Text = "过账需要机台时！" + bc.ErrowInfo;
            }
            else if (checkBox1.Checked && bc.JUDGE_MACHINE_AND_GROUP(comboBox1.Text, comboBox2.Text))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
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

        private void add()
        {
            ClearText();
            IDO  = cSTEP.GETID();
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


                dt = bc.getdt(cSTEP.sql + " WHERE A.STID LIKE '%" + textBox4.Text + "%' AND A.STEP LIKE '%" + textBox5.Text + "%'");
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
            if (bc.exists(string.Format("SELECT * FROM FLOW_CHART_DET WHERE STID='{0}'", bc.RETURN_STID(id))))
            {
                hint.Text = string.Format("站别 {0} 已经在途程图中使用不允许删除", id);

            }
            else
            {
                IFExecution_SUCCESS = false;
                string strSql = "DELETE FROM STEP WHERE STEP_ID='" + id + "'";
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
            if (select != 0)
            {
                hint.Text = "";
                if (dataGridView1.Enabled == true)
                {
                    int indexNumber = dataGridView1.CurrentCell.RowIndex;
                    string v1 = dataGridView1.Rows[indexNumber].Cells[0].Value.ToString().Trim();
                    string v2 = dataGridView1.Rows[indexNumber].Cells[1].Value.ToString().Trim();
                    string v3 = dataGridView1.Rows[indexNumber].Cells[2].Value.ToString().Trim();

                    if (select == 2)
                    {
                        PRODUCTION_MANAGE.FLOW_CHARTT.STID = bc.RETURN_STID(v1);
                        PRODUCTION_MANAGE.FLOW_CHARTT.STEP_ID = v1;
                        PRODUCTION_MANAGE.FLOW_CHARTT.STEP = v2;
                        PRODUCTION_MANAGE.FLOW_CHARTT.IF_DOUBLE_CLICK = true;
                    }
                    else if (select == 1)
                    {
                        PRODUCTION_MANAGE.STEP_WAREIDT.STID = bc.RETURN_STID(v1);
                        PRODUCTION_MANAGE.STEP_WAREIDT.STEP_ID = v1;
                        PRODUCTION_MANAGE.STEP_WAREIDT.STEP = v2;
                        PRODUCTION_MANAGE.STEP_WAREIDT.IF_DOUBLE_CLICK = true;
                    }

                    this.Close();
                }
            }
            else
            {

                int i = dataGridView1.CurrentCell.RowIndex;
                string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                if (v1 != "")
                {
                    IDO = bc.getOnlyString(string.Format("SELECT STID FROM STEP WHERE STEP_ID='{0}'", v1));
                    textBox2.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    textBox3.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                    if (dt.Rows[i]["过账是否需要机台"].ToString() == "是")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;

                    }
                    if (dt.Rows[i]["机台群组代码"].ToString() != "")
                    {
                        comboBox1.Text = dt.Rows[i]["机台群组代码"].ToString() + "-" + dt.Rows[i]["机台群组名称"].ToString();
                        comboBox2.Text = dt.Rows[i]["机台代码"].ToString() + "-" + dt.Rows[i]["机台名称"].ToString();
                    }
                    else
                    {
                        comboBox1.Text = "";
                        comboBox2.Text = "";

                    }
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
  
        }
        public void FLOW_CHART_USE()
        {
            select = 2;
        }
        public void STEP_WAREID_USE()
        {
            select = 1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            dt1 = bc.getdt(string.Format(@"
SELECT 
B.MACHINE_ID,
B.MACHINE 
FROM MACHINE_AND_GROUP A 
LEFT JOIN MACHINE B ON A.MAID=B.MAID 
WHERE 
A.MRID =(SELECT MRID FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='{0}' ) 
ORDER BY MRID ASC", bc.REMOVE_NAME(comboBox1.Text, '-')));

            //dt1 = bc.getdt("SELECT * FROM MACHINE");
            AutoCompleteStringCollection inputInfoSource_T = new AutoCompleteStringCollection();
            if (dt1.Rows.Count > 0)
            {

                foreach (DataRow dr in dt1.Rows)
                {

                    string suggestWord = dr["MACHINE_ID"].ToString();
                    comboBox2.Items.Add(dr["MACHINE_ID"].ToString() + "-" + dr["MACHINE"].ToString());
                    inputInfoSource_T.Add(suggestWord);

                }
            }
        }
    }
}

