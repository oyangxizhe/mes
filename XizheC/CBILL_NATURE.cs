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
    public class CBILL_NATURE
    {
        basec bc = new basec();
    
        #region nature

        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _MAKERID;
        public string MAKERID
        {
            set { _MAKERID = value; }
            get { return _MAKERID; }

        }
        public string _BNID;
        public string BNID
        {
            set { _BNID = value; }
            get { return _BNID; }

        }

        private string _BILL_NATURE;
        public string BILL_NATURE
        {
            set { _BILL_NATURE = value; }
            get { return _BILL_NATURE; }

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
        private  bool _IFExecutionSUCCESS;
        public  bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
 
        #endregion
        #region setsql
        string setsql = @"

SELECT 
A.BNID AS ID,
A.BILL_NATURE AS 单据性质,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM  BILL_NATURE A

";
      
        string setsqlo = @"

";
      string setsqlt = @"
INSERT INTO BILL_NATURE(
BNID,
BILL_NATURE,
DATE,
MAKERID,
YEAR,
ACTIVE,
MONTH
)
VALUES 
(
@BNID,
@BILL_NATURE,
@DATE,
@MAKERID,
@YEAR,
@ACTIVE,
@MONTH
)
";
      string setsqlth = @"
UPDATE BILL_NATURE SET 
BILL_NATURE=@BILL_NATURE,
DATE=@DATE,
MAKERID=@MAKERID,
YEAR=@YEAR,
MONTH=@MONTH,
ACTIVE=@ACTIVE
"; 
        #endregion

         public CBILL_NATURE()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            //GETID =bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_SCRAP_MST", "WSID", "WS");
            sql = setsql; /*BILL_NATURE*/
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth; 
        }

         public string GETID()
         {
             string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM BILL_NATURE", "BNID", "BN");
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
                  string GET_BILL_NATURE = bc.getOnlyString("SELECT BILL_NATURE FROM BILL_NATURE WHERE BNID='" + BNID + "'");

                  if (!bc.exists("SELECT BNID FROM BILL_NATURE WHERE BNID='" + BNID + "'"))
                  {
                      if (bc.exists("SELECT * FROM BILL_NATURE where BILL_NATURE='" + BILL_NATURE + "'"))
                      {

                          ErrowInfo = "该单据性质已经存在了！";
                          IFExecution_SUCCESS = false;

                      }

                      else
                      {
                        
                          SQlcommandE_MST(sqlt);
                          IFExecution_SUCCESS = true;

                      }
                  }
                  else if (GET_BILL_NATURE != BILL_NATURE)
                  {

                      if (bc.exists("SELECT * FROM BILL_NATURE where BILL_NATURE='" + BILL_NATURE + "'"))
                      {
                          ErrowInfo = "该单据性质已经存在了！";
                          IFExecution_SUCCESS = false;
                      }
                      else
                      {
                          SQlcommandE_MST(sqlth + " WHERE BNID='" + BNID + "'");
                          IFExecution_SUCCESS = true;
                      }
                  }
                  else
                  {
                      SQlcommandE_MST(sqlth + " WHERE BNID='" + BNID + "'");
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
                  sqlcom.Parameters.Add("@BNID", SqlDbType.VarChar, 20).Value = BNID;
                  sqlcom.Parameters.Add("@BILL_NATURE", SqlDbType.VarChar, 20).Value = BILL_NATURE;
                  sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
                  sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = MAKERID;
                  sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
                  sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
                  sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
                  sqlcom.ExecuteNonQuery();
                  sqlcon.Close();
              }
              #endregion
    }
}
