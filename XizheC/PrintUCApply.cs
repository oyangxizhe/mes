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
    public class PrintUCApply
    {
        basec bc = new basec();
        string sqlo = @"
            select A.UCKEY AS 索引,A.UCID as 用车单号,A.CUID AS 客户代码,B.CNAME AS 客户名称,C.ADDRESS AS 收货地址,
A.SN as 项次,D.ADDRESS AS 送货地址,F.USEDATE AS 使用日期,F.APPLICANTID AS 申请人工号,(SELECT DEPART FROM EMPLOYEEINFO WHERE EMID=F.USEPERSONID) AS 部门,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.APPLICANTID ) AS 申请人,F.USEPERSONID AS 使用人工号,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.USEPersonID) AS 使用人,F.USEDAYS AS 使用天数,
F.USECAUSE AS 事由说明,F.PLAN_CARTYPE AS 预约车辆类型,F.PLAN_RETURNTIME AS 预计返回时间,
F.TOGETHER_PERSONS AS 随行人数,F.DISPATCHERID AS 调度员工号,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.DISPATCHERID ) AS 调度员,
F.DRIVERID AS 驾驶员工号,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.DRIVERID ) AS 驾驶员,
F.CAID AS 车辆编号,G.PLATENUM AS 车牌号码,F.USEUNITPRICE AS 用车单价,
F.DEPARTURE_TIME AS 出车时间,F.DEPARTURE_VKT AS 出车时里程数,F.DEPARTURE_SECURITYID AS 出车保安工号 ,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.DEPARTURE_SECURITYID ) AS 出车保安,
F.RETURN_TIME AS 回车时间,F.RETURN_VKT AS 回车时里程数,F.RETURN_SECURITYID AS 回车保安工号 ,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.RETURN_SECURITYID ) AS 回车保安,
F.APPROVERID AS 审核人工号,(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=F.APPROVERID ) AS 审核人,
G.CAR_NATURE AS 车辆属性,G.CARTYPE AS 车辆类型,"
+ "E.START_OCOUNT as 出车数量 ,E.OCOUNT AS 回车数量,E.SellUnitPrice as 销售单价 ,E.TaxRate as 税率,"
+ "E.SELLUNITPRICE*E.OCOUNT AS 金额,E.TAXRATE/100*E.SELLUNITPRICE*E.OCOUNT AS 税额,"
+ " E.SELLUNITPRICE*(1+(E.TAXRATE)/100)*E.OCOUNT AS 含税金额,E.TYPOGRAPHY_COST AS 排班费用,"
+ "A.REMARK AS 备注 from UCApply_DET A "
+ " LEFT JOIN CUSTOMERINFO_MST B ON A.CUID=B.CUID"
+ " LEFT JOIN CUSTOMERINFO_DET C ON A.CUKEY=C.CUKEY"
+ " LEFT JOIN RECEIVINGANDDELIVERY D ON A.RDID=D.RDID"
+ " LEFT JOIN GODE E ON A.UCKEY=E.GEKEY"
+ " LEFT JOIN UCAPPLY_MST F ON A.UCID=F.UCID"
+ " LEFT JOIN CARINFO G ON F.CAID=G.CAID";

        string sqlt = @"";

        public PrintUCApply()
        {

        }
        #region ask
        public  DataTable ask(string sql)
        {
            string sql1 = sqlo + sql + sqlt;
            DataTable dtt= bc.getdt(sql1);
            return dtt;
        }
        #endregion
    }
}


