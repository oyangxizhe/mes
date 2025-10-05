using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using XizheC;
using System.Windows.Forms;
using System.Text;

namespace XizheC
{
    public class CPOSTING
    {
        basec bc = new basec();
        CFLOW_CHART cflow_chart = new CFLOW_CHART();
        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private decimal _TOTAL_DEFECT_COUNT;
        public decimal TOTAL_DEFECT_COUNT
        {

            set { _TOTAL_DEFECT_COUNT = value; }
            get { return _TOTAL_DEFECT_COUNT; }

        }

        private string _PSKEY;
        public string PSKEY
        {
            set { _PSKEY = value; }
            get { return _PSKEY; }

        }
        private bool _BOOL_REJUDGE_COUNT;
        public bool BOOL_REJUDGE_COUNT
        {
            set { _BOOL_REJUDGE_COUNT = value; }
            get { return _BOOL_REJUDGE_COUNT; }

        }
        private bool _BOOL_RE_PROCESSING_COUNT;
        public bool BOOL_RE_PROCESSING_COUNT
        {

            set { _BOOL_RE_PROCESSING_COUNT = value; }
            get { return _BOOL_RE_PROCESSING_COUNT; }

        }
        private bool _BOOL_SCRAP_COUNT;
        public bool BOOL_SCRAP_COUNT
        {

            set { _BOOL_SCRAP_COUNT = value; }
            get { return _BOOL_SCRAP_COUNT; }

        }
        
        private string _PSID;
        public string PSID
        {
            set { _PSID = value; }
            get { return _PSID; }

        }
  
        private string _WOID;
        public string WOID
        {
            set { _WOID = value; }
            get { return _WOID; }

        }

        private string _STID;
        public string STID
        {
            set { _STID = value; }
            get { return _STID; }

        }

        private string _BATCHID;
        public string BATCHID
        {
            set { _BATCHID = value; }
            get { return _BATCHID; }

        }

        private string _UNIT_LOT;
        public string UNIT_LOT
        {
            set { _UNIT_LOT = value; }
            get { return _UNIT_LOT; }

        }

        private string _MRID;
        public string MRID
        {
            set { _MRID = value; }
            get { return _MRID; }

        }
        private string _MAID;
        public string MAID
        {
            set { _MAID = value; }
            get { return _MAID; }

        }
        private string _ACTION_RULE;
        public string ACTION_RULE
        {
            set { _ACTION_RULE = value; }
            get { return _ACTION_RULE; }

        }
        private string _STATUS;
        public string STATUS
        {
            set { _STATUS = value; }
            get { return _STATUS; }

        }

        private string _FCID;
        public string FCID
        {
            set { _FCID = value; }
            get { return _FCID; }

        }
        private string _FLOW_CHART_EDITION;
        public string FLOW_CHART_EDITION
        {
            set { _FLOW_CHART_EDITION = value; }
            get { return _FLOW_CHART_EDITION; }

        }
        private string _OK_COUNT;
        public string OK_COUNT
        {
            set { _OK_COUNT = value; }
            get { return _OK_COUNT; }

        }

        private string _REJUDGE_COUNT;
        public string REJUDGE_COUNT
        {
            set { _REJUDGE_COUNT = value; }
            get { return _REJUDGE_COUNT; }

        }

        private string _BGID;
        public string BGID
        {
            set { _BGID = value; }
            get { return _BGID; }

        }
        private string _BPID;
        public string BPID
        {
            set { _BPID = value; }
            get { return _BPID; }

        }
        private string _SCRAP_COUNT;
        public string SCRAP_COUNT
        {
            set { _SCRAP_COUNT = value; }
            get { return _SCRAP_COUNT; }

        }
        private string _RE_PROCESSING_COUNT;
        public string RE_PROCESSING_COUNT
        {
            set { _RE_PROCESSING_COUNT = value; }
            get { return _RE_PROCESSING_COUNT; }

        }
        private string _BBID;
        public string BBID
        {
            set { _BBID = value; }
            get { return _BBID; }

        }
        private string _NEW_BATCHID;
        public string NEW_BATCHID
        {
            set { _NEW_BATCHID = value; }
            get { return _NEW_BATCHID; }

        }
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _sqlo;
        public string sqlo
        {
            set { _sqlo = value; }
            get { return _sqlo; }

        }
        private string _sqlt;
        public string sqlt
        {
            set { _sqlt = value; }
            get { return _sqlt; }

        }
        private string _sqlth;
        public string sqlth
        {
            set { _sqlth = value; }
            get { return _sqlth; }

        }
        private string _sqlf;
        public string sqlf
        {
            set { _sqlf = value; }
            get { return _sqlf; }

        }
        private string _sqlfi;
        public string sqlfi
        {
            set { _sqlfi = value; }
            get { return _sqlfi; }

        }
      
        private string _sqlsi;
        public string sqlsi
        {
            set { _sqlsi = value; }
            get { return _sqlsi; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
      
        private  bool _IFExecutionSUCCESS;
        public  bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _PAYMENT;
        public string PAYMENT
        {
            set { _PAYMENT = value; }
            get { return _PAYMENT; }

        }

        private string _SN;
        public string SN
        {
            set { _SN = value; }
            get { return _SN; }

        }
      
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
        private string _BAKEY;
        public string BAKEY
        {
            set { _BAKEY = value; }
            get { return _BAKEY; }

        }
        #endregion
        DataTable dt = new DataTable();
        CBATCH cbatch = new CBATCH();
        #region sql
        string setsql = @"
SELECT 
A.PSID AS 交易编号,
A.WOID AS 工单号,
A.BATCHID AS 批号,
A.UNIT_LOT AS 单位批号量,
A.MRID AS 机台群组编号,
D.MACHINE_GROUP_ID AS 机台群组代码,
D.MACHINE_GROUP AS 机台群组名称,
A.MAID AS 机台编号,
E.MACHINE_ID AS 机台代码,
E.MACHINE AS 机台名称,
CASE WHEN A.ACTION_RULE ='TRACK IN ' THEN '入账'
WHEN A.ACTION_RULE ='TRACK OUT' THEN '出账'
WHEN A.ACTION_RULE ='TRACK REJUDGE' THEN '复判'
ELSE '内包'
END AS 执行规则,
CASE WHEN A.STATUS='WAIT' THEN '等待'
WHEN A.STATUS='PROCESS' THEN '生产中'
WHEN A.STATUS='COMPLETE' THEN '完工'
WHEN A.STATUS='REJUDGE' THEN '复判'
WHEN A.STATUS='HOLD' THEN '中断'
WHEN A.STATUS='RE_PROCESSING' THEN '重工'
ELSE '报废'
END AS 状态,
A.FCID AS 途程编号,
F.FLOW_CHART_ID AS 途程代码,
F.FLOW_CHART  AS 途程名称,
A.FLOW_CHART_EDITION AS 途程版本,
A.STID AS 站别编号,
G.STEP_ID AS 站别代码,
G.STEP AS 站别名称,
A.OK_COUNT AS OK数量,
A.REJUDGE_COUNT AS 复判数量,
A.RE_PROCESSING_COUNT AS 重工数量,
K.SCRAP_COUNT AS 报废数量,
K.BGID AS 不良现象群组编号,
H.BAD_PHENOMENON_GROUP_ID AS 不良现象群组代码,
H.BAD_PHENOMENON_GROUP  AS 不良现象群组名称,
K.BPID AS 不良现象编号,
I.BAD_PHENOMENON_ID AS 不良现象代码,
I.BAD_PHENOMENON AS 不良现象,
K.BBID AS 不良原因编号,
J.BAD_PHENOMENON_BECAUSE_ID AS 不良原因代码,
J.BAD_PHENOMENON_BECAUSE AS 不良原因
FROM POSTING_MST A 
LEFT JOIN WORKORDER_MST C ON A.WOID=C.WOID
LEFT JOIN MACHINE_GROUP D ON A.MRID=D.MRID
LEFT JOIN MACHINE E ON A.MAID=E.MAID
LEFT JOIN FLOW_CHART_MST F ON A.FCID=F.FCID
LEFT JOIN STEP G ON A.STID=G.STID
LEFT JOIN POSTING_DET K ON A.PSID=K.PSID
LEFT JOIN BAD_PHENOMENON_GROUP H ON K.BGID=H.BGID
LEFT JOIN BAD_PHENOMENON I ON K.BPID=I.BPID
LEFT JOIN BAD_PHENOMENON_BECAUSE J ON K.BBID=J.BBID

";


        string setsqlo = @"
INSERT INTO POSTING_DET
(
PSKEY,
PSID ,
BATCHID ,
SCRAP_COUNT ,
BGID ,
BPID ,
BBID ,
YEAR ,
MONTH ,
DAY
)
VALUES
(
@PSKEY,
@PSID ,
@BATCHID ,
@SCRAP_COUNT ,
@BGID ,
@BPID ,
@BBID ,
@YEAR ,
@MONTH ,
@DAY
)
";

        string setsqlt = @"
INSERT INTO POSTING_MST
(
PSID ,
WOID ,
BATCHID ,
UNIT_LOT ,
MRID ,
MAID ,
ACTION_RULE ,
STATUS ,
FCID ,
SN,
FLOW_CHART_EDITION ,
STID ,
OK_COUNT ,
REJUDGE_COUNT ,
RE_PROCESSING_COUNT ,
SCRAP_COUNT,
MakerID ,
Date,
YEAR ,
MONTH ,
DAY
)
VALUES
(
@PSID ,
@WOID ,
@BATCHID ,
@UNIT_LOT ,
@MRID ,
@MAID ,
@ACTION_RULE ,
@STATUS ,
@FCID ,
@SN,
@FLOW_CHART_EDITION ,
@STID ,
@OK_COUNT ,
@REJUDGE_COUNT ,
@RE_PROCESSING_COUNT ,
@SCRAP_COUNT,
@MakerID ,
@Date,
@YEAR ,
@MONTH ,
@DAY
)

";
        string setsqlth = @"
UPDATE POSTING_MST SET 
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY
";

        string setsqlf = @"
SELECT
A.WOID AS 工单号,
A.WAREID AS 物料编号,
B.CO_WAREID AS 料号,
B.WNAME AS 品名,
A.WO_COUNT AS 工单数量,
F.BATCHID AS 批号,
CASE WHEN F.STATUS='WAIT' THEN '等待'
WHEN F.STATUS='PROCESS' THEN '生产中'
WHEN F.STATUS='COMPLETE' THEN '完工'
WHEN F.STATUS='REJUDGE' THEN '复判'
WHEN F.STATUS='HOLD' THEN '中断'
WHEN F.STATUS='RE_PROCESSING' THEN '重工'
ELSE '报废'
END AS 状态,
F.UNIT_LOT AS 单位批号量,
CASE WHEN F.ACTION_RULE ='TRACK IN ' THEN '入账'
WHEN F.ACTION_RULE ='TRACK OUT' THEN '出账'
WHEN F.ACTION_RULE ='TRACK REJUDGE' THEN '复判'
ELSE '内包'
END AS 当前执行规则,
F.OK_COUNT AS OK数量,
F.REJUDGE_COUNT AS 复判数量,
F.RE_PROCESSING_COUNT AS 重工数量,
F.SCRAP_COUNT AS 报废数量,
H.STEP_ID AS 当前站别代码,
H.STEP AS 当前站别名称,
C.FCID AS 途程编号,
C.FLOW_CHART_ID AS 途程代码,
C.FLOW_CHART AS 途程名称,
D.SN AS 途程项次,
A.FLOW_CHART_EDITION AS 途程版本,
E.STEP_ID AS 站别代码,
E.STEP AS 站别名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=G.MAKERID) AS 制单人,
B.DATE AS 制单日期
FROM WORKORDER_MST A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN FLOW_CHART_MST C ON A.FCID=C.FCID
LEFT JOIN FLOW_CHART_DET D ON D.FCID =C.FCID 
LEFT JOIN STEP E ON D.STID =E.STID 
LEFT JOIN BATCH_DET F ON F.WOID=A.WOID
LEFT JOIN BATCH_MST G ON F.BAID=G.BAID
LEFT JOIN STEP H ON H.STID =F.CURRENT_STID 
";
        string setsqlfi = @"

";
        string setsqlsi = @"


";
        #endregion
        public CPOSTING()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            //GETID =bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_PICKING_MST", "WPID", "WP");

            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
        #region GetTableInfo
        public DataTable GetTableInfo()
        {
            dt = new DataTable();
            dt.Columns.Add("项次", typeof(string));
            dt.Columns.Add("不良现象群组代码",typeof (string));
            dt.Columns.Add("不良现象群组名称", typeof(string));
            dt.Columns.Add("不良现象代码", typeof(string));
            dt.Columns.Add("不良现象名称", typeof(string));
            dt.Columns.Add("不良原因代码", typeof(string));
            dt.Columns.Add("不良原因名称", typeof(string));
            dt.Columns.Add("报废数量", typeof(decimal));
            return dt;
        }
        #endregion
        public string GETID()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.numYM(10, 4, "0001", "select * from POSTING_MST", "PSID", "PS");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
              
            }
            return GETID;
        }
        #region RETURN_DB_ACTION_RULE
        public string RETURN_DB_ACTION_RULE(string ACTION_RULE)
        {
            string v1 = "";
            if (ACTION_RULE == "入账")
            {
                v1 = "TRACK IN ";
            }
            else if (ACTION_RULE == "出账")
            {
                v1 = "TRACK OUT";
            }
            else if (ACTION_RULE == "复判")
            {
                v1 = "TRACK REJUDGE";
            }
            else if (ACTION_RULE == "重工")
            {
                v1 = "TRACK RE_PROCESSING";
            }
            else if(ACTION_RULE =="内包")
            {
                v1 = "PACKING";

            }
            return v1;
        }
        #endregion
        #region RETURN_DB_STATUS
        public string RETURN_DB_STATUS(string STATUS)
        {
            string v1 = "";
            if (STATUS == "等待")
            {
                v1 = "WAIT";
            }
            else if (STATUS == "生产中")
            {
                v1 = "PROCESS";
            }
            else if (STATUS == "内包")
            {
                v1 = "PACKING";
            }
            else if (STATUS == "完工")
            {
                v1 = "COMPLETE";
            }
            else if (STATUS == "复判")
            {
                v1 = "REJUDGE";
            }
            else if (STATUS == "重工")
            {
                v1 = "RE_PROCESSING";
            }
            else if (STATUS == "报废")
            {
                v1 = "SCRAP";
            }
            else if (STATUS == "中断")
            {
                v1 = "HOLD";
            }
            return v1;
        }
        #endregion
        #region save
        public void save(DataTable dt)
        {
           
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");

           if (ACTION_RULE == "TRACK IN ")
           {
              
                SQlcommandE_MST(sqlt);
                if (bc.getOnlyString("SELECT STEP FROM STEP WHERE STID='" + STID + "'") == "内包")
                {
                    basec.getcoms("UPDATE BATCH_DET SET STATUS='COMPLETE',ACTION_RULE='PACKING' WHERE BATCHID='" + BATCHID + "'");
                }
                else
                {
                    basec.getcoms("UPDATE BATCH_DET SET STATUS='PROCESS',ACTION_RULE='TRACK OUT' WHERE BATCHID='" + BATCHID + "'");
                }
                IFExecution_SUCCESS = true;
            }
            else if (ACTION_RULE == "TRACK OUT")
            {
                
                //MessageBox.Show(OK_COUNT + "," + REJUDGE_COUNT + "," + RE_PROCESSING_COUNT);
                SQlcommandE_MST(sqlt);
                cflow_chart.RETURN_LAST_AND_NEXT_STID(STID, FCID, FLOW_CHART_EDITION);
                action_t();
                //MessageBox.Show(BOOL_REJUDGE_COUNT.ToString() + "," + BOOL_RE_PROCESSING_COUNT.ToString() + "," + BOOL_SCRAP_COUNT.ToString());
                if (REJUDGE_COUNT !="0" && BOOL_REJUDGE_COUNT ==false)
                {
                   
                    action(REJUDGE_COUNT,"0","0","REJUDGE");
                }
                if (RE_PROCESSING_COUNT !="0" && BOOL_RE_PROCESSING_COUNT ==false)
                {

                    action("0",RE_PROCESSING_COUNT ,"0","RE_PROCESSING");
                }
                if (TOTAL_DEFECT_COUNT !=0 && BOOL_SCRAP_COUNT ==false)
                {
                   
                    action("0", "0",TOTAL_DEFECT_COUNT.ToString (),"SCRAP");
                    ACTION_DET(dt);
                }
                IFExecution_SUCCESS = true;
            }
            
         
        }
        #endregion
        #region action_t()
        private  void action_t()
        {
            string STATUS = "";
            string ACTION_RULE = "";
            decimal d1 = 0, d2 = 0, d3 = 0,d4=0;
            string CURRENT_STEP = "";
            BOOL_REJUDGE_COUNT = false;
            BOOL_RE_PROCESSING_COUNT = false;
            BOOL_SCRAP_COUNT = false;
            if (OK_COUNT != "0")
            {
                if (cflow_chart.NEXT_STID != null)
                {
                    if (bc.getOnlyString("SELECT STEP FROM STEP WHERE STID='" + cflow_chart.NEXT_STID + "'")=="内包")
                    {
                        STATUS = "WAIT";
                        ACTION_RULE = "TRACK OUT ";
                    }
                    else
                    {
                        STATUS = "WAIT";
                        ACTION_RULE = "TRACK IN ";
                        
                    }
                    CURRENT_STEP = cflow_chart.NEXT_STID;
                }
                else
                {
                    STATUS = "COMPLETE";
                    ACTION_RULE = "PACKING ";
                    CURRENT_STEP = STID;
                }
                d1 = decimal.Parse(OK_COUNT);
            }
            else if (REJUDGE_COUNT != "0")
            {
                d2 = decimal.Parse(REJUDGE_COUNT);
                BOOL_REJUDGE_COUNT = true;
                STATUS = "REJUDGE";
                ACTION_RULE = "TRACK OUT ";
                CURRENT_STEP = STID;
            }
            else if (RE_PROCESSING_COUNT != "0")
            {
                d3 = decimal.Parse(RE_PROCESSING_COUNT);
                BOOL_RE_PROCESSING_COUNT = true;
                STATUS = "RE_PROCESSING";
                ACTION_RULE = "TRACK OUT ";
                CURRENT_STEP = STID;
            }
            else
            {
                d4 = TOTAL_DEFECT_COUNT;
                BOOL_SCRAP_COUNT = true;
                STATUS = "SCRAP";
                ACTION_RULE = "TRACK OUT ";
                CURRENT_STEP = STID;

            }
            StringBuilder sqb = new StringBuilder();
            sqb.AppendFormat("UPDATE BATCH_DET SET ");
            sqb.AppendFormat("STATUS='{0}',ACTION_RULE='{1}',",STATUS,ACTION_RULE);
            sqb.AppendFormat("OK_COUNT='{0}',", d1);
            sqb.AppendFormat("REJUDGE_COUNT='{0}',", d2);
            sqb.AppendFormat("RE_PROCESSING_COUNT='{0}',", d3);
            sqb.AppendFormat("SCRAP_COUNT='{0}',", d4);
            sqb.AppendFormat("CURRENT_STID='{0}'", CURRENT_STEP );
            sqb.AppendFormat(" WHERE BATCHID='{0}'", BATCHID);
            basec.getcoms(sqb.ToString());

        }
        #endregion
        #region action
        private void action(string REJUDGE_COUNT,string RE_PROCESSING_COUNT,string SCRAP_COUNT,string STATUS)
        {

            StringBuilder sqb = new StringBuilder();
            sqb.AppendFormat("SELECT * FROM BATCH_NO WHERE SUBSTRING(BATCHID,1,{0})='{1}'",BATCHID .Length ,BATCHID );
            sqb.AppendFormat(" AND LEN(BATCHID)='{0}'",BATCHID .Length +5);
            NEW_BATCHID = bc.numNOYMD(BATCHID .Length +5, 4, "0001", sqb.ToString (), "BATCHID", BATCHID + "-");
            BAKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM BATCH_DET", "BAKEY", "BA");
            cbatch.BAKEY = BAKEY;
            cbatch.BAID = bc.getOnlyString("SELECT BAID FROM BATCH_DET WHERE BATCHID='" + BATCHID + "'");
            cbatch.SN = bc.getOnlyString("SELECT SN FROM BATCH_DET WHERE BATCHID='" + BATCHID + "'");
            cbatch.WOID = WOID;
            cbatch.BATCHID = NEW_BATCHID;
            cbatch.UNIT_LOT = UNIT_LOT;
            cbatch.OK_COUNT = "0";
            cbatch.REJUDGE_COUNT = REJUDGE_COUNT;
            cbatch.RE_PROCESSING_COUNT = RE_PROCESSING_COUNT;
            cbatch.SCRAP_COUNT = SCRAP_COUNT;
            cbatch.FCID = FCID;
            cbatch.FLOW_CHART_EDITION = FLOW_CHART_EDITION;
            cbatch.CURRENT_STID = STID;
            cbatch.STATUS = STATUS;
            cbatch.ACTION_RULE = "TRACK OUT";
            cbatch.MAKERID = MAKERID;
            cbatch.SQlcommandE_DET(cbatch.sqlo);//batch_det
            StringBuilder sqb1 = new StringBuilder();
            sqb1.AppendFormat("INSERT INTO BATCH_NO(NO_KEY,BATCHID) VALUES ('{0}','{1}')", BAKEY,NEW_BATCHID);
            basec.getcoms(sqb1.ToString());


        }
        #endregion
        #region ACTION_DET
        private void ACTION_DET(DataTable dt) //posting_det 1/2
        {

            basec.getcoms("DELETE POSTING_DET WHERE PSID='" + PSID + "'");
            foreach (DataRow dr in dt.Rows)
            {
                PSKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM POSTING_DET", "PSKEY", "PS");
                BGID = bc.getOnlyString(string.Format("SELECT BGID FROM BAD_PHENOMENON_GROUP WHERE BAD_PHENOMENON_GROUP_ID='{0}'", dr["不良现象群组代码"].ToString()));
                BPID = bc.getOnlyString(string.Format("SELECT BPID FROM BAD_PHENOMENON WHERE BAD_PHENOMENON_ID='{0}'", dr["不良现象代码"].ToString()));
                BBID = bc.getOnlyString(string.Format("SELECT BBID FROM BAD_PHENOMENON_BECAUSE WHERE BAD_PHENOMENON_BECAUSE_ID='{0}'", dr["不良原因代码"].ToString()));
                SCRAP_COUNT = dr["报废数量"].ToString();
                SN = dr["项次"].ToString();
                SQlcommandE_DET(sqlo);
            }
        }
        #endregion
        #region SQlcommandE_DET
        protected void SQlcommandE_DET(string sql)//posting_det 2/2
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace ("-","/");
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@PSKEY", SqlDbType.VarChar, 20).Value = PSKEY;
            sqlcom.Parameters.Add("@PSID ", SqlDbType.VarChar, 20).Value = PSID;
            sqlcom.Parameters.Add("@BATCHID ", SqlDbType.VarChar).Value = NEW_BATCHID;
            sqlcom.Parameters.Add("@SCRAP_COUNT ", SqlDbType.VarChar, 20).Value = SCRAP_COUNT;
            sqlcom.Parameters.Add("@BGID ", SqlDbType.VarChar, 20).Value = BGID;
            sqlcom.Parameters.Add("@BPID ", SqlDbType.VarChar, 20).Value = BPID;
            sqlcom.Parameters.Add("@BBID ", SqlDbType.VarChar, 20).Value = BBID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region SQlcommandE_MST
        protected void SQlcommandE_MST(string sql) //posting_mst
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@PSID ", SqlDbType.VarChar, 20).Value = PSID;
            sqlcom.Parameters.Add("@WOID ", SqlDbType.VarChar, 20).Value = WOID;
            sqlcom.Parameters.Add("@BATCHID ", SqlDbType.VarChar, 20).Value = BATCHID;
            sqlcom.Parameters.Add("@SN ", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@UNIT_LOT ", SqlDbType.VarChar, 20).Value = UNIT_LOT;
            sqlcom.Parameters.Add("@MRID ", SqlDbType.VarChar, 20).Value = MRID;
            sqlcom.Parameters.Add("@MAID ", SqlDbType.VarChar, 20).Value = MAID;
            sqlcom.Parameters.Add("@ACTION_RULE ", SqlDbType.VarChar, 20).Value = ACTION_RULE;
            sqlcom.Parameters.Add("@STATUS ", SqlDbType.VarChar, 20).Value = STATUS;
            sqlcom.Parameters.Add("@FCID ", SqlDbType.VarChar, 20).Value = FCID;
            sqlcom.Parameters.Add("@FLOW_CHART_EDITION ", SqlDbType.VarChar, 20).Value = FLOW_CHART_EDITION;
            sqlcom.Parameters.Add("@STID ", SqlDbType.VarChar, 20).Value = STID;
            sqlcom.Parameters.Add("@OK_COUNT ", SqlDbType.VarChar, 20).Value = OK_COUNT;
            sqlcom.Parameters.Add("@REJUDGE_COUNT ", SqlDbType.VarChar, 20).Value = REJUDGE_COUNT;
            sqlcom.Parameters.Add("@RE_PROCESSING_COUNT ", SqlDbType.VarChar, 20).Value = RE_PROCESSING_COUNT;
            sqlcom.Parameters.Add("@SCRAP_COUNT ", SqlDbType.VarChar, 20).Value = TOTAL_DEFECT_COUNT;
            sqlcom.Parameters.Add("@DATE ", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MakerID ", SqlDbType.VarChar, 20).Value = MAKERID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
  
    
    }
}
