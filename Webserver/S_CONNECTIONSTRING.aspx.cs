using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XizheC_SERVER;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Webserver
{
    public partial class S_CONNECTIONSTRING : System.Web.UI.Page
    {
        basec bc = new basec();
        private string _CONNECTIONSTRING;
        public string CONNECTIONSTRING
        {

            set { _CONNECTIONSTRING = value; }
            get { return _CONNECTIONSTRING; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Form["conn-token"] != "" && Request.Form["conn-token"] != null)
                {
                    //验证调用的令牌
                    if (Request.Form["conn-token"].ToString() == ConfigurationManager.AppSettings["conn-token"].ToString())
                    {
                        string M_str_sqlcon = ConfigurationManager.AppSettings["ConnectionDB"].ToString();
                        List<string> list1 = new List<string>();
                        CONNECTIONSTRING = M_str_sqlcon;
                        list1.Add(CONNECTIONSTRING);
                        Response.Write(JsonConvert.SerializeObject(list1));
                    }

                }

            }
            catch (Exception ex)
            {
                List<string> list1 = new List<string>();
                list1.Add(ex.Message);
                Response.Write(JsonConvert.SerializeObject(list1));
            }
        }
    }
}