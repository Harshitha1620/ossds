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

public partial class Admin_CompanyMaster : System.Web.UI.Page
{
    Masters objm = new Masters();
    Master_BE objbe = new Master_BE();
    CommonFuncs objCommon = new CommonFuncs();
    string UserName = "", conkey;
    DataTable dt;
    SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();

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
            conkey = Session["ConnKey"].ToString();
            UserName = Session["UsrName"].ToString();
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        }
        if (!IsPostBack)
        {
            random();
            this.txt_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
            viewdata();
            btn_Update.Visible = false;
        }
    }
    private void viewdata()
    {
        try
        {
            dt = new DataTable();
            objbe.Action = "R";
            dt = objm.Company_IUDR(objbe, conkey);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
            check();
            if (PageValidate())
            {
                objbe.active = rblactive.SelectedValue;
                objbe.efct_dt = objCommon.Texttodateconverter(txt_Date.Text.Trim());
                objbe.CompanyName = txtcmnyName.Text.Trim();
                objbe.username = UserName;
                objbe.Action = "I";
                dt = new DataTable();
                dt = objm.Company_IUDR(objbe, conkey);
                if (dt.Rows.Count > 0)
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                else
                    objCommon.ShowAlertMessage("Company Saved");
                txtcmnyName.Text = "";
                viewdata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected bool PageValidate()
    {
        if (txt_Date.Text == "")
        {
            objCommon.ShowAlertMessage("Please Select From Date");
            return false;
        }       
        if (txtcmnyName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Company Name");
            return false;
        }
        if (txt_Date.Text != "")
        {
            bool val;
            val = obj.CheckInput_new(txt_Date.Text);
            if (val == true)
            {
                Response.Redirect("~/Error.aspx");
                return false;
            }
            else
                return true;
        }
        if (txtcmnyName.Text != "")
        {
            bool val;
            val = obj.CheckInput_new(txtcmnyName.Text);
            if (val == true)
            {
                Response.Redirect("~/Error.aspx");
                return false;
            }
            else
                return true;
        }
        else
            return true;
    }
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_RowCancelling(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = -1;
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                objbe.CompanyID = ((Label)(gvrow.FindControl("lblcompcode"))).Text;
                objbe.Action = "D";
                dt = objm.Company_IUDR(objbe, conkey);
                if (dt.Rows.Count > 0)
                    objCommon.ShowAlertMessage("Deletion Failed");
                else
                    objCommon.ShowAlertMessage("Company Deleted");                
                viewdata();
            }
            if (e.CommandName == "Edt")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                txtcmnyName.Text = ((Label)(gvrow.FindControl("lblCpnm"))).Text;
                lblcompnycode.Text = ((Label)(gvrow.FindControl("lblcompcode"))).Text;
                string status = ((Label)(gvrow.FindControl("lblstatus"))).Text;
                txt_Date.Text = ((Label)(gvrow.FindControl("lbleffdate"))).Text;
                rblactive.SelectedValue = status;
                txt_Date.Enabled = true;
                btn_Update.Visible = true;
                btn_Save.Visible = false;
            }
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        check();
        try
        {
            objbe.active = rblactive.SelectedValue;
            objbe.efct_dt = objCommon.Texttodateconverter(txt_Date.Text.Trim());
            objbe.CompanyName = txtcmnyName.Text.Trim();
            objbe.username = UserName;
            objbe.CompanyID = lblcompnycode.Text;
            objbe.Action = "U";
            dt = new DataTable();
            dt = objm.Company_IUDR(objbe, conkey);          
            if (dt.Rows.Count > 0)
                objCommon.ShowAlertMessage("Unable to Update");
            else
            {
                objCommon.ShowAlertMessage("Updated Successfully");
                btn_Save.Visible = true;
                btn_Update.Visible = false;
            }
            viewdata();
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
