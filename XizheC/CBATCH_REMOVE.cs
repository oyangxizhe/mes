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
    public class CBATCH_REMOVE
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
 
        private string _BEKEY;
        public string BEKEY
        {
            set { _BEKEY = value; }
            get { return _BEKEY; }

        }
        private string _CURRENT_STID;
        public string CURRENT_STID
        {
            set { _CURRENT_STID = value; }
            get { return _CURRENT_STID; }

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
        private bool _BOOL_BATCH_REMOVE_COUNT;
        public bool BOOL_BATCH_REMOVE_COUNT
        {
            set { _BOOL_BATCH_REMOVE_COUNT = value; }
            get { return _BOOL_BATCH_REMOVE_COUNT; }

        }
        private string _BEID;
        public string BEID
        {
            set { _BEID = value; }
            get { return _BEID; }

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
        private decimal _OK_COUNT;
        public decimal OK_COUNT
        {
            set { _OK_COUNT = value; }
            get { return _OK_COUNT; }

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
    
        private decimal _BATCH_REMOVE_COUNT;
        public decimal BATCH_REMOVE_COUNT
        {

            set { _BATCH_REMOVE_COUNT = value; }
            get { return _BATCH_REMOVE_COUNT; }

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

        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
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
";


        string setsqlo = @"
INSERT INTO BATCH_REMOVE_MST
(
BEKEY,
BEID,
BATCHID,
SN,
UNIT_LOT,
OK_COUNT,
REJUDGE_COUNT,
RE_PROCESSING_COUNT,
NEW_BATCHID,
BATCH_REMOVE_COUNT,
FCID,
FLOW_CHART_EDITION,
CURRENT_STID,
STATUS,
ACTION_RULE,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
)
VALUES
(
@BEKEY,
@BEID,
@BATCHID,
@SN,
@UNIT_LOT,
@OK_COUNT,
@REJUDGE_COUNT,
@RE_PROCESSING_COUNT,
@NEW_BATCHID,
@BATCH_REMOVE_COUNT,
@FCID,
@FLOW_CHART_EDITION,
@CURRENT_STID,
@STATUS,
@ACTION_RULE,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY
)
";

        string setsqlt = @"
SELECT 
A.BATCHID AS 母批号,
CASE WHEN A.OK_COUNT!=0 AND A.REJUDGE_COUNT=0 AND A.RE_PROCESSING_COUNT=0 THEN A.OK_COUNT
WHEN A.OK_COUNT=0 AND A.REJUDGE_COUNT!=0 AND A.RE_PROCESSING_COUNT=0 THEN A.REJUDGE_COUNT
ELSE A.RE_PROCESSING_COUNT
END AS 母批号数量,
CASE WHEN B.OK_COUNT!=0 AND B.REJUDGE_COUNT=0 AND B.RE_PROCESSING_COUNT=0 THEN B.OK_COUNT
WHEN B.OK_COUNT=0 AND B.REJUDGE_COUNT!=0 AND B.RE_PROCESSING_COUNT=0 THEN B.REJUDGE_COUNT
ELSE B.RE_PROCESSING_COUNT
END AS 现母批号数量,
NEW_BATCHID AS 子批号,
BATCH_REMOVE_COUNT AS 子批号数量,
CASE WHEN C.OK_COUNT!=0 AND C.REJUDGE_COUNT=0 AND C.RE_PROCESSING_COUNT=0 THEN C.OK_COUNT
WHEN C.OK_COUNT=0 AND C.REJUDGE_COUNT!=0 AND C.RE_PROCESSING_COUNT=0 THEN C.REJUDGE_COUNT
ELSE C.RE_PROCESSING_COUNT
END AS 现子批号数量,
(SELECT ENAME FROM EmployeeInfo WHERE EMID =A.MakerID ) AS 制单人,
A.Date AS 制单日期
FROM 
BATCH_REMOVE_MST A
LEFT JOIN BATCH_DET B ON A.BATCHID=B.BATCHID 
LEFT JOIN BATCH_DET C ON A.NEW_BATCHID =C.BATCHID 

";
        string setsqlth = @"

";

        string setsqlf = @"

";
        string setsqlfi = @"

";
        string setsqlsi = @"


";
        #endregion
        public CBATCH_REMOVE()
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
            dt.Columns.Add("不良现象群组代码", typeof(string));
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
            string v1 = bc.numYM(10, 4, "0001", "select * from BATCH_REMOVE_MST", "BEID", "BE");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;

            }
            return GETID;
        }
  
        #region save
        public void save()
        {
          
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            if (OK_COUNT> 0)
            {
                action(BATCH_REMOVE_COUNT, 0, 0);
            }
            else if (REJUDGE_COUNT > 0)
            {
                action(0,BATCH_REMOVE_COUNT, 0);
            }
            else
            {
                action(0, 0,BATCH_REMOVE_COUNT);
            }
        
            SQlcommandE_MST(sqlo);
            IFExecution_SUCCESS = true;
            action_t();
            IFExecution_SUCCESS = true;
        }
        #endregion
        private void action_t()
        {
            decimal d1 = 0;
            StringBuilder sqb = new StringBuilder();
            sqb.AppendFormat("UPDATE BATCH_DET SET ");
            if (OK_COUNT > 0)
            {
                d1 = OK_COUNT - BATCH_REMOVE_COUNT;
                sqb.AppendFormat("OK_COUNT='{0}',", d1);
                sqb.AppendFormat("REJUDGE_COUNT='{0}',", 0);
                sqb.AppendFormat("RE_PROCESSING_COUNT='{0}'", 0);
            }
            else if (REJUDGE_COUNT > 0)
            {
                d1 = REJUDGE_COUNT - BATCH_REMOVE_COUNT;
                sqb.AppendFormat("OK_COUNT='{0}',", 0);
                sqb.AppendFormat("REJUDGE_COUNT='{0}',", d1);
                sqb.AppendFormat("RE_PROCESSING_COUNT='{0}'", 0);

            }
            else
            {
                d1 = RE_PROCESSING_COUNT - BATCH_REMOVE_COUNT;
                sqb.AppendFormat("OK_COUNT='{0}',", 0);
                sqb.AppendFormat("REJUDGE_COUNT='{0}',", 0);
                sqb.AppendFormat("RE_PROCESSING_COUNT='{0}'", d1);

            }
            sqb.AppendFormat(" WHERE BATCHID='{0}'", BATCHID);
            basec.getcoms(sqb.ToString());
        }
        private void action(decimal OK_COUNT,decimal REJUDGE_COUNT,decimal RE_PROCESSING_COUNT)
        {
            StringBuilder sqb = new StringBuilder();
            sqb.AppendFormat("SELECT * FROM BATCH_NO WHERE SUBSTRING(BATCHID,1,{0})='{1}'", BATCHID.Length, BATCHID);
            sqb.AppendFormat(" AND LEN(BATCHID)='{0}'", BATCHID.Length + 5);
            NEW_BATCHID = bc.numNOYMD(BATCHID.Length + 5, 4, "0001", sqb.ToString(), "BATCHID", BATCHID + "-");
            BAKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM BATCH_DET", "BAKEY", "BA");
            cbatch.BAKEY = BAKEY;
            cbatch.BAID = bc.getOnlyString("SELECT BAID FROM BATCH_DET WHERE BATCHID='" + BATCHID + "'");
            cbatch.SN = bc.getOnlyString("SELECT SN FROM BATCH_DET WHERE BATCHID='" + BATCHID + "'");
            cbatch.WOID = WOID;
            cbatch.BATCHID = NEW_BATCHID;
            cbatch.UNIT_LOT = UNIT_LOT;
            cbatch.OK_COUNT = OK_COUNT.ToString();
            cbatch.REJUDGE_COUNT = REJUDGE_COUNT.ToString();
            cbatch.RE_PROCESSING_COUNT = RE_PROCESSING_COUNT.ToString();
            cbatch.SCRAP_COUNT = "0";
            cbatch.FCID = FCID;
            cbatch.FLOW_CHART_EDITION = FLOW_CHART_EDITION;
            cbatch.CURRENT_STID = CURRENT_STID;
            cbatch.STATUS = STATUS;
            cbatch.ACTION_RULE = "TRACK OUT";
            cbatch.MAKERID = MAKERID;
            cbatch.SQlcommandE_DET(cbatch.sqlo);//batch_det
            StringBuilder sqb1 = new StringBuilder();
            sqb1.AppendFormat("INSERT INTO BATCH_NO(NO_KEY,BATCHID) VALUES ('{0}','{1}')", BAKEY, NEW_BATCHID);
            basec.getcoms(sqb1.ToString());

         
        }
        #region SQlcommandE_MST
        public void SQlcommandE_MST(string sql)
        {
            
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@BEKEY", SqlDbType.VarChar, 20).Value =bc.numYMD(20, 12, "000000000001", "SELECT * FROM BATCH_REMOVE_MST", "BEKEY", "BE");
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = "";
            sqlcom.Parameters.Add("@BEID", SqlDbType.VarChar, 20).Value = BEID;
            sqlcom.Parameters.Add("@BATCHID", SqlDbType.VarChar).Value = BATCHID;
            sqlcom.Parameters.Add("@OK_COUNT", SqlDbType.VarChar, 20).Value = OK_COUNT;
            sqlcom.Parameters.Add("@REJUDGE_COUNT", SqlDbType.VarChar, 20).Value = REJUDGE_COUNT;
            sqlcom.Parameters.Add("@RE_PROCESSING_COUNT", SqlDbType.VarChar, 20).Value = RE_PROCESSING_COUNT;
            dt = bc.getdt(string .Format ("SELECT * FROM BATCH_DET WHERE BATCHID='{0}'",BATCHID ));
            if (dt.Rows.Count > 0)
            {
                sqlcom.Parameters.Add("@UNIT_LOT", SqlDbType.VarChar, 20).Value = dt.Rows [0]["UNIT_LOT"].ToString ();
                sqlcom.Parameters.Add("@FCID", SqlDbType.VarChar, 20).Value = dt.Rows[0]["FCID"].ToString ();
                sqlcom.Parameters.Add("@FLOW_CHART_EDITION", SqlDbType.VarChar, 20).Value = dt.Rows [0]["FLOW_CHART_EDITION"].ToString ();
                sqlcom.Parameters.Add("@CURRENT_STID", SqlDbType.VarChar, 20).Value = dt.Rows [0]["CURRENT_STID"].ToString ();
                sqlcom.Parameters.Add("@STATUS", SqlDbType.VarChar, 20).Value =dt.Rows [0]["STATUS"].ToString ();
                sqlcom.Parameters.Add("@ACTION_RULE", SqlDbType.VarChar, 20).Value =dt.Rows [0]["ACTION_RULE"].ToString ();
            }
            sqlcom.Parameters.Add("@NEW_BATCHID", SqlDbType.VarChar).Value = NEW_BATCHID;
            sqlcom.Parameters.Add("@BATCH_REMOVE_COUNT", SqlDbType.VarChar, 20).Value = BATCH_REMOVE_COUNT;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = MAKERID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region emptydatatable_T
        public DataTable emptydatatable_T()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("母批号", typeof(string));
            dt.Columns.Add("母批号数量", typeof(string));
            dt.Columns.Add("现母批号数量", typeof(string));
            dt.Columns.Add("子批号", typeof(string));
            dt.Columns.Add("子批号数量", typeof(string));
            dt.Columns.Add("现子批号数量", typeof(string));
            dt.Columns.Add("制单人", typeof(string));
            dt.Columns.Add("制单日期", typeof(string));
            return dt;
        }
        #endregion
        #region RETURN_HAVE_ID_DT
        public DataTable RETURN_HAVE_ID_DT(DataTable dtx)
        {
            DataTable dt = emptydatatable_T();
            int i = 1;
            foreach (DataRow dr1 in dtx.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["序号"] = i.ToString();
                dr["母批号"] = dr1["母批号"].ToString();
                dr["母批号数量"] = dr1["母批号数量"].ToString();
                dr["现母批号数量"] = dr1["现母批号数量"].ToString();
                dr["子批号"] = dr1["子批号"].ToString();
                dr["子批号数量"] = dr1["子批号数量"].ToString();
                dr["现子批号数量"] = dr1["现子批号数量"].ToString();
                dr["制单人"] = dr1["制单人"].ToString();
                dr["制单日期"] = dr1["制单日期"].ToString();
                dt.Rows.Add(dr);
                i = i + 1;
            }
            return dt;
        }
        #endregion
    }
}
