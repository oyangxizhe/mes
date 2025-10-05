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
    public partial class WORKORDERT : Form
    {
        DataTable dt = new DataTable();
        basec bc=new basec ();
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
        CWORKORDER cWORKORDER = new CWORKORDER();
       
        public WORKORDERT()
        {
            InitializeComponent();
        }
    
        private void WORKORDERT_Load(object sender, EventArgs e)
        {
            textBox1.Text = IDO;
       
            bind();
        }
        #region bind
        private void bind()
        {

            this.Icon = Resource1.xz_200X200;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy/MM/dd";
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "yyyy/MM/dd";
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.CustomFormat = "yyyy/MM/dd";
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            textBox2.Focus();
            hint.Location = new Point(400, 100);
            hint.ForeColor = Color.Red;
            comboBox1.BackColor  = Color.Yellow;
            textBox4.BackColor = Color.Yellow;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {

                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            dt = basec.getdts(cWORKORDER.getsql + "  ORDER BY  A.WOID ASC ");
            this.Text = "工单信息";
            dataGridView1.DataSource = dt;
            dgvStateControl();
            comboBox2.BackColor = Color.Yellow;
            textBox7.ReadOnly = true;
        }
        #endregion
        public void ClearText()
        {
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker3.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker4.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dateTimePicker5.Text = DateTime.Now.ToString("yyyy/MM/dd");
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
          
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
                if (IFExecution_SUCCESS == true )
                {
                    add();
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
        private void add()
        {
            ClearText();
            textBox1.Text = cWORKORDER.GETID();
         
            bind();
         
            ADD_OR_UPDATE = "ADD";
           

        }
        private void save()
        {
            btnSave.Focus();
            //dgvfoucs();
            cWORKORDER.WOID = textBox1.Text;
            cWORKORDER.WAREID = comboBox1.Text;
            cWORKORDER.WO_COUNT = textBox4.Text;
            cWORKORDER.FCID = comboBox2.Text;
            cWORKORDER.FLOW_CHART_EDITION = textBox7.Text;
            cWORKORDER.DELIVERY_DATE = dateTimePicker1.Text;
            cWORKORDER.GODE_NEED_DATE = dateTimePicker2.Text;
            cWORKORDER.LAST_PICKING_DATE = dateTimePicker3.Text;
            cWORKORDER.COMPLETE_DATE = dateTimePicker4.Text;
            cWORKORDER.ADVICE_DELIVER_DATE = dateTimePicker5.Text;
            cWORKORDER.MAKERID = LOGIN.EMID;
            cWORKORDER.STATUS = "OPEN";
            cWORKORDER.save();
            IFExecution_SUCCESS = cWORKORDER.IFExecution_SUCCESS;
            hint.Text = cWORKORDER.ErrowInfo;
            if (IFExecution_SUCCESS)
            {

                bind();
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
           if (comboBox1 .Text =="")
            {
                hint.Text = "ID不能为空！";
                b = true;
            }
           else if (!bc.exists(string.Format("SELECT * FROM WAREINFO WHERE WAREID='{0}'", comboBox1.Text)))
           {
               hint.Text = "ID不存于系统中！";
               b = true;
           }
           else if (textBox4.Text == "")
           {
               hint.Text = "数量不能为空！";
               b = true;
           }
           else if (bc.yesno (textBox4 .Text )==0)
           {
               hint.Text = "数量只能为数字！";
               b = true;
           }
           else if(!bc.exists("SELECT * FROM FLOW_CHART_MST WHERE WAREID='" + comboBox1.Text + "' AND ACTIVE='Y'"))
           {
               hint.Text = "此物料编号的途程不存在或未生效需先维护！";
               b = true;

           }
           else if (!bc.exists("SELECT * FROM FLOW_CHART_MST WHERE FCID='" + comboBox2.Text + "'"))
           {
               hint.Text = "此途程编号为空或不存在系统中！";
               b = true;

           }
           else if (!bc.exists("SELECT * FROM FLOW_CHART_MST WHERE FCID='" + comboBox2.Text + "' AND  WAREID='"+comboBox1 .Text  +"'"))
           {
               hint.Text =string.Format ( "此途程编号："+"{0}"+" 不是物料编码："+"{1}"+"的途程！",comboBox2.Text ,comboBox1 .Text );
               b = true;

           }
           else if (bc.exists("SELECT * FROM WORKORDER_MST WHERE WOID='" + textBox1.Text + "'") && bc.getOnlyString(@"
SELECT STATUS FROM WORKORDER_MST WHERE WOID='" + textBox1.Text + "'") != "OPEN")
           {
               hint.Text = string.Format("此工单号：" + "{0}" + " 状态不为开立不允许修改", textBox1.Text);
               b = true;
           }
          /* else if (juage3()==0)
           {
               hint.Text = "需点选一个默认联系人！";
               b = true;
           }
           else if (juage3()>1)
           {
               hint.Text = "默认联系人只能选择一个！";
               b = true;
           }*/
            return b;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该工单吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (bc.exists(string.Format ("SELECT * FROM BATCH_DET WHERE WOID='{0}'",dt.Rows [dataGridView1 .CurrentCell .RowIndex ]["工单号"].ToString ())))
                {
                    hint.Text = "该工单号已经产生批号不允许删除";
                }
                else
                {

                    basec.getcoms("DELETE WORKORDER_MST WHERE WOID='" + textBox1.Text + "'");
                    bind();
                    ClearText();
                    textBox1.Text = "";
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
     

            dataGridView1.Columns["工单号"].Width = 80;
            dataGridView1.Columns["制单人"].Width = 80;
            dataGridView1.Columns["制单日期"].Width = 120;
            dataGridView1.Columns["工单数量"].Width = 70;
            dataGridView1.Columns["物料编号"].Width = 70;

            dataGridView1.Columns["交货日期"].Width = 70;
            dataGridView1.Columns["需求日期"].Width = 70;
            dataGridView1.Columns["下料日期"].Width = 70;
            dataGridView1.Columns["齐套日期"].Width = 70;
            dataGridView1.Columns["建议交期"].Width = 70;
            dataGridView1.Columns["状态"].Width = 50;
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
       
        }

        private void 删除此项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string v1 = dt.Rows[dataGridView1.CurrentCell.RowIndex][0].ToString();
            string sql2 = "DELETE FROM CUSTOMERINFO_DET WHERE CUID='" + textBox1.Text + "' AND SN='" + v1 + "'";
            if (dt.Rows.Count > 0)
            {

                if (MessageBox.Show("确定要删除该条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!bc.exists("SELECT * FROM CUSTOMERINFO_DET WHERE CUID='" + textBox1.Text + "' AND SN='"+v1+"'"))
                    {
                        hint.Text = "此条记录还未写入数据库";
                    }
                    else  if (bc.juageOne("SELECT * FROM CUSTOMERINFO_DET WHERE CUID='" + textBox1.Text + "'"))
                    {

                        basec.getcoms(sql2);
                        string sql3 = "DELETE CUSTOMERINFO_MST WHERE CUID='" + textBox1.Text + "'";
                        basec.getcoms(sql3);
                        basec.getcoms("DELETE REMARK WHERE CUID='" + textBox1.Text + "'");
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            BASE_INFO.WAREINFO FRM = new CSPSS.BASE_INFO.WAREINFO();
            FRM.WORKORDER_USE();
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
            textBox4.Focus();
            DataTable dtx = bc.getdt("SELECT * FROM FLOW_CHART_MST WHERE WAREID='"+comboBox1.Text +"' AND ACTIVE='Y'");
            if (dtx.Rows.Count > 0)
            {
                hint.Text = "";
                comboBox2.Text = dtx.Rows[0]["FCID"].ToString();
                textBox5.Text = dtx.Rows[0]["FLOW_CHART_ID"].ToString();
                textBox6.Text = dtx.Rows[0]["FLOW_CHART"].ToString();
                textBox7.Text = dtx.Rows[0]["FLOW_CHART_EDITION"].ToString();

            }
            else
            {
                hint.Text = "此物料编号不存在途程或是没有生效需先维护";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hint.Text = "";
            int i=dataGridView1 .CurrentCell.RowIndex ;
            string v1 = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            if (v1 != "")
            {
                textBox1.Text = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                comboBox1.Text = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox2.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox3.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox4.Text = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                comboBox2.Text = Convert.ToString(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox5.Text = Convert.ToString(dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox6.Text = Convert.ToString(dataGridView1[7, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                textBox7.Text = Convert.ToString(dataGridView1[8, dataGridView1.CurrentCell.RowIndex].Value).Trim();
                dateTimePicker1.Text = dt.Rows[i]["交货日期"].ToString();
                dateTimePicker2.Text = dt.Rows[i]["需求日期"].ToString();
                dateTimePicker3.Text = dt.Rows[i]["下料日期"].ToString();
                dateTimePicker4.Text = dt.Rows[i]["齐套日期"].ToString();
                dateTimePicker5.Text = dt.Rows[i]["建议交期"].ToString();
            }
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {

            PRODUCTION_MANAGE.FLOW_CHART FRM = new CSPSS.PRODUCTION_MANAGE.FLOW_CHART();
            FRM.WORKORDER_USE();
            FRM.ShowDialog();
            this.comboBox2.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.comboBox2.DroppedDown = false;//使组合框不显示其下拉部分
            this.comboBox2.IntegralHeight = true;//恢复默认值
            if (IF_DOUBLE_CLICK)
            {
                comboBox2.Text = FCID;
                textBox5.Text = FLOW_CHART_ID;
                textBox6.Text = FCNAME;
                textBox7.Text = FLOW_CHART_EDITION;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Enabled == true)
            {
                int indexNumber = dataGridView1.CurrentCell.RowIndex;
                if (select == 1)
                {

                    BATCHT.WOID = dataGridView1.Rows[indexNumber].Cells[0].Value.ToString().Trim();
                    BATCHT.WAREID = dataGridView1.Rows[indexNumber].Cells[1].Value.ToString().Trim();
                    BATCHT.CO_WAREID = dataGridView1.Rows[indexNumber].Cells[2].Value.ToString().Trim();
                    BATCHT.WNAME = dataGridView1.Rows[indexNumber].Cells[3].Value.ToString().Trim();
                    BATCHT.WO_COUNT  = dataGridView1.Rows[indexNumber].Cells[4].Value.ToString().Trim();
                    BATCHT.IF_DOUBLE_CLICK = true;
                }

                if (select == 19)
                {

                }
                this.Close();
            }
        }

        public void BATCH_USE()
        {
            dataGridView1.ReadOnly = true;
            select = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bc.getOnlyString("SELECT STATUS FROM WORKORDER_MST WHERE WOID='" + textBox1.Text + "'") != "OPEN")
            {
                hint.Text = string.Format("此工单号：" + "{0}" + " 状态不为开立不允许作废", textBox1.Text);
            }
            else
            {
                basec.getcoms("UPDATE WORKORDER_MST SET STATUS='SCRAP' WHERE WOID='" + textBox1.Text + "'");
                hint.Text = "已经作废";
                bind();
            }
        }


  

     
   
    }
}
