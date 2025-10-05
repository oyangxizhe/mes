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

    public class PERIOD
    {
        basec bc = new basec();
        private string _FINANCIAL_YEARE_STARTDATE;
        public string FINANCIAL_YEAR_STARTDATE
        {
            set { _FINANCIAL_YEARE_STARTDATE = value; }
            get { return _FINANCIAL_YEARE_STARTDATE; }
        }
        private string _FINANCIAL_YEARE_ENDDATE;
        public string FINANCIAL_YEAR_ENDDATE
        {
            set { _FINANCIAL_YEARE_ENDDATE = value; }
            get { return _FINANCIAL_YEARE_ENDDATE; }
        }
        private string _ACCOUNTING_PERIOD;
        public string ACCOUNTING_PERIOD
        {
            set { _ACCOUNTING_PERIOD = value; }
            get { return _ACCOUNTING_PERIOD; }

        }
        private string _FINANCIAL_YEAR_INITIAL_DATE;
        public string FINANCIAL_YEAR_INITIAL_DATE
        {

            set { _FINANCIAL_YEAR_INITIAL_DATE = value; }
            get { return _FINANCIAL_YEAR_INITIAL_DATE; }

        }
        private string _EXPIRATION_DATE;
        public string EXPIRATION_DATE
        {

            set { _EXPIRATION_DATE = value; }
            get { return _EXPIRATION_DATE; }

        }
        private string _FINANCIAL_YEAR;
        public string FINANCIAL_YEAR
        {
            set { _FINANCIAL_YEAR = value; }
            get { return _FINANCIAL_YEAR; }

        }
        private string _GETPERIOD;
        public string GETPERIOD
        {
            set { _GETPERIOD = value; }
            get { return _GETPERIOD; }

        }
        private string _NEXT_FINANCIAL_YEAR;
        public string NEXT_FINANCIAL_YEAR
        {
            set { _NEXT_FINANCIAL_YEAR = value; }
            get { return _NEXT_FINANCIAL_YEAR; }

        }
        private string _NEXT_PERIOD;
        public string NEXT_PERIOD
        {
            set { _NEXT_PERIOD = value; }
            get { return _NEXT_PERIOD; }

        }
        private string _NEXT_PERIOD_t;
        public string NEXT_PERIOD_t
        {
            set { _NEXT_PERIOD_t = value; }
            get { return _NEXT_PERIOD_t; }

        }
        private string _sql;
        public string sql
        {
            set { _sql = value; }
            get { return _sql; }

        }
        private string _ACCOUNTING_PERIOD_START_DATE;
        public string ACCOUNTING_PERIOD_START_DATE
        {
            set { _ACCOUNTING_PERIOD_START_DATE = value; }
            get { return _ACCOUNTING_PERIOD_START_DATE; }
        }
        private string _ACCOUNTING_PERIOD_EXPIRATION_DATE;
        public string ACCOUNTING_PERIOD_EXPIRATION_DATE
        {

            set { _ACCOUNTING_PERIOD_EXPIRATION_DATE = value; }
            get { return _ACCOUNTING_PERIOD_EXPIRATION_DATE; }

        }
        private bool _JUAGE_IF_NO_CURRENT_ACCOUNTING_PERIOD;
        public bool JUAGE_IF_NO_CURRENT_ACCOUNTING_PERIOD
        {
            set { _JUAGE_IF_NO_CURRENT_ACCOUNTING_PERIOD = value; }
            get { return _JUAGE_IF_NO_CURRENT_ACCOUNTING_PERIOD; }

        }
        private string _CURRENT_PERIOD_EXPIRATION_DATE;
        public string CURRENT_PERIOD_EXPIRATION_DATE
        {

            set { _CURRENT_PERIOD_EXPIRATION_DATE = value; }
            get { return _CURRENT_PERIOD_EXPIRATION_DATE; }

        }
        private bool _IF_CARRY;
        public bool IF_CARRY
        {
            set { _IF_CARRY = value; }
            get { return _IF_CARRY; }

        }
        private string _ERROW;
        public string ERROW
        {

            set { _ERROW = value; }
            get { return _ERROW; }

        }
        string setsql = @"
INSERT INTO Period(
PEID,
FINANCIAL_YEAR,
PERIOD,
FINANCIAL_YEAR_INITIAL_DATE,
ACCOUNTING_PERIOD_START_DATE,
ACCOUNTING_PERIOD_EXPIRATION_DATE,
ACCOUNT_IF_START_USING,
IF_CURRENT_ACCOUNTING_PERIOD,
MAKERID,
DATE,
YEAR,
MONTH
) VALUES 

(
@PEID,
@FINANCIAL_YEAR,
@PERIOD,
@FINANCIAL_YEAR_INITIAL_DATE,
@ACCOUNTING_PERIOD_START_DATE,
@ACCOUNTING_PERIOD_EXPIRATION_DATE,
@ACCOUNT_IF_START_USING,
@IF_CURRENT_ACCOUNTING_PERIOD,
@MAKERID,
@DATE,
@YEAR,
@MONTH

)

";
        public PERIOD()
        {
            DataTable dt = bc.getdt("SELECT * FROM PERIOD WHERE IF_CURRENT_ACCOUNTING_PERIOD='Y'");
            if (dt.Rows.Count > 0)
            {
                FINANCIAL_YEAR_STARTDATE = dt.Rows[0]["FINANCIAL_YEAR"].ToString() + "/01/01 00:00:00";
                FINANCIAL_YEAR_ENDDATE = dt.Rows[0]["FINANCIAL_YEAR"].ToString() + "/12/31 23:59:59";
                ACCOUNTING_PERIOD = " 当前帐期：" + dt.Rows[0]["FINANCIAL_YEAR"].ToString() + " 年" + " 第 " + dt.Rows[0]["PERIOD"].ToString() + " 期";
                FINANCIAL_YEAR_INITIAL_DATE = dt.Rows[0]["FINANCIAL_YEAR_INITIAL_DATE"].ToString();
                if (dt.Rows[0]["FINANCIAL_YEAR_INITIAL_DATE"].ToString() != "")
                {
                    DateTime d3 = Convert.ToDateTime(dt.Rows[0]["FINANCIAL_YEAR_INITIAL_DATE"].ToString());
                    DateTime d5 = d3.AddMonths(+1).AddDays(-1);
                    EXPIRATION_DATE = d5.ToString("yyyy/MM/dd");
                }
               
                FINANCIAL_YEAR = dt.Rows[0]["FINANCIAL_YEAR"].ToString();
                GETPERIOD = dt.Rows[0]["PERIOD"].ToString();
                DateTime d6 = Convert.ToDateTime (dt.Rows[0]["FINANCIAL_YEAR"].ToString() + "/" + dt.Rows[0]["PERIOD"].ToString());
                DateTime d7 = d6.AddMonths(+1);
              
                NEXT_FINANCIAL_YEAR = d7.ToString("yyyy");
                if (bc.GET_NO_ZERO_MONTH(d7.ToString("MM")) != "")
                {
                    NEXT_PERIOD = bc.GET_NO_ZERO_MONTH(d7.ToString("MM"));
                }
           
                DateTime d8 = Convert.ToDateTime(dt.Rows[0]["ACCOUNTING_PERIOD_EXPIRATION_DATE"].ToString());
                CURRENT_PERIOD_EXPIRATION_DATE = dt.Rows[0]["ACCOUNTING_PERIOD_EXPIRATION_DATE"].ToString();
                DateTime d4 = d8.AddDays(+1);
                ACCOUNTING_PERIOD_START_DATE = d4.ToString("yyyy/MM/dd");
                DateTime d9 = d4.AddMonths(+1).AddDays (-1);
                ACCOUNTING_PERIOD_EXPIRATION_DATE = d9.ToString("yyyy/MM/dd");
            }
            sql = setsql;
          
            if (bc.exists("SELECT * FROM VOUCHER_MST WHERE FINANCIAL_YEAR='" + FINANCIAL_YEAR + "' AND PERIOD='" +GETPERIOD + "' AND STATUS='CARRY'"))
            {
           
                IF_CARRY = true;
            }
        
        }
        public PERIOD(string VOID)
        {
            PERIOD period = new PERIOD();
            DataTable dt = bc.getdt("SELECT * FROM VOUCHER_MST WHERE VOID='"+VOID+"'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["FINANCIAL_YEAR"].ToString() != period.FINANCIAL_YEAR || dt.Rows[0]["PERIOD"].ToString() != period.GETPERIOD)
                {
                    JUAGE_IF_NO_CURRENT_ACCOUNTING_PERIOD = true;
                    string v1= " 凭证帐期：" + dt.Rows[0]["FINANCIAL_YEAR"].ToString() + " 年" + " 第 " + dt.Rows[0]["PERIOD"].ToString() + " 期";
                    ERROW = "非当前帐期不能改动该凭证！" + v1 + period.ACCOUNTING_PERIOD;

                }


            }



        }
        public string GET_NUM_ID()
        {
            string id = "";
            string a1 = bc.numYM(10, 4, "0001", "SELECT * FROM PERIOD", "PEID", "PE");
            if (a1 == "Exceed Limited")
            {
                MessageBox.Show("编码超出限制！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                id = a1;
            }
            return id;
        }
        

    }
}
