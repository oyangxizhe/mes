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
    public class CMACHINE_AND_GROUP:IGETID 
    {
        basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }

        private string _MAID;
        public string MAID
        {
            set { _MAID = value; }
            get { return _MAID; }

        }
        private string _MRID;
        public string MRID
        {
            set { _MRID = value; }
            get { return _MRID; }

        }
        private string _MACHINE_AND_GROUP_ID;
        public string MACHINE_AND_GROUP_ID
        {
            set { _MACHINE_AND_GROUP_ID = value; }
            get { return _MACHINE_AND_GROUP_ID; }

        }
        private string _MACHINE_AND_GROUP;
        public string MACHINE_AND_GROUP
        {
            set { _MACHINE_AND_GROUP = value; }
            get { return _MACHINE_AND_GROUP; }

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
A.MACHINE_ID AS 机台代码,
A.MACHINE AS 机台名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM MACHINE A 

";


        string setsqlo = @"

SELECT 
A.MACHINE_GROUP_ID AS 机台群组代码,
A.MACHINE_GROUP AS 机台群组名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM MACHINE_GROUP A 

";

        string setsqlt = @"

INSERT INTO MACHINE_AND_GROUP
(
MAID,
MRID,
DATE,
MAKERID,
YEAR,
MONTH
)
VALUES
(
@MAID,
@MRID,
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
B.MACHINE_ID AS 机台代码,
B.MACHINE AS 机台名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM MACHINE_AND_GROUP A
LEFT JOIN MACHINE B ON A.MAID=B.MAID
LEFT JOIN MACHINE_GROUP C ON A.MRID =C.MRID 
";
        string setsqlfi = @"
SELECT
B.MACHINE_ID AS 机台代码,
B.MACHINE AS 机台名称,
C.MACHINE_GROUP_ID AS 机台群组代码,
C.MACHINE_GROUP AS 机台群组名称
FROM MACHINE_AND_GROUP A 
LEFT JOIN MACHINE B ON A.MAID=B.MAID
LEFT JOIN MACHINE_GROUP C ON A.MRID=C.MRID
";
        string setsqlsi = @"


";
        #endregion
      
        public CMACHINE_AND_GROUP()
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
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM MACHINE_AND_GROUP", "MRID", "MR");
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
            basec.getcoms("DELETE MACHINE_AND_GROUP WHERE MAID='" + MAID + "'");
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
            sqlcom.Parameters.Add("@MAID", SqlDbType.VarChar, 20).Value = MAID;
            sqlcom.Parameters.Add("@MRID", SqlDbType.VarChar, 20).Value = MRID;
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
