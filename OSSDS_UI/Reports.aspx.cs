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

public partial class DashBoard : System.Web.UI.Page
{

    DataTable dt;
    CommonFuncs cf = new CommonFuncs(); 
    Masters objm = new Masters();
    HmpgDashBoard db = new HmpgDashBoard();
    string  con;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();

        if (!IsPostBack)
        {
            getReports();
        }

    }

    protected void getReports()
    {
        try
        {
            string season = objm.GetSeasonByMonth(DateTime.Now.Month.ToString(), con);
            string year = cf.getCurrentFinancialYear();

            dt = new DataTable();
            dt = db.GetDetails("DistWsstock", year, season, con);
            Session["GvdistStock"] = dt;
            if (dt.Rows.Count > 0)
            {
                GvdistStock.DataSource = dt;
                GvdistStock.DataBind();
            }

            dt = db.GetDetails("DistWsnof", year, season, con);
            Session["GvdistNof"] = dt;
            if (dt.Rows.Count > 0)
            {
                GvdistNof.DataSource = dt;
                GvdistNof.DataBind();
            }


            dt = db.GetDetails("DistWsdbtn", year, season, con);
            Session["GvDistSeed"] = dt;
            if (dt.Rows.Count > 0)
            {
                GvDistSeed.DataSource = dt;
                GvDistSeed.DataBind();
            }

            dt = new DataTable();
            dt = db.GetDetails("CropWsstock", year, season, con);
            Session["GvCropStock"] = dt;
            if (dt.Rows.Count > 0)
            {
                GvCropStock.DataSource = dt;
                GvCropStock.DataBind();
            }

            dt = db.GetDetails("CropWsnof", year, season, con);
            Session["GvCropnof"] = dt;
            if (dt.Rows.Count > 0)
            {
                GVCropnof.DataSource = dt;
                GVCropnof.DataBind();
            }


            dt = db.GetDetails("CropWsdbtn", year, season, con);
            Session["GvCropSeed"] = dt;
            if (dt.Rows.Count > 0)
            {
                GVCropSeed.DataSource = dt;
                GVCropSeed.DataBind();
            }

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvdistStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal totQty = 0;
               
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.BackColor = System.Drawing.Color.DarkGray;
            DataTable dtdiststock = (DataTable)Session["GvdistStock"];

            if (dtdiststock.Rows.Count > 0)
            {
                for (int i = 0; i < dtdiststock.Rows.Count; i++)
                {
                    if (dtdiststock.Rows[i]["stockrcvd"].ToString() != "")
                    {
                        totQty += Convert.ToDecimal(dtdiststock.Rows[i]["stockrcvd"].ToString());

                    }
                }
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = totQty.ToString();
        }
    }
    protected void GvdistNof_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal totQty = 0;
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.BackColor = System.Drawing.Color.DarkGray;
            DataTable dtdiststock = (DataTable)Session["GvdistNof"];

            if (dtdiststock.Rows.Count > 0)
            {
                for (int i = 0; i < dtdiststock.Rows.Count; i++)
                {
                    if (dtdiststock.Rows[i]["farmers"].ToString() != "")
                    {
                        totQty += Convert.ToDecimal(dtdiststock.Rows[i]["farmers"].ToString());

                    }
                }
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = totQty.ToString();
        }
    }
    protected void GvDistSeed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal totQty = 0;
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.BackColor = System.Drawing.Color.DarkGray;
            DataTable dtdiststock = (DataTable)Session["GvDistSeed"];

            if (dtdiststock.Rows.Count > 0)
            {
                for (int i = 0; i < dtdiststock.Rows.Count; i++)
                {
                    if (dtdiststock.Rows[i]["seed"].ToString() != "")
                    {
                        totQty += Convert.ToDecimal(dtdiststock.Rows[i]["seed"].ToString());

                    }
                }
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = totQty.ToString();
        }
    }
    protected void GvCropStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal totQty = 0;

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.BackColor = System.Drawing.Color.DarkGray;
            DataTable dtdiststock = (DataTable)Session["GvCropStock"];

            if (dtdiststock.Rows.Count > 0)
            {
                for (int i = 0; i < dtdiststock.Rows.Count; i++)
                {
                    if (dtdiststock.Rows[i]["stockrcvd"].ToString() != "")
                    {
                        totQty += Convert.ToDecimal(dtdiststock.Rows[i]["stockrcvd"].ToString());

                    }
                }
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = totQty.ToString();
        }
    }
    protected void GVCropnof_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal totQty = 0;
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.BackColor = System.Drawing.Color.DarkGray;
            DataTable dtdiststock = (DataTable)Session["GvCropnof"];

            if (dtdiststock.Rows.Count > 0)
            {
                for (int i = 0; i < dtdiststock.Rows.Count; i++)
                {
                    if (dtdiststock.Rows[i]["farmers"].ToString() != "")
                    {
                        totQty += Convert.ToDecimal(dtdiststock.Rows[i]["farmers"].ToString());

                    }
                }
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = totQty.ToString();
        }
    }
    protected void GVCropSeed_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        decimal totQty = 0;
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.BackColor = System.Drawing.Color.DarkGray;
            DataTable dtdiststock = (DataTable)Session["GvCropSeed"];

            if (dtdiststock.Rows.Count > 0)
            {
                for (int i = 0; i < dtdiststock.Rows.Count; i++)
                {
                    if (dtdiststock.Rows[i]["seed"].ToString() != "")
                    {
                        totQty += Convert.ToDecimal(dtdiststock.Rows[i]["seed"].ToString());

                    }
                }
            }
            e.Row.Cells[0].Text = "Total";
            e.Row.Cells[1].Text = totQty.ToString();
        }
    }
    
}