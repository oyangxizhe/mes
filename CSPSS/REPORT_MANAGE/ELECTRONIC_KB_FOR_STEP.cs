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

namespace CSPSS.REPORT_MANAGE
{
    public partial class ELECTRONIC_KB_FOR_STEP : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2= new DataTable();
        basec bc=new basec ();
        CELECTRONIC_KB_FOR_STEP cELECTRONIC_KB_FOR_SETP = new CELECTRONIC_KB_FOR_STEP();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private string _STEP_ID;
        public string STEP_ID
        {
            set { _STEP_ID = value; }
            get { return _STEP_ID; }
        }
        private string _START_DATE;
        public string START_DATE
        {
            set { _START_DATE = value; }
            get { return _START_DATE; }
        }
        private string _END_DATE;
        public string END_DATE
        {
            set { _END_DATE = value; }
            get { return _END_DATE; }
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
        private int _TIME_INTERVAL;
        public int TIME_INTERVAL
        {
            set { _TIME_INTERVAL = value; }
            get { return _TIME_INTERVAL; }
        }
        private  delegate bool dele(string a1,string a2);
        private delegate void delex();
        protected int M_int_judge, i;
        protected int select;
        CBATCH cbatch = new CBATCH();
        CPOSTING cposting = new CPOSTING();
        CELECTRONIC_KB_FOR_STEP cELECTRONIC_KB_FOR_STEP = new CELECTRONIC_KB_FOR_STEP();
        public ELECTRONIC_KB_FOR_STEP()
        {
            InitializeComponent();
        }
        private void ELECTRONIC_KB_FOR_STEP_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label7.Text = "数据日期为所选日期的上午8点到第二天上午7点59分59秒";
            label7.ForeColor = CCOLOR.rose;
            hint.Text = "";
            this.Text = "电子看板-站别";
            this.groupBox1.Text = "查询条件";
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.Icon = Resource1.xz_200X200;
            Bind();

        }
        private void Bind()
        {
            timer1.Enabled = true;
            if (comboBox2.Text == "")
            {
                TIME_INTERVAL = 5;
            }
            else
            {
                TIME_INTERVAL = Convert.ToInt32(comboBox2.Text);
            }
        
            try
            {
                CHART(dateTimePicker1.Value);
                ShowData();
                chart1.ChartAreas[0].BackColor = CCOLOR.qls;
                chart2.ChartAreas[0].BackColor = CCOLOR.qcs;
                chart3.ChartAreas[0].BackColor = CCOLOR.qmhs;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;//不显示网格x线
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;//不显示网格y线
                chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;//不显示网格x线
                chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;//不显示网格y线
                chart3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;//不显示网格x线255, 192, 192
                chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;//不显示网格y线
                chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                chart3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                label3.Text = "入账数量";
                label4.Text = "出账数量";
                label5.Text = "良率";
            }
            catch (Exception)
            {


            }
        }
        private void CHART(DateTime selectdate)
        {
            START_DATE = selectdate.ToString("yyyy/MM/dd 08:00:00");
            END_DATE = selectdate.AddDays (+1).ToString("yyyy/MM/dd 07:59:59");
            List<CSTEP> listt = cELECTRONIC_KB_FOR_SETP.RETURN_STEP();
            dt = cELECTRONIC_KB_FOR_SETP.EMPTY_DT();
            for (int j = 0; j < listt.Count; j++)
            {
                DataRow dr1 = dt.NewRow();
                dr1["站别代码"] = listt[j].STEP_ID;
                dr1["站别名称"] = listt[j].STEP;
                dr1["入账数量"] = 0;
                dr1["出账数量"] = 0;
                dr1["良率"] = 1;
                dt.Rows.Add(dr1);
            }
            foreach (DataRow dr in dt.Rows)
            {
                DataTable dtx = bc.getdt(string.Format(cELECTRONIC_KB_FOR_SETP.sql, START_DATE, END_DATE));
                DataTable dtx1 = bc.GET_DT_TO_DV_TO_DT(dtx, "", "执行规则='TRACK IN' AND 站别代码='" + dr["站别代码"].ToString() + "'");
                if (dtx1.Rows.Count > 0)
                {
                    dr["入账数量"] = dtx1.Rows[0]["入账或出账数量"].ToString();
                }
                DataTable dtx2 = bc.GET_DT_TO_DV_TO_DT(dtx, "", "执行规则='TRACK OUT' AND 站别代码='" + dr["站别代码"].ToString() + "'");
                if (dtx2.Rows.Count > 0)
                {
                    dr["出账数量"] = dtx2.Rows[0]["入账或出账数量"].ToString();
                }
            }

            foreach (DataRow dr in dt.Rows)
            {
                decimal d1 = 0, d2 = 0;
                if (!string.IsNullOrEmpty(dr["入账数量"].ToString()))
                {
                    d1 = decimal.Parse(dr["入账数量"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["出账数量"].ToString()))
                {
                    d2 = decimal.Parse(dr["出账数量"].ToString());
                }
                if (d1 > 0)
                {
                    dr["良率"] = (d2 / d1);
                }
                else
                {

                    dr["良率"] = "1";
                }

            }

        }
        private void ShowData()
        {

            if (dt.Rows.Count > 0)
            {
                chart1.DataSource = dt;
                chart1.Series["INPUT"].XValueMember = "站别名称";
                chart1.Series["INPUT"].YValueMembers = "入账数量";
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1.0;
            }
            else
            {


                hint.Text = "今日无站别入账记录";
            }
            if (dt.Rows.Count > 0)
            {

                chart2.DataSource = dt;
                chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1.0;
                chart2.Series["OUTPUT"].XValueMember = "站别名称";
                chart2.Series["OUTPUT"].YValueMembers = "出账数量";
            }
            else
            {

                hint.Text = "今日无站别出账记录";
            }
            if (dt.Rows.Count > 0)
            {
                chart3.DataSource = dt;
                chart3.Series["Utilization"].XValueMember = "站别名称";
                chart3.Series["Utilization"].YValueMembers = "良率";
                chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1.0;
                chart3.ChartAreas[0].AxisY.LabelStyle.Format = "0%";//格式化，为了显示百分号
                chart3.Series[0].Label = "#VAL{P}";
            }
            else
            {
                hint.Text = "今日无站别过账记录";
            }
        }
      
        public void ClearText()
        {
            comboBox2.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString("yyyy/MM/dd");
           
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
    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            hint.Text = "";
            if (judge())
            {

            }
            else
            {
                Bind();
               
            }
            try
            {
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        private bool judge()
        {
            bool b = false;
            if (comboBox2 .Text != "" && bc.yesno(comboBox2 .Text) == 0)
            {
                hint.Text = "刷新时间间隔只能输入数字且大于等于1分钟！";
                b = true;
            }
            return b;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            int n = TIME_INTERVAL  * 60000;
            if (n >= 60000)
            {

                timer1.Interval = n;
            }
            Bind();
            
        }
    }
}
