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
    public class CFLOW_CHART
    {
        basec bc = new basec();
        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private string _TEL;
        public string TEL
        {
            set { _TEL = value; }
            get { return _TEL; }

        }
        private string _CURRENT_STID;
        public string CURRENT_STID
        {
            set { _CURRENT_STID = value; }
            get { return _CURRENT_STID; }

        }
        private string _LAST_STID;
        public string LAST_STID
        {
            set { _LAST_STID = value; }
            get { return _LAST_STID; }

        }
        private string _NEXT_STID;
        public string NEXT_STID
        {
            set { _NEXT_STID = value; }
            get { return _NEXT_STID; }

        }
        private string _RMKEY;
        public string RMKEY
        {
            set { _RMKEY = value; }
            get { return _RMKEY; }

        }

        private string _STID;
        public string STID
        {
            set { _STID = value; }
            get { return _STID; }

        }
        private string _PHONE;
        public string PHONE
        {
            set { _PHONE = value; }
            get { return _PHONE; }

        }
 
        private string _FLOW_CHART_EDITION;
        public string FLOW_CHART_EDITION
        {
            set { _FLOW_CHART_EDITION = value; }
            get { return _FLOW_CHART_EDITION; }

        }
       
        private string _FCID;
        public string FCID
        {
            set { _FCID = value; }
            get { return _FCID; }

        }
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _FLOW_CHART_ID;
        public string FLOW_CHART_ID
        {
            set { _FLOW_CHART_ID = value; }
            get { return _FLOW_CHART_ID; }

        }
        private string _FLOW_CHART;
        public string FLOW_CHART
        {
            set { _FLOW_CHART = value; }
            get { return _FLOW_CHART; }

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
        private string _POSTCODE;
        public string POSTCODE
        {
            set { _POSTCODE = value; }
            get { return _POSTCODE; }

        }
        private string _ADDRESS;
        public string ADDRESS
        {
            set { _ADDRESS = value; }
            get { return _ADDRESS; }

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
        private string _FCKEY;
        public string FCKEY
        {
            set { _FCKEY = value; }
            get { return _FCKEY; }

        }
        private  bool _IFExecutionSUCCESS;
        public  bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private string _PAYMENT;
        public string PAYMENT
        {
            set { _PAYMENT = value; }
            get { return _PAYMENT; }

        }

        private string _SN;
        public string SN
        {
            set { _SN = value; }
            get { return _SN; }

        }
        private string _ACTIVE;
        public string ACTIVE
        {
            set { _ACTIVE = value; }
            get { return _ACTIVE; }

        }
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }

        }
        private string _PROVINCE;
        public string PROVINCE
        {
            set { _PROVINCE = value; }
            get { return _PROVINCE; }

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
B.FCID AS 途程编号,
B.FLOW_CHART_ID AS 途程代码,
B.FLOW_CHART AS 途程名称,
B.FLOW_CHART_EDITION AS 版本号,
A.SN AS 项次,
C.STID AS 站别编号,
C.STEP_ID AS 站别代码,
C.STEP AS 站别名称,
CASE WHEN B.ACTIVE='Y' THEN '已生效'
ELSE '未生效'
END 
AS 生效否,
B.WAREID AS 物料编号,
D.CO_WAREID AS 料号,
D.WNAME AS 品名,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=B.MAKERID) AS 制单人,
B.DATE AS 制单日期,
A.REMARK AS 备注
FROM FLOW_CHART_DET A 
LEFT JOIN FLOW_CHART_MST B ON A.FCID=B.FCID
LEFT JOIN STEP C ON A.STID=C.STID
LEFT JOIN WAREINFO D ON B.WAREID=D.WAREID

";


        string setsqlo = @"
INSERT INTO FLOW_CHART_DET
(
FCKEY,
FCID,
SN,
STID,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
)
VALUES
(
@FCKEY,
@FCID,
@SN,
@STID,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY

)


";

        string setsqlt = @"

INSERT INTO FLOW_CHART_MST
(
FCID,
FLOW_CHART_ID,
FLOW_CHART,
WAREID,
FLOW_CHART_EDITION,
ACTIVE,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@FCID,
@FLOW_CHART_ID,
@FLOW_CHART,
@WAREID,
@FLOW_CHART_EDITION,
@ACTIVE,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlth = @"
UPDATE FLOW_CHART_MST SET 
FLOW_CHART_ID=@FLOW_CHART_ID,
FLOW_CHART=@FLOW_CHART,
WAREID=@WAREID,
FLOW_CHART_EDITION=@FLOW_CHART_EDITION,
ACTIVE=@ACTIVE,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY
";

        string setsqlf = @"

";
        string setsqlfi = @"

";
        string setsqlsi = @"


";
        #endregion
        public CFLOW_CHART()
        {
            string year, month, day;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            //GETID =bc.numYM(10, 4, "0001", "SELECT * FROM WORKORDER_PICKING_MST", "WPID", "WP");

            sql = setsql;
            sqlo = setsqlo;
            sqlt = setsqlt;
            sqlth = setsqlth;
            sqlf = setsqlf;
            sqlfi = setsqlfi;
            sqlsi = setsqlsi;
        }
        #region GetTableInfo
        public DataTable GetTableInfo()
        {
            dt = new DataTable();
            dt.Columns.Add("项次", typeof(string));
            dt.Columns.Add("站别代码", typeof(string));
            dt.Columns.Add("站别名称", typeof(string));
            return dt;
        }
 
        #endregion
        public string GETID()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.numYM(10, 4, "0001", "select * from FLOW_CHART_MST", "FCID", "FC");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
              
            }
            return GETID;
        }
        #region save
        public void save(DataTable dt)
        {

            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string GET_WAREID= bc.getOnlyString("SELECT WAREID FROM FLOW_CHART_MST WHERE  WAREID='" +WAREID  + "'");

            string GET_FLOW_CHART_EDITION = bc.getOnlyString("SELECT FLOW_CHART_EDITION  FROM FLOW_CHART_MST WHERE FCID='" + FCID + "'");
          
            if (!bc.exists("SELECT FCID FROM FLOW_CHART_DET WHERE FCID='" + FCID + "'"))
            {
                if (bc.exists("SELECT * FROM FLOW_CHART_MST where WAREID='" + WAREID  + "' AND FLOW_CHART_EDITION='"+FLOW_CHART_EDITION +"'"))
                {

                    ErrowInfo = string.Format("物料编号：{0}"+"+"+"版本号：{1}"+"已经存在系统", WAREID,FLOW_CHART_EDITION );
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    if (ACTIVE =="Y" && bc.exists("SELECT * FROM FLOW_CHART_MST where WAREID='" + WAREID + "'"))
                    {

                        bc.getcom("UPDATE FLOW_CHART_MST SET ACTIVE='N' WHERE WAREID='"+WAREID +"'");
                    }
                    ACTION_DET(dt);
                    SQlcommandE_MST(sqlt);
                    IFExecution_SUCCESS = true;
                }
            }
            else if (WAREID != GET_WAREID || FLOW_CHART_EDITION != GET_FLOW_CHART_EDITION)
            {
                if (bc.exists("SELECT * FROM FLOW_CHART_MST where WAREID='" + WAREID + "' AND FLOW_CHART_EDITION='" + FLOW_CHART_EDITION + "'"))
                {

                    ErrowInfo = string.Format("物料编号：{0}" + "+" + "版本号：{1}" + "已经存在系统", WAREID, FLOW_CHART_EDITION);
                    IFExecution_SUCCESS = false;
                }
                else
                {
                    if (ACTIVE == "Y" && bc.exists("SELECT * FROM FLOW_CHART_MST where WAREID='" + WAREID + "'"))
                    {
                        bc.getcom("UPDATE FLOW_CHART_MST SET ACTIVE='N' WHERE WAREID='" + WAREID + "'");
                    }
                    ACTION_DET(dt);
                    SQlcommandE_MST(sqlth + " WHERE FCID='" + FCID + "'");

                    IFExecution_SUCCESS = true;
                }
            }
            else
            {

                if (ACTIVE == "Y" && bc.exists("SELECT * FROM FLOW_CHART_MST where WAREID='" + WAREID + "'"))
                {

                    bc.getcom("UPDATE FLOW_CHART_MST SET ACTIVE='N' WHERE WAREID='" + WAREID + "'");

                }
                    ACTION_DET(dt);
                    SQlcommandE_MST(sqlth + " WHERE FCID='" + FCID + "'");
                    IFExecution_SUCCESS = true;
            }
        }
        #endregion
        #region SQlcommandE_DET
        protected void SQlcommandE_DET(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace ("-","/");
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@FCKEY", SqlDbType.VarChar, 20).Value = FCKEY;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@FCID", SqlDbType.VarChar, 20).Value = FCID;
            sqlcom.Parameters.Add("@STID", SqlDbType.VarChar, 20).Value = STID;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
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
            sqlcom.Parameters.Add("@FCID", SqlDbType.VarChar, 20).Value = FCID;
            sqlcom.Parameters.Add("@FLOW_CHART", SqlDbType.VarChar, 20).Value = FLOW_CHART;
            sqlcom.Parameters.Add("@FLOW_CHART_ID", SqlDbType.VarChar, 20).Value = FLOW_CHART_ID;
            sqlcom.Parameters.Add("@FLOW_CHART_EDITION", SqlDbType.VarChar, 20).Value = FLOW_CHART_EDITION;
            sqlcom.Parameters.Add("@ACTIVE", SqlDbType.VarChar, 20).Value = ACTIVE;
            sqlcom.Parameters.Add("@WAREID", SqlDbType.VarChar, 20).Value = WAREID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = EMID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        private void ACTION_DET(DataTable dt)
        {
           
            basec.getcoms("DELETE FLOW_CHART_DET WHERE FCID='" + FCID + "'");
            foreach (DataRow dr in dt.Rows)
            {
                FCKEY = bc.numYMD(20, 12, "000000000001", "SELECT * FROM FLOW_CHART_DET", "FCKEY", "FC");
                STID = bc.getOnlyString(string.Format("SELECT STID FROM STEP WHERE STEP_ID='{0}'", dr["站别代码"].ToString()));
                SN = dr["项次"].ToString();
                SQlcommandE_DET(sqlo);
            }
        }
        public void RETURN_LAST_AND_NEXT_STID(string STID, string FCID, string FLOW_CHART_EDITION)
        {
            dt = bc.GET_DT_TO_DV_TO_DT(bc.getdt(sql), "", string.Format("途程编号='{0}' AND 版本号='{1}'", FCID, FLOW_CHART_EDITION));
            DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", string.Format ("站别编号='{0}'",STID));
            if (dt.Rows.Count > 0)
            {
                if (dtx.Rows.Count > 0)
                {

                    int i = Convert.ToInt32(dtx.Rows[0]["项次"].ToString());
                    if (i < dt.Rows.Count)
                    {
                        dtx = bc.GET_DT_TO_DV_TO_DT(dt, "",string.Format ("项次='{0}'",(i+1).ToString ()));
                        NEXT_STID = dtx.Rows[0]["站别编号"].ToString();
                    }

                }

            }
        }
    
    }
}
