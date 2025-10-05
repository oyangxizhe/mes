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
    public class CWIP_INTERRUPT
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
        private string _WIID;
        public string WIID
        {
            set { _WIID = value; }
            get { return _WIID; }

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
        private string _BATCHID;
        public string BATCHID
        {
            set { _BATCHID = value; }
            get { return _BATCHID; }

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
SELECT
cast(0   as   bit)   as   复选框,
A.BATCHID AS 批号,
A.WOID AS 工单号,
C.CO_WAREID AS 料号,
C.WNAME AS 品名,
B.WO_COUNT AS 工单数量,
D.FLOW_CHART_ID AS 途程代码,
D.FLOW_CHART AS 途程名称,
D.FLOW_CHART_EDITION AS 途程版本,
E.STEP_ID AS 当前站别代码,
E.STEP AS 当前站别名称,
CASE WHEN A.ACTION_RULE='TRACK IN ' THEN '入账'
WHEN A.ACTION_RULE='TRACK OUT' THEN '出账'
WHEN A.ACTION_RULE='TRACK REJUDGE' THEN '复判'
WHEN A.ACTION_RULE='PACKING' THEN '内包'
END AS 当前执行规则,
CASE WHEN A.STATUS='WAIT' THEN '等待'
WHEN A.STATUS='PROCESS' THEN '生产中'
WHEN A.STATUS='COMPLETE' THEN '完工'
WHEN A.STATUS='REJUDGE' THEN '复判'
WHEN A.STATUS='HOLD' THEN '中断'
WHEN A.STATUS='RE_PROCESSING' THEN '重工'
WHEN A.STATUS='SCRAP' THEN '报废'
ELSE '未投产'
END AS 状态,
A.UNIT_LOT AS 单位批号量,
A.OK_COUNT AS OK数量,
A.REJUDGE_COUNT AS 复判数量,
A.RE_PROCESSING_COUNT AS 重工数量,
A.SCRAP_COUNT AS 报废数量,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=G.MAKERID) AS 制单人,
G.DATE AS 制单日期
FROM BATCH_DET A
LEFT JOIN WORKORDER_MST B ON A.WOID =B.WOID 
LEFT JOIN WAREINFO C ON B.WAREID=C.WAREID
LEFT JOIN FLOW_CHART_MST D ON B.FCID =D.FCID 
LEFT JOIN STEP E ON A.CURRENT_STID =E.STID 
LEFT JOIN BATCH_MST G ON A.BAID =G.BAID 
";


        string setsqlo = @"
INSERT INTO WIP_INTERRUPT_MST
(
WIID,
BATCHID,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
)
VALUES
(
@WIID,
@BATCHID,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY
)
";

        string setsqlt = @"

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
        public CWIP_INTERRUPT()
        {
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
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM WIP_INTERRUPT_MST", "WIID", "WI");
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
            SQlcommandE_MST(sqlo);
            bc.getcom(string.Format("UPDATE BATCH_DET SET STATUS='HOLD' WHERE BATCHID='{0}'",BATCHID ));
            IFExecution_SUCCESS = true;
        }
        #endregion
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
            sqlcom.Parameters.Add("@WIID", SqlDbType.VarChar, 20).Value = WIID;
            sqlcom.Parameters.Add("@BATCHID", SqlDbType.VarChar).Value = BATCHID;
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
            dt.Columns.Add("复选框", typeof(bool));
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("批号", typeof(string));
            dt.Columns.Add("工单号", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("工单数量", typeof(string));
            dt.Columns.Add("途程代码", typeof(string));
            dt.Columns.Add("途程名称", typeof(string));
            dt.Columns.Add("途程版本", typeof(string));
            dt.Columns.Add("当前站别代码", typeof(string));
            dt.Columns.Add("当前站别名称", typeof(string));
            dt.Columns.Add("当前执行规则", typeof(string));
            dt.Columns.Add("状态", typeof(string));
            dt.Columns.Add("单位批号量", typeof(string));
            dt.Columns.Add("OK数量", typeof(string));
            dt.Columns.Add("复判数量", typeof(string));
            dt.Columns.Add("重工数量", typeof(string));
            dt.Columns.Add("报废数量", typeof(string));
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
                dr["复选框"] = false;
                dr["序号"] = i.ToString();
                dr["工单号"] = dr1["工单号"].ToString();
                dr["料号"] = dr1["料号"].ToString();
                dr["品名"] = dr1["品名"].ToString();
                dr["工单数量"] = dr1["工单数量"].ToString();
                dr["途程代码"] = dr1["途程代码"].ToString();
                dr["途程名称"] = dr1["途程名称"].ToString();
                dr["途程版本"] = dr1["途程版本"].ToString();
                dr["批号"] = dr1["批号"].ToString();
                dr["当前站别代码"] = dr1["当前站别代码"].ToString();
                dr["当前站别名称"] = dr1["当前站别名称"].ToString();
                dr["当前执行规则"] = dr1["当前执行规则"].ToString();
                dr["状态"] = dr1["状态"].ToString();
                dr["单位批号量"] = dr1["单位批号量"].ToString();
                dr["OK数量"] = dr1["OK数量"].ToString();
                dr["复判数量"] = dr1["复判数量"].ToString();
                dr["重工数量"] = dr1["重工数量"].ToString();
                dr["报废数量"] = dr1["报废数量"].ToString();
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
