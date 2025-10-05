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

namespace XizheC
{
    public class CBATCH_YIELD:IGETID 
    {
        basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
    
   
        private string _STID;
        public string STID
        {
            set { _STID = value; }
            get { return _STID; }

        }
        private string _STEP_ID;
        public string STEP_ID
        {
            set { _STEP_ID = value; }
            get { return _STEP_ID; }

        }
        private string _STEP;
        public string STEP
        {
            set { _STEP = value; }
            get { return _STEP; }

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
        #endregion
        DataTable dt = new DataTable();
        #region sql
        string setsql = @"

SELECT 
A.WOID AS 工单号,
C.CO_WAREID AS 料号,
C.WNAME AS 品名,
SUBSTRING (A.BATCHID,1,15) AS 批号,
UNIT_LOT AS 投入数量,
CASE WHEN SUM(OK_COUNT) IS NOT NULL THEN SUM(OK_COUNT)
ELSE 0
END 完工数量,
CASE WHEN SUM(REJUDGE_COUNT) IS NOT NULL THEN SUM(REJUDGE_COUNT)
ELSE 0
END AS 复判数量,
CASE WHEN SUM(RE_PROCESSING_COUNT) IS NOT NULL THEN SUM(RE_PROCESSING_COUNT)
ELSE 0
END AS 重工数量,
CASE WHEN SUM(SCRAP_COUNT) IS NOT NULL THEN SUM(SCRAP_COUNT)
ELSE 0
END
AS 报废数量,
(
UNIT_LOT 
-
CASE WHEN SUM(OK_COUNT) IS NOT NULL THEN SUM(OK_COUNT)
ELSE 0
END
)
AS 不良数量,
RTRIM(CONVERT(DECIMAL(18,2),SUM(OK_COUNT)/UNIT_LOT*100))+'%'
AS 良率,
RTRIM(CONVERT(DECIMAL(18,2),(UNIT_LOT-SUM(OK_COUNT))/UNIT_LOT *100))+'%'
AS 不良率,
D.Date AS 日期
FROM BATCH_DET A
LEFT JOIN WORKORDER_MST B ON A.WOID =B.WOID 
LEFT JOIN WAREINFO C ON B.WAREID=C.WAREID 
LEFT JOIN BATCH_MST D ON A.BAID =D.BAID 

";


        string setsqlo = @"



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
      
        public CBATCH_YIELD()
        {
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
        public string GETID()
        {
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM STEP", "STID", "ST");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
            }
            return GETID;
        }
        public DataTable emptydatatable_T()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("工单号", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("批号", typeof(string));
            dt.Columns.Add("投入数量", typeof(string));
            dt.Columns.Add("完工数量", typeof(string));
            dt.Columns.Add("复判数量", typeof(string));
            dt.Columns.Add("重工数量", typeof(string));
            dt.Columns.Add("报废数量", typeof(string));
            dt.Columns.Add("不良数量", typeof(string));
            dt.Columns.Add("良率", typeof(string));
            dt.Columns.Add("不良率", typeof(string));
            dt.Columns.Add("日期", typeof(string));
            return dt;
        }
        public DataTable RETURN_HAVE_ID_DT(DataTable dtx)
        {
            DataTable dt = emptydatatable_T();
            int i = 1;
            foreach (DataRow dr1 in dtx.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["序号"] = i.ToString();
                dr["工单号"] = dr1["工单号"].ToString();
                dr["料号"] = dr1["料号"].ToString();
                dr["品名"] = dr1["品名"].ToString();
                dr["批号"] = dr1["批号"].ToString();
                dr["投入数量"] = dr1["投入数量"].ToString();
                dr["完工数量"] = dr1["完工数量"].ToString();
                dr["复判数量"] = dr1["复判数量"].ToString();
                dr["重工数量"] = dr1["重工数量"].ToString();
                dr["报废数量"] = dr1["报废数量"].ToString();
                dr["不良数量"] = dr1["不良数量"].ToString();
                dr["良率"] = dr1["良率"].ToString();
                dr["不良率"] = dr1["不良率"].ToString();
                dr["日期"] = dr1["日期"].ToString();
                dt.Rows.Add(dr);
                i = i + 1;
            }
            return dt;
        }
    
    }
}
