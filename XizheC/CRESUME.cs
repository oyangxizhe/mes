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
using System.Collections.Generic;
namespace XizheC
{
    public class CRESUME:IGETID 
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
G.CO_WAREID AS 料号,
G.WNAME AS 品名,
F.WO_COUNT AS 工单数量,
D.FLOW_CHART_ID AS 途程代码,
D.FLOW_CHART AS 途程名称,
A.FLOW_CHART_EDITION AS 途程版本,
E.STEP_ID AS 站别代码,
E.STEP AS 站别名称,
A.BATCHID AS 批号,
A.UNIT_LOT AS 单位批号量,
B.MACHINE_GROUP_ID AS 机台群组代码,
B.MACHINE_GROUP AS 机台群组名称,
C.MACHINE_ID AS 机台代码,
C.MACHINE AS 机台名称,
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
A.OK_COUNT AS OK数量,
A.REJUDGE_COUNT AS 复判数量,
A.RE_PROCESSING_COUNT AS 重工数量,
A.SCRAP_COUNT AS 报废数量,
(SELECT ENAME FROM EmployeeInfo WHERE EMID=A.MakerID ) AS 制单人,
A.DATE AS 制单日期
FROM 
POSTING_MST A
LEFT JOIN MACHINE_GROUP B ON A.MRID =B.MRID
LEFT JOIN MACHINE C ON A.MAID =C.MAID 
LEFT JOIN FLOW_CHART_MST D ON A.FCID=D.FCID 
LEFT JOIN STEP E ON A.STID=E.STID 
LEFT JOIN WORKORDER_MST F ON A.WOID =F.WOID 
LEFT JOIN WareInfo G ON G.WareID =F.WAREID 

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
      
        public CRESUME()
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
            dt.Columns.Add("工单数量", typeof(string));
            dt.Columns.Add("途程代码", typeof(string));
            dt.Columns.Add("途程名称", typeof(string));
            dt.Columns.Add("途程版本", typeof(string));
            dt.Columns.Add("站别代码", typeof(string));
            dt.Columns.Add("站别名称", typeof(string));
            dt.Columns.Add("机台群组代码", typeof(string));
            dt.Columns.Add("机台群组名称", typeof(string));
            dt.Columns.Add("机台代码", typeof(string));
            dt.Columns.Add("机台名称", typeof(string));
            dt.Columns.Add("批号", typeof(string));
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
                dr["站别代码"] = dr1["站别代码"].ToString();
                dr["站别名称"] = dr1["站别名称"].ToString();
                dr["机台群组代码"] = dr1["机台群组代码"].ToString();
                dr["机台群组名称"] = dr1["机台群组名称"].ToString();
                dr["机台代码"] = dr1["机台代码"].ToString();
                dr["机台名称"] = dr1["机台名称"].ToString();
                dr["批号"] = dr1["批号"].ToString();
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
    }
}
