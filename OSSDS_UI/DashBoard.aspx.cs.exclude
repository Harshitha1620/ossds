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

public partial class DashBoard : System.Web.UI.Page
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
            //getReports();
            GetChart();
            GetPrevChart();
        }
    }

    protected void getReports()
    {
        try
        {
            string season = objm.GetSeasonByMonth(DateTime.Now.Month.ToString(), con);
            string year = cf.getCurrentFinancialYear();

            lblyear.Text = year;
            lblseason.Text = season;

            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Stock", "Today", con);
            //if (dt.Rows.Count > 0)
            //    lblStockToday.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Stock", "Week", con);
            //if (dt.Rows.Count > 0)
            //    lblStockweek.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Stock", "Month", con);
            //if (dt.Rows.Count > 0)
            //    lblStockmnth.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Stock", "Season", con);
            //if (dt.Rows.Count > 0)
            //    lblStockseason.Text = dt.Rows[0][0].ToString();


            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "prmt", "Today", con);
            //if (dt.Rows.Count > 0)
            //    lblPermitToday.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "prmt", "Week", con);
            //if (dt.Rows.Count > 0)
            //    lblPermitWeek.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "prmt", "Month", con);
            //if (dt.Rows.Count > 0)
            //    lblPermitMonth.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "prmt", "Season", con);
            //if (dt.Rows.Count > 0)
            //    lblPermitSeason.Text = dt.Rows[0][0].ToString();


            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "sale", "Today", con);
            //if (dt.Rows.Count > 0)
            //    lblSaleToday.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "sale", "Week", con);
            //if (dt.Rows.Count > 0)
            //    lblSaleWeek.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "sale", "Month", con);
            //if (dt.Rows.Count > 0)
            //    lblSaleMonth.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "sale", "Season", con);
            //if (dt.Rows.Count > 0)
            //    lblSaleSeason.Text = dt.Rows[0][0].ToString();

            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Subsidy", "Today", con);
            //if (dt.Rows.Count > 0)
            //    lblSubsidyToday.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Subsidy", "Week", con);
            //if (dt.Rows.Count > 0)
            //    lblSubsidyWeek.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Subsidy", "Month", con);
            //if (dt.Rows.Count > 0)
            //    lblSubsidyMonth.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Subsidy", "Season", con);
            //if (dt.Rows.Count > 0)
            //    lblSubsidySeason.Text = dt.Rows[0][0].ToString();

            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Today", con);
            //if (dt.Rows.Count > 0)
            //    lblFarmersToday.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Week", con);
            //if (dt.Rows.Count > 0)
            //    lblFarmersWeek.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Month", con);
            //if (dt.Rows.Count > 0)
            //    lblFarmersMonth.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "farmerCnt", "Season", con);
            //if (dt.Rows.Count > 0)
            //    lblFarmersSeason.Text = dt.Rows[0][0].ToString();

            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Crop", "GM", con);
            //if (dt.Rows.Count > 0)
            //    lblgrnmnr.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Crop", "pulses", con);
            //if (dt.Rows.Count > 0)
            //    lblpulses.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Crop", "cereal", con);
            //if (dt.Rows.Count > 0)
            //    lblcereals.Text = dt.Rows[0][0].ToString();
            //dt = new DataTable();
            //dt = db.GetDashBoradDetails(year, season, "Crop", "OilSeeds", con);
            //if (dt.Rows.Count > 0)
            //    lbloil.Text = dt.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }


    private DataTableReader GetReader(string year,string season)
    {
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(db.GetChartDetails(year, season, "0", "0", "allotment", con));
        dataSet.Tables.Add(db.GetChartDetails(year, season, "0", "0", "stock", con));
        dataSet.Tables.Add(db.GetChartDetails(year, season, "0", "0", "sale", con));
        return dataSet.CreateDataReader();
    }

    private DataTableReader GetDist1Reader(string year, string season)
    {       
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(db.GetChartDetails(year, season, "501", "686", "DistAllot", con));
        dataSet.Tables.Add(db.GetChartDetails(year, season, "501", "686", "Diststock", con));
        dataSet.Tables.Add(db.GetChartDetails(year, season, "501", "686", "DistSale", con));
        return dataSet.CreateDataReader();
    }

    private DataTableReader GetDist2Reader(string year, string season)
    {
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(db.GetChartDetails(year, season, "687", "721", "DistAllot", con));
        dataSet.Tables.Add(db.GetChartDetails(year, season, "687", "721", "Diststock", con));
        dataSet.Tables.Add(db.GetChartDetails(year, season, "687", "721", "DistSale", con));
        return dataSet.CreateDataReader();
    }

    protected void GetChart()
    {
        string season = objm.GetSeasonByMonth(DateTime.Now.Month.ToString(), con);
        string year = cf.getCurrentFinancialYear();
        lblyear.Text = year;
        lblseason.Text = season;
        using (DataSet result = new DataSet())
        {
            DataTable Table1 = new DataTable();
            DataTable Table2 = new DataTable();
            DataTable Table3 = new DataTable();

            result.Tables.Add(Table1);
            result.Tables.Add(Table2);
            result.Tables.Add(Table3);

            DataTableReader reader = GetReader(year,season);

            result.Load(reader, LoadOption.OverwriteChanges, Table1, Table2,Table3);

            if (result.Tables[0].Rows.Count > 0)
            {
                Chart1.ChartAreas.Add("chtArea");
                //Chart1.ChartAreas[0].AxisX.Title = "Crop";
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                //Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 12, System.Drawing.FontStyle.Regular);

               // Chart1.ChartAreas[0].AxisY.Title = "Allotment-Stock Received-Sales ";
                //Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 12, System.Drawing.FontStyle.Regular);

                Chart1.Series.Add("Allotment");
                Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart1.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "CropName", result.Tables[0].DefaultView, "allotment");
                Chart1.Series[0].IsVisibleInLegend = true;
                //Chart1.Series[0].IsValueShownAsLabel = true;
                Chart1.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart1.Series[0]["PixelPointWidth"] = "50";
                Chart1.Series[0].Color = Color.Goldenrod;

                Chart1.Series.Add("Stock");
                Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart1.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "CropName", result.Tables[1].DefaultView, "stock");
                Chart1.Series[1].IsVisibleInLegend = true;
                //Chart1.Series[1].IsValueShownAsLabel = true;
                Chart1.Series[1].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart1.Series[1]["PixelPointWidth"] = "50";
                Chart1.Series[1].Color = Color.Tomato;

                Chart1.Series.Add("Sale");
                Chart1.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart1.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "CropName", result.Tables[2].DefaultView, "sale");
                Chart1.Series[2].IsVisibleInLegend = true;
                //Chart1.Series[2].IsValueShownAsLabel = true;
                Chart1.Series[2].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart1.Series[2]["PixelPointWidth"] = "50";
                Chart1.Series[2].Color = Color.Green;


                Chart1.Legends.Add("Crop");
                Chart1.Legends[0].LegendStyle = LegendStyle.Table;
                Chart1.Legends[0].TableStyle = LegendTableStyle.Wide;
                Chart1.Legends[0].Docking = Docking.Bottom;

            }
        }

        using (DataSet result = new DataSet())
        {
            DataTable Table1 = new DataTable();
            DataTable Table2 = new DataTable();
            DataTable Table3 = new DataTable();

            result.Tables.Add(Table1);
            result.Tables.Add(Table2);
            result.Tables.Add(Table3);

            DataTableReader reader1 = GetDist1Reader(year, season);

            result.Load(reader1, LoadOption.OverwriteChanges, Table1,Table2,Table3);

            if (result.Tables[0].Rows.Count > 0)
            {
                Chart2.ChartAreas.Add("chtArea");
                Chart2.ChartAreas[0].AxisX.Interval = 1;
                Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                Chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

                Chart2.Series.Add("Allotment");
                Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart2.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "DistName", result.Tables[0].DefaultView, "allotment");
                Chart2.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart2.Series[0]["PixelPointWidth"] = "50";
                Chart2.Series[0].Color = Color.Goldenrod;

                Chart2.Series.Add("Stock");
                Chart2.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart2.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "DistName", result.Tables[1].DefaultView, "stock");               
                Chart2.Series[1].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart2.Series[1]["PixelPointWidth"] = "50";
                Chart2.Series[1].Color = Color.Tomato;


                Chart2.Series.Add("Sale");
                Chart2.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart2.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "DistName", result.Tables[2].DefaultView, "sale");
                Chart2.Series[2].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart2.Series[2]["PixelPointWidth"] = "50";
                Chart2.Series[2].Color = Color.Green;
                    
            }
        }


        using (DataSet result = new DataSet())
        {
            DataTable Table1 = new DataTable();
            DataTable Table2 = new DataTable();
            DataTable Table3 = new DataTable();

            result.Tables.Add(Table1);
            result.Tables.Add(Table2);
            result.Tables.Add(Table3);

            DataTableReader reader2 = GetDist2Reader(year, season);

            result.Load(reader2, LoadOption.OverwriteChanges, Table1, Table2, Table3);

            if (result.Tables[0].Rows.Count > 0)
            {
                Chart3.ChartAreas.Add("chtArea");
                Chart3.ChartAreas[0].AxisX.Interval = 1;
                Chart3.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                Chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                     
                Chart3.Series.Add("Allotment");
                Chart3.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart3.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "DistName", result.Tables[0].DefaultView, "allotment");
                Chart3.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart3.Series[0]["PixelPointWidth"] = "50";
                Chart3.Series[0].Color = Color.Goldenrod;
                     
                Chart3.Series.Add("Stock");
                Chart3.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart3.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "DistName", result.Tables[1].DefaultView, "stock");
                Chart3.Series[1].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart3.Series[1]["PixelPointWidth"] = "50";
                Chart3.Series[1].Color = Color.Tomato;
                     
                     
                Chart3.Series.Add("Sale");
                Chart3.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart3.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "DistName", result.Tables[2].DefaultView, "sale");
                Chart3.Series[2].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart3.Series[2]["PixelPointWidth"] = "50";
                Chart3.Series[2].Color = Color.Green;

            }
        }

    }

    protected void GetPrevChart()
    {
        
        string season = objm.GetSeasonByMonth(DateTime.Now.Month.ToString(), con);
        string PreviousSeason, PreviousYear;

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
        lblprevYear.Text = PreviousYear;
        lblprevSeason.Text = PreviousSeason;
        using (DataSet result = new DataSet())
        {
            DataTable Table1 = new DataTable();
            DataTable Table2 = new DataTable();
            DataTable Table3 = new DataTable();

            result.Tables.Add(Table1);
            result.Tables.Add(Table2);
            result.Tables.Add(Table3);

            DataTableReader reader = GetReader(PreviousYear, PreviousSeason);

            result.Load(reader, LoadOption.OverwriteChanges, Table1, Table2, Table3);

            if (result.Tables[0].Rows.Count > 0)
            {
                Chart4.ChartAreas.Add("chtArea");
                Chart4.ChartAreas[0].AxisX.Interval = 1;
                Chart4.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                Chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart4.Series.Add("Allotment");
                Chart4.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart4.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "CropName", result.Tables[0].DefaultView, "allotment");
                Chart4.Series[0].IsVisibleInLegend = true;
                Chart4.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart4.Series[0]["PixelPointWidth"] = "50";
                Chart4.Series[0].Color = Color.Goldenrod;
                Chart4.Series.Add("Stock");
                Chart4.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart4.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "CropName", result.Tables[1].DefaultView, "stock");
                Chart4.Series[1].IsVisibleInLegend = true;
                Chart4.Series[1].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart4.Series[1]["PixelPointWidth"] = "50";
                Chart4.Series[1].Color = Color.Tomato;
                Chart4.Series.Add("Sale");
                Chart4.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart4.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "CropName", result.Tables[2].DefaultView, "sale");
                Chart4.Series[2].IsVisibleInLegend = true;
                Chart4.Series[2].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart4.Series[2]["PixelPointWidth"] = "50";
                Chart4.Series[2].Color = Color.Green;
                Chart4.Legends.Add("Crop");
                Chart4.Legends[0].LegendStyle = LegendStyle.Table;
                Chart4.Legends[0].TableStyle = LegendTableStyle.Wide;
                Chart4.Legends[0].Docking = Docking.Bottom;

            }
        }

        using (DataSet result = new DataSet())
        {
            DataTable Table1 = new DataTable();
            DataTable Table2 = new DataTable();
            DataTable Table3 = new DataTable();

            result.Tables.Add(Table1);
            result.Tables.Add(Table2);
            result.Tables.Add(Table3);

            DataTableReader reader1 = GetDist1Reader(PreviousYear, PreviousSeason);

            result.Load(reader1, LoadOption.OverwriteChanges, Table1, Table2, Table3);

            if (result.Tables[0].Rows.Count > 0)
            {
                Chart5.ChartAreas.Add("chtArea");
                Chart5.ChartAreas[0].AxisX.Interval = 1;
                Chart5.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                Chart5.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart5.Series.Add("Allotment");
                Chart5.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart5.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "DistName", result.Tables[0].DefaultView, "allotment");
                Chart5.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart5.Series[0]["PixelPointWidth"] = "50";
                Chart5.Series[0].Color = Color.Goldenrod;
                Chart5.Series.Add("Stock");
                Chart5.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart5.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "DistName", result.Tables[1].DefaultView, "stock");
                Chart5.Series[1].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart5.Series[1]["PixelPointWidth"] = "50";
                Chart5.Series[1].Color = Color.Tomato;
                Chart5.Series.Add("Sale");
                Chart5.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart5.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "DistName", result.Tables[2].DefaultView, "sale");
                Chart5.Series[2].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart5.Series[2]["PixelPointWidth"] = "50";
                Chart5.Series[2].Color = Color.Green;

            }
        }


        using (DataSet result = new DataSet())
        {
            DataTable Table1 = new DataTable();
            DataTable Table2 = new DataTable();
            DataTable Table3 = new DataTable();

            result.Tables.Add(Table1);
            result.Tables.Add(Table2);
            result.Tables.Add(Table3);

            DataTableReader reader2 = GetDist2Reader(PreviousYear, PreviousSeason);

            result.Load(reader2, LoadOption.OverwriteChanges, Table1, Table2, Table3);

            if (result.Tables[0].Rows.Count > 0)
            {
                Chart6.ChartAreas.Add("chtArea");
                Chart6.ChartAreas[0].AxisX.Interval = 1;
                Chart6.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                Chart6.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart6.Series.Add("Allotment");
                Chart6.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart6.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "DistName", result.Tables[0].DefaultView, "allotment");
                Chart6.Series[0].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart6.Series[0]["PixelPointWidth"] = "50";
                Chart6.Series[0].Color = Color.Goldenrod;
                Chart6.Series.Add("Stock");
                Chart6.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart6.Series[1].Points.DataBindXY(result.Tables[1].DefaultView, "DistName", result.Tables[1].DefaultView, "stock");
                Chart6.Series[1].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart6.Series[1]["PixelPointWidth"] = "50";
                Chart6.Series[1].Color = Color.Tomato;
                Chart6.Series.Add("Sale");
                Chart6.Series[2].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                Chart6.Series[2].Points.DataBindXY(result.Tables[2].DefaultView, "DistName", result.Tables[2].DefaultView, "sale");
                Chart6.Series[2].ToolTip = "Data Point Y Value: #VALY{G}";
                Chart6.Series[2]["PixelPointWidth"] = "50";
                Chart6.Series[2].Color = Color.Green;

            }
        }

    }
}