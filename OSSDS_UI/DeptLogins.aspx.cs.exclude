using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Seed_DL;

public partial class DeptLogins : System.Web.UI.Page
{
    DataTable dt;
    CommonFuncs cf = new CommonFuncs();
    Masters objm = new Masters();
    HmpgDashBoard db = new HmpgDashBoard();
    string con;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();
        if (!IsPostBack)
        {
            getloginIDs();
            BindDistricts();
        }

    }
    protected void BindDistricts()
    {
        dt = new DataTable();
        dt = objm.GetDistricts("36", cf.getCurrentFinancialYear(), objm.GetSeasonByMonth(DateTime.Now.Month.ToString(), con), con);
        cf.BindDropDownLists(ddlDist, dt, "DistName", "DistCode", "Select District");
        cf.BindDropDownLists(ddldistnm, dt, "DistName", "DistCode", "Select District");
    }
    protected void getloginIDs()
    {
        try
        {
            dt = new DataTable();
            dt = db.GetUserIDs("dm", "0", "0", con);
            if (dt.Rows.Count > 0)
            {
                GVDmLogins.DataSource = dt;
                GVDmLogins.DataBind();
            }       


            dt = new DataTable();
            dt = db.GetUserIDs("dist", "0", "0", con);
            if (dt.Rows.Count > 0)
            {
                GvDistLogins.DataSource = dt;
                GvDistLogins.DataBind();
            }           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            dt = db.GetUserIDs("mand", ddlDist.SelectedValue, "0",  con);
            if (dt.Rows.Count > 0)
            {
                GvMandLogins.DataSource = dt;
                GvMandLogins.DataBind();
            }           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddldistnm_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = objm.GetMandals("36", ddldistnm.SelectedValue, cf.getCurrentFinancialYear(), objm.GetSeasonByMonth(DateTime.Now.Month.ToString(), con), con);
        cf.BindDropDownLists(ddlmand, dt, "MandName", "MandCode", "Select Mandal");
    }
    protected void ddlmand_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            dt = db.GetUserIDs("aeo", ddldistnm.SelectedValue, ddlmand.SelectedValue, con);
            if (dt.Rows.Count > 0)
            {
                GvAeoLogins.DataSource = dt;
                GvAeoLogins.DataBind();
            }
            else
            {
                GvAeoLogins.DataSource = null;
                GvAeoLogins.DataBind();
            }

            dt = new DataTable();
            dt = db.GetUserIDs("sp",ddldistnm.SelectedValue, ddlmand.SelectedValue, con);
            if (dt.Rows.Count > 0)
            {
                GVSpLogins.DataSource = dt;
                GVSpLogins.DataBind();
            }
            else
            {
                GVSpLogins.DataSource = null;
                GVSpLogins.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}