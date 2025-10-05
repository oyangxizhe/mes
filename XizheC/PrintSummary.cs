using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;

namespace XizheC
{
    public class   PrintSummary
    {
        basec bc = new basec();
        string sqlo = @"
SELECT B.PLATENUM AS 车牌号码,D.UCID AS 用车单号,
C.ENAME AS 驾驶员,E.CNAME AS 客户名称,F.ADDRESS AS 收货地址,G.ADDRESS AS 送货地址,
CASE WHEN sum(A.SELLUNITPRICE*A.OCOUNT) IS NULL THEN 0
ELSE sum(A.SELLUNITPRICE*A.OCOUNT)
END
 AS 运费收入,
 CASE WHEN sum(A.TYPOGRAPHY_COST) IS NULL THEN 0
ELSE sum(A.TYPOGRAPHY_COST)
END
 AS 排班收入,
CASE WHEN SUM(A.REPAIR_COST)IS NULL THEN  0
ELSE  SUM(A.REPAIR_COST)
END 
AS 维修费用,
CASE WHEN SUM(A.GASCARD_MRCOUNT) IS NULL THEN 0
ELSE SUM(A.GASCARD_MRCOUNT)
END
AS 油库耗油,
CASE WHEN SUM(A.GAS_COST) IS NULL THEN 0
ELSE SUM(A.GAS_COST)
END
AS 加油费用,
CASE WHEN SUM(A.WASH_COUNT*A.WASH_UNITPRICE) IS NULL THEN 0
ELSE SUM(A.WASH_COUNT*A.WASH_UNITPRICE)
END
AS 轮胎费用,
CASE WHEN SUM(A.INSURE_COST) IS NULL THEN 0
ELSE  SUM(A.INSURE_COST)
END
AS 保险费用,
CASE WHEN SUM(A.AUDIT_COST) IS NULL THEN 0
ELSE SUM(A.AUDIT_COST)
END
AS 年审费用,
CASE WHEN SUM(A.TOLL) IS NULL THEN 0
ELSE SUM(A.TOLL)
END
AS 过路费用,
CASE WHEN SUM(A.UPKEEP_COST) IS NULL THEN 0
ELSE SUM(A.UPKEEP_COST)
END
AS 保养费用,
CASE WHEN SUM(A.OTHER_COST)IS NULL THEN 0
ELSE SUM(A.OTHER_COST)
END
AS 其它费用,
(
CASE WHEN 
SUM(A.REPAIR_COST)IS NULL THEN  0
ELSE SUM(A.REPAIR_COST)
END +
CASE WHEN SUM(A.GAS_COST) IS NULL THEN 0
ELSE SUM(A.GAS_COST)
END +
CASE WHEN SUM(A.WASH_COUNT*A.WASH_UNITPRICE) IS NULL THEN 0
ELSE SUM(A.WASH_COUNT*A.WASH_UNITPRICE)
END+
CASE WHEN SUM(A.INSURE_COST) IS NULL THEN 0
ELSE SUM(A.INSURE_COST)
END+
CASE WHEN SUM(A.AUDIT_COST) IS NULL THEN 0
ELSE SUM(A.AUDIT_COST)
END+
CASE WHEN SUM(A.TOLL) IS NULL THEN 0
ELSE SUM(A.TOLL)
END+
CASE WHEN SUM(A.UPKEEP_COST) IS NULL THEN 0
ELSE SUM(A.UPKEEP_COST)
END+
CASE WHEN SUM(A.OTHER_COST)IS NULL THEN 0
ELSE SUM(A.OTHER_COST)
END

) AS 费用合计,
CASE WHEN sum(A.SELLUNITPRICE*A.OCOUNT) IS NULL THEN 0
ELSE sum(A.SELLUNITPRICE*A.OCOUNT)
END
+
 CASE WHEN sum(A.TYPOGRAPHY_COST) IS NULL THEN 0
ELSE sum(A.TYPOGRAPHY_COST)
END
-
(
CASE WHEN 
SUM(A.REPAIR_COST)IS NULL THEN  0
ELSE SUM(A.REPAIR_COST)
END +
CASE WHEN SUM(A.GAS_COST) IS NULL THEN 0
ELSE SUM(A.GAS_COST)
END +
CASE WHEN SUM(A.WASH_COUNT*A.WASH_UNITPRICE) IS NULL THEN 0
ELSE  SUM(A.WASH_COUNT*A.WASH_UNITPRICE)
END+
CASE WHEN SUM(A.INSURE_COST) IS NULL THEN 0
ELSE SUM(A.INSURE_COST)
END+
CASE WHEN SUM(A.AUDIT_COST) IS NULL THEN 0
ELSE SUM(A.AUDIT_COST)
END+
CASE WHEN SUM(A.TOLL) IS NULL THEN 0
ELSE SUM(A.TOLL)
END+
CASE WHEN SUM(A.UPKEEP_COST) IS NULL THEN 0
ELSE SUM(A.UPKEEP_COST)
END+
CASE WHEN SUM(A.OTHER_COST)IS NULL THEN 0
ELSE SUM(A.OTHER_COST)
END

) AS 实现利润,
CASE WHEN SUM(A.OCOUNT) IS NOT NULL THEN SUM(A.OCOUNT)
ELSE 0
END 
AS 吨数 
FROM GODE A
LEFT JOIN CARINFO B ON A.CAID=B.CAID 
LEFT JOIN UCAPPLY_DET D ON D.UCID=A.UCID   
LEFT JOIN CustomerInfo_MST E ON D.CUID =E.CUID 
LEFT JOIN CustomerInfo_DET F ON D.CUKEY =F.CUKEY 
LEFT JOIN ReceivingAndDelivery G ON D.RDID =G.RDID
LEFT JOIN UCAPPLY_MST H ON H.UCID=D.UCID 
LEFT JOIN EMPLOYEEINFO C ON H.DRIVERID=C.EMID
";
        string sqlt = @"  A.CAID IS NOT NULL AND A.AUDIT_STATUS='Y'  GROUP BY A.CAID,B.PLATENUM,C.ENAME,D.UCID
,CNAME,F.Address ,G.Address  ORDER BY A.CAID,D.UCID ASC";

        public PrintSummary()
        {

        }
        #region ask
        public  DataTable ask(string sql,string startdate,string enddate)
        {
            string sql1 = sqlo + sql+ sqlt;
            DataTable dtt1 = bc.getdt(sql1);
            DataTable dtt = new DataTable();
            dtt.Columns.Add("用车单号", typeof(string));
            dtt.Columns.Add("车牌号码", typeof(string));
            dtt.Columns.Add("驾驶员", typeof(string));
            dtt.Columns.Add("客户名称", typeof(string));
            dtt.Columns.Add("收货地址", typeof(string));
            dtt.Columns.Add("送货地址", typeof(string));
            dtt.Columns.Add("运费收入", typeof(decimal));
            dtt.Columns.Add("排班收入", typeof(decimal));
            dtt.Columns.Add("维修费用", typeof(decimal));
            dtt.Columns.Add("油库耗油", typeof(decimal));
            dtt.Columns.Add("加油费用", typeof(decimal));
            dtt.Columns.Add("轮胎费用", typeof(decimal));
            dtt.Columns.Add("保险费用", typeof(decimal));
            dtt.Columns.Add("年审费用", typeof(decimal));
            dtt.Columns.Add("过路费用", typeof(decimal));
            dtt.Columns.Add("保养费用", typeof(decimal));
            dtt.Columns.Add("其它费用", typeof(decimal));
            dtt.Columns.Add("费用合计", typeof(decimal));
            dtt.Columns.Add("实现利润", typeof(decimal));
            dtt.Columns.Add("起始日期", typeof(string));
            dtt.Columns.Add("截止日期", typeof(string));
            dtt.Columns.Add("公里数", typeof(decimal));
            dtt.Columns.Add("吨数", typeof(decimal));

            foreach (DataRow dr in dtt1.Rows)
            {
                DataRow dr1 = dtt.NewRow();
                dr1["用车单号"] = dr["用车单号"].ToString();
                dr1["车牌号码"] = dr["车牌号码"].ToString();
                dr1["驾驶员"] = dr["驾驶员"].ToString();
                dr1["客户名称"] = dr["客户名称"].ToString();
                dr1["收货地址"] = dr["收货地址"].ToString();
                dr1["送货地址"] = dr["送货地址"].ToString();
                dr1["运费收入"] = dr["运费收入"].ToString();
                dr1["排班收入"] = dr["排班收入"].ToString();
                dr1["维修费用"] = dr["维修费用"].ToString();
                dr1["油库耗油"] = dr["油库耗油"].ToString();
                dr1["加油费用"] = dr["加油费用"].ToString();
                dr1["轮胎费用"] = dr["轮胎费用"].ToString();
                dr1["保险费用"] = dr["保险费用"].ToString();
                dr1["年审费用"] = dr["年审费用"].ToString();
                dr1["过路费用"] = dr["过路费用"].ToString();
                dr1["保养费用"] = dr["保养费用"].ToString();
                dr1["其它费用"] = dr["其它费用"].ToString();
                dr1["费用合计"] = dr["费用合计"].ToString();
                dr1["实现利润"] = dr["实现利润"].ToString();
                dr1["起始日期"] = startdate;
                dr1["截止日期"] = enddate;
                dr1["吨数"] = dr["吨数"].ToString();
                dtt.Rows.Add(dr1);
            }
            string sql2 = "SELECT UCID,(RETURN_VKT-DEPARTURE_VKT) AS VKT FROM UCAPPLY_MST WHERE UCAPPLY_STATUS ='APPROVE'";
            DataTable dtt2=bc.getdt(sql2);
            foreach (DataRow dr3 in dtt.Rows)
            {

                foreach (DataRow dr4 in dtt2.Rows)
                {
                    if(dr3["用车单号"].ToString ()==dr4["UCID"].ToString ())
                    {

                        dr3["公里数"] = dr4["VKT"].ToString();
                        break;
                    }

                }

            }
            DataRow dr2 = dtt.NewRow();
            dr2["用车单号"] = "合计";
            dr2["运费收入"] = dtt.Compute("SUM(运费收入)", "");
            dr2["排班收入"] = dtt.Compute("SUM(排班收入)", "");
            dr2["维修费用"] = dtt.Compute("SUM(维修费用)", "");
            dr2["油库耗油"] = dtt.Compute("SUM(油库耗油)", "");
            dr2["加油费用"] = dtt.Compute("SUM(加油费用)", "");
            dr2["轮胎费用"] = dtt.Compute("SUM(轮胎费用)", "");
            dr2["保险费用"] = dtt.Compute("SUM(保险费用)", "");
            dr2["年审费用"] = dtt.Compute("SUM(年审费用)", "");
            dr2["过路费用"] = dtt.Compute("SUM(过路费用)", "");
            dr2["保养费用"] = dtt.Compute("SUM(保养费用)", "");
            dr2["其它费用"] = dtt.Compute("SUM(其它费用)", "");
            dr2["费用合计"] = dtt.Compute("SUM(费用合计)", "");
            dr2["实现利润"] = dtt.Compute("SUM(实现利润)", "");
            dr2["公里数"] = dtt.Compute("SUM(公里数)", "");
            dr2["吨数"] = dtt.Compute("SUM(吨数)", "");
            dtt.Rows.Add(dr2);
            return dtt;
        }
        #endregion
    }
}
