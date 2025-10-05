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
    public class CSTEP_YIELD:IGETID 
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
A.BATCHID AS 批号,
A.ACTION_RULE AS 执行规则,
A.STATUS AS 状态,
B.STEP_ID AS 站别代码,
B.STEP AS 站别名称,
A.OK_COUNT AS 投入数量,
A.REJUDGE_COUNT AS 复判数量,
A.RE_PROCESSING_COUNT 重工数量,
A.SCRAP_COUNT AS 报废数量
FROM POSTING_MST  A 
WHERE {0}
LEFT JOIN STEP B ON A.STID=B.STID 
ORDER BY 
A.STID ,
A.ACTION_RULE ,
A.STATUS,
A.BATCHID  
ASC

";


        string setsqlo = @"
SELECT 
D.CO_WAREID  AS 料号,
A.ACTION_RULE AS 执行规则,
C.STEP_ID AS 站别代码,
C.STEP AS 站别名称,
SUM(A.OK_COUNT) AS 投入或产出
FROM POSTING_MST A
LEFT JOIN WORKORDER_MST B ON A.WOID =B.WOID 
LEFT JOIN STEP C ON A.STID=C.STID 
LEFT JOIN WareInfo D ON B.WAREID =D.WareID 
WHERE B.STATUS NOT IN ('SCRAP','COMPLETE')
GROUP BY 
A.ACTION_RULE ,
C.STEP_ID ,
C.STEP,
D.CO_WAREID  
ORDER BY 
A.ACTION_RULE ,
C.STEP_ID ,
C.STEP,
D.CO_WAREID  
 ASC



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
      
        public CSTEP_YIELD()
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
    
        #region TemporaryData2
        public DataTable  TemporaryData2()
        {
            dt = bc.getdt(sqlt);
            DataTable dtt = new DataTable();
            dtt.Columns.Add("料号", typeof(string));
            dtt.Columns.Add("站别代码", typeof(string));
            dtt.Columns.Add("站别名称", typeof(string));
            dtt.Columns.Add("投入数", typeof(decimal));
            dtt.Columns.Add("完工數", typeof(decimal));
            dtt.Columns.Add("不良數", typeof(decimal));
            dtt.Columns.Add("良率", typeof(decimal));
            dtt.Columns.Add("不良率", typeof(decimal));
            if (dt.Rows.Count > 0)
            {
                DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dtt, "", "");
                /*for (int i = 0; i < dtx.Rows.Count; i++)
                {

                    decimal varTO_OK_QTY = decimal.Parse(dtx.Rows[i]["KTO_OK_QTY"].ToString());
                    decimal varTO_NG_QTY = decimal.Parse(dtx.Rows[i]["KTO_NG_QTY"].ToString());
                    decimal varRLS_QTY = decimal.Parse(dtx.Rows[i]["KTO_OK_QTY"].ToString()) + decimal.Parse(dtx.Rows[i]["KTO_NG_QTY"].ToString());
                    DataRow dr = dty.NewRow();
                    dr["序號"] = i + 1;
                    dr["批號"] = dtx.Rows[i]["KENTITY_ID"].ToString();
                    dr["料號"] = dtx.Rows[i]["KITEM_ID"].ToString();
                    dr["交易日期"] = dtx.Rows[i]["KTRX_DATE"].ToString();
                    dr["投入數"] = varRLS_QTY.ToString("0");
                    dr["完工數"] = varTO_OK_QTY.ToString("0");
                    dr["不良數"] = varTO_NG_QTY.ToString("0");
                    dr["良率"] = ((varTO_OK_QTY / varRLS_QTY) * 100).ToString("0.00") + "%";
                    dr["不良率"] = ((varTO_NG_QTY / varRLS_QTY) * 100).ToString("0.00") + "%";
                    dty.Rows.Add(dr);
                }*/

            }

            return dtt;
        }
        #endregion
    }
}
