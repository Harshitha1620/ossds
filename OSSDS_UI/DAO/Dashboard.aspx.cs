//By Harshitha on 16/06/2020
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using Seed_DL;
using Seed_BE;
public partial class DAO_Dashboard : System.Web.UI.Page
{
    Masters objm = new Masters();
    DAOReports rprt = new DAOReports();
    DataTable dt;
    CommonFuncs cf = new CommonFuncs();
    SeedRequest sr = new SeedRequest();
    Master_BE objbe = new Master_BE();
    string dist, state, con;
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
        PrevBrowCache.enforceNoCache();
        //if (Session["UsrName"] == null && Session["Role"].ToString() != "District Agriculture Officer")
        if (Session["UsrName"] == null && Session["RoleID"].ToString() != "3")
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            dist = Session["distCode"].ToString();
            state = Session["StateCode"].ToString();
            con = Session["ConnKey"].ToString();
        }
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            try
            {
                //getReports();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }

    protected void getReports()
    {
        // pfc.AddFontFile("../Fonts/madfont.ttf");

        objbe.month = DateTime.Now.Month.ToString();


        lblyear.Text = objbe.year;
        lblSeason.Text = objbe.season;
        dt = new DataTable();

        dt = sr.ViewRequest(objbe, con);
        if (dt.Rows.Count > 0)
        {
            lbltitle.Visible = true;
            gvrequest.DataSource = dt;
            gvrequest.DataBind();
        }
        else
        {
            lbltitle.Visible = false;
            gvrequest.DataSource = null;
            gvrequest.DataBind();
        }

        dt = new DataTable();
        objbe.year = cf.getCurrentFinancialYear();
        objbe.season = objm.GetSeasonByMonth(objbe, con);
        objbe.distcd = dist;

        objbe.Action = "Alotmnt";
        dt = rprt.GetDetails(objbe, con);
        if (dt.Rows.Count > 0)
        {
            gvAllotment.DataSource = dt;
            gvAllotment.DataBind();
        }

        objbe.Action = "unfrzdAdmin";
        dt = rprt.GetDetails(objbe, con);
        if (dt.Rows.Count > 0)
        {
            gvUnfrzStk.DataSource = dt;
            gvUnfrzStk.DataBind();
        }
        
        dt = new DataTable();
        objbe.Action = "stock";
        dt = rprt.GetDetails(objbe, con);
        if (dt.Rows.Count > 0)
        {
            GvStock.DataSource = dt;
            GvStock.DataBind();
        }

        objbe.Action = "unfrzdDao";
        dt = rprt.GetDetails(objbe, con);
        if (dt.Rows.Count > 0)
        {
            gvUnfrzAllot.DataSource = dt;
            gvUnfrzAllot.DataBind();
        }
    }
}