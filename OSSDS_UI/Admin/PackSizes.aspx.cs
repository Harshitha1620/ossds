using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Seed_DL;

public partial class Admin_PackSizes : System.Web.UI.Page
{
    Masters objm = new Masters();
    //Admin ad = new Admin();
    DataTable dt;
    CommonFuncs objCommon = new CommonFuncs();
    string state,conkey;
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
            state = Session["StateCode"].ToString();
            conkey = Session["ConnKey"].ToString();
        }
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            //BindCrops();
            BindAgencies();
            BindGrid();
            BindScheme();
            random();
        }
    }
    protected void BindScheme()
    {
        //dt = objm.GetSchemes(conkey);
        objCommon.BindDropDownLists(ddlScheme, dt, "Scheme_Name", "Scheme_Id", "Select Scheme");
    }
    protected void BindAgencies()
    {
        try
        {
            dt = new DataTable();
            //dt = objm.GetAgencies(conkey);
            ddlAgency.Items.Clear();
            objCommon.BindDropDownLists(ddlAgency, dt, "AgencyName", "AgencyCode", "Select Agency");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindCrops()
    {
        try
        {
            dt = new DataTable();
            //dt = objm.GetCrops(ddlScheme.SelectedValue, conkey);
            ddlcropname.Items.Clear();
            objCommon.BindDropDownLists(ddlcropname, dt, "CropName", "CropCode", "Select Crop Name");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddlScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCrops();
    }
    protected void ddlcropname_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           BindCropVareity();
            dt=new DataTable();
            //dt = objm.GetPackSize(ddlAgency.SelectedValue, ddlcropname.SelectedValue, conkey);
            if (dt.Rows.Count > 0)
            {
                grdPckSizes.DataSource = dt;
                grdPckSizes.DataBind();
            }
            else
            {
                grdPckSizes.DataSource = null;
                grdPckSizes.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
     protected void BindCropVareity()
    {
        try
        {
            dt = new DataTable();
            //dt = objm.GetCropVarieties(ddlcropname.SelectedValue, conkey);
            objCommon.BindDropDownLists(seeds, dt, "CropVName", "CropVCode", "Select");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
     protected bool ValidatePage()
     {
         if (ddlAgency.SelectedIndex == 0)
         {
             objCommon.ShowAlertMessage("Select Agency ");
             ddlAgency.Focus();
             return false;
         }
         if (ddlcropname.SelectedIndex == 0)
         {
             objCommon.ShowAlertMessage("Select Crop ");
             ddlcropname.Focus();
             return false;
         }
         if (seeds.SelectedIndex == 0)
         {
             objCommon.ShowAlertMessage("Select Crop Variety");
             seeds.Focus();
             return false;
         }
         if (txtpcksz.Text == "")
         {
             objCommon.ShowAlertMessage("Enter Crop Pack Size ");
             txtpcksz.Focus();
             return false;
         }
         if (txtpcksz.Text != "")
         {
             bool val;
             val = obj.CheckInput_new(txtpcksz.Text);
             if (val == true)
             {
                 Response.Redirect("~/Error.aspx");
                 return false;
             }
             else
                 return true;
         }
         return false;
     }
    protected void Save_Click(object sender, EventArgs e)
    {
        check();
        if (ValidatePage())
        {
            try
            {
                dt = new DataTable();
                //dt = objm.InsertPackSize(ddlcropname.SelectedValue, seeds.SelectedValue, ddlAgency.SelectedValue, txtpcksz.Text.Trim(), conkey);
                if (dt.Rows.Count > 0)
                    objCommon.ShowAlertMessage("Not Saved");
                else
                {
                    objCommon.ShowAlertMessage("Saved");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    protected void BindGrid()
    {
        try
        {
            dt = new DataTable();
            //dt = objm.GetPackSize(conkey);
            if (dt.Rows.Count > 0)
            {
                grdPckSizes.DataSource = dt;
                grdPckSizes.DataBind();
            }
            else
            {
                grdPckSizes.DataSource = null;
                grdPckSizes.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddlAgency_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            //dt = objm.GetPackSize(ddlAgency.SelectedValue, conkey);
            if (dt.Rows.Count > 0)
            {
                grdPckSizes.DataSource = dt;
                grdPckSizes.DataBind();
            }
            else
            {
                grdPckSizes.DataSource = null;
                grdPckSizes.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void seeds_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            //dt = objm.GetPackSize(ddlAgency.SelectedValue, ddlcropname.SelectedValue, seeds.SelectedValue, conkey);
            if (dt.Rows.Count > 0)
            {
                grdPckSizes.DataSource = dt;
                grdPckSizes.DataBind();
            }
            else
            {
                grdPckSizes.DataSource = null;
                grdPckSizes.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void grdPckSizes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edt")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                BindAgencies();
                ddlAgency.SelectedValue = ((Label)gvrow.FindControl("lblagencycode")).Text.Trim();

                BindCrops();
                ddlcropname.SelectedValue = ((Label)gvrow.FindControl("lblcropcode")).Text;

                BindCropVareity();
                seeds.SelectedValue = ((Label)gvrow.FindControl("lblcvcode")).Text;

                txtpcksz.Text = ((Label)gvrow.FindControl("lblsize")).Text;
                lblaid.Text = ((Label)gvrow.FindControl("pckid")).Text;

                btnUpdate.Visible = true;
            }
            if (e.CommandName == "Dlt")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                lblaid.Text = ((Label)gvrow.FindControl("pckid")).Text;
                dt = new DataTable();
                //dt = objm.DeletePackSize(lblaid.Text, conkey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Failed to Delete");
                    BindGrid();
                }
                else
                {
                    objCommon.ShowAlertMessage("Pack Size Deleted.");
                    BindGrid();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        check();
        if (ValidatePage())
        {
            try
            {
                dt = new DataTable();
                //dt = objm.UpdatePackSize(ddlcropname.SelectedValue, seeds.SelectedValue, ddlAgency.SelectedValue, txtpcksz.Text, lblaid.Text, conkey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Failed to Update");
                    BindGrid();
                }
                else
                {
                    objCommon.ShowAlertMessage("Pack Size Updated.");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
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