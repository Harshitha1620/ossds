using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_DL;
using Seed_BE;
using System.Data;
using System.Web.Security;
using System.Configuration;


public partial class login : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    string ConnKey = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();
    string year,season;
    Masters objm = new Masters();
    Master_BE objbe = new Master_BE();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtUname.Attributes.Add("autocomplete", "off");
        txtPwd.Attributes.Add("autocomplete", "off");
        if (!IsPostBack)
        {
            random();
            ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
            txtUname.Focus();
            //getCaptchaImage();
            
        }
    }
    protected bool CheckCaptcha()
    {
        //if (captch.Text == ViewState["captchtext"].ToString())
        //{
        //    return true;
        //}
        //else
        //{
        //    lblmsg.Text = "image code is not valid.";
        //    captch.Text = "";
        //    return false;
        //}
        return true;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        check();
        try
        {
            if (CheckCaptcha())
            {
                Login_DL objLogin = new Login_DL();
                objbe.month=DateTime.Now.Month.ToString();
                objbe.season = objm.GetSeasonByMonth(objbe, ConnKey);
                objbe.year = objCommon.getCurrentFinancialYear();
                objbe.username = txtUname.Text.Trim();
                objbe.Action = "R";
                DataTable dtLogin = objLogin.GetLoginDetails(objbe, ConnKey);
                if (dtLogin.Rows.Count > 0)
                {
                    string password = dtLogin.Rows[0]["Password"].ToString();
                    string StateCode = dtLogin.Rows[0]["StateCode"].ToString();
                    string DistCode = dtLogin.Rows[0]["DistCode"].ToString();
                    string MandCode = dtLogin.Rows[0]["MandCode"].ToString();
                    string SPCode = dtLogin.Rows[0]["code"].ToString();
                    string district = dtLogin.Rows[0]["DistName"].ToString();
                    string mandal = dtLogin.Rows[0]["MandName"].ToString();
                    string roleNm = dtLogin.Rows[0]["role_name"].ToString();
                    string section = dtLogin.Rows[0]["section"].ToString();

                    string myval = ShaEncrypt(ViewState["KeyGenerator"].ToString());
                    string value = ShaEncrypt(password.ToLower() + myval.ToLower());

                    if (txtPwdHash.Value == value.ToLower())
                    {

                        string guid = Guid.NewGuid().ToString();
                        Session["AuthToken"] = guid;                        
                        Response.ClearContent();
                        Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                        Session["ConnKey"] = ConnKey;

                        objbe.username = txtUname.Text.Trim();
                        objbe.date_time = DateTime.Now;
                        objbe.ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                        objbe.loginStatus = "Login Successful";
                        Session["UserID"] = objLogin.UserLoginStatus(objbe, ConnKey);

                        //if (password.ToUpper() == "6B4C8CBCB6B66F050C12D6A0203C58A8BC6D36E5A8C28B74111681F7AECE378A")
                        //{
                        //    Session["Role"] = roleNm;
                        //    Session["UsrName"] = txtUname.Text;
                        //    Session["StateCode"] = StateCode;
                        //    Session["SpCode"] = SPCode;
                        //    Session["distCode"] = DistCode;
                        //    Session["mandcode"] = MandCode;
                        //    Session["district"] = district;
                        //    Session["mandal"] = mandal;
                        //    Response.Redirect("ChangePWD.aspx", false);
                        //}

                        //else
                        if (dtLogin.Rows[0]["Role"].ToString() == "2")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["SpCode"] = SPCode;
                            Session["distCode"] = DistCode;
                            Session["mandcode"] = MandCode;
                            Session["district"] = district;
                            Session["mandal"] = mandal;
                            Response.Redirect("~/Salepoint/DashBoard.aspx",false);
                        }
                        else if (dtLogin.Rows[0]["Role"].ToString() == "1")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["Section"] = section;
                            Response.Redirect("~/Admin/DashBoard.aspx",false);
                        }
                        else if (dtLogin.Rows[0]["Role"].ToString() == "0")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Response.Redirect("~/SuperAdmin/Discussion.aspx",false);
                        }
                        else if (dtLogin.Rows[0]["Role"].ToString() == "3")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["distCode"] = DistCode;
                            Session["district"] = district;
                           Response.Redirect("~/DAO/Dashboard.aspx",false);
                        }
                        else if (dtLogin.Rows[0]["Role"].ToString() == "4")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["distCode"] = DistCode;
                            Session["district"] = district;
                            Session["mandcode"] = MandCode;
                            Session["mandal"] = mandal;
                            Response.Redirect("~/MAO/DashBoard.aspx",false);
                        }
                        else if (dtLogin.Rows[0]["Role"].ToString() == "5")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["distCode"] = DistCode;
                            Session["district"] = district;
                            Session["mandcode"] = MandCode;
                            Session["mandal"] = mandal;
                            Session["repid"] = dtLogin.Rows[0]["code"].ToString();
                            Response.Redirect("~/Rep/home.aspx",false);
                        }
                        else if (dtLogin.Rows[0]["Role"].ToString() == "6")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["distCode"] = DistCode;
                            Session["district"] = district;
                            Session["agency_id"] = dtLogin.Rows[0]["code"].ToString();
                            Response.Redirect("~/DM/home.aspx", false);
                        }

                        else if (dtLogin.Rows[0]["Role"].ToString() == "7")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["agency_id"] = dtLogin.Rows[0]["code"].ToString();
                            Response.Redirect("~/SM/home.aspx", false);
                        }
                        else if (dtLogin.Rows[0]["Role"].ToString() == "8")
                        {
                            Session["Role"] = roleNm;
                            Session["UsrName"] = txtUname.Text;
                            Session["StateCode"] = StateCode;
                            Session["Section"] = section;
                            Response.Redirect("~/NFSM/DashBoard.aspx", false);
                        }
                    }
                    else
                    {
                        //captch.Text = "";
                        ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                        getCaptchaImage();
                        objCommon.ShowAlertMessage("Invalid Username & Password");
                    }
                }
                else
                {
                    //captch.Text = "";
                    ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                    getCaptchaImage();
                    objCommon.ShowAlertMessage("Please Enter Valid user name");

                }
            }
            else
            {
                //captch.Text = "";
                ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                getCaptchaImage();
                lblmsg.Text = "The characters you entered didn't match.Please try again";

            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //Response.Redirect("~/Error.aspx");
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

    public void getCaptchaImage()
    {
        Captcha ci = new Captcha();
        string text = Captcha.generateRandomCode();
        ViewState["captchtext"] = text;
        //Image2.ImageUrl = "~/cpImg/cpImage.aspx?randomNo=" + text;
    }
    protected void btnImgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        //captch.Text = "";
        getCaptchaImage();
    }



    public void random()
    {
        try
        {
            string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string num = "";
            Random rm = new Random();
            for (int i = 0; i < 16; i++)
            {
                int randomcharindex = rm.Next(0, strString.Length);
                char randomchar = strString[randomcharindex];
                num += Convert.ToString(randomchar);
            }

            Response.Cookies.Add(new HttpCookie("ASPFIXATION2", num));
            hf.Value = num;
            Session["ASPFIXATION2"] = num;
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx",false);
        }
    }
    public void check()
    {
        try
        {
            string cookie_value = null;
            string session_value = null;
            //cookie_value = System.Web.HttpContext.Current.Request.Cookies["ASPFIXATION2"].Value;
            cookie_value = hf.Value;
            session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
            if (cookie_value != session_value)
            {
                System.Web.HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.Redirect("~/Error.aspx",false);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}