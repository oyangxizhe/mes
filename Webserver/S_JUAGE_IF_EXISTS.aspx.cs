using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using XizheC_SERVER;
using System.Text;

namespace WebServer
{
    public partial class S_JUAGE_IF_EXISTS : System.Web.UI.Page
    {
        basec bc = new basec();
        DataTable dt = new DataTable();
   
        StringBuilder sqb = new StringBuilder();
        private string _ErrowInfo;
        public string ErrowInfo
        {

            set { _ErrowInfo = value; }
            get { return _ErrowInfo; }
        }
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        private bool _JUAGE_IF_EXISTS;
        public bool JUAGE_IF_EXISTS
        {
            set { _JUAGE_IF_EXISTS = value; }
            get { return _JUAGE_IF_EXISTS; }

        }
        private string _TABLE_NAME;
        public string TABLE_NAME
        {

            set { _TABLE_NAME = value; }
            get { return _TABLE_NAME; }
        }
        private string _COLUMN_NAME;
        public string COLUMN_NAME
        {

            set { _COLUMN_NAME = value; }
            get { return _COLUMN_NAME; }
        }
        private string _COLUMN_VALUE;
        public string COLUMN_VALUE
        {

            set { _COLUMN_VALUE = value; }
            get { return _COLUMN_VALUE; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
            List<string> list2 = new List<string>();
            List<bool> list3 = new List<bool>();
           /* sqb = new StringBuilder();
            sqb.AppendFormat("JUAGE_IF_EXISTS={0}", '*');
            sqb.AppendFormat("&TABLE_NAME={0}", "PROJECT_INFO");
            sqb.AppendFormat("&COLUMN_NAME={0}", "PROJECT_ID");
            sqb.AppendFormat("&COLUMN_VALUE={0}", "DBXM1604001");
            string url1 = "http://" +"localhost"+ "/webserver/s_juage_if_exists.aspx";
            JArray jar1 = bc.RETURN_JARRAY(url1, sqb.ToString());
            MessageBox.Show(jar1[0].ToString());*/
            if (Request.Form["JUAGE_IF_EXISTS"] != "" && Request.Form["JUAGE_IF_EXISTS"] != null)
            {
                TABLE_NAME = Request.Form["TABLE_NAME"];
                COLUMN_NAME = Request.Form["COLUMN_NAME"];
                COLUMN_VALUE = Request.Form["COLUMN_VALUE"];
                JUAGE_IF_EXISTS = bc.exists(TABLE_NAME, COLUMN_NAME, COLUMN_VALUE, "");
                list3.Add(JUAGE_IF_EXISTS);
                Response.Write(JsonConvert.SerializeObject(true ));
            }
            else
            {
                Response.Write(JsonConvert.SerializeObject(true));
            }
        }
 
         
           
        
    }
}