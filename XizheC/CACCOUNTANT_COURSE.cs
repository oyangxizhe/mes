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

namespace XizheC
{
    public class CACCOUNTANT_COURSE
    {
        basec bc = new basec();
        DataTable dt = new DataTable();
        public CACCOUNTANT_COURSE()
        {

        }
      
        public string GETID()
        {
            string v1 = bc.numYM(10, 4, "0001", "SELECT * FROM ACCOUNTANT_COURSE", "ACID", "AC");
            string GETID = "";
            if (v1 != "Exceed Limited")
            {
                GETID = v1;
            }
            return GETID;
        }
        
    }
}
