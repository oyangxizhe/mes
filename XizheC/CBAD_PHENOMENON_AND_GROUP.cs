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
    public class CBAD_PHENOMENON_AND_GROUP:IGETID 
    {
        basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }

        private string _BPID;
        public string BPID
        {
            set { _BPID = value; }
            get { return _BPID; }

        }
        private string _BGID;
        public string BGID
        {
            set { _BGID = value; }
            get { return _BGID; }

        }
        private string _BAD_PHENOMENON_AND_GROUP_ID;
        public string BAD_PHENOMENON_AND_GROUP_ID
        {
            set { _BAD_PHENOMENON_AND_GROUP_ID = value; }
            get { return _BAD_PHENOMENON_AND_GROUP_ID; }

        }
        private string _BAD_PHENOMENON_AND_GROUP;
        public string BAD_PHENOMENON_AND_GROUP
        {
            set { _BAD_PHENOMENON_AND_GROUP = value; }
            get { return _BAD_PHENOMENON_AND_GROUP; }

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
CAST(0   as   bit)   as   复选框,
A.BAD_PHENOMENON_ID AS 不良现象代码,
A.BAD_PHENOMENON AS 不良现象名称
FROM BAD_PHENOMENON A 

";


        string setsqlo = @"

SELECT 
A.BAD_PHENOMENON_GROUP_ID AS 不良现象群组代码,
A.BAD_PHENOMENON_GROUP AS 不良现象群组名称
FROM BAD_PHENOMENON_GROUP A 

";

        string setsqlt = @"

INSERT INTO BAD_PHENOMENON_AND_GROUP
(
BPID,
BGID,
DATE,
MAKERID,
YEAR,
MONTH
)
VALUES
(
@BPID,
@BGID,
@DATE,
@MAKERID,
@YEAR,
@MONTH
)
";
        string setsqlth = @"

";

        string setsqlf = @"
SELECT 
CAST(0   as   bit)   as   复选框,
B.BAD_PHENOMENON_ID AS 不良现象代码,
B.BAD_PHENOMENON AS 不良现象名称
FROM BAD_PHENOMENON_AND_GROUP A
LEFT JOIN BAD_PHENOMENON B ON A.BPID=B.BPID
";
        string setsqlfi = @"
SELECT
B.BAD_PHENOMENON_ID AS 不良现象代码,
B.BAD_PHENOMENON AS 不良现象名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MAKERID) AS 制单人,
B.DATE AS 制单日期
FROM BAD_PHENOMENON_AND_GROUP A 
LEFT JOIN BAD_PHENOMENON B ON A.BPID=B.BPID
LEFT JOIN BAD_PHENOMENON_GROUP C ON A.BGID=C.BGID
";
        string setsqlsi = @"


";
        #endregion
      
        public CBAD_PHENOMENON_AND_GROUP()
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
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM BAD_PHENOMENON_AND_GROUP", "BGID", "MR");
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
            SQlcommandE_MST(sqlt );
            IFExecution_SUCCESS = true;
        }
        #endregion
        #region save_t
        public void save_t()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            basec.getcoms("DELETE BAD_PHENOMENON_AND_GROUP WHERE BPID='" + BPID + "'");
            IFExecution_SUCCESS = true;
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
            sqlcom.Parameters.Add("@BPID", SqlDbType.VarChar, 20).Value = BPID;
            sqlcom.Parameters.Add("@BGID", SqlDbType.VarChar, 20).Value = BGID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = MAKERID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion

    }
}
