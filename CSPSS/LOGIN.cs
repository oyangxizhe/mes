using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using XizheC;
using System.IO;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSPSS
{
    public partial class LOGIN : Form
    {
        private static string _USID;
        public static string USID
        {
            set { _USID = value; }
            get { return _USID; }

        }

        private string _WATER_MARK_CONTENT;
        public string WATER_MARK_CONTENT
        {
            set { _WATER_MARK_CONTENT = value; }
            get { return _WATER_MARK_CONTENT; }

        }
        private static string _UNAME;
        public static string UNAME
        {
            set { _UNAME = value; }
            get { return _UNAME; }

        }
        private static string _EMID;
        public static string EMID
        {
            set { _EMID = value; }
            get { return _EMID; }

        }
        private static string _ENAME;
        public static string ENAME
        {
            set { _ENAME = value; }
            get { return _ENAME; }

        }
        private static string _DEPART;
        public static string DEPART
        {
            set { _DEPART = value; }
            get { return _DEPART; }

        }
        private static string _AUID;
        public static string AUID
        {
            set { _AUID = value; }
            get { return _AUID; }
        }
        int i;
        public byte[] PWD;
        basec bc = new basec();
        CUSER cuser = new CUSER();
        CFileInfo cfileinfo = new CFileInfo();

        public LOGIN()
        {
            InitializeComponent();
        }
        #region  InitializeComponent()
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labURight = new System.Windows.Forms.Label();
            this.labDepart = new System.Windows.Forms.Label();
            this.labUserID = new System.Windows.Forms.Label();
            this.hint = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码：";
            // 
            // labURight
            // 
            this.labURight.AutoSize = true;
            this.labURight.Location = new System.Drawing.Point(204, 160);
            this.labURight.Name = "labURight";
            this.labURight.Size = new System.Drawing.Size(0, 12);
            this.labURight.TabIndex = 7;
            // 
            // labDepart
            // 
            this.labDepart.AutoSize = true;
            this.labDepart.Location = new System.Drawing.Point(99, 103);
            this.labDepart.Name = "labDepart";
            this.labDepart.Size = new System.Drawing.Size(0, 12);
            this.labDepart.TabIndex = 8;
            this.labDepart.Visible = false;
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.Location = new System.Drawing.Point(88, 160);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(0, 12);
            this.labUserID.TabIndex = 9;
            this.labUserID.Visible = false;
            // 
            // hint
            // 
            this.hint.AutoSize = true;
            this.hint.Location = new System.Drawing.Point(99, 17);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(29, 12);
            this.hint.TabIndex = 11;
            this.hint.Text = "hint";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 120;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(70, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 80);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(70, 148);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(250, 37);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Enter += new System.EventHandler(this.btnLogin_Enter);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(70, 110);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "记住密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.hint);
            this.Controls.Add(this.labUserID);
            this.Controls.Add(this.labDepart);
            this.Controls.Add(this.labURight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "制造执行系统";
            this.Load += new System.EventHandler(this.LOGIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        DataTable dt = new DataTable();

    
    
        private void LOGIN_Load(object sender, EventArgs e)
        {
          
  
            //this.Text = "昆山多宾陈列展示有限公司项目管理系统";
            //this.Text = "项目管理系统";
            string v5 = AppDomain.CurrentDomain.BaseDirectory;//获取应用程序之前安装的路径 16/01/10
            try
            {
                if (File.Exists(v5 + "LOGIN_INFO.xml"))
                {
                    dt = basec.XML_TO_DT(v5 + "LOGIN_INFO.xml");
                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            this.comboBox1.Items.Add(dt.Rows[i]["UNAME"].ToString());
                        }
                        this.comboBox1.Text = dt.Rows[0]["UNAME"].ToString();
                        if (dt.Rows[0]["PWD"].ToString() != "")
                        {
                            string c = basec.DESDecrypt(dt.Rows[0]["PWD"].ToString(), "abcdefgh", "12345678");
                            textBox1.Text = c;
                        }
                        if (dt.Rows[0]["IF_RECORD"].ToString() == "Y")
                        {
                            checkBox1.Checked = true;
                        }

                    }
                }
                else
                {
                    dt = new DataTable();
                    dt.Columns.Add("UNAME", typeof(string));
                    dt.Columns.Add("PWD", typeof(string));
                    dt.Columns.Add("IF_RECORD", typeof(string));

                }
                
                label1.ForeColor = CCOLOR.SHS;
                label2.ForeColor = CCOLOR.SHS;
                checkBox1.ForeColor = CCOLOR.SHS;
                this.Icon = Resource1.xz_200X200;


                hint.Text = "";
                hint.ForeColor = Color.Red;
                textBox1.PasswordChar = '*';

                btnLogin.Size = new Size(250, 37);
                btnLogin.FlatStyle = FlatStyle.Flat;/*使BUTTON 采用IMG做底图*/
                btnLogin.FlatAppearance.BorderSize = 0;/*去掉底图黑线*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region 
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {


            if (this.ActiveControl.TabIndex == 113)
            {

            }
            else
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

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        #region login
        private void login()
        {
               if (cuser.JUAGE_LOGIN_IF_SUCCESS(comboBox1 .Text ,textBox1 .Text ))
                {
                 
                    DEPART = cuser.DEPART;
                    UNAME = comboBox1.Text;
                    ENAME = cuser.ENAME;
                    EMID = cuser.EMID;
                    USID = cuser.USID;
                   /*下面代码执行的是记住密码的操作 160127 start*/
                    try
                    {
                        string b = basec.DESEncrypt(textBox1.Text, "abcdefgh", "12345678");
                        if (dt.Rows .Count >0)
                        {
                            DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", "UNAME='" + comboBox1.Text + "'");
                            if (dtx.Rows.Count > 0)
                            {

                                for (i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["UNAME"].ToString() == comboBox1.Text)
                                    {
                                        if (checkBox1.Checked)
                                        {
                                            dt.Rows[i]["PWD"] = b;
                                            dt.Rows[i]["IF_RECORD"] = "Y";
                                        }
                                        else
                                        {
                                            dt.Rows[i]["PWD"] = "N";
                                            dt.Rows[i]["IF_RECORD"] = "N";

                                        }
                                        break;
                                    }
                                }
                                dt.TableName = "LOGIN_INFO";
                                dt.WriteXml("LOGIN_INFO.xml");

                            }
                            else
                            {
                                DataRow dr = dt.NewRow();
                                dr["UNAME"] = comboBox1.Text;
                                if (checkBox1.Checked)
                                {
                                    dr["PWD"] = b;
                                    dr["IF_RECORD"] = "Y";
                                }
                                else
                                {
                                    dr["PWD"] = "N";
                                    dr["IF_RECORD"] = "N";
                                }
                                dt.Rows.Add(dr);
                                dt.TableName = "LOGIN_INFO";
                                dt.WriteXml("LOGIN_INFO.xml");
                            }
                        }
                            else
                            {
                                DataRow dr = dt.NewRow();
                                dr["UNAME"] = comboBox1.Text;
                                if (checkBox1.Checked)
                                {
                                    dr["PWD"] = b;
                                    dr["IF_RECORD"] = "Y";
                                }
                                else
                                {
                                    dr["PWD"] = "N";
                                    dr["IF_RECORD"] = "N";
                                }
                                dt.Rows.Add(dr);
                                dt.TableName = "LOGIN_INFO";
                                dt.WriteXml("LOGIN_INFO.xml");
                            }
                      
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    /*下面代码执行的是记住密码的操作 160127 end*/
                    if (JUAGE_IF_ALREADY_LOGIN())
                    {
                    
                    }
                    else
                    {
                        AUID = cuser.GETID_AUID();
                        cuser.AUID = cuser.GETID_AUID();
                        cuser.SQlcommandE(cuser.sqlth);
                        MAIN frm = new MAIN();
                        this.Hide();
                        frm.Show();
                    }
                }
                else
                {

                    hint.Text = "密码不正确，请重新输入！";
                }

        }
        #endregion
        #region juage()
        private bool juage()
        {

            string uname = comboBox1.Text;
            string pwd = textBox1.Text;
            bool b = false;
           if (uname == "")
            {
                b = true;
                hint.Text = "用户名不能为空！";

            }
            else if (!bc.exists ("SELECT * FROM USERINFO WHERE UNAME='"+uname+"'"))
            {
                b = true;
                hint.Text = "用户名不存在！";
            }
            else if (pwd== "")
            {
                b = true;
                hint.Text = "密码不能为空！";

            }
            return b;

        }
        #endregion
        private bool JUAGE_IF_ALREADY_LOGIN()
        {
            bool b = false;
            try
            {
                DataTable  dtx = bc.getdt("SELECT * FROM AUTHORIZATION_USER WHERE USID='" + USID + "' AND STATUS='Y'");
                if (dtx.Rows.Count > 0)
                {
                    if (UNAME == "admin")
                    {
                    }
                    else
                    {
                        hint.Text = string.Format("您已登录 {0} 不能重复登录", UNAME);
                        b = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return b;
        }
        private void btnLogin_Enter(object sender, EventArgs e)
        {
            /*USID = "US13110001";
            UNAME = "admin";
            EMID = "1405001";
            ENAME = "系统管理";
            MAIN frm = new MAIN();
            this.Hide();
            frm.Show();*/
            try
            {
                if (bc.GET_SQLCONNECTION_STRING() == "")
                {
                    hint.Text = bc.ErrowInfo;
                }
                else if (juage())
                {
                }
                else
                {
                    login();

                }
                textBox1.Focus();/*执行BTNLOGIN 事件时将FOCUS移到其它控件避免选中时出现底框*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
           
                if (bc.GET_SQLCONNECTION_STRING() == "")
                {
                  
                    hint.Text = bc.ErrowInfo;
                }
                else if (juage())
                {
                }
                else
                {
                    login();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
            DataTable dtx = bc.GET_DT_TO_DV_TO_DT(dt, "", "UNAME='" + comboBox1.Text + "'");
            if (dtx.Rows.Count > 0)
            {

                if (dtx.Rows[0]["PWD"].ToString() != "N")
                {
                    string c = basec.DESDecrypt(dtx.Rows[0]["PWD"].ToString(), "abcdefgh", "12345678");
                    textBox1.Text = c;
                }
                else
                {
                    textBox1.Text = "";

                }
                if (dtx.Rows[0]["IF_RECORD"].ToString() == "Y")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;

                }

            }
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            string v1 = bc.POST("http://www.oyxxi.com/webserver_mes/s_connectionstring.aspx", "S_CONNECTIONSTRING=*");
            MessageBox.Show(v1);

        }

   

      

    

    }
}
