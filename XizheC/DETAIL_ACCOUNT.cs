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
    public class DETAIL_ACCOUNT
    {

        private string _getsql;
        public string getsql
        {
            set { _getsql = value; }
            get { return _getsql; ; }

        }
        private string _getsql1;
        public string getsql1
        {
            set { _getsql1 = value; }
            get { return _getsql1; ; }

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

        string sql = @"
SELECT 
A.VOID AS 凭证号,
B.VOUCHER_DATE AS 凭证日期,
A.ACID  AS 科目编号,
C.ACCODE AS 科目代码,
C.ACNAME AS 科目名称,
B.YEAR AS 年,
B.MONTH AS 月,
B.DAY AS 日,
A.CYID AS 币别编号,
D.CYCODE  AS 币别,
D.CYNAME AS 名称,
A.EXCHANGE_RATE AS 汇率,
B.STATUS AS 状态,
B.LAST_YEAR_CARYY_OVER_DATE AS 结转日期 ,
B.ACCOUNTING_PERIOD_EXPIRATION_DATE AS 本期结帐日期,
C.BALANCE_DIRECTION AS 方向,
A.INITIAL_DEBIT AS 期初借方,
A.INITIAL_CREDITED  AS 期初贷方,
SUM(A.DEBIT_ORIGINALAMOUNT) AS 借方原币金额,
SUM(A.DEBIT_AMOUNT) AS 借方本币金额,
SUM(A.CREDITED_ORIGINALAMOUNT) AS 贷方原币金额,
SUM(A.CREDITED_AMOUNT) AS 贷方本币金额

 FROM VOUCHER_DET A 
 LEFT JOIN VOUCHER_MST B ON A.VOID=B.VOID 
 LEFT JOIN ACCOUNTANT_COURSE C ON A.ACID =C.ACID 
 LEFT JOIN CURRENCY_MST D ON A.CYID =D.CYID
";
        string sql1 = @"
 GROUP BY
 B.VOUCHER_DATE ,
 A.ACID,
 C.ACCODE ,
 C.ACNAME ,
 A.CYID ,
 D.CYCODE ,
 D.CYNAME,
 A.EXCHANGE_RATE,
 B.YEAR,
 B.MONTH,
 B.DAY,
 A.VOID,
 C.BALANCE_DIRECTION,
 A.INITIAL_DEBIT ,
 A.INITIAL_CREDITED ,
 B.LAST_YEAR_CARYY_OVER_DATE,
 B.ACCOUNTING_PERIOD_EXPIRATION_DATE,
 B.STATUS
 ORDER BY
 C.ACCODE ASC
";


        basec bc = new basec();
        DataTable dt = new DataTable();
        DataTable dto = new DataTable();
        ExcelToCSHARP etc = new ExcelToCSHARP();
        public GENERAL_ACCOUNT()
        {
            IFExecution_SUCCESS = true;
            getsql = sql;
            getsql1 = sql1;

        }
        #region GetTableInfo
        public DataTable GetTableInfo()
        {
            dt = new DataTable();
            dt.Columns.Add("科目代码", typeof(string));
            dt.Columns.Add("科目名称", typeof(string));
            dt.Columns.Add("日期", typeof(string));
            dt.Columns.Add("凭证号", typeof(string));
            dt.Columns.Add("摘要", typeof(string));
            dt.Columns.Add("借方", typeof(decimal));
            dt.Columns.Add("贷方", typeof(decimal));
            dt.Columns.Add("方向", typeof(string));
            dt.Columns.Add("余额", typeof(decimal));
            return dt;
        }
        #endregion
        #region GetTableInfo_INITIAL
        public DataTable GetTableInfo_INITAIL()
        {
            dt = new DataTable();
            dt.Columns.Add("科目代码", typeof(string));
            dt.Columns.Add("科目名称", typeof(string));
            dt.Columns.Add("日期", typeof(string));
            dt.Columns.Add("凭证号", typeof(string));
            dt.Columns.Add("摘要", typeof(string));
            dt.Columns.Add("借方", typeof(decimal));
            dt.Columns.Add("贷方", typeof(decimal));
            dt.Columns.Add("方向", typeof(string));
            dt.Columns.Add("余额", typeof(decimal));
            DataTable dtx = bc.getdt("SELECT * FROM ACCOUNTANT_COURSE WHERE PARENT_NODEID IS NULL ORDER BY ACCODE ASC");
            foreach (DataRow dr in dtx.Rows)
            {

                DataRow dr1 = dt.NewRow();
                dr1["科目代码"] = dr["ACCODE"].ToString();
                dr1["科目名称"] = dr["ACNAME"].ToString();
                dr1["摘要"] = "上年结转";
                dt.Rows.Add(dr1);
                DataRow dr2 = dt.NewRow();
                dr2["摘要"] = "本期合计";
                dt.Rows.Add(dr2);
                DataRow dr3 = dt.NewRow();
                dr3["摘要"] = "本年累计";
                dt.Rows.Add(dr3);
            }
            return dt;
        }
        #endregion
        #region GetTableInfo
        public DataTable GetTableInfo_O()
        {
            dt = this.GetTableInfo();

            dt.Columns.Add("结转", typeof(decimal));
            dt.Columns.Add("本期合计", typeof(decimal));
            dt.Columns.Add("本年累计", typeof(decimal));
            return dt;
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

        #region GET_TABLEINFO
        public DataTable GET_TABLEINFO(DataTable dt)
        {
            decimal sum = 0, sum1 = 0, sum2 = 0;
            string accode;

            DataTable dt4 = this.GetTableInfo();
            if (dt.Rows.Count > 0)
            {
                accode = dt.Rows[0]["科目代码"].ToString();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    decimal d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0, d7 = 0, d8 = 0;
                    if (!string.IsNullOrEmpty(dt.Rows[i]["借方原币金额"].ToString()))
                    {
                        d1 = decimal.Parse(dt.Rows[i]["借方原币金额"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["贷方原币金额"].ToString()))
                    {
                        d2 = decimal.Parse(dt.Rows[i]["贷方原币金额"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["期初借方"].ToString()))
                    {
                        d3 = decimal.Parse(dt.Rows[i]["期初借方"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["期初贷方"].ToString()))
                    {
                        d4 = decimal.Parse(dt.Rows[i]["期初贷方"].ToString());
                    }

                    d5 = d2 - d1 + d3 - d4;
                    d6 = d1 - d2 - d3 + d4;
                    if (accode != dt.Rows[i]["科目代码"].ToString())
                    {
                        sum = 0;
                        sum1 = 0;
                        sum2 = 0;
                        accode = dt.Rows[i]["科目代码"].ToString();
                    }
                    DataRow dr1 = dt4.NewRow();
                    if (dt.Rows[i]["期初借方"].ToString() != "" || dt.Rows[i]["期初贷方"].ToString() != "")
                    {
                        dr1["摘要"] = "上年结转";
                        dr1["科目代码"] = dt.Rows[i]["科目代码"].ToString();
                        dr1["科目名称"] = dt.Rows[i]["科目名称"].ToString();
                        if (dt.Rows[i]["状态"].ToString() != "INITIAL")
                        {
                            MessageBox.Show(dt.Rows[i]["状态"].ToString());

                            dr1["凭证号"] = dt.Rows[i]["凭证号"].ToString();
                        }


                        dr1["日期"] = dt.Rows[i]["结转日期"].ToString();


                        if (d5 > 0)
                        {
                            dr1["余额"] = d5;
                            dr1["方向"] = dt.Rows[i]["方向"].ToString();
                            sum2 = d5;
                        }

                        if (d6 > 0)
                        {
                            dr1["余额"] = d6;
                            dr1["方向"] = "贷";
                            sum2 = -d6;
                        }
                        dt4.Rows.Add(dr1);
                    }

                    DataRow dr2 = dt4.NewRow();
                    dr2["摘要"] = "本期合计";
                    if (dt.Rows[i]["期初借方"].ToString() != "" || dt.Rows[i]["期初贷方"].ToString() != "")
                    {
                    }
                    else
                    {
                        dr2["科目代码"] = dt.Rows[i]["科目代码"].ToString();
                        dr2["科目名称"] = dt.Rows[i]["科目名称"].ToString();
                        if (dt.Rows[i]["状态"].ToString() != "INITIAL")
                        {

                            dr2["凭证号"] = dt.Rows[i]["凭证号"].ToString();
                        }


                    }
                    dr2["日期"] = dt.Rows[i]["本期结帐日期"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["借方原币金额"].ToString()))
                    {
                        dr2["借方"] = dt.Rows[i]["借方原币金额"].ToString();
                        sum = sum + decimal.Parse(dt.Rows[i]["借方原币金额"].ToString());


                    }
                    else
                    {
                        dr2["借方"] = DBNull.Value;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["贷方原币金额"].ToString()))
                    {
                        dr2["贷方"] = dt.Rows[i]["贷方原币金额"].ToString();
                        sum1 = sum1 + decimal.Parse(dt.Rows[i]["贷方原币金额"].ToString());
                    }
                    else
                    {
                        dr2["贷方"] = DBNull.Value;
                    }

                    d7 = d1 - d2 + sum2;
                    d8 = d2 - d1 - sum2;

                    if (d7 > 0)
                    {
                        dr2["余额"] = d7;
                        dr2["方向"] = dt.Rows[i]["方向"].ToString();
                        sum2 = d7;
                    }

                    if (d8 > 0)
                    {
                        dr2["余额"] = d8;
                        dr2["方向"] = "贷";
                        sum2 = -d8;
                    }
                    if (d7 == 0)
                    {

                        dr2["余额"] = 0;
                        dr2["方向"] = "平";
                        sum2 = 0;
                    }
                    dt4.Rows.Add(dr2);


                    DataRow dr3 = dt4.NewRow();
                    dr3["摘要"] = "本年累计";
                    /*dr3["科目代码"] = dt.Rows[i]["科目代码"].ToString();
                    dr3["科目名称"] = dt.Rows[i]["科目名称"].ToString();
                    dr3["凭证号"] = dt.Rows[i]["凭证号"].ToString();*/
                    dr3["日期"] = dt.Rows[i]["本期结帐日期"].ToString();
                    if (sum > 0)
                    {
                        dr3["借方"] = sum;
                    }
                    else
                    {
                        dr3["借方"] = DBNull.Value;

                    }
                    if (sum1 > 0)
                    {
                        dr3["贷方"] = sum1;
                    }
                    else
                    {
                        dr3["贷方"] = DBNull.Value;
                    }

                    if (sum2 > 0)
                    {
                        dr3["余额"] = sum2;
                        dr3["方向"] = "借";

                    }
                    else if (sum2 < 0)
                    {
                        dr3["余额"] = -sum2;
                        dr3["方向"] = "贷";

                    }
                    else
                    {
                        dr3["余额"] = sum2;
                        dr3["方向"] = "平";


                    }
                    dt4.Rows.Add(dr3);

                }

            }
            return dt4;
        }
        #endregion
        #region GET_TABLEINFO
        public DataTable GET_TABLEINFO1(DataTable dt)
        {

            DataTable dt4 = this.GetTableInfo_O();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DataRow dr1 = dt4.NewRow();
                    if (dt.Rows[i]["期初借方"].ToString() != "" || dt.Rows[i]["期初贷方"].ToString() != "")
                    {
                        dr1["摘要"] = "上年结转";
                        dr1["科目代码"] = dt.Rows[i]["科目代码"].ToString();
                        dr1["科目名称"] = dt.Rows[i]["科目名称"].ToString();
                        dr1["凭证号"] = dt.Rows[i]["凭证号"].ToString();

                        dr1["日期"] = dt.Rows[i]["结转日期"].ToString();
                        decimal d1 = 0, d2 = 0, d3 = 0, d4 = 0, d5 = 0, d6 = 0;
                        if (!string.IsNullOrEmpty(dt.Rows[i]["借方原币金额"].ToString()))
                        {
                            d1 = decimal.Parse(dt.Rows[i]["借方原币金额"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i]["贷方原币金额"].ToString()))
                        {
                            d2 = decimal.Parse(dt.Rows[i]["贷方原币金额"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i]["期初借方"].ToString()))
                        {
                            d3 = decimal.Parse(dt.Rows[i]["期初借方"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[i]["期初贷方"].ToString()))
                        {
                            d4 = decimal.Parse(dt.Rows[i]["期初贷方"].ToString());
                        }

                        d5 = d2 - d1 + d3 - d4;
                        d6 = d1 - d2 - d3 + d4;
                        if (d5 > 0)
                        {
                            dr1["余额"] = d5;
                            dr1["方向"] = dt.Rows[i]["方向"].ToString();
                        }

                        if (d6 > 0)
                        {
                            dr1["余额"] = d6;
                            dr1["方向"] = "贷";
                        }


                        dt4.Rows.Add(dr1);
                    }

                    DataRow dr2 = dt4.NewRow();
                    dr2["摘要"] = "本期合计";
                    if (dt.Rows[i]["期初借方"].ToString() != "" || dt.Rows[i]["期初贷方"].ToString() != "")
                    {
                    }
                    else
                    {
                        dr2["科目代码"] = dt.Rows[i]["科目代码"].ToString();
                        dr2["科目名称"] = dt.Rows[i]["科目名称"].ToString();
                        dr2["凭证号"] = dt.Rows[i]["凭证号"].ToString();
                    }
                    dr2["日期"] = dt.Rows[i]["本期结帐日期"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["借方原币金额"].ToString()))
                    {
                        dr2["借方"] = dt.Rows[i]["借方原币金额"].ToString();
                    }
                    else
                    {
                        dr2["借方"] = DBNull.Value;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["贷方原币金额"].ToString()))
                    {
                        dr2["贷方"] = dt.Rows[i]["贷方原币金额"].ToString();
                    }
                    else
                    {
                        dr2["贷方"] = DBNull.Value;
                    }

                    dt4.Rows.Add(dr2);


                    DataRow dr3 = dt4.NewRow();
                    dr3["摘要"] = "原年累计";
                    /*dr3["科目代码"] = dt.Rows[i]["科目代码"].ToString();
                    dr3["科目名称"] = dt.Rows[i]["科目名称"].ToString();
                    dr3["凭证号"] = dt.Rows[i]["凭证号"].ToString();*/
                    dr3["日期"] = dt.Rows[i]["原期结帐日期"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["借方原币金额"].ToString()))
                    {

                        dr3["借方"] = decimal.Parse(dt.Rows[i]["借方原币金额"].ToString());
                    }
                    else
                    {
                        dr3["借方"] = DBNull.Value;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i]["贷方原币金额"].ToString()))
                    {
                        dr3["贷方"] = dt.Rows[i]["贷方原币金额"].ToString();
                    }
                    else
                    {
                        dr3["贷方"] = DBNull.Value;
                    }

                    dt4.Rows.Add(dr3);

                }

            }
            return dt4;
        }
        #endregion
    }
}
