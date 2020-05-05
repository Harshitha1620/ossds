using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;
using Seed_DL;
using Seed_BE;

public partial class ChangePWD : System.Web.UI.Page
{
    DataTable dt;
    CommonFuncs objCommon = new CommonFuncs();
    Login_DL objLogin = new Login_DL();
    Master_BE objbe = new Master_BE();
    Masters objm = new Masters();
    string user;
    string ConnKey = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        user = Session["UsrName"].ToString();
        if (!IsPostBack)
        {
            ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
        }
    }
    protected bool PageValidate()
    {
        if (txtOpwd.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Old Password");
            txtOpwd.Focus();
            return false;
        }
        if (txtNpwd.Text == "")
        {
            objCommon.ShowAlertMessage("Enter New Password");
            txtOpwd.Focus();
            return false;
        }
        if (txtCpwd.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Confirm Password");
            txtCpwd.Focus();
            return false;
        }
        return true;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (PageValidate())
        {
            objbe.year = objCommon.getCurrentFinancialYear();
            objbe.month = DateTime.Now.Month.ToString();
            objbe.season = objm.GetSeasonByMonth(objbe, ConnKey);
            objbe.userid = Session["UserID"].ToString();
            DataTable dtLogin = objLogin.GetLoginDetails(objbe, ConnKey);
            if (dtLogin.Rows.Count > 0)
            {
                string password = dtLogin.Rows[0]["Password"].ToString();
                string myval = ShaEncrypt(ViewState["KeyGenerator"].ToString());
                string value = ShaEncrypt(password.ToLower() + myval.ToLower());
                if (password.ToLower() != txtNewPwdHash.Value)
                {
                    if (txtOldPwdHash.Value == value.ToLower())
                    {
                        objbe.userid = user;
                        objbe.pwd = txtNewPwdHash.Value;
                        objbe.ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                        dt = objLogin.GetLoginDetails(objbe, ConnKey);
                        if (dt.Rows.Count > 0)
                        {
                            objCommon.ShowAlertMessage("Password successfully changed");
                            Response.Redirect("login.aspx");
                        }
                        else
                        {
                            txtOldPwdHash.Value = "";
                            txtNewPwdHash.Value = "";
                            objCommon.ShowAlertMessage("Invalid Old Password");
                        }
                    }
                    else
                    {
                        txtOldPwdHash.Value = "";
                        txtNewPwdHash.Value = "";
                        objCommon.ShowAlertMessage("Invalid Old Password");
                    }

                }
                else
                {
                    objCommon.ShowAlertMessage("New Password should not be same as old password");
                }
            }
            else
            {
                objCommon.ShowAlertMessage("New Password should not be same as old password");
            }
        }
    }

    public string ShaEncrypt(string Ptext)
    {
        string hash = "";
        System.Security.Cryptography.SHA256CryptoServiceProvider m1 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
        byte[] s1 = System.Text.Encoding.ASCII.GetBytes(Ptext);
        s1 = m1.ComputeHash(s1);
        foreach (byte bt in s1)
        {
            hash = hash + bt.ToString("x2");
        }
        return hash;
    }
}