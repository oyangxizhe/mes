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
    public partial class POSTINGT : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        CFLOW_CHART cflow_chart = new CFLOW_CHART();
        basec bc=new basec ();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private static string _MRID;
        public static string MRID
        {
            set { _MRID = value; }
            get { return _MRID; }

        }
        private static string _MACHINE_GROUP_ID;
        public static string MACHINE_GROUP_ID
        {
            set { _MACHINE_GROUP_ID = value; }
            get { return _MACHINE_GROUP_ID; }

        }
        private static string _MACHINE_GROUP;
        public static string MACHINE_GROUP
        {
            set { _MACHINE_GROUP = value; }
            get { return _MACHINE_GROUP; }

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
        private static string _MAID;
        public static string MAID
        {
            set { _MAID = value; }
            get { return _MAID; }

        }
        private static string _MACHINE_ID;
        public static string MACHINE_ID
        {
            set { _MACHINE_ID = value; }
            get { return _MACHINE_ID; }

        }
        private static string _MACHINE;
        public static string MACHINE
        {
            set { _MACHINE = value; }
            get { return _MACHINE; }

        }
        private static string _BGID;
        public static string BGID
        {
            set { _BGID = value; }
            get { return _BGID; }

        }
        private bool _IF_DEFECT_OR_BOX;
        public bool IF_DEFECT_OR_BOX
        {
            set { _IF_DEFECT_OR_BOX = value; }
            get { return _IF_DEFECT_OR_BOX; }

        }
        private static string _BAD_PHENOMENON_GROUP_ID;
        public static string BAD_PHENOMENON_GROUP_ID
        {
            set { _BAD_PHENOMENON_GROUP_ID = value; }
            get { return _BAD_PHENOMENON_GROUP_ID; }

        }
        private static string _BAD_PHENOMENON_GROUP;
        public static string BAD_PHENOMENON_GROUP
        {
            set { _BAD_PHENOMENON_GROUP = value; }
            get { return _BAD_PHENOMENON_GROUP; }

        }
        private static string _BPID;
        public static string BPID
        {
            set { _BPID = value; }
            get { return _BPID; }

        }
        private static string _BBID;
        public static string BBID
        {
            set { _BBID = value; }
            get { return _BBID; }

        }
        private static string _BAD_PHENOMENON_ID;
        public static string BAD_PHENOMENON_ID
        {
            set { _BAD_PHENOMENON_ID = value; }
            get { return _BAD_PHENOMENON_ID; }

        }
        private static string _BAD_PHENOMENON;
        public static string BAD_PHENOMENON
        {
            set { _BAD_PHENOMENON = value; }
            get { return _BAD_PHENOMENON; }
        }
        private static string _BAD_PHENOMENON_BECAUSE_ID;
        public static string BAD_PHENOMENON_BECAUSE_ID
        {
            set { _BAD_PHENOMENON_BECAUSE_ID = value; }
            get { return _BAD_PHENOMENON_BECAUSE_ID; }

        }

        private static string _BAD_PHENOMENON_BECAUSE;
        public static string BAD_PHENOMENON_BECAUSE
        {
            set { _BAD_PHENOMENON_BECAUSE = value; }
            get { return _BAD_PHENOMENON_BECAUSE; }
        }
        private decimal _OKCOUNT;
        public decimal OKCOUNT
        {

            set { _OKCOUNT = value; }
            get { return _OKCOUNT; }

        }
        private decimal _TOTAL_DEFECT_COUNT;
        public decimal TOTAL_DEFECT_COUNT
        {

            set { _TOTAL_DEFECT_COUNT = value; }
            get { return _TOTAL_DEFECT_COUNT; }

        }
        private decimal _REJUDGE_COUNT;
        public decimal REJUDGE_COUNT
        {

            set { _REJUDGE_COUNT = value; }
            get { return _REJUDGE_COUNT; }

        }
        private decimal _RE_PROCESSING_COUNT;
        public decimal RE_PROCESSING_COUNT
        {

            set { _RE_PROCESSING_COUNT = value; }
            get { return _RE_PROCESSING_COUNT; }

        }
        private  delegate bool dele(string a1,string a2);
        private delegate void delex();
       
        protected int M_int_judge, i;
        protected int select;
        CPOSTING cPOSTING = new CPOSTING();
        CBATCH cbatch = new CBATCH();
        CCOLOR ccolor = new CCOLOR();
        CBOX cbox = new CBOX();
        public POSTINGT()
        {
            InitializeComponent();
        }
 
        private void POSTINGT_Load(object sender, EventArgs e)
        {
            bind();
        }
        #region total1
        private DataTable total1()
        {
            DataTable dtt2 = cPOSTING.GetTableInfo();
            for (i = 1; i <= 6; i++)
            {
                DataRow dr = dtt2.NewRow();
                dr["项次"] = i;
                dtt2.Rows.Add(dr);
            }
            return dtt2;
        }
        #endregion
        #region override enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ((!(ActiveControl is System.Windows.Forms.TextBox) ||
                !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn)))
            {
                if (this.ActiveControl == textBox1 && keyData ==Keys.Enter )
                {
                    bool b=current_active_control();
                }
                else
                {
                  
                    SendKeys.SendWait("{Tab}");
                }
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
            textBox7.Text = "";
    
            textBox11.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "N";
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
            textBox1.BackColor = Color.Yellow;
            textBox16.BackColor = Color.Yellow;
            textBox2.BackColor =CCOLOR.qmhs;
            textBox13.BackColor =CCOLOR.qmhs;
            textBox15.BackColor =CCOLOR.qmhs;
            //comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
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
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            textBox1.Focus();
            hint.Location = new Point(258, 114);
            hint.ForeColor = Color.Red;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {

                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
       
            dt3= cbox.RETURN_NO_PACKING_DT(textBox1 .Text );
            DataTable  dtx = bc.GET_DT_TO_DV_TO_DT(dt3, "", "批号='"+textBox1.Text +"'");
            if (dtx.Rows.Count > 0 )
            {

                dt = dt3;
                groupBox4.Text = "批号装入内箱";
                dataGridView1.DataSource = dt;
                dgvStateControl_th();
                IF_DEFECT_OR_BOX = true;
            
            }
            else
            {
                IF_DEFECT_OR_BOX = false;
                dt = total1();
                dataGridView1.DataSource = dt;
                dgvStateControl();
            }
        
            this.Text = "过账信息";
          
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
            hint.Text = "";
            TOTAL_DEFECT_COUNT = 0;
            btnSave.Focus();
            if (juage())
            {
                IFExecution_SUCCESS = false;
            }
            else
            {
                save();
                textBox17.Text = "";
                textBox18.Text = "";
                current_active_control();
                if (IFExecution_SUCCESS)
                {
                    bind();
                }
             
                //F1.load();
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
            textBox2.Text = cPOSTING.GETID();
            bind();
            ADD_OR_UPDATE = "ADD";
        }
        private void save()
        {
            btnSave.Focus();
            DataTable dtx = bc.getdt(string.Format(cPOSTING .sqlf + " WHERE F.BATCHID='{0}'", textBox1.Text));
            if (dtx.Rows.Count > 0)
            {
              
                    textBox2.Text = dtx.Rows[0]["当前执行规则"].ToString();
                    if (dtx.Rows[0]["当前执行规则"].ToString() == "入账")
                    {
                        dataGridView1.Visible = false;
                        textBox17.Visible = false;
                        textBox18.Visible = false;
                        label18.Visible = false;
                        label21.Visible = false;
                        textBox16.ReadOnly = true;
                    }
                    textBox16.ReadOnly = false;
                    cPOSTING.PSID = cPOSTING.GETID();
                    cPOSTING.WOID = dtx.Rows[0]["工单号"].ToString();
                    cPOSTING.BATCHID = textBox1.Text;
                    cPOSTING.UNIT_LOT = dtx.Rows[0]["单位批号量"].ToString();
                    if (comboBox1.Text != "")
                    {
                        cPOSTING.MRID = bc.getOnlyString(string.Format("SELECT MRID FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='{0}'", bc.REMOVE_NAME(comboBox1.Text, '-')));
                    }
                    else
                    {
                        cPOSTING.MRID = "";

                    }
                    if (comboBox2.Text != "")
                    {
                        cPOSTING.MAID = bc.getOnlyString(string.Format("SELECT MAID FROM MACHINE WHERE MACHINE_ID='{0}'", bc.REMOVE_NAME(comboBox2.Text, '-'))); 
                    }
                    else
                    {

                        cPOSTING.MAID = "";
                    }
      
                    cPOSTING.TOTAL_DEFECT_COUNT = TOTAL_DEFECT_COUNT;
                    cPOSTING.ACTION_RULE = cPOSTING.RETURN_DB_ACTION_RULE(dtx.Rows[0]["当前执行规则"].ToString());
                    cPOSTING.STATUS = cPOSTING.RETURN_DB_STATUS(dtx.Rows[0]["状态"].ToString());
                    cPOSTING.FCID = bc.RETURN_FCID(dtx.Rows[0]["途程代码"].ToString());
                    cPOSTING.SN = dtx.Rows[0]["途程项次"].ToString();
                    cPOSTING.FLOW_CHART_EDITION = dtx.Rows[0]["途程版本"].ToString();
                    cPOSTING.STID = bc.RETURN_STID(dtx.Rows[0]["当前站别代码"].ToString());
                    cPOSTING.OK_COUNT = textBox16.Text;
                   
                    if (textBox17.Text == "")
                    {
                        cPOSTING.REJUDGE_COUNT = "0";

                    }
                    else
                    {
                        cPOSTING.REJUDGE_COUNT = textBox17.Text;

                    }
                    if (textBox18.Text == "")
                    {
                        cPOSTING.RE_PROCESSING_COUNT = "0";
                    }
                    else
                    {
                        cPOSTING.RE_PROCESSING_COUNT = textBox18.Text;
                    }
                    cPOSTING.MAKERID = LOGIN.EMID;
                    btnSave.Focus();
                    cPOSTING.save(dt2);
                    if (dt3.Rows.Count > 0)
                    {
                        cbox.MAKERID = LOGIN.EMID;
                        cbox.save(dt3);
                  
                    }
                    IFExecution_SUCCESS = cPOSTING.IFExecution_SUCCESS;
                    hint.Text = cPOSTING.ErrowInfo;
                

            }
           /* if (dt.Rows.Count > 0)
            {
                DataTable dtx = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "站别编号 IS NOT NULL");
                if (dtx.Rows.Count > 0)
                {

                  
                    F1.Bind();
                    F1.search();

                }
                else
                {
                
                    hint.Text = "至少有一项站别编号才能保存！";

                }
            }*/
           
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
            DataTable dtx = bc.getdt(string.Format(cPOSTING.sqlf + " WHERE F.BATCHID='{0}'", textBox1.Text));
            if(bc.JUAGE_BATCHID(textBox1 .Text ))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (bc.JUDGE_STEP_IF_NEED_MACHINE(dtx.Rows[0]["当前站别代码"].ToString())==false )
            {
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            else  if (bc.DELEGATE_JUAGE_T (textBox1 .Text ,bc.JUAGE_BATCHID ))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (comboBox1.Text == "" && bc.JUDGE_STEP_IF_NEED_MACHINE (dtx.Rows [0]["当前站别代码"].ToString ()))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (comboBox1 .Text !="" && bc.JUDGE_MACHINE_GROUP (comboBox1 .Text ))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (comboBox1.Text != "" && bc.JUDGE_MACHINE(comboBox2.Text))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (comboBox1.Text != "" && bc.JUDGE_MACHINE_AND_GROUP (comboBox1 .Text ,comboBox2.Text ))
            {
                hint.Text = bc.ErrowInfo;
                b = true;
            }
            else if (dtx.Rows[0]["状态"].ToString() == "报废")
            {
                hint.Text = "报废的批号不允许过账";
                b = true;
            }
            else if (dtx.Rows[0]["状态"].ToString() == "完工")
            {
                hint.Text = "该批号已经完工";
                b = true;
            }
            else if (dtx.Rows[0]["状态"].ToString() == "中断")
            {
                hint.Text = "该批号状态中断不能过账";
                b = true;
            }
            else if (textBox16.Text == "")
            {
                hint.Text = "OK数量不能为空！";
                textBox16.Focus();
                b = true;

            }
            else if (bc.yesno (textBox16.Text)==0)
            {
                hint.Text = "OK数量只能输入数字！";
                textBox16.Focus();
                b = true;

            }
          else if(IF_DEFECT_OR_BOX ==false )
            {
               
           if(juage2())
           {
            
               b = true;
            }
         }
      
            return b;
        }
        #region juage2()
  
        private bool juage2()
        {
            bool b = false;
            decimal d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0;
            TOTAL_DEFECT_COUNT = 0;
            d1 = decimal.Parse(textBox16.Text);
            if (!string.IsNullOrEmpty(textBox17.Text))
            {
                d2 = decimal.Parse(textBox17.Text);
            }
            if (!string.IsNullOrEmpty(textBox18.Text))
            {
                d3 = decimal.Parse(textBox18.Text);
            }
          
         
            dt2 = bc.GET_NOEXISTS_EMPTY_ROW_DT(dt, "", "报废数量 IS NOT NULL");
            if (dt2.Rows.Count > 0)
            {
                d4 = decimal.Parse(dt2.Compute("SUM(报废数量)", "").ToString());
                TOTAL_DEFECT_COUNT = d4;
            }
            d5 = cbatch.RETURN_BATCHID_TOTAL_COUNT(textBox1.Text);
      
            string v2 = bc.getOnlyString("SELECT UNIT_LOT FROM BATCH_DET WHERE BATCHID='"+textBox1 .Text +"'");
            if (!string.IsNullOrEmpty(v2))
            {
                d6 = decimal.Parse(v2);
            }
       
            
            foreach (DataRow dr in dt2.Rows)
            {
                string v1 = dr["不良现象群组代码"].ToString();
                if (bc.DELEGATE_JUAGE(v1, dr["项次"].ToString(), bc.JUAGE_BAD_PHENOMENON_GROUP))
                {
                    hint.Text = bc.ErrowInfo;
                    b = true;
                    break;
                }
                else if (bc.DELEGATE_JUAGE(dr["不良现象代码"].ToString(), dr["项次"].ToString(), bc.JUAGE_BAD_PHENOMENON))
                {
                    hint.Text = bc.ErrowInfo;
                    b = true;
                    break;
                }
                else if (bc.exists(string.Format(@"
SELECT
A.BGID,
A.BPID 
FROM 
BAD_PHENOMENON_AND_GROUP A 
LEFT JOIN BAD_PHENOMENON B ON A.BPID=B.BPID
LEFT JOIN BAD_PHENOMENON_GROUP C ON A.BGID=C.BGID
WHERE B.BAD_PHENOMENON_ID='{0}' AND C.BAD_PHENOMENON_GROUP_ID='{1}'", dr["不良现象群组代码"].ToString(), dr["不良现象代码"].ToString())))
                {
                    StringBuilder sqb = new StringBuilder();
                    sqb.AppendFormat("项次 {0} ", dr["项次"].ToString());
                    sqb.AppendFormat("不良现象代码 {0} 不在", dr["不良现象代码"].ToString());
                    sqb.AppendFormat("不良现象群组代码 {0}中", dr["不良现象群组代码"].ToString());
                    hint.Text = sqb.ToString();
                    break;
                }
                else if (bc.DELEGATE_JUAGE(dr["不良原因代码"].ToString(), dr["项次"].ToString(), bc.JUAGE_BAD_PHENOMENON_BECAUSE))
                {
                    hint.Text = bc.ErrowInfo;
                    b = true;
                    break;
                }
            }
            if (d1 + d2 + d3 + d4 + d5 != d6)
            {
                b = true;
                StringBuilder sqb=new StringBuilder ();
                sqb .AppendFormat ("OK数量 {0} + ",d1);
                sqb.AppendFormat("复判数量 {0} + ", d2);
                sqb.AppendFormat("重工数量 {0} + ", d3);
                sqb.AppendFormat("合计报废数量 {0} + ", d4);
                sqb.AppendFormat("该母批号产生的子批号历史(OK数量+复判数量+重工数量+报废数量)之和 {0}", d5);
                sqb.AppendFormat(" = {0}+{1}+{2}+{3}+{4} = {5} 不等于单位批号量 {6} ", d1,d2,d3,d4,d5,d1+d2+d3+d4+d5,d6);
                hint.Text = sqb.ToString();
            }
            return b;
        }
        #endregion
     
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                 if (MessageBox.Show("确定要删除该条凭证吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    basec.getcoms("DELETE POSTING_MST WHERE FCID='" + textBox2.Text + "'");
                    basec.getcoms("DELETE POSTING_DET WHERE FCID='" + textBox2.Text + "'");
                    bind();
                    ClearText();
                    textBox2.Text = "";
                    //F1.load();
                }
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

    
        #region dgvStateControl
        private void dgvStateControl()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;
       
            int numCols1 = dataGridView1.Columns.Count;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            dataGridView1.Columns["项次"].Width = 40;
            dataGridView1.Columns["不良现象群组代码"].Width = 110;
            dataGridView1.Columns["不良现象群组名称"].Width = 140;
            dataGridView1.Columns["不良现象代码"].Width = 100;
            dataGridView1.Columns["不良现象名称"].Width = 140;
            dataGridView1.Columns["不良原因代码"].Width = 110;
            dataGridView1.Columns["不良原因名称"].Width = 110;
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
            dataGridView1.Columns["项次"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["项次"].ReadOnly = true;
            dataGridView1.Columns["不良现象群组名称"].ReadOnly = true;
            dataGridView1.Columns["不良现象名称"].ReadOnly = true;
            dataGridView1.Columns["不良原因名称"].ReadOnly = true;

         
        }
        #endregion

        #region dgvStateControl_t
        private void dgvStateControl_t()
        {
            int i;
            dataGridView2.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;

            int numCols1 = dataGridView2.Columns.Count;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            dataGridView2.Columns["项次"].Width = 40;
            dataGridView2.Columns["站别代码"].Width = 110;
            dataGridView2.Columns["站别名称"].Width = 110;
     
            for (i = 0; i < numCols1; i++)
            {

                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;

            }
            for (i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
            dataGridView2.Columns["项次"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns["项次"].ReadOnly = true;
            dataGridView2.Columns["站别代码"].ReadOnly = true;
            dataGridView2.Columns["站别名称"].ReadOnly = true;
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl_th()
        {
            int i;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Lavender;

            int numCols1 = dataGridView1.Columns.Count;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;/*自动调整DATAGRIDVIEW的列宽*/
            dataGridView1.Columns["复选框"].Width = 50;
            dataGridView1.Columns["项次"].Width = 40;
            dataGridView1.Columns["批号"].Width = 200;
            dataGridView1.Columns["当前站别代码"].Width = 100;
            dataGridView1.Columns["当前站别名称"].Width = 100;
            dataGridView1.Columns["执行规则"].Width = 60;
            dataGridView1.Columns["状态"].Width = 60;
            dataGridView1.Columns["批号数量"].Width = 60;
            for (i = 0; i < numCols1; i++)
            {

                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.Lavender;
                if (i != 0)
                { 
                    dataGridView1.Columns[i].ReadOnly = true;
                }
                if (dataGridView1.Columns[i].DataPropertyName== "批号")
                {
                    dataGridView1.Columns["批号"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
            for (i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                i = i + 1;
            }
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
            string sql2 = "DELETE FROM POSTING_DET WHERE FCID='" + textBox2.Text + "' AND SN='" + v1 + "'";
            if (dt.Rows.Count > 0)
            {

                if (MessageBox.Show("确定要删除该条信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!bc.exists("SELECT * FROM POSTING_DET WHERE FCID='" + textBox2.Text + "' AND SN='"+v1+"'"))
                    {
                        hint.Text = "此条记录还未写入数据库";
                    }
                    else  if (bc.juageOne("SELECT * FROM POSTING_DET WHERE FCID='" + textBox2.Text + "'"))
                    {

                        basec.getcoms(sql2);
                        string sql3 = "DELETE POSTING_MST WHERE FCID='" + textBox2.Text + "'";
                        basec.getcoms(sql3);
                        basec.getcoms("DELETE REMARK WHERE FCID='" + textBox2.Text + "'");
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
            comboBox2.Text = "";
            //textBox3.Text = bc.getOnlyString("SELECT MACHINE_GROUP FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='"+comboBox1.Text +"'");
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dt3.Rows.Count > 0)
            {
               
            }
            else
            {
                
                int intC = this.dataGridView1.CurrentCell.RowIndex;
                int c = dataGridView1.CurrentCell.ColumnIndex;
                if (c == 1)
                {
                    CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_GROUP FRM = new CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_GROUP();
                    FRM.POSTING_USE();
                    FRM.ShowDialog();
                    if (IF_DOUBLE_CLICK)
                    {
                        dt.Rows[intC]["不良现象群组代码"] = BAD_PHENOMENON_GROUP_ID;
                        dt.Rows[intC]["不良现象群组名称"] = BAD_PHENOMENON_GROUP;
                        dataGridView1.CurrentCell = dataGridView1["不良现象代码", intC];
                    }
                }
                else if (c == 3)
                {
                    CSPSS.QUALITY_MANAGE.BAD_PHENOMENON FRM = new CSPSS.QUALITY_MANAGE.BAD_PHENOMENON();
                    FRM.POSTING_USE();
                    FRM.BGID = bc.getOnlyString(string.Format(@"SELECT BGID FROM BAD_PHENOMENON_GROUP WHERE BAD_PHENOMENON_GROUP_ID='{0}'
", dt.Rows[intC]["不良现象群组代码"].ToString()));
                    FRM.ShowDialog();
                    if (IF_DOUBLE_CLICK)
                    {
                        dt.Rows[intC]["不良现象代码"] = BAD_PHENOMENON_ID;
                        dt.Rows[intC]["不良现象名称"] = BAD_PHENOMENON;
                        dataGridView1.CurrentCell = dataGridView1["不良原因代码", intC];
                    }
                }
                else if (c == 5)
                {
                    CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_BECAUSE FRM = new CSPSS.QUALITY_MANAGE.BAD_PHENOMENON_BECAUSE();
                    FRM.POSTING_USE();
                    FRM.ShowDialog();
                    if (IF_DOUBLE_CLICK)
                    {
                        dt.Rows[intC]["不良原因代码"] = BAD_PHENOMENON_BECAUSE_ID;
                        dt.Rows[intC]["不良原因名称"] = BAD_PHENOMENON_BECAUSE;
                        dataGridView1.CurrentCell = dataGridView1["不良现象群组代码", intC + 1];
                    }

                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private bool  current_active_control()
        {
            bind();
            OKCOUNT = 0;
            REJUDGE_COUNT = 0;
            RE_PROCESSING_COUNT = 0;
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            hint.Text = "";
            bool b = false;
            DataTable dtx = bc.getdt(string.Format(cPOSTING .sqlf  + " WHERE F.BATCHID='{0}'", textBox1.Text));
            if (dtx.Rows.Count > 0)
            {
              
                textBox2.Text = dtx.Rows[0]["当前执行规则"].ToString();
                if (dtx.Rows[0]["当前执行规则"].ToString() == "入账")
                {
                  
                    dataGridView1.Visible = false;
                    textBox17.Visible = false;
                    textBox18.Visible = false;
                    label18.Visible = false;
                    label21.Visible = false;
                    textBox17.Text = "";
                    textBox18.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Items.Clear();
                }
              
                else
                {
                    if (dtx.Rows[0]["当前站别名称"].ToString() == "内包" && dtx.Rows[0]["状态"].ToString() == "等待")
                    {
                        comboBox1.Text = "";
                        comboBox2.Items.Clear();
                        dataGridView1.Visible = true;
                    }
                    else
                    {
                        dataGridView1.Visible = true;
                    }
                    dataGridView1.Visible = true;
                    textBox17.Visible = true;
                    textBox18.Visible = true;
                    label18.Visible = true;
                    label21.Visible = true;


                }
                textBox5.Text = dtx.Rows[0]["料号"].ToString();
                textBox6.Text = dtx.Rows[0]["品名"].ToString();
                textBox7.Text = dtx.Rows[0]["工单号"].ToString();
                textBox8.Text = dtx.Rows[0]["工单数量"].ToString();
                textBox9.Text = dtx.Rows[0]["途程代码"].ToString();
                textBox10.Text = dtx.Rows[0]["途程名称"].ToString();
                textBox11.Text = dtx.Rows[0]["途程版本"].ToString();
                textBox12.Text = dtx.Rows[0]["当前站别代码"].ToString();
                DataTable dtx2= bc.getdt(string.Format (@"
SELECT 
B.MACHINE_GROUP_ID AS MACHINE_GROUP_ID,
B.MACHINE_GROUP AS MACHINE_GROUP,
C.MACHINE_ID AS MACHINE_ID,
C.MACHINE FROM STEP A 
LEFT JOIN MACHINE_GROUP B ON A.MRID=B.MRID
LEFT JOIN MACHINE C ON A.MAID=C.MAID
WHERE A.STEP_ID='{0}'",dtx.Rows[0]["当前站别代码"].ToString()));
                if (dtx2.Rows.Count > 0)
                {
                    comboBox1.Text = dtx2.Rows[0]["MACHINE_GROUP_ID"].ToString() + "-" + dtx2.Rows[0]["MACHINE_GROUP"].ToString();
                    comboBox2.Text = dtx2.Rows[0]["MACHINE_ID"].ToString() + "-" + dtx2.Rows[0]["MACHINE"].ToString();
                }
                else
                {
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                }
              
                textBox13.Text = dtx.Rows[0]["当前站别名称"].ToString();
                textBox14.Text = dtx.Rows[0]["单位批号量"].ToString();
                textBox15.Text = dtx.Rows[0]["状态"].ToString();
                if (!string.IsNullOrEmpty(dtx.Rows[0]["OK数量"].ToString()) && dtx.Rows[0]["OK数量"].ToString()!="0")
                {
                   textBox16 .Text  = dtx.Rows[0]["OK数量"].ToString();
                   
                }
                if (dtx.Rows[0]["复判数量"].ToString() != "0")
                {

                    textBox17.Text = dtx.Rows[0]["复判数量"].ToString();
                }
                if (dtx.Rows[0]["重工数量"].ToString() != "0")
                {

                    textBox18.Text = dtx.Rows[0]["重工数量"].ToString();
                }
                StringBuilder sqb=new StringBuilder ();
                sqb.Append (cflow_chart.sql);
                sqb.AppendFormat (" WHERE B.FCID='{0}'", dtx.Rows[0]["途程编号"].ToString());
                sqb.AppendFormat (" AND B.FLOW_CHART_EDITION='{0}'", dtx.Rows[0]["途程版本"].ToString());
                DataTable dtx1 = bc.getdt(sqb.ToString());
                DataTable dtt = cflow_chart.GetTableInfo();
            
                foreach (DataRow dr in dtx1.Rows)
                {
                    DataRow dr1 = dtt.NewRow();
                    dr1["项次"] = dr["项次"].ToString();
                    dr1["站别代码"] = dr["站别代码"].ToString();
                    dr1["站别名称"] = dr["站别名称"].ToString();
                    dtt.Rows.Add(dr1);
                }
                dataGridView1.ClearSelection();//取消默认选中列
                dataGridView2.DataSource = dtt;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.ClearSelection();//取消默认选中列
                dgvStateControl_t();
                textBox16.Focus();
              
            }
            else
            {
                hint.Text = "系统不存在此批号";
                dataGridView1.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                label18.Visible = false;
                label21.Visible = false;
                b = true;
            }
            if (juage())
            {
                
            }
            else
            {
                bind();
            }
            return b;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
      
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
ORDER BY MRID ASC", bc.REMOVE_NAME (comboBox1 .Text ,'-')));

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
        private void btndgvInfoCopy_Click(object sender, EventArgs e)
        {

            dgvCopy(ref dataGridView1);

        }
        private void dgvCopy(ref DataGridView  dgv)
        {
            if (dgv.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    Clipboard.SetDataObject(dgv.GetClipboardContent());
                }
                catch (Exception MyEx)
                {
                    MessageBox.Show(MyEx.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) //判断是不是右键
            {
                Control control = new Control();
                Point ClickPoint = new Point(e.X, e.Y);
                control.GetChildAtPoint(ClickPoint);
                if (dataGridView1.HitTest(e.X, e.Y).RowIndex >= 0 && dataGridView1.HitTest(e.X, e.Y).ColumnIndex >= 0)//判断你点的是不是一个信息行里
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].Cells[dataGridView1.HitTest(e.X, e.Y).ColumnIndex];
                    ContextMenu con = new ContextMenu();
                    MenuItem menuDeleteknowledge = new MenuItem("复制");
                    menuDeleteknowledge.Click += new EventHandler(btndgvInfoCopy_Click);
                    con.MenuItems.Add(menuDeleteknowledge);
                    this.dataGridView1.ContextMenu = con;
                    con.Show(dataGridView1, new Point(e.X + 10, e.Y));


                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool b = current_active_control();
        }
    }
}
