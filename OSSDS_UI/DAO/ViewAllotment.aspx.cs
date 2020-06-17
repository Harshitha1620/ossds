using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_DL;
using Seed_BE;

public partial class DAO_ViewAllotment : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
    Masters objm = new Masters();
    DataTable dt;
    Admin ad = new Admin();
    string dist, conkey;
    Master_BE objbe = new Master_BE();
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
        //clear Caching 
        PrevBrowCache.enforceNoCache();

        //if (Session["UsrName"] == null && Session["Role"].ToString() != "District Agriculture Officer")
        if (Session["UsrName"] == null && Session["RoleID"].ToString() != "3")
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            dist = Session["distCode"].ToString();
            conkey = Session["ConnKey"].ToString();
        }
        if (!IsPostBack)
        {
            random();
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();

            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            lblyear.Text = cf.getCurrentFinancialYear();
            objbe.month = DateTime.Now.Month.ToString();
            objbe.Action = "Season";
            lblseason.Text = objm.GetSeasonByMonth(objbe, conkey);
            objbe.season = lblseason.Text;

            if (lblseason.Text == "Kharif")
            {
                lblseason.Text = "VANAKALAM";
            }
            else if (lblseason.Text == "Rabi")
            {
                lblseason.Text = "YASANGI";
            }
            BindGrid();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    public void BindGrid()
    {
        check();
        try
        {
            dt = new DataTable();
            objbe.Action = "distWs";
            objbe.year = lblyear.Text;
            objbe.distcd = dist;
            dt = ad.GetFreezedAllotmentsDistWs(objbe, conkey);
            if (dt.Rows.Count > 0)
            {
                SeedGrid.DataSource = dt;
                SeedGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void AllotSeed(object sender, EventArgs e)
    {
        try
        {
            LinkButton b = (LinkButton)sender;
            string arguments = b.CommandArgument;
            string[] args = arguments.Split(',');
            string year = args[0].ToString();
            string season = args[1].ToString();
            Session["year"] = args[0].ToString();
            Session["season"] = args[1].ToString();
            Session["cropNm"] = args[2].ToString();
            Session["crop"] = args[3].ToString();

            Session["qty"] = args[4].ToString();
            Session["Aid"] = args[5].ToString();
            Session["qtyLeft"] = args[6].ToString();
            Session["agency"] = args[7].ToString();
            Session["scheme"] = args[8].ToString();
            Session["AgencyNm"] = args[9].ToString();
            Session["SchemeNm"] = args[10].ToString();
            Session["cv"] = args[11].ToString();
            Session["cvname"] = args[12].ToString();
            Response.Redirect("SeedAllotment.aspx", false);
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