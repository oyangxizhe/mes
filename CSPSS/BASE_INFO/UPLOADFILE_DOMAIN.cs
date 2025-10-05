using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using XizheC;
namespace CSPSS.BASE_INFO
{
    public partial class UPLOADFILE_DOMAIN : Form
    {
      
        protected string M_str_sql = @"select A.USID AS USID,A.UNAME AS UNAME,A.EMID AS EMID,B.ENAME AS ENAME,A.PWD AS PWD,
(SELECT ENAME FROM EMPLOYEEINFO  WHERE EMID=A.MAKERID) AS MAKER,A.DATE AS DATE from   USERINFO  A LEFT JOIN EMPLOYEEINFO B ON A.EMID=B.EMID";
        basec bc = new basec();
        CUSER cuser = new CUSER();
        private bool _IFExecutionSUCCESS;
        public bool IFExecution_SUCCESS
        {
            set { _IFExecutionSUCCESS = value; }
            get { return _IFExecutionSUCCESS; }

        }
        public UPLOADFILE_DOMAIN()
        {
            InitializeComponent();
        }

  
        #region bind()
        private void bind()
        {

            textBox1.BackColor = Color.Yellow;
         
            hint.ForeColor = Color.Red;
            if (bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS) != "")
            {
                hint.Text = bc.GET_IFExecutionSUCCESS_HINT_INFO(IFExecution_SUCCESS);
            }
            else
            {
                hint.Text = "";
            }
            if (bc.exists("SELECT * FROM UPLOADFILE_DOMAIN"))
                textBox1.Text = bc.getOnlyString("SELECT UPLOADFILE_DOMAIN FROM UPLOADFILE_DOMAIN");
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                save();
            }
            catch (Exception)
            {


            }
        }
        #region save
        protected void save()
        {
            hint.Text = "";
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string varMakerID = LOGIN.EMID;
     
            if (!juage1())
            {

            }

            else
            {


                string sql = @"
INSERT INTO UPLOADFILE_DOMAIN
(
UPLOADFILE_DOMAIN,
MAKERID,
DATE
)
VALUES 
(
@UPLOADFILE_DOMAIN,
@MAKERID,
@DATE
)
";
                string sqlo = @"
UPDATE UPLOADFILE_DOMAIN SET 
UPLOADFILE_DOMAIN=@UPLOADFILE_DOMAIN,
MAKERID=@MAKERID,
DATE=@DATE ";
                if (!bc.exists("SELECT * FROM UPLOADFILE_DOMAIN"))
                {
                    SQlcommandE(sql);
                 
                }
                else
                {
                    SQlcommandE(sqlo);
                 
                }

            }

            
        }
        #endregion
        #region SQlcommandE
        protected void SQlcommandE(string sql)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string varDate = DateTime.Now.ToString("yyy/MM/dd HH:mm:ss").Replace("-", "/");
            string varMakerID = LOGIN.EMID;
            SqlConnection con = bc.getcon();
            SqlCommand sqlcom = new SqlCommand(sql, con);
            sqlcom.Parameters.Add("@UPLOADFILE_DOMAIN", SqlDbType.VarChar, 20).Value = textBox1.Text;
            sqlcom.Parameters.Add("@MAKERID", SqlDbType.VarChar, 20).Value = varMakerID;
            sqlcom.Parameters.Add("@DATE", SqlDbType.VarChar, 20).Value = varDate;
            con.Open();
            sqlcom.ExecuteNonQuery();
            con.Close();
            IFExecution_SUCCESS = true;
            bind();
          
        }
        #endregion
        #region juage1()
        private bool juage1()
        {
         
            bool ju = true;

            if (textBox1.Text == "")
            {
                ju = false;
                hint.Text = "IP或域名不能为空！";

            }
           /* else if (bc.checkEmail(textBox1.Text) == false)
            {
                ju = false;
                hint.Text = "密码只能输入数字字母的组合！";

            }
            else if (textBox1.Text.Length < 6)
            {
                ju = false;
                hint.Text = "密码长度需大于6位！";

            }
            else if (!bc.checkNumber(textBox1.Text))
            {
                ju = false;
                hint.Text = "密码需是数字与字母的组合！";

            }
            else if (!bc.checkLetter(textBox1.Text))
            {
                ju = false;
                hint.Text = "密码需是数字与字母的组合！";

            }*/
         
            return ju;
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter &&
             (
             (
              !(ActiveControl is System.Windows.Forms.TextBox) ||
              !((System.Windows.Forms.TextBox)ActiveControl).AcceptsReturn)
             )
             )
            {
                SendKeys.SendWait("{Tab}");
                return true;
            }
            if (keyData == (Keys.Enter | Keys.Shift))
            {
                SendKeys.SendWait("+{Tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void UPLOADFILE_DOMAIN_Load(object sender, EventArgs e)
        {
            bind();
        }
    }
}
