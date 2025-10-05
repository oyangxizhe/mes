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
using Excel = Microsoft.Office.Interop.Excel;
namespace XizheC
{
    public class CWIP_SEARCH
    {
         basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }

        private string _BAID;
        public string BAID
        {
            set { _BAID = value; }
            get { return _BAID; }

        }
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _REJUDGE_COUNT;
        public string REJUDGE_COUNT
        {
            set { _REJUDGE_COUNT = value; }
            get { return _REJUDGE_COUNT; }

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
        private string _WOID;
        public string WOID
        {
            set { _WOID = value; }
            get { return _WOID; }

        }
        private string _OK_COUNT;
        public string OK_COUNT
        {
            set { _OK_COUNT = value; }
            get { return _OK_COUNT; }

        }
        private string _UNIT_LOT;
        public string UNIT_LOT
        {
            set { _UNIT_LOT = value; }
            get { return _UNIT_LOT; }

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
        private string _POSTCODE;
        public string POSTCODE
        {
            set { _POSTCODE = value; }
            get { return _POSTCODE; }

        }
        private string _ADDRESS;
        public string ADDRESS
        {
            set { _ADDRESS = value; }
            get { return _ADDRESS; }

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
        private string _BAKEY;
        public string BAKEY
        {
            set { _BAKEY = value; }
            get { return _BAKEY; }

        }
        private  bool _IFExecutionSUCCESS;
        public  bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

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
        private string _REMARK;
        public string REMARK
        {
            set { _REMARK = value; }
            get { return _REMARK; }

        }
        private string _FCID;
        public string FCID
        {

            set { _FCID = value; }
            get { return _FCID; }

        }
        private string _CURRENT_STID;
        public string CURRENT_STID
        {

            set { _CURRENT_STID = value; }
            get { return _CURRENT_STID; }

        }
        private string _FLOW_CHART_EDITION;
        public string FLOW_CHART_EDITION
        {

            set { _FLOW_CHART_EDITION = value; }
            get { return _FLOW_CHART_EDITION; }

        }
        private string _STATUS;
        public string STATUS
        {

            set { _STATUS = value; }
            get { return _STATUS; }

        }
        private string _ACTION_RULE;
        public string ACTION_RULE
        {

            set { _ACTION_RULE = value; }
            get { return _ACTION_RULE; }

        }
        private string _BATCHID;
        public string BATCHID
        {

            set { _BATCHID = value; }
            get { return _BATCHID; }

        }
        #endregion
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        #region sql
        string setsql = @"

SELECT
C.WOID AS 工单号,
C.WAREID AS 物料编号,
D.CO_WAREID AS 料号,
D.WNAME AS 品名,
C.WO_COUNT AS 工单数量,
E.FCID AS 途程编号,
E.FLOW_CHART_ID AS 途程代码,
E.FLOW_CHART AS 途程名称,
C.FLOW_CHART_EDITION AS 途程版本,
A.BATCHID AS 批号,
A.CURRENT_STID AS 当前站别编号,
F.STEP_ID AS 当前站别代码,
F.STEP AS 当前站别名称,
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
G.BXID AS 内箱号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MAKERID) AS 制单人,
B.DATE AS 制单日期
FROM BATCH_DET A
LEFT JOIN BATCH_MST B ON A.BAID=B.BAID
LEFT JOIN WORKORDER_MST C ON A.WOID=C.WOID
LEFT JOIN WAREINFO D ON C.WAREID=D.WAREID
LEFT JOIN FLOW_CHART_MST E ON C.FCID=E.FCID
LEFT JOIN STEP F ON A.CURRENT_STID =F.STID 
LEFT JOIN BOX_DET G ON A.BATCHID =G.BATCHID 

";


        string setsqlo = @"
INSERT INTO BATCH_DET
(
BAKEY,
BAID,
WOID,
BATCHID,
SN,
UNIT_LOT,
OK_COUNT,
REJUDGE_COUNT,
RE_PROCESSING_COUNT,
SCRAP_COUNT,
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
@BAKEY,
@BAID,
@WOID,
@BATCHID,
@SN,
@UNIT_LOT,
@OK_COUNT,
@REJUDGE_COUNT,
@RE_PROCESSING_COUNT,
@SCRAP_COUNT,
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

INSERT INTO BATCH_MST
(
BAID,
WOID,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@BAID,
@WOID,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlth = @"
UPDATE BATCH_MST SET 
WOID=@WOID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY
";

        string setsqlf = @"
SELECT 
A.WOID AS 工单号,
A.WO_COUNT AS 工单数量,
CASE WHEN SUM(B.UNIT_LOT) IS NOT NULL THEN SUM(B.UNIT_LOT)
ELSE 0
END AS 已投产数量,
CASE WHEN SUM(B.UNIT_LOT) IS NOT NULL THEN A.WO_COUNT-SUM(B.UNIT_LOT)
ELSE WO_COUNT 
END AS 未投产数量,
CASE WHEN SUM(B.UNIT_LOT) IS NOT NULL THEN COUNT(*)
ELSE 0
END  AS 投产批数
FROM WORKORDER_MST A
LEFT JOIN BATCH_DET B ON A.WOID=B.WOID
LEFT JOIN BATCH_MST C ON B.BAID=C.BAID  
GROUP BY A.WOID,A.WO_COUNT ORDER BY A.WOID ASC
";
        string setsqlfi = @"
SELECT 
SUBSTRING (BATCHID,1,15) AS 批号,
CASE WHEN SUM(OK_COUNT) IS NOT NULL THEN SUM(OK_COUNT)
ELSE 0
END 
+
CASE WHEN SUM(REJUDGE_COUNT) IS NOT NULL THEN SUM(REJUDGE_COUNT)
ELSE 0
END
+
CASE WHEN SUM(RE_PROCESSING_COUNT) IS NOT NULL THEN SUM(RE_PROCESSING_COUNT)
ELSE 0
END
+
CASE WHEN SUM(SCRAP_COUNT) IS NOT NULL THEN SUM(SCRAP_COUNT)
ELSE 0
END
AS TOTAL_COUNT
FROM BATCH_DET
WHERE BATCHID NOT IN ('{0}')
GROUP BY 
SUBSTRING (BATCHID,1,15),UNIT_LOT 
";
        string setsqlsi = @"
SELECT 
SUBSTRING (BATCHID,1,15) AS BATCHID,
CASE WHEN SUM(SCRAP_COUNT) IS NOT NULL THEN SUM(SCRAP_COUNT)
ELSE 0
END
AS TOTAL_COUNT
FROM POSTING_DET


";
        #endregion
        public CWIP_SEARCH()
        {
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
        public DataTable emptydatatable_T()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("工单号", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("工单数量", typeof(string));
            dt.Columns.Add("途程代码", typeof(string));
            dt.Columns.Add("途程名称", typeof(string));
            dt.Columns.Add("途程版本", typeof(string));
            dt.Columns.Add("批号", typeof(string));
            dt.Columns.Add("当前站别代码", typeof(string));
            dt.Columns.Add("当前站别名称", typeof(string));
            dt.Columns.Add("当前执行规则", typeof(string));
            dt.Columns.Add("状态", typeof(string));
            dt.Columns.Add("单位批号量", typeof(string));
            dt.Columns.Add("OK数量", typeof(string));
            dt.Columns.Add("复判数量", typeof(string));
            dt.Columns.Add("重工数量", typeof(string));
            dt.Columns.Add("报废数量", typeof(string));
            dt.Columns.Add("内箱号", typeof(string));
            dt.Columns.Add("制单人", typeof(string));
            dt.Columns.Add("制单日期", typeof(string));
            return dt;
        }
        public DataTable RETURN_HAVE_ID_DT(DataTable dtx)
        {

            DataTable dt = emptydatatable_T();
            int i = 1;
            foreach (DataRow dr1 in dtx.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["工单号"] = dr1["工单号"].ToString();
                dr["序号"] = i.ToString();
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
                dr["内箱号"] = dr1["内箱号"].ToString();
                dr["制单人"] = dr1["制单人"].ToString();
                dr["制单日期"] = dr1["制单日期"].ToString();
                dt.Rows.Add(dr);
                i = i + 1;
            }

            return dt;

        }

    
    }
}
