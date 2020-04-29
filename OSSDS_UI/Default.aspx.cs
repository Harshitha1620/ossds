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

public partial class _Default : System.Web.UI.Page
{
    //Masters objm = new Masters(); 
    string ConnKey = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        GethitcountNote();
    }

    public void GethitcountNote()
    {
        DataTable dt = new DataTable();
        try
        {
            //dt = objm.GetLGHitCount("Seed",ConnKey);
            string html = "This site visted  ";
            char[] c = dt.Rows[0][0].ToString().ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                html += " <span class='hit'>";
                html += c[i];
                html += "</span> ";
            }
            html += "  times";
            hit.InnerHtml = html;
            //lblcnt.Text = "This site visted ' " + dt.Rows[0][0].ToString() +" '  times";
        }
        catch { }
    }
}