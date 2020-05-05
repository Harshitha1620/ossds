using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_DL;
using System.Data;
using System.Web.Security;
using Seed_BE;

public partial class Admin_Cropsale : System.Web.UI.Page
{
    Masters objm = new Masters();
    Master_BE objbe = new Master_BE();
    CommonFuncs objCommon = new CommonFuncs();
    string UserName = "", conkey;
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "Admin")
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            conkey = Session["ConnKey"].ToString();
        }
        if (!IsPostBack)
        {
            random();
            viewdata();
            Bindata();
        }
    }
    private void viewdata()
    {
        try
        {
            dt = new DataTable();
            objbe.Action = "S1";
            dt = objm.Crop_IUDR(objbe,conkey);
            GVsale.DataSource = dt;
            GVsale.DataBind();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    private void Bindata()
    {
        try
        {
            dt = new DataTable();
            objbe.Action = "S2";
            dt = objm.Crop_IUDR(objbe, conkey);
            Gvsalestock.DataSource = dt;
            Gvsalestock.DataBind();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtcrop = new DataTable();
            dtcrop.Columns.Add("CropCode", typeof(string));  
            int j = 0;
            foreach (GridViewRow gr in GVsale.Rows)
            {
                if (((CheckBox)gr.FindControl("chkSelct")).Checked == true)
                {
                    dtcrop.Rows.Add();
                    dtcrop.Rows[j]["CropCode"] = ((Label)gr.FindControl("lblcropcode")).Text;
                    j++;
                }
                if (j == 0)
                    objCommon.ShowAlertMessage("Select atleast one Crop");
            }
            objbe.TVP = dtcrop;
            objbe.Action = "I";
            dt = objm.Issustopsale(objbe, conkey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage("Not Saved, try again");
                viewdata();
            }
            else
            {
                objCommon.ShowAlertMessage(" Data Saved");
                viewdata();
                Bindata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtcrop = new DataTable();
            dtcrop.Columns.Add("CropCode", typeof(string));
            int j = 0;
            foreach (GridViewRow gr in Gvsalestock.Rows)
            {
                if (((CheckBox)gr.FindControl("chkSel")).Checked == true)
                {
                    dtcrop.Rows.Add();
                    dtcrop.Rows[j]["CropCode"] = ((Label)gr.FindControl("lblcropcode")).Text;
                    j++;
                }
                if (j == 0)
                    objCommon.ShowAlertMessage("Select atleast one row to Crop");
            }
            objbe.TVP = dtcrop;
            objbe.Action = "U";
            dt = objm.Issustopsale(objbe, conkey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage("Not Saved, try again");
                viewdata();
            }
            else
            {
                objCommon.ShowAlertMessage(" Data Updated");
                viewdata();
                Bindata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
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
            Response.Redirect("~/Error.aspx");
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
                HttpContext.Current.Response.Redirect("~/Error.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    
}