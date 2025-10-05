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
    public class CMACHINE_GROUP:IGETID 
    {
        basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
    
   
        private string _MRID;
        public string MRID
        {
            set { _MRID = value; }
            get { return _MRID; }

        }
        private string _MACHINE_GROUP_ID;
        public string MACHINE_GROUP_ID
        {
            set { _MACHINE_GROUP_ID = value; }
            get { return _MACHINE_GROUP_ID; }

        }
        private string _MACHINE_GROUP;
        public string MACHINE_GROUP
        {
            set { _MACHINE_GROUP = value; }
            get { return _MACHINE_GROUP; }

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
A.MACHINE_GROUP_ID AS 机台群组代码,
A.MACHINE_GROUP AS 机台群组名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM MACHINE_GROUP A 

";


        string setsqlo = @"



";

        string setsqlt = @"

INSERT INTO MACHINE_GROUP
(
MRID,
MACHINE_GROUP_ID,
MACHINE_GROUP,
DATE,
MAKERID,
YEAR,
MONTH
)
VALUES
(
@MRID,
@MACHINE_GROUP_ID,
@MACHINE_GROUP,
@DATE,
@MAKERID,
@YEAR,
@MONTH
)
";
        string setsqlth = @"
UPDATE MACHINE_GROUP SET 
MACHINE_GROUP_ID=@MACHINE_GROUP_ID,
MACHINE_GROUP=@MACHINE_GROUP,
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
      
        public CMACHINE_GROUP()
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
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM MACHINE_GROUP", "MRID", "MR");
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
            string GET_MACHINE_GROUP = bc.getOnlyString("SELECT MACHINE_GROUP FROM MACHINE_GROUP WHERE  MRID='" + MRID + "'");

            string GET_MACHINE_GROUP_ID = bc.getOnlyString("SELECT MACHINE_GROUP_ID FROM MACHINE_GROUP WHERE MRID='" + MRID + "'");

            if (!bc.exists("SELECT MRID FROM MACHINE_GROUP WHERE MRID='" + MRID + "'"))
            {
                if (MACHINE_GROUP_ID != "" && bc.exists("SELECT * FROM MACHINE_GROUP where MACHINE_GROUP_ID='" + MACHINE_GROUP_ID + "'"))
                {

                    ErrowInfo = "该机台群组代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else if (bc.exists("SELECT * FROM MACHINE_GROUP WHERE MACHINE_GROUP='" + MACHINE_GROUP + "'"))
                {

                    ErrowInfo = "该机台群组名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlt);
                    IFExecution_SUCCESS = true;

                }
            }
            else if (MACHINE_GROUP_ID != "" && GET_MACHINE_GROUP_ID != MACHINE_GROUP_ID)
            {


                if (bc.exists("SELECT * FROM MACHINE_GROUP where MACHINE_GROUP_ID='" + MACHINE_GROUP_ID + "'"))
                {

                    ErrowInfo = "该机台群组代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else
                {
                   
                    SQlcommandE_MST(sqlth + " WHERE MRID='" + MRID + "'");
                    IFExecution_SUCCESS = true;
                }


            }
            else if (GET_MACHINE_GROUP != MACHINE_GROUP)
            {
                if (MACHINE_GROUP != "" && bc.exists("SELECT * FROM MACHINE_GROUP WHERE MACHINE_GROUP='" + MACHINE_GROUP + "'"))
                {

                    ErrowInfo = "该机台群组名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlth + " WHERE MRID='" + MRID + "'");

                    IFExecution_SUCCESS = true;
                }

            }
            else
            {
              
                SQlcommandE_MST(sqlth + " WHERE MRID='" + MRID + "'");

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
            sqlcom.Parameters.Add("@MRID", SqlDbType.VarChar, 20).Value = MRID;
            sqlcom.Parameters.Add("@MACHINE_GROUP", SqlDbType.VarChar, 20).Value = MACHINE_GROUP;
            sqlcom.Parameters.Add("@MACHINE_GROUP_ID", SqlDbType.VarChar, 20).Value = MACHINE_GROUP_ID;
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
