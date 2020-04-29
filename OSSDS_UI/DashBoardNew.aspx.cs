using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using Seed_DL;

public partial class DashBoard_Default : System.Web.UI.Page
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
            getReports();
           // GetChart();
        }
    }
    protected void getReports()
    {
        try
        {
            string PreviousSeason, PreviousYear;
            string season = objm.GetSeasonByMonth(DateTime.Now.Month.ToString(), con);
            string year = cf.getCurrentFinancialYear();

            lblyear.Text = year;
            lblseason.Text = season;

            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Stock", "Today", con);
            if (dt.Rows.Count > 0)
                lblStockToday.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Stock", "Week", con);
            if (dt.Rows.Count > 0)
                lblStockweek.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Stock", "Month", con);
            if (dt.Rows.Count > 0)
                lblStockmnth.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Stock", "Season", con);
            if (dt.Rows.Count > 0)
                lblstkseson.Text = dt.Rows[0][0].ToString();


            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "prmt", "Today", con);
            if (dt.Rows.Count > 0)
                lblPermitToday.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "prmt", "Week", con);
            if (dt.Rows.Count > 0)
                lblPermitWeek.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "prmt", "Month", con);
            if (dt.Rows.Count > 0)
                lblPermitMonth.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "prmt", "Season", con);
            if (dt.Rows.Count > 0)
                lblpermitSesn.Text = dt.Rows[0][0].ToString();


            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "sale", "Today", con);
            if (dt.Rows.Count > 0)
                lblSaleToday.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "sale", "Week", con);
            if (dt.Rows.Count > 0)
                lblSaleWeek.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "sale", "Month", con);
            if (dt.Rows.Count > 0)
                lblSaleMonth.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "sale", "Season", con);
            if (dt.Rows.Count > 0)
                lblSaleSesn.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Subsidy", "Today", con);
            if (dt.Rows.Count > 0)
                lblSubsidyToday.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Subsidy", "Week", con);
            if (dt.Rows.Count > 0)
                lblSubsidyWeek.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Subsidy", "Month", con);
            if (dt.Rows.Count > 0)
                lblSubsidyMonth.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Subsidy", "Season", con);
            if (dt.Rows.Count > 0)
                lblSubsidySesn.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Today", con);
            if (dt.Rows.Count > 0)
                lblFarmersToday.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Week", con);
            if (dt.Rows.Count > 0)
                lblFarmersWeek.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Month", con);
            if (dt.Rows.Count > 0)
                lblFarmersMonth.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Season", con);
            if (dt.Rows.Count > 0)
                lblFarmersSesn.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Crop", "GM", con);
            if (dt.Rows.Count > 0)
                lblgrnmnr.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Crop", "pulses", con);
            if (dt.Rows.Count > 0)
                lblpulses.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Crop", "cereal", con);
            if (dt.Rows.Count > 0)
                lblcereals.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "Crop", "OilSeeds", con);
            if (dt.Rows.Count > 0)
                lbloil.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "scst", "Today", con);
            if (dt.Rows.Count > 0)
                lblscstToday.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "scst", "Week", con);
            if (dt.Rows.Count > 0)
                lblscstweek.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "scst", "Month", con);
            if (dt.Rows.Count > 0)
                lblscstmnth.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "scst", "Season", con);
            if (dt.Rows.Count > 0)
                lblscstSeason.Text = dt.Rows[0][0].ToString();


            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "general", "Today", con);
            if (dt.Rows.Count > 0)
                lblGnToday.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "general", "Week", con);
            if (dt.Rows.Count > 0)
                lblGnWeek.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "general", "Month", con);
            if (dt.Rows.Count > 0)
                lblGnMnth.Text = dt.Rows[0][0].ToString();
            dt = new DataTable();
            dt = db.GetDashBoradDetails(year, season, "general", "Season", con);
            if (dt.Rows.Count > 0)
                lblGnSeason.Text = dt.Rows[0][0].ToString();

            // Previous Season
            if (season == "Kharif")
            {
                PreviousSeason = "Rabi";
                PreviousYear = cf.getPrviousFinancialYear();
            }
            else
            {
                PreviousSeason = "Kharif";
                PreviousYear = cf.getCurrentFinancialYear();
            }
            lblpyear.Text = PreviousYear;
            lblpseason.Text = PreviousSeason;
            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "Stock", "Season", con);
            if (dt.Rows.Count > 0)
                lblStockseason.Text = dt.Rows[0][0].ToString();


            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "prmt", "Season", con);
            if (dt.Rows.Count > 0)
                lblPermitSeason.Text = dt.Rows[0][0].ToString();


            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "sale", "Season", con);
            if (dt.Rows.Count > 0)
                lblSaleSeason.Text = dt.Rows[0][0].ToString();

          
            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "Subsidy", "Season", con);
            if (dt.Rows.Count > 0)
                lblSubsidySeason.Text = dt.Rows[0][0].ToString();

            
            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "farmerCnt", "Season", con);
            if (dt.Rows.Count > 0)
                lblFarmersSeason.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "Allotment", "Season", con);
            if (dt.Rows.Count > 0)
                lblAllot.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "male", "Season", con);
            if (dt.Rows.Count > 0)
                lblmale.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "female", "Season", con);
            if (dt.Rows.Count > 0)
                lblfemale.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "gn", "Season", con);
            if (dt.Rows.Count > 0)
                lblgn.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "sc", "Season", con);
            if (dt.Rows.Count > 0)
                lblsc.Text = dt.Rows[0][0].ToString();

            dt = new DataTable();
            dt = db.GetDashBoradDetails(PreviousYear, PreviousSeason, "st", "Season", con);
            if (dt.Rows.Count > 0)
                lblst.Text = dt.Rows[0][0].ToString();

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}