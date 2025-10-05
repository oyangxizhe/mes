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
    public class CBAD_PHENOMENON_BECAUSE:IGETID 
    {
        basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
    
   
        private string _BBID;
        public string BBID
        {
            set { _BBID = value; }
            get { return _BBID; }

        }
        private string _BAD_PHENOMENON_BECAUSE_ID;
        public string BAD_PHENOMENON_BECAUSE_ID
        {
            set { _BAD_PHENOMENON_BECAUSE_ID = value; }
            get { return _BAD_PHENOMENON_BECAUSE_ID; }

        }
        private string _BAD_PHENOMENON_BECAUSE;
        public string BAD_PHENOMENON_BECAUSE
        {
            set { _BAD_PHENOMENON_BECAUSE = value; }
            get { return _BAD_PHENOMENON_BECAUSE; }

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
A.BAD_PHENOMENON_BECAUSE_ID AS 不良原因代码,
A.BAD_PHENOMENON_BECAUSE AS 不良原因名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM BAD_PHENOMENON_BECAUSE A 

";


        string setsqlo = @"



";

        string setsqlt = @"

INSERT INTO BAD_PHENOMENON_BECAUSE
(
BBID,
BAD_PHENOMENON_BECAUSE_ID,
BAD_PHENOMENON_BECAUSE,
DATE,
MAKERID,
YEAR,
MONTH
)
VALUES
(
@BBID,
@BAD_PHENOMENON_BECAUSE_ID,
@BAD_PHENOMENON_BECAUSE,
@DATE,
@MAKERID,
@YEAR,
@MONTH
)
";
        string setsqlth = @"
UPDATE BAD_PHENOMENON_BECAUSE SET 
BAD_PHENOMENON_BECAUSE_ID=@BAD_PHENOMENON_BECAUSE_ID,
BAD_PHENOMENON_BECAUSE=@BAD_PHENOMENON_BECAUSE,
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
      
        public CBAD_PHENOMENON_BECAUSE()
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
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM BAD_PHENOMENON_BECAUSE", "BBID", "BB");
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
            string GET_BAD_PHENOMENON_BECAUSE = bc.getOnlyString("SELECT BAD_PHENOMENON_BECAUSE FROM BAD_PHENOMENON_BECAUSE WHERE  BBID='" + BBID + "'");

            string GET_BAD_PHENOMENON_BECAUSE_ID = bc.getOnlyString("SELECT BAD_PHENOMENON_BECAUSE_ID FROM BAD_PHENOMENON_BECAUSE WHERE BBID='" + BBID + "'");

            if (!bc.exists("SELECT BBID FROM BAD_PHENOMENON_BECAUSE WHERE BBID='" + BBID + "'"))
            {
                if (BAD_PHENOMENON_BECAUSE_ID != "" && bc.exists("SELECT * FROM BAD_PHENOMENON_BECAUSE where BAD_PHENOMENON_BECAUSE_ID='" + BAD_PHENOMENON_BECAUSE_ID + "'"))
                {

                    ErrowInfo = "该不良原因代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else if (bc.exists("SELECT * FROM BAD_PHENOMENON_BECAUSE WHERE BAD_PHENOMENON_BECAUSE='" + BAD_PHENOMENON_BECAUSE + "'"))
                {

                    ErrowInfo = "该不良原因名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlt);
                    IFExecution_SUCCESS = true;

                }
            }
            else if (BAD_PHENOMENON_BECAUSE_ID != "" && GET_BAD_PHENOMENON_BECAUSE_ID != BAD_PHENOMENON_BECAUSE_ID)
            {


                if (bc.exists("SELECT * FROM BAD_PHENOMENON_BECAUSE where BAD_PHENOMENON_BECAUSE_ID='" + BAD_PHENOMENON_BECAUSE_ID + "'"))
                {

                    ErrowInfo = "该不良原因代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else
                {
                   
                    SQlcommandE_MST(sqlth + " WHERE BBID='" + BBID + "'");
                    IFExecution_SUCCESS = true;
                }


            }
            else if (GET_BAD_PHENOMENON_BECAUSE != BAD_PHENOMENON_BECAUSE)
            {
                if (BAD_PHENOMENON_BECAUSE != "" && bc.exists("SELECT * FROM BAD_PHENOMENON_BECAUSE WHERE BAD_PHENOMENON_BECAUSE='" + BAD_PHENOMENON_BECAUSE + "'"))
                {

                    ErrowInfo = "该不良原因名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlth + " WHERE BBID='" + BBID + "'");

                    IFExecution_SUCCESS = true;
                }

            }
            else
            {
              
                SQlcommandE_MST(sqlth + " WHERE BBID='" + BBID + "'");

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
            sqlcom.Parameters.Add("@BBID", SqlDbType.VarChar, 20).Value = BBID;
            sqlcom.Parameters.Add("@BAD_PHENOMENON_BECAUSE", SqlDbType.VarChar, 20).Value = BAD_PHENOMENON_BECAUSE;
            sqlcom.Parameters.Add("@BAD_PHENOMENON_BECAUSE_ID", SqlDbType.VarChar, 20).Value = BAD_PHENOMENON_BECAUSE_ID;
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
