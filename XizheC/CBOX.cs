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
    public class CBOX
    {
        basec bc = new basec();
        CFLOW_CHART cflow_chart = new CFLOW_CHART();
        DataTable dt = new DataTable();
        CBATCH cbatch = new CBATCH();
        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _BXKEY;
        public string BXKEY
        {
            set { _BXKEY = value; }
            get { return _BXKEY; }

        }
        private string _BXID;
        public string BXID
        {
            set { _BXID = value; }
            get { return _BXID; }

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
  
        #endregion
       
        #region sql
        string setsql = @"
SELECT
A.WOID AS 工单号,
A.WAREID AS 物料编号,
B.CO_WAREID AS 料号,
B.WNAME AS 品名,
A.WO_COUNT AS 工单数量,
E.FCID AS 途程编号,
E.FLOW_CHART_ID AS 途程代码,
E.FLOW_CHART AS 途程名称,
A.FLOW_CHART_EDITION AS 途程版本,
C.STID AS 站别编号,
D.STEP_ID AS 站别代码,
D.STEP AS 站别名称,
C.SN AS 途程项次,
F.BATCHID AS 批号,
F.CURRENT_STID AS 当前站别编号,
G.STEP_ID AS 当前站别代码,
G.STEP AS 当前站别名称,
CASE WHEN F.ACTION_RULE='TRACK IN ' THEN '入账'
WHEN F.ACTION_RULE='TRACK OUT' THEN '出账'
WHEN F.ACTION_RULE='TRACK REJUDGE' THEN '复判'
WHEN F.ACTION_RULE='PACKING' THEN '内包'
END AS 当前执行规则,
CASE WHEN F.STATUS='WAIT' THEN '等待'
WHEN F.STATUS='PROCESS' THEN '生产中'
WHEN F.STATUS='COMPLETE' THEN '完工'
WHEN F.STATUS='REJUDGE' THEN '复判'
WHEN F.STATUS='HOLD' THEN '中断'
WHEN F.STATUS='RE_PROCESSING' THEN '重工'
WHEN F.STATUS='SCRAP' THEN '报废'
ELSE '未投产'
END AS 状态,
F.UNIT_LOT AS 单位批号量,
F.OK_COUNT AS OK数量,
F.REJUDGE_COUNT AS 复判数量,
F.RE_PROCESSING_COUNT AS 重工数量,
F.SCRAP_COUNT AS 报废数量,
H.BXID AS 内箱号,
A.DELIVERY_DATE AS 交货日期,
A.GODE_NEED_DATE AS 需求日期,
A.LAST_PICKING_DATE AS 下料日期,
A.COMPLETE_DATE AS 齐套日期,
A.ADVICE_DELIVERY_DATE AS 建议交期,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM WORKORDER_MST A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN FLOW_CHART_DET C ON A.FCID =C.FCID 
LEFT JOIN STEP D ON C.STID=D.STID 
LEFT JOIN FLOW_CHART_MST E ON A.FCID=E.FCID
LEFT JOIN BATCH_DET F ON A.WOID=F.WOID 
LEFT JOIN STEP G ON F.CURRENT_STID =G.STID 
LEFT JOIN BOX_DET H ON F.BATCHID =H.BATCHID 
";


        string setsqlo = @"
INSERT INTO BOX_DET
(
BXKEY,
BXID ,
SN,
BATCHID ,
YEAR ,
MONTH ,
DAY
)
VALUES
(
@BXKEY,
@BXID ,
@SN ,
@BATCHID ,
@YEAR ,
@MONTH ,
@DAY
)
";

        string setsqlt = @"

INSERT INTO BOX_MST
(
BXID ,
MAKERID,
DATE,
YEAR ,
MONTH ,
DAY
)
VALUES
(
@BXID ,
@MAKERID,
@DATE,
@YEAR ,
@MONTH ,
@DAY
)
";
        string setsqlth = @"
UPDATE BOX_MST SET 
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY
";

        string setsqlf = @"

";
        string setsqlfi = @"

";
        string setsqlsi = @"


";
        #endregion
        public CBOX()
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
            dt.Columns.Add("复选框", typeof(bool));
            dt.Columns.Add("项次", typeof(string));
            dt.Columns.Add("批号", typeof(string));
            dt.Columns.Add("当前站别代码", typeof(string));
            dt.Columns.Add("当前站别名称", typeof(string));
            dt.Columns.Add("执行规则", typeof(string));
            dt.Columns.Add("状态", typeof(string));
            dt.Columns.Add("批号数量", typeof(decimal));
            return dt;
        }
        #endregion
        #region RETURN_NO_PACKING_DT
        public DataTable RETURN_NO_PACKING_DT()
        {
            DataTable dtt = GetTableInfo();
            dt = bc.getdt(sql + " WHERE G.STEP ='内包' AND D.STEP ='内包' AND F.STATUS='WAIT'");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    int i = 1;
                    DataRow dr1 = dtt.NewRow();
                    dr1["项次"] = i.ToString();
                    dr1["批号"] = dr["批号"].ToString();
                    dr1["当前站别代码"] = dr["当前站别代码"].ToString();
                    dr1["当前站别名称"] = dr["当前站别名称"].ToString();
                    dr1["执行规则"] = dr["当前执行规则"].ToString();
                    dr1["状态"] = dr["状态"].ToString();
                    dr1["批号数量"] = dr["OK数量"].ToString();
                    dtt.Rows.Add(dr1);
                    i = i + 1;
                }
            }
            return dtt;
        }
        #endregion
        #region RETURN_NO_PACKING_DT
        public DataTable RETURN_NO_PACKING_DT(string BATCHID)
        {
            DataTable dtt = GetTableInfo();
            DataTable dt = RETURN_NO_PACKING_DT();
            DataTable dt3 = bc.GET_DT_TO_DV_TO_DT(RETURN_NO_PACKING_DT(), "", string.Format("批号='{0}'", BATCHID));
            if (dt3.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {

                    DataRow dr1 = dtt.NewRow();
                    if (dr["批号"].ToString() == BATCHID)
                    {
                        dr1["复选框"] = true;
                    }
                    dr1["项次"] = i.ToString();
                    dr1["批号"] = dr["批号"].ToString();
                    dr1["当前站别代码"] = dr["当前站别代码"].ToString();
                    dr1["当前站别名称"] = dr["当前站别名称"].ToString();
                    dr1["执行规则"] = dr["执行规则"].ToString();
                    dr1["状态"] = dr["状态"].ToString();
                    dr1["批号数量"] = dr["批号数量"].ToString();
                    dtt.Rows.Add(dr1);
                    i = i + 1;
                }

            }

            return dtt;
        }
        #endregion
        public string GETID()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM BOX_MST", "BXID", "BX");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
            }
            return GETID;
        }

        #region save
        public void save(DataTable dt)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            ACTION_DET(dt);
            if (!bc.exists("SELECT * FROM BOX_DET WHERE BXID='" + BXID + "'"))
            {
                IFExecution_SUCCESS = false;
                return;
            }
            else
            {

                SQlcommandE_MST(sqlt);
                IFExecution_SUCCESS = true;

             if (MessageBox.Show(string.Format ("要打印内箱号 {0} 吗？",BXID ), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
              {
                  MessageBox.Show("此功能尚未启用");
              }
          
            }
        }
        #endregion
        #region SQlcommandE_DET
        protected void SQlcommandE_DET(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace ("-","/");
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@BXKEY", SqlDbType.VarChar, 20).Value = BXKEY;
            sqlcom.Parameters.Add("@SN ", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@BXID ", SqlDbType.VarChar, 20).Value = BXID;
            sqlcom.Parameters.Add("@BATCHID ", SqlDbType.VarChar, 20).Value = BATCHID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region SQlcommandE_MST
        protected void SQlcommandE_MST(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@BXID ", SqlDbType.VarChar, 20).Value = BXID;
            sqlcom.Parameters.Add("@DATE ", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID ", SqlDbType.VarChar, 20).Value = MAKERID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        private void ACTION_DET(DataTable dt)
        {
            basec.getcoms("DELETE BOX_DET WHERE BXID='" + BXID + "'");
            BXID = GETID();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["复选框"].ToString() == "True")
                {
                  BXKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM BOX_DET", "BXKEY", "BX");
                  BATCHID = dr["批号"].ToString();
                  SN = dr["项次"].ToString();
                  SQlcommandE_DET(sqlo);
                  basec.getcoms("UPDATE BATCH_DET SET STATUS='COMPLETE',ACTION_RULE='PACKING' WHERE BATCHID='" +dr["批号"].ToString () + "'");
                  IFExecution_SUCCESS = true;
                }
         
            }
        }
    
    }
}
