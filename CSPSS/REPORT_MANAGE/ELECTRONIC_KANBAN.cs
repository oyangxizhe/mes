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
    public partial class ELECTRONIC_KANBAN : Form
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2= new DataTable();
        basec bc=new basec ();
        CELECTRONIC_KANBAN cELECTRONIC_KANBAN = new CELECTRONIC_KANBAN();
        private string _IDO;
        public string IDO
        {
            set { _IDO = value; }
            get { return _IDO; }

        }
        private string _MACHINE_GROUP_ID;
        public string MACHINE_GROUP_ID
        {
            set { _MACHINE_GROUP_ID = value; }
            get { return _MACHINE_GROUP_ID; }
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
        CELECTRONIC_KANBAN celectronic_kanban = new CELECTRONIC_KANBAN();
     
        public ELECTRONIC_KANBAN()
        {
            InitializeComponent();
        }



        private void ELECTRONIC_KANBAN_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label7.Text = "数据日期为所选日期的上午8点到第二天上午7点59分59秒";
            label7.ForeColor = CCOLOR.rose;
            this.Icon = Resource1.xz_200X200;
            hint.Text = "";
            this.Text = "电子看板-机台";
            this.groupBox1.Text = "查询条件";
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            comboBox1.Items.Clear();
            DataTable dt1 = bc.getdt("SELECT * FROM MACHINE_GROUP");
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
            if (comboBox1.Text == "")
            {
              
                DataTable dtx = bc.getdt(@"
SELECT  
B.MACHINE_GROUP_ID 
FROM POSTING_MST A
LEFT JOIN MACHINE_GROUP B ON A.MRID=B.MRID 
WHERE B.MACHINE_GROUP_ID IS NOT NULL
GROUP BY B.MACHINE_GROUP_ID ");
                if (dtx.Rows.Count > 0)
                {
                    MACHINE_GROUP_ID = dtx.Rows[0]["MACHINE_GROUP_ID"].ToString();
                    
                }
            
            }
            else
            {
                MACHINE_GROUP_ID = bc.REMOVE_NAME(comboBox1.Text, '-');
            }
          
            try
            {
               
                if (MACHINE_GROUP_ID != "" &&  MACHINE_GROUP_ID.Length > 0)
                {
                    
                    CHART(dateTimePicker1.Value, MACHINE_GROUP_ID );
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
                }
                else
                {
                    chart1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
                    chart2.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
                    chart3.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
                }
                label3.Text = "入账数量";
                label4.Text = "出账数量";
                label5.Text = "良率";
            }
            catch (Exception)
            {


            }
        }
        private void ShowData()
        {
            
               if (dt.Rows.Count > 0)
                {
                    chart1.DataSource = dt;
                    chart1.Series["INPUT"].XValueMember = "时段";
                    chart1.Series["INPUT"].YValueMembers = "入账数量";
                    chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1.0;
                }
                else
                {

                   
                    hint.Text = "今日无机台入账记录";
                }
                if (dt.Rows.Count > 0)
                {

                    chart2.DataSource = dt;
                    chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1.0;
                    chart2.Series["OUTPUT"].XValueMember = "时段";
                    chart2.Series["OUTPUT"].YValueMembers = "出账数量";
                }
                else
                {

                    hint.Text = "今日无机台出账记录";
                }
                if (dt.Rows.Count > 0)
                {
                    chart3.DataSource = dt;
                    chart3.Series["Utilization"].XValueMember = "时段";
                    chart3.Series["Utilization"].YValueMembers = "良率";
                    chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1.0;
                    chart3.ChartAreas[0].AxisY.LabelStyle.Format = "0%";//格式化，为了显示百分号
                    chart3.Series[0].Label = "#VAL{P}";
                }
                else
                {
                    hint.Text = "今日无机台过账记录";
                }
        }
        private void    CHART(DateTime selectdate, string MACHINE_GROUP_ID)
        {
            List<string> listt = celectronic_kanban.RETURN_DATE(selectdate);
            dt = celectronic_kanban.EMPTY_DT();
            int time = 10;
            for (int j = 0; j < listt.Count - 1; j++)
            {
                DataTable dtx = bc.getdt(string.Format(celectronic_kanban.sql, listt[j], listt[j + 1], MACHINE_GROUP_ID ));
                dtx = bc.GET_DT_TO_DV_TO_DT(dtx, "", "执行规则='TRACK IN'");
                if (dtx.Rows.Count > 0)
                {
                  
                    DataRow dr1 = dt.NewRow();
                    dr1["机台群组代码"] = dtx.Rows[0]["机台群组代码"].ToString();
                    dr1["机台群组名称"] = dtx.Rows[0]["机台群组名称"].ToString();
                    dr1["时段"] = time;
                    dr1["入账数量"] = dtx.Rows[0]["入账或出账数量"].ToString();
                    dt.Rows.Add(dr1);
                    if (time == 22)
                    {
                        time = 0;
                    }
                    else
                    {
                        time = time + 2;
                    }
                }
                else
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["机台群组代码"] = MACHINE_GROUP_ID;
                    dr1["机台群组名称"] = bc.getOnlyString("SELECT MACHINE_GROUP FROM MACHINE_GROUP WHERE MACHINE_GROUP_ID='"+MACHINE_GROUP_ID +"'");
                    dr1["时段"] = time;
                    dr1["入账数量"] = 0;
                    dt.Rows.Add(dr1);
                    if (time == 22)
                    {
                        time = 0;
                    }
                    else
                    {
                        time = time + 2;
                    }
                }
                j = j + 1;
            }
             time = 10;
            for (int j = 0; j < listt.Count - 1; j++)
            {
                DataTable dtx = bc.getdt(string.Format(celectronic_kanban.sql, listt[j], listt[j + 1],MACHINE_GROUP_ID ));
                dtx = bc.GET_DT_TO_DV_TO_DT(dtx, "", "执行规则='TRACK OUT'");
                if (dtx.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        if (dr1["时段"].ToString() == time.ToString())
                        {
                            dr1["出账数量"] = dtx.Rows[0]["入账或出账数量"].ToString();
                            break;
                        }
                    }
                    if (time == 22)
                    {
                        time = 0;
                    }
                    else
                    {
                        time = time + 2;
                    }
                }
                else
                {
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        if (dr1["时段"].ToString() == time.ToString())
                        {
                            dr1["出账数量"] = 0;
                            break;
                        }
                    }
                    if (time == 22)
                    {
                        time = 0;
                    }
                    else
                    {
                        time = time + 2;
                    }
                }
                j = j + 1;
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
