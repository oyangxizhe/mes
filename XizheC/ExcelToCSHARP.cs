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
    public class ExcelToCSHARP
    {

        private string _getsql;
        public string getsql
        {
            set { _getsql = value; }
            get { return _getsql; ; }

        }
        private string _COURSE_TYPE;
        public string COURSE_TYPE
        {
            set { _COURSE_TYPE = value; }
            get { return _COURSE_TYPE; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _ACID;
        public string ACID
        {
            set { _ACID = value; }
            get { return _ACID; }
        }
        private string _ACCODE;
        public string ACCODE
        {
            set { _ACCODE = value; }
            get { return _ACCODE; }


        }
        private string _EMID;
        public  string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private bool _IfFirstDetailCourse;
        public bool IfFirstDetailCourse
        {
            set { _IfFirstDetailCourse = value; }
            get { return _IfFirstDetailCourse; }
        }
        private bool _IFCONSULENZA;
        public bool IFCONSULENZA
        {
            set { _IFCONSULENZA = value; }
            get { return _IFCONSULENZA; }
        }
        private string _hint;
        public string hint
        {
            set { _hint = value; }
            get { return _hint; }
        }
        private string _ADD_OR_UPDATE;
        public string ADD_OR_UPDATE
        {
            set { _ADD_OR_UPDATE = value; }
            get { return _ADD_OR_UPDATE; }
        }
  
        string sql = @"
SELECT A.ACID AS ACID,
A.ACCODE AS ACCODE,
A.ACNAME AS ACNAME,
A.COURSE_TYPE AS COURSE_TYPE,
A.BALANCE_DIRECTION AS BALANCE_DIRECTION ,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID ) AS MAKER,
A.DATE AS  DATE,
A.PARENT_NODEID AS PARENT_NODEID,
A.CYID AS CYID,
A.COURSE_NATURE AS COURSE_NATURE
FROM Accountant_Course A
";
        string sql1 = @"INSERT INTO Accountant_Course(
ACID,
ACCODE,
ACNAME,
MAKERID,
DATE,
YEAR,
MONTH,
COURSE_TYPE,
BALANCE_DIRECTION,
PARENT_NODEID,
CYID,
COURSE_NATURE
) 
VALUES 
(
@ACID,
@ACCODE,
@ACNAME,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@COURSE_TYPE,
@BALANCE_DIRECTION,
@PARENT_NODEID,
@CYID,
@COURSE_NATURE
)

";
        string sql2 = @"UPDATE Accountant_Course SET 
ACID=@ACID,
ACCODE=@ACCODE,
ACNAME=@ACNAME,
MAKERID=@MAKERID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
COURSE_TYPE=@COURSE_TYPE,
BALANCE_DIRECTION=@BALANCE_DIRECTION,
PARENT_NODEID=@PARENT_NODEID,
CYID=@CYID,
COURSE_NATURE=@COURSE_NATURE
";
        basec bc = new basec();
        DataTable dt = new DataTable();
        DataTable dto = new DataTable();
        public ExcelToCSHARP()
        {
            IFExecution_SUCCESS = true;
            getsql = sql;
          

        }

        #region SQlcommandE
        protected void SQlcommandE(string sql, string v1, string v2, string v3, string v4, string v5,string v6,string v7,string v8)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            //string varMakerID = bc.getOnlyString("SELECT EMID FROM USERINFO WHERE USID='" + n2 + "'");
            string varMakerID = EMID;
            SqlConnection sqlcon = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@ACID", SqlDbType.VarChar, 20).Value = v1;
            if (v2 == "")
            {
                sqlcom.Parameters.Add("@ACCODE", SqlDbType.VarChar, 20).Value = v1;
            }
            else
            {
                sqlcom.Parameters.Add("@ACCODE", SqlDbType.VarChar, 20).Value = v2;
            }
            sqlcom.Parameters.Add("@ACNAME", SqlDbType.VarChar, 20).Value = v3;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@COURSE_TYPE", SqlDbType.VarChar, 20).Value = v4;
            sqlcom.Parameters.Add("@BALANCE_DIRECTION", SqlDbType.VarChar, 20).Value = v5;
            if (!string.IsNullOrEmpty (v6))
            {
                sqlcom.Parameters.Add("@PARENT_NODEID", SqlDbType.VarChar, 20).Value = v6;
            }
            else
            {
                sqlcom.Parameters.Add("@PARENT_NODEID", SqlDbType.VarChar, 20).Value = DBNull.Value;
            }
            sqlcom.Parameters.Add("@CYID", SqlDbType.VarChar, 20).Value = bc.getOnlyString("SELECT CYID FROM CURRENCY_MST WHERE CYCODE='"+v7+"'");
            sqlcom.Parameters.Add("@COURSE_NATURE", SqlDbType.VarChar, 20).Value = v8;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion

    
        private bool JuageACCODEFormat(int i,DataTable  dt)
        {
            bool b = false;
            DataTable dtt = bc.getdt("SELECT * FROM ACCOUNTANT_COURSE");
                if (JuageACCODEFormatt(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(),dt.Rows[i][4].ToString(),i))
                {
                  
                    b = true;
                    //break;
                }
                for (int j = 0; j < dtt.Rows.Count; j++)
                {

                    if (dt.Rows[i][0].ToString() == dtt.Rows[j]["ACCODE"].ToString())
                    {

                        MessageBox.Show("科目代码：" + dt.Rows[i][0].ToString() + " 已经存在系统中！");
                        b = true;
                        break;

                    }
                    else if (dt.Rows[i][1].ToString() == dtt.Rows[j]["ACNAME"].ToString())
                    {

                        MessageBox.Show("科目名称：" + dt.Rows[i][1].ToString() + " 已经存在系统中！");
                        b = true;
                        break;

                    }
                }
            
            return b;
        }
        #region JuageACCODEFormat()
        public bool JuageACCODEFormatt(string ACCODE, string ACNAME, string COURSE_TYPE, string BALANCE_DIRECTION,string CYCODE,int i)
        {
            List<string> list = this.getCOURSE_TYPE_INFO();
            List<string> list1 = this.getBALANCE_DIRECTION_INFO();
            int n = ACCODE.Length;
            bool b = false;
          
            if (ACCODE == "")
            {

                b = true;
                MessageBox.Show("第" + i + "行" + "科目代码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ACNAME == "")
            {
                b = true;
                MessageBox.Show("第" + i + "行" + "科目名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (COURSE_TYPE == "")
            {
                b = true;
                MessageBox.Show("科目代码为" + ACCODE + "的科目类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BALANCE_DIRECTION == "")
            {
                b = true;
                MessageBox.Show("科目代码为" + ACCODE + "的借贷方向不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (bc.JuageIfAllowKEYIN(list, COURSE_TYPE, "科目类别不存在！"))
            {
                b = true;

            }
            else if (bc.JuageIfAllowKEYIN(list1, BALANCE_DIRECTION, "余额方向只能为：借,贷"))
            {
                b = true;

            }
            else if (bc.yesno(ACCODE) == 0)
            {
                b = true;
                MessageBox.Show("科目代码：" + ACCODE + "只能输入数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (n != 4 && n != 7 && n != 10 && n != 13 && n != 16 && n != 19)
            {
                b = true;
                MessageBox.Show("科目代码格式不正确，需为4-3-3-3-3-3！" + Convert.ToString(n), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (checkLastACCODEIfNoExists("ACCOUNTANT_COURSE", "ACCODE", ACCODE, "") == 0)
            {
                b = true;
            }

            else if (CYCODE =="")
            {
                b = true;
                MessageBox.Show("第" + i + "行" + "币别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (!bc.exists("SELECT * FROM CURRENCY_MST WHERE CYCODE='" + CYCODE + "'"))
            {
                b = true;
                MessageBox.Show("第" + i + "行" + "币别不存在于系统中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return b;
        }
        #endregion

        #region JuageACCODEFormat()
        public bool JuageACCODEFormatt(string ACCODE, string ACNAME, string COURSE_TYPE, string BALANCE_DIRECTION)
        {
            List<string> list = this.getCOURSE_TYPE_INFO();
            List<string> list1 = this.getBALANCE_DIRECTION_INFO();
            int n = ACCODE.Length;
            bool b = false;
            if (ACCODE == "")
            {

                b = true;
                MessageBox.Show("科目代码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ACNAME == "")
            {
                b = true;
                MessageBox.Show("科目名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (COURSE_TYPE == "")
            {
                b = true;
                MessageBox.Show("科目类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BALANCE_DIRECTION == "")
            {
                b = true;
                MessageBox.Show("借贷方向不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (bc.JuageIfAllowKEYIN(list, COURSE_TYPE, "科目类别不存在！"))
            {
                b = true;

            }
            else if (bc.JuageIfAllowKEYIN(list1, BALANCE_DIRECTION, "余额方向只能为：借,贷"))
            {
                b = true;

            }
            else if (bc.yesno(ACCODE) == 0)
            {
                b = true;
                MessageBox.Show("科目代码：" + ACCODE + "只能输入数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (n != 4 && n != 7 && n != 10 && n != 13 && n != 16 && n != 19)
            {
                b = true;
                MessageBox.Show("科目代码格式不正确，需为4-3-3-3-3-3！" + Convert.ToString(n), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (checkLastACCODEIfNoExists("ACCOUNTANT_COURSE", "ACCODE", ACCODE, "") == 0)
            {
                b = true;
            }
            return b;
        }
        #endregion
        #region importExcelToDataSet
        public static DataSet importExcelToDataSet(string FilePath, string tablename)
        {
            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + FilePath + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1'";
            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [" + tablename + "] ", strConn);
            DataSet myDataSet = new DataSet();
            try
            {
                myCommand.Fill(myDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error," + ex.Message);
            }
            return myDataSet;
        }
        #endregion
        #region GetExcelFirstTableName
        public static string GetExcelFirstTableName(string excelFileName)
        {
            string tableName = null;
            if (File.Exists(excelFileName))
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet." +
                  "OLEDB.4.0;Extended Properties=\"Excel 8.0\";Data Source=" + excelFileName))
                {
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    tableName = dt.Rows[0][2].ToString().Trim();

                }
            }
            return tableName;
        }
        #endregion

        
 

        #region save
        public void save(string ACID, string ACCODE, string ACNAME, string COURSE_TYPE, string BALANCE_DIRECTION,string CYCODE,string COURSE_NATURE)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.getOnlyString("SELECT ACCODE FROM Accountant_Course WHERE  ACID='" + ACID + "'");
            string v2 = bc.getOnlyString("SELECT ACNAME FROM Accountant_Course WHERE  ACID='" + ACID + "'");
            string v3 = "NULL";
            //string varMakerID;
            if (!bc.exists("SELECT ACID FROM Accountant_Course WHERE ACID='" + ACID + "'"))
            {
                if (bc.exists("SELECT * FROM Accountant_Course WHERE ACCODE='" + ACCODE + "'"))
                {
                    IFExecution_SUCCESS = false;
                   
                    hint = "科目代码已经存在于系统！";

                }
                else if (bc.exists("SELECT * FROM Accountant_Course WHERE  ACNAME='" + ACNAME + "'"))
                {
                    IFExecution_SUCCESS = false;
                    hint = "科目名称已经存在于系统！";

                }
                else
                {
                    IFExecution_SUCCESS = true;

                    SQlcommandE(sql1, ACID, ACCODE, ACNAME, COURSE_TYPE, BALANCE_DIRECTION, v3, CYCODE,COURSE_NATURE );
                    ADD_OR_UPDATE = "ADD";
                }

            }
        
            else if (v1 != ACCODE && v2 == ACNAME)
            {
                if (bc.exists("SELECT * FROM Accountant_Course WHERE ACCODE='" + ACCODE + "'"))
                {
                    IFExecution_SUCCESS = false;
                    hint = "科目代码已经存在于系统！";

                }
                else
                {
                    IFExecution_SUCCESS = true;
                    SQlcommandE(sql2 + " WHERE ACID='" + ACID + "'", ACID, ACCODE, ACNAME, COURSE_TYPE, BALANCE_DIRECTION, v3, CYCODE, COURSE_NATURE);
                    ADD_OR_UPDATE = "UPDATE";

                }
            }
            else if (v1 == ACCODE && v2 != ACNAME)
            {
                if (bc.exists("SELECT * FROM Accountant_Course WHERE ACNAME='" + ACNAME + "'"))
                {
                    IFExecution_SUCCESS = false;
                    hint = "科目名称已经存在于系统！";

                }
                else
                {
                    IFExecution_SUCCESS = true;
                    SQlcommandE(sql2 + " WHERE ACID='" + ACID + "'", ACID, ACCODE, ACNAME, COURSE_TYPE, BALANCE_DIRECTION, v3, CYCODE, COURSE_NATURE);
                    ADD_OR_UPDATE = "UPDATE";

                }
            }
            else if (v1 != ACCODE && v2 != ACNAME)
            {
                if (bc.exists("SELECT * FROM Accountant_Course WHERE ACCODE='" + ACCODE + "'"))
                {
                    IFExecution_SUCCESS = false;
                    hint = "科目代码已经存在于系统！";

                }
                else if (bc.exists("SELECT * FROM Accountant_Course WHERE  ACNAME='" + ACNAME + "'"))
                {
                    IFExecution_SUCCESS = false;
                    hint = "科目名称已经存在于系统！";

                }
                else
                {
                    IFExecution_SUCCESS = true;
                    SQlcommandE(sql2 + " WHERE ACID='" + ACID + "'", ACID, ACCODE, ACNAME, COURSE_TYPE, BALANCE_DIRECTION, v3, CYCODE, COURSE_NATURE);
                    ADD_OR_UPDATE = "UPDATE";

                }
            }
            else
            {
                IFExecution_SUCCESS = true;
                SQlcommandE(sql2 + " WHERE ACID='" + ACID + "'", ACID, ACCODE, ACNAME, COURSE_TYPE, BALANCE_DIRECTION, v3, CYCODE, COURSE_NATURE);
                ADD_OR_UPDATE = "UPDATE";


            }
        }
        #endregion
        #region GetCOURSE_TypeData
        public DataTable GetCOURSE_TypeData(int k)
        {



           
            try
            {
                dt = bc.getdt(sql + " WHERE SUBSTRING(ACCODE,1,1)='" + Convert.ToString(k) + "' ORDER BY ACCODE ASC");

            }
            catch (Exception)
            {

            }
            return dt;
        }
        #endregion
        #region GetCOURSE_LoadData
        public DataTable GetCOURSE_LoadData()
        {
            DataTable dto = new DataTable();
            dt = bc.getdt(sql + " ORDER BY ACCODE ASC");
            if (dt.Rows.Count > 0)
            {
                dto = dt;
            }
            return dto;
        }
        #endregion
        #region Search()
        public DataTable Search(string ACCODE, string ACNAME)
        {

            string sql1 = @" where A.ACCODE like '%" + ACCODE + "%' AND A.ACNAME LIKE '%" + ACNAME + "%' ORDER BY ACCODE ASC";
            dt = basec.getdts(sql + sql1);
            return dt;
        }
        #endregion
        #region GetLastCourseAnd_CurrentCourseName
        public string GetLastCourseAnd_CurrentCourseName(string ACCODE)
        {
            string v1, v2, v3, v4, v5;
            string GET_NEWACNAME = "";
            if (ACCODE.Length > 0)
            {


                if (ACCODE.Length == 7)
                {
                    v1 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 4) + "'");
                    GET_NEWACNAME = v1 + " - " + bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 7) + "'");

                }
                else if (ACCODE.Length == 10)
                {
                    v1 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 4) + "'");
                    v2 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 7) + "'");
                    GET_NEWACNAME = v1 + " - " + v2 + " - " +
                        bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 10) + "'");
                }
                else if (ACCODE.Length == 13)
                {
                    v1 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 4) + "'");
                    v2 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 7) + "'");
                    v3 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 10) + "'");
                    GET_NEWACNAME = v1 + " - " + v2 + " - " + v3 + " - " +
                        bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 13) + "'");
                }
                else if (ACCODE.Length == 16)
                {
                    v1 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 4) + "'");
                    v2 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 7) + "'");
                    v3 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 10) + "'");
                    v4 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 13) + "'");
                    GET_NEWACNAME = v1 + " - " + v2 + " - " + v3 + " - " + v4 + " - " +
                       bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 16) + "'");
                }
                else if (ACCODE.Length == 19)
                {
                    v1 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 4) + "'");
                    v2 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 7) + "'");
                    v3 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 10) + "'");
                    v4 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 13) + "'");
                    v5 = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 16) + "'");
                    GET_NEWACNAME = v1 + " - " + v2 + " - " + v3 + " - " + v4 + " - " + v5 + " - " +
                      bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE.Substring(0, 19) + "'");
                }
                else
                {

                    GET_NEWACNAME = bc.getOnlyString("SELECT ACNAME FROM ACCOUNTANT_COURSE WHERE ACCODE='" + ACCODE + "'");

                }

            }
            return GET_NEWACNAME;
        }
        #endregion
        #region dgvNoShowCourseType
        public DataTable dgvNoShowCourseType(DataTable dt)
        {

            DataTable dt4 = new DataTable();
            dt4.Columns.Add("ACID", typeof(string));
            dt4.Columns.Add("ACCODE", typeof(string));
            dt4.Columns.Add("ACNAME", typeof(string));
            dt4.Columns.Add("MAKER", typeof(string));
            dt4.Columns.Add("DATE", typeof(string));
            dt4.Columns.Add("PARENT_NODEID", typeof(string));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow dr1 = dt4.NewRow();
                    dr1["ACID"] = dr["ACID"].ToString();
                    dr1["ACCODE"] = dr["ACCODE"].ToString();
                    dr1["ACNAME"] = dr["ACNAME"].ToString();
                    dr1["MAKER"] = dr["MAKER"].ToString();
                    dr1["DATE"] = dr["DATE"].ToString();
                    dr1["PARENT_NODEID"] = dr["PARENT_NODEID"].ToString();
                    dt4.Rows.Add(dr1);

                }
            }
            return dt4;
        }
        #endregion
        public List<string> getCOURSE_TYPE_INFO()
        {
            List<string> list1 = new List<string>();
            string[] xw = new string[] { 
"流动资产",
"长期资产",
"流动负债",
"长期负债",
"共同",
"所有者权益",
"成本",
"营业收入",
"其它收益",
"其它损失",
"营业成本及税金",
"营业税金及附加",
"期间费用",
"所得税",
"以前年度损益调整"


            };
            for (int i = 0; i < xw.Length; i++)
            {

                list1.Add(xw[i]);
            }
            return list1;
        }
        #region getBALANCE_DIRECTION_INFO
        public List<string> getBALANCE_DIRECTION_INFO()
        {
            List<string> list1 = new List<string>();
            string[] xw = new string[] { "借", "贷" };
            for (int i = 0; i < xw.Length; i++)
            {

                list1.Add(xw[i]);
            }
            return list1;
        }
        #endregion
        public bool JuageFirstDetailCourse(string ACCODE)
        {
            bool ju = false;
            dt = bc.getdt("SELECT * FROM ACCOUNTANT_COURSE WHERE ACCODE LIKE '%" + ACCODE + "%'");
            if (dt.Rows.Count == 1)
            {
                ju = true;
                IfFirstDetailCourse = true;
            }
            return ju;
        }
        public bool JuageIf_CONSULENZA(string ACID)
        {
            bool ju = false;
            dt = bc.getdt("SELECT * FROM VOUCHER_DET WHERE ACID LIKE '%" + ACID + "%'");
            if (dt.Rows.Count > 0)
            {
                ju = true;
                IFCONSULENZA = true;

            }
            return ju;
        }
        #region CheckKeyInValueIfExistsDetailCourse
        public int CheckKeyInValueIfExistsDetailCourse(string TABLENAME, string COLUMN_NAME, string COLUMN_VALUE, string REMARK,string REMARKT)
        {
            int ju = 0;
            int len = COLUMN_VALUE.Length;
            int len1 = len + 3;
            DataTable dt = bc.getdt("SELECT *  FROM " + TABLENAME + " WHERE SUBSTRING(" + COLUMN_NAME + ",1," + len + 
                ")='"+COLUMN_VALUE+"'"+" AND LEN("+COLUMN_NAME+")="+len1);
           
            if (dt.Rows.Count == 1)
            {
                ju = 1;
                MessageBox.Show(REMARK + " " + COLUMN_VALUE + REMARKT , "提示", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else if (dt.Rows.Count > 1)
            {
                ju = 2;
                MessageBox.Show(REMARK + " " + COLUMN_VALUE + REMARKT, "提示", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            }
 
            return ju;
        }
        #endregion
        #region JuageOnlayOneDetailCourse
        public int JuageOnlayOneDetailCourse(string TABLENAME, string COLUMN_NAME, string COLUMN_VALUE, string REMARK)
        {
            int ju = 0;
            int len = COLUMN_VALUE.Length;
            int len2 = len - 3;
            hint = null;
            DataTable dt1 = bc.getdt("SELECT *  FROM " + TABLENAME + " WHERE SUBSTRING(" + COLUMN_NAME + " ,1," + len2 + ")" +
                "= SUBSTRING('" + COLUMN_VALUE + "' ,1," + len2 + ")" + " AND LEN(" + COLUMN_NAME + ")=" + len);
             if (dt1.Rows.Count == 1) /*no exists detail course and same grade only one course*/
            {
                ju = 3;
           
                if (JuageIf_CONSULENZA(dt1.Rows[0]["ACID"].ToString()))
                {

                    ACID = bc.getOnlyStringO("ACCOUNTANT_COURSE", "ACID", "ACCODE", COLUMN_VALUE.Substring(0, len2));
                    ACCODE= bc.getOnlyStringO("ACCOUNTANT_COURSE", "ACCODE", "ACCODE", COLUMN_VALUE.Substring(0, len2));
                    hint = REMARK + " " + COLUMN_VALUE +
                        " 为明细科目，且同级别下只有该科目一个，如果删除该科目该科目本年度发生的金额将结转到其上级科目" + ACCODE + "上！是否要继续？";
                }
              
            }
            else if (dt1.Rows.Count > 1)
            {
                ju = 4;
                /*MessageBox.Show(REMARK + " " + COLUMN_VALUE + "为明细科目，且同级别下有多个同级科目！",
                    "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
          
            return ju;
        }
        #endregion
        #region  checkLastACCODEIfNoExists
        public int checkLastACCODEIfNoExists(string TABLENAME, string COLUMN_NAME, string COLUMN_VALUE, string REMARK)
        {
            int ju = 0;
            int len = COLUMN_VALUE.Length;
            int len1 = len -3;
            if (len > 4)
            {
                DataTable dt = bc.getdt("SELECT *  FROM " + TABLENAME + " WHERE " + COLUMN_NAME + " =SUBSTRING('" + COLUMN_VALUE + "',1," + len1 + ")");
                if (dt.Rows.Count == 1)
                {
                    ju = 1;
                    ACCODE = dt.Rows[0]["ACCODE"].ToString();
                    ACID = dt.Rows[0]["ACID"].ToString();
                    JuageFirstDetailCourse(ACCODE);
                    JuageIf_CONSULENZA(ACID);
                }
                else
                {
                    MessageBox.Show("科目代码" + COLUMN_VALUE + "不存在上级科目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                ju = 1;

            }
            return ju;
        }
        #endregion

        #region CHECK_DATATABLE_IF_EXISTS_DETAIL_COURSE()
        public bool CHECK_DATATABLE_IF_EXISTS_DETAIL_COURSE(DataTable dt)
        {
            bool b = false;

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (juage(k,dt))
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        #endregion
        #region juage()
        private bool juage(int k,DataTable dt)
        {
            bool b = false;
            string v1 = dt.Rows[k]["科目代码"].ToString();
            string v2 = dt.Rows[k]["累计借方"].ToString();
            string v3 = dt.Rows[k]["累计贷方"].ToString();
            string v4 = dt.Rows[k]["期初借方"].ToString();
            string v5 = dt.Rows[k]["期初贷方"].ToString();

            if ((v2 != "" || v3 != "" || v4 != "" || v5 != "") &&
                CheckKeyInValueIfExistsDetailCourse("ACCOUNTANT_COURSE", "ACCODE", v1, "科目代码", "存在明细科目，需使用明细科目记帐！") == 1)
            {
                b = true;
            }
            return b;
        }
        #endregion
    }
}
