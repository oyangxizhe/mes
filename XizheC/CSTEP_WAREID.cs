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

namespace XizheC
{
    public class CSTEP_WAREID
    {
        basec bc = new basec();
        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }
        }
        private string _SWKEY;
        public string SWKEY
        {
            set { _SWKEY = value; }
            get { return _SWKEY; }

        }
        private string _SWID;
        public string SWID
        {
            set { _SWID = value; }
            get { return _SWID; }

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
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }
        }
        private string _DET_WAREID;
        public string DET_WAREID
        {
            set { _DET_WAREID = value; }
            get { return _DET_WAREID; }
        }
        private string _STEP;
        public string STEP
        {
            set { _STEP = value; }
            get { return _STEP; }

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
        private string _SN;
        public string SN
        {
            set { _SN = value; }
            get { return _SN; }

        }
        private string _IF_CHECK_WAREID;
        public string IF_CHECK_WAREID
        {
            set { _IF_CHECK_WAREID = value; }
            get { return _IF_CHECK_WAREID; }

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
       
        #endregion
        DataTable dt = new DataTable();
        #region sql
        string setsql = @"
SELECT 
ROW_NUMBER() OVER (ORDER BY A.SWKEY ASC) AS 序号,
B.SWID AS 编号,
C.STID AS 站别编号,
C.STEP_ID AS 站别代码,
C.STEP AS 站别名称,
A.SN AS 项次,
B.WAREID AS 物料编号,
D.CO_WAREID AS 料号,
D.WNAME AS 品名,
A.DET_WAREID AS BOM物料编号,
CASE WHEN B.IF_CHECK_WAREID='Y' THEN '是'
ELSE '否'
END AS 过帐是否检查物料,
(SELECT CO_WAREID FROM WAREINFO WHERE WAREID=A.DET_WAREID) AS BOM料号,
(SELECT WNAME FROM WAREINFO WHERE WAREID=A.DET_WAREID) AS BOM品名,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MAKERID) AS 制单人,
B.DATE AS 制单日期,
A.REMARK AS 备注
FROM STEP_WAREID_DET A 
LEFT JOIN STEP_WAREID_MST B ON A.SWID=B.SWID
LEFT JOIN STEP C ON B.STID=C.STID
LEFT JOIN WAREINFO D ON B.WAREID=D.WAREID

";


        string setsqlo = @"
INSERT INTO STEP_WAREID_DET
(
SWKEY,
SWID,
SN,
DET_WAREID,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
)
VALUES
(
@SWKEY,
@SWID,
@SN,
@DET_WAREID,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY

)


";

        string setsqlt = @"

INSERT INTO STEP_WAREID_MST
(
SWID,
STID,
WAREID,
IF_CHECK_WAREID,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@SWID,
@STID,
@WAREID,
@IF_CHECK_WAREID,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlth = @"
UPDATE STEP_WAREID_MST SET 
STID=@STID,
WAREID=@WAREID,
IF_CHECK_WAREID=@IF_CHECK_WAREID,
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
        public CSTEP_WAREID()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
        #region GetTableInfo
        public DataTable emptydatatable_T()
        {
            dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("站别代码", typeof(string));
            dt.Columns.Add("站别名称", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("项次", typeof(string));
            dt.Columns.Add("BOM料号", typeof(string));
            dt.Columns.Add("BOM品名", typeof(string));
            dt.Columns.Add("过帐是否检查物料", typeof(string));
            dt.Columns.Add("制单人", typeof(string));
            dt.Columns.Add("制单日期", typeof(string));
            return dt;
        }
        #endregion
        #region GetTableInfo
        public DataTable GetTableInfo()
        {
            dt = new DataTable();
            dt.Columns.Add("项次", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            return dt;
        }
        #endregion
        public string GETID()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.numYM(10, 4, "0001", "select * from STEP_WAREID_MST", "SWID", "SW");
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
            string GET_WAREID= bc.getOnlyString("SELECT WAREID FROM STEP_WAREID_MST WHERE  SWID='" +SWID  + "'");
            string GET_STID = bc.getOnlyString("SELECT STID  FROM STEP_WAREID_MST WHERE SWID='" + SWID + "'");
            if (!bc.exists("SELECT SWID FROM STEP_WAREID_DET WHERE SWID='" + SWID + "'"))
            {
                if (bc.exists("SELECT * FROM STEP_WAREID_MST where WAREID='" + WAREID  + "' AND STID='"+STID +"'"))
                {
                    ErrowInfo = string.Format("站别：{0} "+"+"+"料号：{1} "+"已经存在系统", STEP_ID,DET_WAREID );
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    ACTION_DET(dt);
                    SQlcommandE_MST(sqlt);
                    IFExecution_SUCCESS = true;
                }
            }
            else if (WAREID != GET_WAREID || STID != GET_STID)
            {
                if (bc.exists("SELECT * FROM STEP_WAREID_MST where WAREID='" + WAREID + "' AND STID='" + STID + "'"))
                {
                    ErrowInfo = string.Format("站别：{0} " + "+" + "料号：{1} " + "已经存在系统", STEP_ID, DET_WAREID);
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    ACTION_DET(dt);
                    SQlcommandE_MST(sqlth + " WHERE SWID='" + SWID + "'");
                    IFExecution_SUCCESS = true;
                }
            }
            else
            {
                    ACTION_DET(dt);
                    SQlcommandE_MST(sqlth + " WHERE SWID='" + SWID + "'");
                    IFExecution_SUCCESS = true;
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
            sqlcom.Parameters.Add("@SWKEY", SqlDbType.VarChar, 20).Value = SWKEY;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@SWID", SqlDbType.VarChar, 20).Value = SWID;
            sqlcom.Parameters.Add("@DET_WAREID", SqlDbType.VarChar, 20).Value = DET_WAREID;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
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
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcon.Open();
            sqlcom.Parameters.Add("@SWID", SqlDbType.VarChar, 20).Value = SWID;
            sqlcom.Parameters.Add("@STID", SqlDbType.VarChar, 20).Value = STID;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@IF_CHECK_WAREID", SqlDbType.VarChar, 20).Value = IF_CHECK_WAREID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        private void ACTION_DET(DataTable dt)
        {
            basec.getcoms("DELETE STEP_WAREID_DET WHERE SWID='" + SWID + "'");
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                SWKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM STEP_WAREID_DET", "SWKEY", "SW");
                DET_WAREID = bc.RETURN_WAREID(dr["料号"].ToString());
                SN = i.ToString();
                SQlcommandE_DET(sqlo);
                i = i + 1;
            }
        }
        #region RETURN_HAVE_ID_DT
        public DataTable RETURN_HAVE_ID_DT(DataTable dtx)
        {
            DataTable dt = emptydatatable_T();
            foreach (DataRow dr1 in dtx.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["序号"] = dr1["序号"].ToString();
                dr["项次"] = dr1["项次"].ToString();
                dr["站别代码"] = dr1["站别代码"].ToString();
                dr["站别名称"] = dr1["站别名称"].ToString();
                dr["料号"] = dr1["料号"].ToString();
                dr["品名"] = dr1["品名"].ToString();
                dr["BOM料号"] = dr1["BOM料号"].ToString();
                dr["BOM品名"] = dr1["BOM品名"].ToString();
                dr["过帐是否检查物料"] = dr1["过帐是否检查物料"].ToString();
                dr["制单人"] = dr1["制单人"].ToString();
                dr["制单日期"] = dr1["制单日期"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion
    
    }
}
