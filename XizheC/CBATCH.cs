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
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using Microsoft.CSharp;
using System.Configuration;

namespace XizheC
{
    public class CBATCH
    {
        basec bc = new basec();

        #region nature
        private string _EMID;
        public string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }

        private string _BAID;
        public string BAID
        {
            set { _BAID = value; }
            get { return _BAID; }

        }
        private string _WAREID;
        public string WAREID
        {
            set { _WAREID = value; }
            get { return _WAREID; }

        }
        private string _REJUDGE_COUNT;
        public string REJUDGE_COUNT
        {
            set { _REJUDGE_COUNT = value; }
            get { return _REJUDGE_COUNT; }

        }
        private string _SCRAP_COUNT;
        public string SCRAP_COUNT
        {
            set { _SCRAP_COUNT = value; }
            get { return _SCRAP_COUNT; }

        }
        private string _RE_PROCESSING_COUNT;
        public string RE_PROCESSING_COUNT
        {
            set { _RE_PROCESSING_COUNT = value; }
            get { return _RE_PROCESSING_COUNT; }

        }
        private string _WOID;
        public string WOID
        {
            set { _WOID = value; }
            get { return _WOID; }

        }
        private string _OK_COUNT;
        public string OK_COUNT
        {
            set { _OK_COUNT = value; }
            get { return _OK_COUNT; }

        }
        private string _UNIT_LOT;
        public string UNIT_LOT
        {
            set { _UNIT_LOT = value; }
            get { return _UNIT_LOT; }

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
        private string _BAKEY;
        public string BAKEY
        {
            set { _BAKEY = value; }
            get { return _BAKEY; }

        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }

        private string _SN;
        public string SN
        {
            set { _SN = value; }
            get { return _SN; }

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
        private string _FCID;
        public string FCID
        {

            set { _FCID = value; }
            get { return _FCID; }

        }
        private string _CURRENT_STID;
        public string CURRENT_STID
        {

            set { _CURRENT_STID = value; }
            get { return _CURRENT_STID; }

        }
        private string _FLOW_CHART_EDITION;
        public string FLOW_CHART_EDITION
        {

            set { _FLOW_CHART_EDITION = value; }
            get { return _FLOW_CHART_EDITION; }

        }
        private string _STATUS;
        public string STATUS
        {

            set { _STATUS = value; }
            get { return _STATUS; }

        }
        private string _ACTION_RULE;
        public string ACTION_RULE
        {

            set { _ACTION_RULE = value; }
            get { return _ACTION_RULE; }

        }
        private string _BATCHID;
        public string BATCHID
        {

            set { _BATCHID = value; }
            get { return _BATCHID; }

        }
        #endregion
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        #region sql
        string setsql = @"


SELECT
A.WOID AS 工单号,
A.WAREID AS 物料编号,
B.CO_WAREID AS 料号,
B.WNAME AS 品名,
A.WO_COUNT AS 工单数量,
F.BATCHID AS 批号,
F.UNIT_LOT AS 单位批号量,
F.ACTION_RULE AS 当前执行规则,
H.STEP_ID AS 当前站别代码,
H.STEP AS 当前站别名称,
C.FCID AS 途程编号,
C.FLOW_CHART_ID AS 途程代码,
C.FLOW_CHART AS 途程名称,
D.SN AS 途程项次,
A.FLOW_CHART_EDITION AS 途程版本,
E.STEP_ID AS 站别代码,
E.STEP AS 站别名称,
(SELECT ENAME FROM EMPLOYEEINFO WHERE EMID=G.MAKERID) AS 制单人,
B.DATE AS 制单日期
FROM WORKORDER_MST A
LEFT JOIN WAREINFO B ON A.WAREID=B.WAREID
LEFT JOIN FLOW_CHART_MST C ON A.FCID=C.FCID
LEFT JOIN FLOW_CHART_DET D ON D.FCID =C.FCID 
LEFT JOIN STEP E ON D.STID =E.STID 
LEFT JOIN BATCH_DET F ON F.WOID=A.WOID
LEFT JOIN BATCH_MST G ON F.BAID=G.BAID
LEFT JOIN STEP H ON H.STID =F.CURRENT_STID 

";


        string setsqlo = @"
INSERT INTO BATCH_DET
(
BAKEY,
BAID,
WOID,
BATCHID,
SN,
UNIT_LOT,
OK_COUNT,
REJUDGE_COUNT,
RE_PROCESSING_COUNT,
SCRAP_COUNT,
FCID,
FLOW_CHART_EDITION,
CURRENT_STID,
STATUS,
ACTION_RULE,
MAKERID,
DATE,
YEAR,
MONTH,
DAY
)
VALUES
(
@BAKEY,
@BAID,
@WOID,
@BATCHID,
@SN,
@UNIT_LOT,
@OK_COUNT,
@REJUDGE_COUNT,
@RE_PROCESSING_COUNT,
@SCRAP_COUNT,
@FCID,
@FLOW_CHART_EDITION,
@CURRENT_STID,
@STATUS,
@ACTION_RULE,
@MAKERID,
@DATE,
@YEAR,
@MONTH,
@DAY

)


";

        string setsqlt = @"

INSERT INTO BATCH_MST
(
BAID,
WOID,
DATE,
MAKERID,
YEAR,
MONTH,
DAY
)
VALUES
(
@BAID,
@WOID,
@DATE,
@MAKERID,
@YEAR,
@MONTH,
@DAY
)
";
        string setsqlth = @"
UPDATE BATCH_MST SET 
WOID=@WOID,
DATE=@DATE,
YEAR=@YEAR,
MONTH=@MONTH,
DAY=@DAY
";

        string setsqlf = @"
SELECT 
A.WOID AS 工单号,
A.WO_COUNT AS 工单数量,
CASE WHEN SUM(B.UNIT_LOT) IS NOT NULL THEN SUM(B.UNIT_LOT)
ELSE 0
END AS 已投产数量,
CASE WHEN SUM(B.UNIT_LOT) IS NOT NULL THEN A.WO_COUNT-SUM(B.UNIT_LOT)
ELSE WO_COUNT 
END AS 未投产数量,
CASE WHEN SUM(B.UNIT_LOT) IS NOT NULL THEN COUNT(*)
ELSE 0
END  AS 投产批数
FROM WORKORDER_MST A
LEFT JOIN BATCH_DET B ON A.WOID=B.WOID
LEFT JOIN BATCH_MST C ON B.BAID=C.BAID  
GROUP BY A.WOID,A.WO_COUNT ORDER BY A.WOID ASC
";
        string setsqlfi = @"
SELECT 
SUBSTRING (BATCHID,1,15) AS 批号,
CASE WHEN SUM(OK_COUNT) IS NOT NULL THEN SUM(OK_COUNT)
ELSE 0
END 
+
CASE WHEN SUM(REJUDGE_COUNT) IS NOT NULL THEN SUM(REJUDGE_COUNT)
ELSE 0
END
+
CASE WHEN SUM(RE_PROCESSING_COUNT) IS NOT NULL THEN SUM(RE_PROCESSING_COUNT)
ELSE 0
END
+
CASE WHEN SUM(SCRAP_COUNT) IS NOT NULL THEN SUM(SCRAP_COUNT)
ELSE 0
END
AS TOTAL_COUNT
FROM BATCH_DET
WHERE BATCHID NOT IN ('{0}')
GROUP BY 
SUBSTRING (BATCHID,1,15),UNIT_LOT 
";
        string setsqlsi = @"
SELECT 
SUBSTRING (BATCHID,1,15) AS BATCHID,
CASE WHEN SUM(SCRAP_COUNT) IS NOT NULL THEN SUM(SCRAP_COUNT)
ELSE 0
END
AS TOTAL_COUNT
FROM POSTING_DET


";
        #endregion
        int i;
        public CBATCH()
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

        public void emptydatatable()
        {

            dt.Columns.Add("项次", typeof(string));
            dt.Columns.Add("工单号", typeof(string));
            dt.Columns.Add("批号", typeof(string));
            /*dt.Columns.Add("工单数量", typeof(decimal));*/
            dt.Columns.Add("单位批号量", typeof(decimal));
            /*dt.Columns.Add("物料编号", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("制单人", typeof(string));
            dt.Columns.Add("制单日期", typeof(string));*/


        }
        public DataTable emptydatatable_T()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("工单号", typeof(string));
            dt.Columns.Add("料号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("工单数量", typeof(string));
            dt.Columns.Add("途程代码", typeof(string));
            dt.Columns.Add("途程名称", typeof(string));
            dt.Columns.Add("途程版本", typeof(string));
            dt.Columns.Add("批号", typeof(string));
            dt.Columns.Add("当前站别代码", typeof(string));
            dt.Columns.Add("当前站别名称", typeof(string));
            dt.Columns.Add("当前执行规则", typeof(string));
            dt.Columns.Add("状态", typeof(string));
            dt.Columns.Add("单位批号量", typeof(string));
            dt.Columns.Add("OK数量", typeof(string));
            dt.Columns.Add("复判数量", typeof(string));
            dt.Columns.Add("重工数量", typeof(string));
            dt.Columns.Add("报废数量", typeof(string));
            dt.Columns.Add("内箱号", typeof(string));
            dt.Columns.Add("制单人", typeof(string));
            dt.Columns.Add("制单日期", typeof(string));
            return dt;
        }
        public DataTable RETURN_HAVE_ID_DT(DataTable dtx)
        {

            DataTable dt = emptydatatable_T();
            int i = 1;
            foreach (DataRow dr1 in dtx.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["工单号"] = dr1["工单号"].ToString();
                dr["序号"] = i.ToString();
                dr["料号"] = dr1["料号"].ToString();
                dr["品名"] = dr1["品名"].ToString();
                dr["工单数量"] = dr1["工单数量"].ToString();
                dr["途程代码"] = dr1["途程代码"].ToString();
                dr["途程名称"] = dr1["途程名称"].ToString();
                dr["途程版本"] = dr1["途程版本"].ToString();
                dr["批号"] = dr1["批号"].ToString();
                dr["当前站别代码"] = dr1["当前站别代码"].ToString();
                dr["当前站别名称"] = dr1["当前站别名称"].ToString();
                dr["当前执行规则"] = dr1["当前执行规则"].ToString();
                dr["状态"] = dr1["状态"].ToString();
                dr["单位批号量"] = dr1["单位批号量"].ToString();
                dr["OK数量"] = dr1["OK数量"].ToString();
                dr["复判数量"] = dr1["复判数量"].ToString();
                dr["重工数量"] = dr1["重工数量"].ToString();
                dr["报废数量"] = dr1["报废数量"].ToString();
                dr["内箱号"] = dr1["内箱号"].ToString();
                dr["制单人"] = dr1["制单人"].ToString();
                dr["制单日期"] = dr1["制单日期"].ToString();
                dt.Rows.Add(dr);
                i = i + 1;
            }

            return dt;

        }
        public decimal RETURN_BATCHID_TOTAL_COUNT(string BATCHID)
        {
            decimal d1 = 0;
            dt = bc.getdt(string.Format(sqlfi, BATCHID));
            DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", "批号='" + BATCHID.Substring(0, 15) + "'");
            if (dtx.Rows.Count > 0)
            {
                d1 = decimal.Parse(dtx.Rows[0]["TOTAL_COUNT"].ToString());
            }
            return d1;
        }
        public string GETID()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string v1 = bc.numYM(10, 4, "0001", "select * from BATCH_MST", "BAID", "BA");
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
            DataTable dtx = bc.getdt("SELECT * FROM BATCH_MST WHERE WOID='" + WOID + "'");
            if (dtx.Rows.Count > 0)
            {
            }
            else
            {
                dt = new DataTable();//删除数据库表时DATATABLE 重新实例化使客户端DATAGRIDVIEW数据显示一致，避免存在之前已经删除的数据
            }
            if (dt.Rows.Count > 0)
            {
            }
            else
            {
                emptydatatable();//dt在写入第一笔数据后不在新增新的例名，避免重复新增例名出错

            }
            if (bc.exists("SELECT * FROM BATCH_MST WHERE BAID='" + BAID + "'"))
            {
                SQlcommandE_DET(sqlo);
                IFExecution_SUCCESS = true;
            }
            else
            {
                SQlcommandE_DET(sqlo);
                SQlcommandE_MST(sqlt);
                IFExecution_SUCCESS = true;
            }
            ACTION_DET();

        }
        #endregion
        public DataTable ACTION_DET()
        {

            DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", string.Format("批号='{0}'", BATCHID));
            if (dtx.Rows.Count > 0)
            {
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["批号"] = BATCHID;
                dr["项次"] = SN;
                dr["工单号"] = WOID;
                dr["单位批号量"] = UNIT_LOT;
                dt.Rows.Add(dr);

            }
            return dt;
        }

        #region SQlcommandE_DET
        public void SQlcommandE_DET(string sql)
        {

            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            SqlConnection sqlcon = bc.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add("@BAKEY", SqlDbType.VarChar, 20).Value = BAKEY;
            sqlcom.Parameters.Add("@SN", SqlDbType.VarChar, 20).Value = SN;
            sqlcom.Parameters.Add("@BAID", SqlDbType.VarChar, 20).Value = BAID;
            sqlcom.Parameters.Add("@WOID", SqlDbType.VarChar, 20).Value = WOID;
            sqlcom.Parameters.Add("@BATCHID", SqlDbType.VarChar).Value = BATCHID;
            sqlcom.Parameters.Add("@UNIT_LOT", SqlDbType.VarChar, 20).Value = UNIT_LOT;
            sqlcom.Parameters.Add("@OK_COUNT", SqlDbType.VarChar, 20).Value = OK_COUNT;
            sqlcom.Parameters.Add("@REJUDGE_COUNT", SqlDbType.VarChar, 20).Value = REJUDGE_COUNT;
            sqlcom.Parameters.Add("@RE_PROCESSING_COUNT", SqlDbType.VarChar, 20).Value = RE_PROCESSING_COUNT;
            sqlcom.Parameters.Add("@SCRAP_COUNT", SqlDbType.VarChar, 20).Value = SCRAP_COUNT;
            sqlcom.Parameters.Add("@FCID", SqlDbType.VarChar, 20).Value = FCID;
            sqlcom.Parameters.Add("@FLOW_CHART_EDITION", SqlDbType.VarChar, 20).Value = FLOW_CHART_EDITION;
            sqlcom.Parameters.Add("@CURRENT_STID", SqlDbType.VarChar, 20).Value = CURRENT_STID;
            sqlcom.Parameters.Add("@STATUS", SqlDbType.VarChar, 20).Value = STATUS;
            sqlcom.Parameters.Add("@ACTION_RULE", SqlDbType.VarChar, 20).Value = ACTION_RULE;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = MAKERID;
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
            sqlcom.Parameters.Add("@BAID", SqlDbType.VarChar, 20).Value = BAID;
            sqlcom.Parameters.Add("@WOID", SqlDbType.VarChar, 20).Value = WOID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = MAKERID;
            sqlcom.Parameters.Add("@YEAR", SqlDbType.VarChar, 20).Value = year;
            sqlcom.Parameters.Add("@MONTH", SqlDbType.VarChar, 20).Value = month;
            sqlcom.Parameters.Add("@DAY", SqlDbType.VarChar, 20).Value = day;
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }
        #endregion
        #region ExcelPrint-for-epplus
        public void ExcelPrintForEpplus(DataTable dt2, string BillName, string Printpath)
        {
            // 使用 EPPlus 代替 Excel COM 组件
            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(Printpath)))
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    // 获取或创建第一个工作表
                    var worksheet = package.Workbook.Worksheets.Count > 0
                        ? package.Workbook.Worksheets[0]
                        : package.Workbook.Worksheets.Add("Sheet1");

                    // 清空指定区域的数据
                    worksheet.Cells[2, 2].Value = ""; // 批号
                    worksheet.Cells[2, 5].Value = ""; // 批号条码
                    worksheet.Cells[3, 2].Value = ""; // 批号数量
                    worksheet.Cells[3, 5].Value = ""; // 工单号
                    worksheet.Cells[3, 8].Value = ""; // 工单数量
                    worksheet.Cells[4, 2].Value = ""; // 料号
                    worksheet.Cells[4, 5].Value = ""; // 品名
                    worksheet.Cells[5, 2].Value = ""; // 途程代码
                    worksheet.Cells[5, 5].Value = ""; // 途程版本

                    // 清空 7-50 行，1-4 列的数据
                    for (int k = 7; k <= 50; k++)
                    {
                        for (int j = 1; j <= 4; j++)
                        {
                            worksheet.Cells[k, j].Value = "";
                        }
                    }

                    DataTable dtx2 = bc.getdt(sql);
                    DataTable dtx1 = bc.GET_DT_TO_DV_TO_DT(dtx2, "", string.Format("批号='{0}'", dt2.Rows[i]["批号"].ToString()));

                    if (dtx1.Rows.Count > 0)
                    {
                        // 填充数据
                        worksheet.Cells[2, 2].Value = dtx1.Rows[0]["批号"].ToString(); // 批号
                        worksheet.Cells[2, 5].Value = "*" + dtx1.Rows[0]["批号"].ToString() + "*"; // 批号条码
                        worksheet.Cells[3, 2].Value = dtx1.Rows[0]["单位批号量"].ToString(); // 批号数量
                        worksheet.Cells[3, 5].Value = dtx1.Rows[0]["工单号"].ToString(); // 工单号
                        worksheet.Cells[3, 8].Value = dtx1.Rows[0]["工单数量"].ToString(); // 工单数量
                        worksheet.Cells[4, 2].Value = dtx1.Rows[0]["料号"].ToString(); // 料号
                        worksheet.Cells[4, 5].Value = dtx1.Rows[0]["品名"].ToString(); // 品名
                        worksheet.Cells[5, 2].Value = dtx1.Rows[0]["途程代码"].ToString(); // 途程代码
                        worksheet.Cells[5, 5].Value = dtx1.Rows[0]["途程版本"].ToString(); // 途程版本

                        // 填充途程数据
                        for (int n = 0; n < dtx1.Rows.Count; n++)
                        {
                            worksheet.Cells[7 + n, 1].Value = dtx1.Rows[n]["途程项次"].ToString(); // 途程项次
                            worksheet.Cells[7 + n, 2].Value = dtx1.Rows[n]["站别代码"].ToString(); // 站别代码
                            worksheet.Cells[7 + n, 4].Value = dtx1.Rows[n]["站别名称"].ToString(); // 站别名称
                        }

                        // 保存文件
                        package.Save();

                        // 调用打印方法（需要确保 bc.csharpExcelPrint 方法兼容 EPPlus 生成的文件）
                        bc.csharpExcelPrint(Printpath);
                    }
                }
            }

            // 注意：EPPlus 使用 using 语句自动释放资源，不需要手动调用 GC.Collect()
        }
        #endregion
    }
}