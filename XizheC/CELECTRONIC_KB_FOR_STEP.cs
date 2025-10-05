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
    public class CELECTRONIC_KB_FOR_STEP:IGETID 
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
C.STEP_ID AS 站别代码,
C.STEP  AS 站别名称,
SUM(A.OK_COUNT) AS 入账或出账数量
FROM POSTING_MST  A 
LEFT JOIN WORKORDER_MST B ON A.WOID =B.WOID 
LEFT JOIN STEP C ON A.STID=C.STID 
WHERE 
B.STATUS NOT IN ('SCRAP') 
AND A.DATE BETWEEN '{0}' AND '{1}'
GROUP BY 
A.ACTION_RULE ,
C.STEP_ID ,
C.STEP 
ORDER BY 
A.ACTION_RULE ,
C.STEP_ID
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
      
        public CELECTRONIC_KB_FOR_STEP()
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
            dtt.Columns.Add("站别代码", typeof(string));
            dtt.Columns.Add("站别名称", typeof(string));
            dtt.Columns.Add("时段", typeof(string));
            dtt.Columns.Add("入账数量", typeof(decimal));
            dtt.Columns.Add("出账数量", typeof(decimal));
            dtt.Columns.Add("良率", typeof(decimal));
            return dtt;
        }
        #endregion
        public List<CSTEP> RETURN_STEP()
        {
            List<CSTEP> listt = new List<CSTEP>();
            dt = bc.getdt("SELECT * FROM STEP");
           
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CSTEP cstep = new CSTEP();
                    cstep .STEP_ID =dr["STEP_ID"].ToString ();
                    cstep .STEP =dr["STEP"].ToString ();
                    listt.Add(cstep);
                }
            }
            return listt;
        }
        #region RETURN_STEP_ID_DT
        public DataTable RETURN_STEP_ID_DT()
        {
            dt = bc.getdt(sql);
            DataTable dtt = EMPTY_DT();
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dtt, "", string.Format("站别代码='{0}'", dr["站别代码"].ToString()));
                    if (dtx.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        decimal d1 = 0, d2 = 0;

                        DataRow dr1 = dtt.NewRow();
                        dr1["站别代码"] = dr["站别代码"].ToString();
                        dr1["站别名称"] = dr["站别名称"].ToString();
                        dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", string.Format("站别代码='{0}' AND 执行规则='TRACK IN '", dr["站别代码"].ToString()));
                        if (!string.IsNullOrEmpty(dtx.Rows[0]["入账或出账"].ToString()))
                        {
                            d1 = decimal.Parse(dtx.Rows[0]["入账或出账"].ToString());
                        }
                        dr1["入账数量"] = d1;
                        dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", string.Format("站别代码='{0}' AND 执行规则='TRACK OUT'", dr["站别代码"].ToString()));
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
