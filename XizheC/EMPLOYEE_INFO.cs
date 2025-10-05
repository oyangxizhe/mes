using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using XizheC;

namespace XizheC
{
    public class EMPLOYEE_INFO
    {

        private string _getsql;
        public string getsql
        {
            set { _getsql = value; }
            get { return _getsql; ; }

        }
        private string _PWD;
        public string PWD
        {
            set { _PWD = value; }
            get { return _PWD; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        
        string sql = @"

";


        string sql1 = @"INSERT INTO USER_INFO(

USID, 
UNAME, 
PWD, 
EMID, 
MAKERID,
DATE,
YEAR,
MONTH

) VALUES 

(
@USID, 
@UNAME, 
@PWD, 
@EMID, 
@MAKERID,
@DATE,
@YEAR,
@MONTH


)

";
        string sql2 = @"UPDATE USER_INFO SET 
USID=@USID,
UNAME=@UNAME,
PWD=@PWD,
EMID=@EMID,
MAKERID=@MAKERID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH
";
    basec bc = new basec();
        DataTable dt = new DataTable();
        DataTable dto = new DataTable();
        public EMPLOYEE_INFO()
        {
            IFExecution_SUCCESS = true;
            getsql = sql;
          

        }
      
        #region save IDVALUE
        public void save(string TABLENAME, string COLUMNID, string COLUMNNAME, string IDVALUE, string NAMEVALUE, string INFOID, string INFONAME)
        {
            
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.getOnlyString("SELECT " + COLUMNID + " FROM " + TABLENAME + " WHERE " + COLUMNID + "='" + IDVALUE + "'");
            string v2 = bc.getOnlyString("SELECT " + COLUMNID + " FROM " + TABLENAME + " WHERE " + COLUMNNAME + "='" + NAMEVALUE + "'");
            //string varMakerID;
            if (!bc.exists("SELECT " + COLUMNID + " FROM " + TABLENAME + " WHERE " + COLUMNID + "='" + IDVALUE + "'"))
            {
                if (bc.exists("SELECT " + COLUMNID + " FROM " + TABLENAME + " WHERE " + COLUMNNAME + "='" + NAMEVALUE + "'"))
                {

                    MessageBox.Show(INFONAME + "已经存在于系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    SQlcommandE(sql1, IDVALUE, NAMEVALUE);

                }

            }

            else if (v2 != NAMEVALUE)
            {
                if (bc.exists("SELECT " + COLUMNID + " FROM " + TABLENAME + " WHERE " + COLUMNNAME + "='" + NAMEVALUE + "'"))
                {

                    MessageBox.Show(INFONAME + "已经存在于系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    SQlcommandE(sql2 + " WHERE " + COLUMNID + "='" + IDVALUE + "'", IDVALUE, NAMEVALUE);

                }
            }

            else
            {

                SQlcommandE(sql2 + " WHERE " + COLUMNID + "='" + IDVALUE + "'", IDVALUE, NAMEVALUE);

            }
          
        }
        #endregion

        #region SQlcommandE
        protected void SQlcommandE(string sql, string IDVALUE, string NAMEVALUE)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            Byte[] B = bc.GetMD5(PWD);
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@USID", SqlDbType.VarChar, 20).Value = IDVALUE;
            sqlcom.Parameters.Add("@UNAME", SqlDbType.VarChar, 20).Value = NAMEVALUE;
            sqlcom.Parameters.Add("@PWD", SqlDbType.Binary, 50).Value = B;
            sqlcom.Parameters.Add("@EMID", SqlDbType.VarChar, 20).Value = "";
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = "";
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
       

        
      
    }
}
