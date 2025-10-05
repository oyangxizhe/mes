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
    public class CUNIT_LOT:IGETID 
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
        public string _ULID;
        public string ULID
        {
            set { _ULID = value; }
            get { return _ULID; }

        }
        public string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        public string _ACTIVE;
        public string ACTIVE
        {
            set { _ACTIVE = value; }
            get { return _ACTIVE; }

        }
        private string _UNIT_LOT;
        public string UNIT_LOT
        {
            set { _UNIT_LOT = value; }
            get { return _UNIT_LOT; }

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
A.ULID AS 编号,
A.WAREID AS 物料编号,
B.CO_WAREID AS 料号,
B.WNAME AS 品名,
A.UNIT_LOT AS 批号量,
CASE WHEN A.ACTIVE='Y' THEN '已生效'
ELSE '未生效'
END 
AS 生效否,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM  UNIT_LOT A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID 

";
      
        string setsqlo = @"

";
      string setsqlt = @"
INSERT INTO UNIT_LOT(
ULID,
WAREID,
UNIT_LOT,
ACTIVE,
DATE,
MAKERID,
YEAR,
MONTH
)
VALUES 
(
@ULID,
@WAREID,
@UNIT_LOT,
@ACTIVE,
@DATE,
@MAKERID,
@YEAR,
@MONTH
)
";
      string setsqlth = @"
UPDATE 
UNIT_LOT 
SET 
WAREID=@WAREID,
UNIT_LOT=@UNIT_LOT,
ACTIVE=@ACTIVE,
DATE=@DATE,
MAKERID=@MAKERID,
YEAR=@YEAR,
MONTH=@MONTH
"; 
        #endregion

         public CUNIT_LOT()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
         
            sql = setsql; /*UNIT_LOT*/
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth; 
        }

         public string GETID()
         {
             string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM UNIT_LOT", "ULID", "UL");
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
                  string GET_UNIT_LOT = bc.getOnlyString("SELECT UNIT_LOT FROM UNIT_LOT WHERE ULID='" + ULID + "'");

                  if (!bc.exists("SELECT ULID FROM UNIT_LOT WHERE ULID='" + ULID + "'"))
                  {
                      if (ACTIVE == "Y")
                      {
                          if (bc.exists("SELECT * FROM UNIT_LOT where WAREID='" + WAREID + "'"))
                          {

                              bc.getcom("UPDATE UNIT_LOT SET ACTIVE='N' WHERE WAREID='"+WAREID +"'");
                          }
                      }

                      SQlcommandE_MST(sqlt);
                      IFExecution_SUCCESS = true;
                
                  }
           
                  else
                  {
                      if (ACTIVE == "Y")
                      {
                          if (bc.exists("SELECT * FROM UNIT_LOT where WAREID='" + WAREID + "'"))
                          {

                              bc.getcom("UPDATE UNIT_LOT SET ACTIVE='N' WHERE WAREID='" + WAREID + "'");
                          }
                      }
                      SQlcommandE_MST(sqlth + " WHERE ULID='" + ULID + "'");
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
                  sqlcom.Parameters.Add("@ULID", SqlDbType.VarChar, 20).Value = ULID;
                  sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
                  sqlcom.Parameters.Add("@UNIT_LOT", SqlDbType.VarChar, 20).Value = UNIT_LOT;
                  sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = ACTIVE;
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
