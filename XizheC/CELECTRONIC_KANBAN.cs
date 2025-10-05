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
using System.Collections.Generic;
namespace XizheC
{
    public class CELECTRONIC_KANBAN:IGETID 
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
        #endregion
        DataTable dt = new DataTable();
        #region sql
        string setsql = @"

SELECT 
A.ACTION_RULE AS 执行规则,
C.MACHINE_GROUP_ID AS 机台群组代码,
C.MACHINE_GROUP AS 机台群组名称,
SUM(A.OK_COUNT) AS 入账或出账数量
FROM POSTING_MST  A 
LEFT JOIN WORKORDER_MST B ON A.WOID =B.WOID 
LEFT JOIN MACHINE_GROUP C ON A.MRID =C.MRID 
WHERE 
B.STATUS NOT IN ('SCRAP','COMPLETE') 
AND A.DATE BETWEEN '{0}' AND '{1}'
AND C.MACHINE_GROUP_ID='{2}'
GROUP BY 
A.ACTION_RULE ,
C.MACHINE_GROUP_ID ,
C.MACHINE_GROUP 
ORDER BY 
A.ACTION_RULE ,
C.MACHINE_GROUP_ID
ASC
";


        string setsqlo = @"



";

        string setsqlt = @"


";
        string setsqlth = @"

";

        string setsqlf = @"

";
        string setsqlfi = @"

";
        string setsqlsi = @"


";
        #endregion
      
        public CELECTRONIC_KANBAN()
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
        #region EMPTY_DT
        public DataTable EMPTY_DT()
        {
          
            DataTable dtt = new DataTable();
            dtt.Columns.Add("机台群组代码", typeof(string));
            dtt.Columns.Add("机台群组名称", typeof(string));
            dtt.Columns.Add("时段", typeof(string));
            dtt.Columns.Add("入账数量", typeof(decimal));
            dtt.Columns.Add("出账数量", typeof(decimal));
            dtt.Columns.Add("良率", typeof(decimal));
            return dtt;
        }
        #endregion
        public List<string> RETURN_DATE(DateTime selectdate)
        {
            List<string> listt = new List<string>();
            listt.Add(selectdate.ToString("yyyy/MM/dd 08:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 09:59:59").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 10:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 11:59:59").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 12:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 13:59:59").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 14:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 15:59:59").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 16:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 17:59:59").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 18:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 19:59:59").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 20:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 21:59:59").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 22:00:00").Replace("-", "/"));
            listt.Add(selectdate.ToString("yyyy/MM/dd 23:59:59").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 00:00:00").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 01:59:59").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 02:00:00").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 03:59:59").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 04:00:00").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 05:59:59").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 06:00:00").Replace("-", "/"));
            listt.Add(selectdate.AddDays(+1).ToString("yyyy/MM/dd 07:59:59").Replace("-", "/"));
            return listt;
        }
        #region RETURN_MACHINE_GROUP_DT
        public DataTable RETURN_MACHINE_GROUP_DT()
        {
            dt = bc.getdt(sql);
            DataTable dtt = EMPTY_DT();
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dtt, "", string.Format("机台群组代码='{0}'", dr["机台群组代码"].ToString()));
                    if (dtx.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        decimal d1 = 0, d2 = 0;

                        DataRow dr1 = dtt.NewRow();
                        dr1["机台群组代码"] = dr["机台群组代码"].ToString();
                        dr1["机台群组名称"] = dr["机台群组名称"].ToString();
                        dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", string.Format("机台群组代码='{0}' AND 执行规则='TRACK IN '", dr["机台群组代码"].ToString()));
                        if (!string.IsNullOrEmpty(dtx.Rows[0]["入账或出账"].ToString()))
                        {
                            d1 = decimal.Parse(dtx.Rows[0]["入账或出账"].ToString());
                        }
                        dr1["入账数量"] = d1;
                        dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", string.Format("机台群组代码='{0}' AND 执行规则='TRACK OUT'", dr["机台群组代码"].ToString()));
                        if (dtx.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dtx.Rows[0]["入账或出账"].ToString()))
                            {
                                d2 = decimal.Parse(dtx.Rows[0]["入账或出账"].ToString());
                            }
                            //MessageBox.Show(dtx.Rows[0]["执行规则"].ToString() + "," + dtx.Rows[0]["入账或出账"].ToString());
                        }
                        dr1["出账数量"] = d2;
                        dr1["良率"] = (d1 / (d1 + d2) * 100).ToString("0.00");
                        dtt.Rows.Add(dr1);
                    }

                }

            }

            return dtt;
        }
        #endregion
  
    }
}
