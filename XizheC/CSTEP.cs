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
    public class CSTEP:IGETID 
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
        private string  _IF_NEED_MACHINE;
        public string  IF_NEED_MACHINE
        {
            set { _IF_NEED_MACHINE = value; }
            get { return _IF_NEED_MACHINE; }

        }
        #endregion
        DataTable dt = new DataTable();
        #region sql
        string setsql = @"
SELECT 
A.STEP_ID AS 站别代码,
A.STEP AS 站别名称,
CASE WHEN A.IF_NEED_MACHINE='Y' THEN '是'
ELSE '否'
END AS 过账是否需要机台,
B.MACHINE_GROUP_ID AS 机台群组代码,
B.MACHINE_GROUP AS 机台群组名称,
C.MACHINE_ID AS 机台代码,
C.MACHINE AS 机台名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM STEP A 
LEFT JOIN MACHINE_GROUP B ON A.MRID=B.MRID
LEFT JOIN MACHINE C ON A.MAID=C.MAID

";


        string setsqlo = @"



";

        string setsqlt = @"

INSERT INTO STEP
(
STID,
STEP_ID,
STEP,
IF_NEED_MACHINE,
MRID,
MAID,
DATE,
MAKERID,
YEAR,
MONTH
)
VALUES
(
@STID,
@STEP_ID,
@STEP,
@IF_NEED_MACHINE,
@MRID,
@MAID,
@DATE,
@MAKERID,
@YEAR,
@MONTH
)
";
        string setsqlth = @"
UPDATE STEP SET 
STEP_ID=@STEP_ID,
STEP=@STEP,
IF_NEED_MACHINE=@IF_NEED_MACHINE,
MRID=@MRID,
MAID=@MAID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH
";

        string setsqlf = @"

";
        string setsqlfi = @"

";
        string setsqlsi = @"


";
        #endregion
      
        public CSTEP()
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
        #region save
        public void save()
        {

            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string GET_STEP = bc.getOnlyString("SELECT STEP FROM STEP WHERE  STID='" + STID + "'");
            string GET_STEP_ID = bc.getOnlyString("SELECT STEP_ID FROM STEP WHERE STID='" + STID + "'");
            if (!bc.exists("SELECT STID FROM STEP WHERE STID='" + STID + "'"))
            {
                if (STEP_ID != "" && bc.exists("SELECT * FROM STEP where STEP_ID='" + STEP_ID + "'"))
                {

                    ErrowInfo = "该站别代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else if (bc.exists("SELECT * FROM STEP WHERE STEP='" + STEP + "'"))
                {

                    ErrowInfo = "该站别名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlt);
                    IFExecution_SUCCESS = true;

                }
            }
            else if (STEP_ID != "" && GET_STEP_ID != STEP_ID)
            {


                if (bc.exists("SELECT * FROM STEP where STEP_ID='" + STEP_ID + "'"))
                {

                    ErrowInfo = "该站别代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else
                {
                   
                    SQlcommandE_MST(sqlth + " WHERE STID='" + STID + "'");
                    IFExecution_SUCCESS = true;
                }


            }
            else if (GET_STEP != STEP)
            {
                if (STEP != "" && bc.exists("SELECT * FROM STEP WHERE STEP='" + STEP + "'"))
                {

                    ErrowInfo = "该站别名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlth + " WHERE STID='" + STID + "'");

                    IFExecution_SUCCESS = true;
                }

            }
            else
            {
              
                SQlcommandE_MST(sqlth + " WHERE STID='" + STID + "'");

                IFExecution_SUCCESS = true;

            }


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
            sqlcom.Parameters.Add("@STID", SqlDbType.VarChar, 20).Value = STID;
            sqlcom.Parameters.Add("@STEP", SqlDbType.VarChar, 20).Value = STEP;
            sqlcom.Parameters.Add("@STEP_ID", SqlDbType.VarChar, 20).Value = STEP_ID;
            sqlcom.Parameters.Add("@IF_NEED_MACHINE", SqlDbType.VarChar, 20).Value = IF_NEED_MACHINE;
            sqlcom.Parameters.Add("@MRID", SqlDbType.VarChar, 20).Value = MRID;
            sqlcom.Parameters.Add("@MAID", SqlDbType.VarChar, 20).Value = MAID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
    }
}
