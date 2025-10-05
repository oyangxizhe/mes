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

    public class CURRENCY
    {
        basec bc = new basec();
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
        private string _NUMID;
        public string NUMID
        {
            set { _NUMID = value; }
            get { return _NUMID; }

        }
        private string _KEY;
        public string KEY
        {
            set { _KEY = value; }
            get { return _KEY; }

        }
        string setsql = @"
INSERT INTO CURRENCY_MST(
CYID,
CYCODE,
CYNAME,
FINANCIAL_YEAR,
MAKERID,
DATE,
YEAR,
MONTH
) VALUES 

(
@CYID,
@CYCODE,
@CYNAME,
@FINANCIAL_YEAR,
@MAKERID,
@DATE,
@YEAR,
@MONTH
)

";
        string setsqlo = @"
UPDATE CURRENCY_MST SET 
CYID=@CYID,
CYCODE=@CYCODE,
CYNAME=@CYNAME,
FINANCIAL_YEAR=@FINANCIAL_YEAR,
MAKERID=@MAKERID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH
";

        public CURRENCY()
        {
          
            sql = setsql;
            sqlo = setsqlo;
            string id = "";
            string ido = "";
            string a1 = bc.numNOYMD(6, 4, "0001", "select * from CURRENCY_MST", "CYID", "CY");
            if (a1 == "Exceed Limited")
            {
                MessageBox.Show("编码超出限制！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                id = a1;
            }
            NUMID = id;

            string a2 = bc.numYMD(20, 12, "000000000001", "select * from CURRENCY_DET", "CYKEY", "CY");
            if (a2 == "Exceed Limited")
            {
                MessageBox.Show("编码超出限制！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ido = a2;
            }
            KEY = ido;
        }
     

    }
}
