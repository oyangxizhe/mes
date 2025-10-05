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
    public class CBAD_PHENOMENON:IGETID 
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
        private string _BAD_PHENOMENON_ID;
        public string BAD_PHENOMENON_ID
        {
            set { _BAD_PHENOMENON_ID = value; }
            get { return _BAD_PHENOMENON_ID; }

        }
        private string _BAD_PHENOMENON;
        public string BAD_PHENOMENON
        {
            set { _BAD_PHENOMENON = value; }
            get { return _BAD_PHENOMENON; }

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
A.BAD_PHENOMENON_ID AS 不良现象代码,
A.BAD_PHENOMENON AS 不良现象名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=A.MAKERID) AS 制单人,
A.DATE AS 制单日期
FROM BAD_PHENOMENON A 

";


        string setsqlo = @"



";

        string setsqlt = @"

INSERT INTO BAD_PHENOMENON
(
BPID,
BAD_PHENOMENON_ID,
BAD_PHENOMENON,
DATE,
MAKERID,
YEAR,
MONTH
)
VALUES
(
@BPID,
@BAD_PHENOMENON_ID,
@BAD_PHENOMENON,
@DATE,
@MAKERID,
@YEAR,
@MONTH
)
";
        string setsqlth = @"
UPDATE BAD_PHENOMENON SET 
BAD_PHENOMENON_ID=@BAD_PHENOMENON_ID,
BAD_PHENOMENON=@BAD_PHENOMENON,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH
";

        string setsqlf = @"
SELECT
A.BATCHID AS 批号,
B.WOID 工单号,
D.CO_WAREID 料号,
D.WName 品名,
E.STEP_ID 站别代码,
E.STEP 站别名称,
G.MACHINE_GROUP 机台群组代码,
G.MACHINE_GROUP_ID 机台群组名称,
H.MACHINE_ID 机台代码,
H.MACHINE 机台名称,
I.BAD_PHENOMENON_GROUP_ID 不良现象群组代码,
I.BAD_PHENOMENON_GROUP 不良现象群组名称,
J.BAD_PHENOMENON_ID 不良现象代码,
J.BAD_PHENOMENON 不良现象名称,
K.BAD_PHENOMENON_BECAUSE_ID 不良原因代码,
K.BAD_PHENOMENON_BECAUSE 不良原因名称,
A.SCRAP_COUNT 报废数量,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MAKERID) 制单人,
B.DATE 制单日期
FROM POSTING_DET A
LEFT JOIN POSTING_MST B ON A.PSID=B.PSID
LEFT JOIN WORKORDER_MST C ON B.WOID=C.WOID
LEFT JOIN WareInfo D ON C.WAREID=D.WareID
LEFT JOIN STEP E ON B.STID=E.STID
LEFT JOIN MACHINE_GROUP G ON B.MRID=G.MRID
LEFT JOIN MACHINE H ON B.MAID=H.MAID
LEFT JOIN BAD_PHENOMENON_GROUP I ON A.BGID=I.BGID
LEFT JOIN BAD_PHENOMENON J ON A.BPID=J.BPID
LEFT JOIN BAD_PHENOMENON_BECAUSE K ON A.BBID=K.BBID

";
        string setsqlfi = @"
SELECT
DISTINCT(B.WOID) 工单号,
D.CO_WAREID 料号,
D.WName 品名
FROM POSTING_DET A
LEFT JOIN POSTING_MST B ON A.PSID=B.PSID
LEFT JOIN WORKORDER_MST C ON B.WOID=C.WOID
LEFT JOIN WareInfo D ON C.WAREID=D.WareID
";
        string setsqlsi = @"


";
        #endregion
      
        public CBAD_PHENOMENON()
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
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM BAD_PHENOMENON", "BPID", "BP");
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
            string GET_BAD_PHENOMENON = bc.getOnlyString("SELECT BAD_PHENOMENON FROM BAD_PHENOMENON WHERE  BPID='" + BPID + "'");

            string GET_BAD_PHENOMENON_ID = bc.getOnlyString("SELECT BAD_PHENOMENON_ID FROM BAD_PHENOMENON WHERE BPID='" + BPID + "'");

            if (!bc.exists("SELECT BPID FROM BAD_PHENOMENON WHERE BPID='" + BPID + "'"))
            {
                if (BAD_PHENOMENON_ID != "" && bc.exists("SELECT * FROM BAD_PHENOMENON where BAD_PHENOMENON_ID='" + BAD_PHENOMENON_ID + "'"))
                {

                    ErrowInfo = "该不良现象代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else if (bc.exists("SELECT * FROM BAD_PHENOMENON WHERE BAD_PHENOMENON='" + BAD_PHENOMENON + "'"))
                {

                    ErrowInfo = "该不良现象名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlt);
                    IFExecution_SUCCESS = true;

                }
            }
            else if (BAD_PHENOMENON_ID != "" && GET_BAD_PHENOMENON_ID != BAD_PHENOMENON_ID)
            {


                if (bc.exists("SELECT * FROM BAD_PHENOMENON where BAD_PHENOMENON_ID='" + BAD_PHENOMENON_ID + "'"))
                {

                    ErrowInfo = "该不良现象代码已经存在了！";
                    IFExecution_SUCCESS = false;

                }
                else
                {
                   
                    SQlcommandE_MST(sqlth + " WHERE BPID='" + BPID + "'");
                    IFExecution_SUCCESS = true;
                }


            }
            else if (GET_BAD_PHENOMENON != BAD_PHENOMENON)
            {
                if (BAD_PHENOMENON != "" && bc.exists("SELECT * FROM BAD_PHENOMENON WHERE BAD_PHENOMENON='" + BAD_PHENOMENON + "'"))
                {

                    ErrowInfo = "该不良现象名称已经存在了！";
                    IFExecution_SUCCESS = false;
                }
                else
                {
                  
                    SQlcommandE_MST(sqlth + " WHERE BPID='" + BPID + "'");

                    IFExecution_SUCCESS = true;
                }

            }
            else
            {
              
                SQlcommandE_MST(sqlth + " WHERE BPID='" + BPID + "'");

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
            sqlcom.Parameters.Add("@BPID", SqlDbType.VarChar, 20).Value = BPID;
            sqlcom.Parameters.Add("@BAD_PHENOMENON", SqlDbType.VarChar, 20).Value = BAD_PHENOMENON;
            sqlcom.Parameters.Add("@BAD_PHENOMENON_ID", SqlDbType.VarChar, 20).Value = BAD_PHENOMENON_ID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
         
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        public DataTable emptydatatable_T()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("工单号", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("批号", typeof(string));
            dt.Columns.Add("站别代码", typeof(string));
            dt.Columns.Add("站别名称", typeof(string));
            dt.Columns.Add("机台群组代码", typeof(string));
            dt.Columns.Add("机台群组名称", typeof(string));
            dt.Columns.Add("机台代码", typeof(string));
            dt.Columns.Add("机台名称", typeof(string));
            dt.Columns.Add("不良现象群组代码", typeof(string));
            dt.Columns.Add("不良现象群组名称", typeof(string));
            dt.Columns.Add("不良现象代码", typeof(string));
            dt.Columns.Add("不良现象名称", typeof(string));
            dt.Columns.Add("不良原因代码", typeof(string));
            dt.Columns.Add("不良原因名称", typeof(string));
            dt.Columns.Add("报废数量", typeof(string));
            dt.Columns.Add("制单人", typeof(string));
            dt.Columns.Add("制单日期", typeof(string));
            return dt;
        }
        #region RETURN_HAVE_ID_DT
        public DataTable RETURN_HAVE_ID_DT(DataTable dtx)
        {

            DataTable dt = emptydatatable_T();
            int i = 1;
            foreach (DataRow dr1 in dtx.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["序号"] = i.ToString();
                dr["工单号"] = dr1["工单号"].ToString();
                dr["料号"] = dr1["料号"].ToString();
                dr["品名"] = dr1["品名"].ToString();
                dr["批号"] = dr1["批号"].ToString();
                dr["站别代码"] = dr1["站别代码"].ToString();
                dr["站别名称"] = dr1["站别名称"].ToString();
                dr["机台群组代码"] = dr1["机台群组代码"].ToString();
                dr["机台群组名称"] = dr1["机台群组名称"].ToString();
                dr["机台代码"] = dr1["机台代码"].ToString();
                dr["机台名称"] = dr1["机台名称"].ToString();
                dr["不良现象群组代码"] = dr1["不良现象群组代码"].ToString();
                dr["不良现象群组名称"] = dr1["不良现象群组名称"].ToString();
                dr["不良现象代码"] = dr1["不良现象代码"].ToString();
                dr["不良现象名称"] = dr1["不良现象名称"].ToString();
                dr["不良原因代码"] = dr1["不良原因代码"].ToString();
                dr["不良原因名称"] = dr1["不良原因名称"].ToString();
                dr["报废数量"] = dr1["报废数量"].ToString();
                dr["制单人"] = dr1["制单人"].ToString();
                dr["制单日期"] = dr1["制单日期"].ToString();
                dt.Rows.Add(dr);
                i = i + 1;
            }
            return dt;
        }
        #endregion
    }
}
