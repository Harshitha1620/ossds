using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Data;
using Seed_DL;

/// <summary> 
/// Summary description for OSSDS_WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class OSSDS_WebService : System.Web.Services.WebService {

    AdminReports rprt = new AdminReports();
    DataTable dt = new DataTable();
    CommonFuncs cf = new CommonFuncs();
    Masters objm = new Masters();
    string con= ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();
    public OSSDS_WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string OSSDS_CMDASHBOARD()
    {
        return GetData();
    }
     public string GetData()
     {
        dt = new DataTable();
      
        StringBuilder strb = new StringBuilder();
        StringBuilder strb1 = new StringBuilder();
        strb.Append("<RetDMDashCaption>");
        strb1.Append("<RetDMDashStateGraph>");
        try
        {
            dt = rprt.SrvcCM_Dashboard(cf.getCurrentFinancialYear(),objm.GetSeasonByMonth(DateTime.Now.Month.ToString(),con), con);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    strb.Append("<DASH>");
                    strb.Append("<state_code>36 </state_code>");
                    strb.Append("<District_code>" + dt.Rows[i][0].ToString() + " </District_code>");
                    strb.Append("<teh_code> 0 </teh_code>");
                    strb.Append("<blk_code> 0 </blk_code>");
                    strb.Append("<sector_code> 2 </sector_code>"); 
                    strb.Append("<dept_code> 37 </dept_code>"); 
                    strb.Append("<Project_code> 100368 </Project_code>");

                    strb.Append("<cnt1>" + dt.Rows[i][1].ToString() + " </cnt1>");//stock
                    strb.Append("<cnt2>" + dt.Rows[i][2].ToString() + " </cnt2>");//Permits Availed
                    strb.Append("<cnt3>" + dt.Rows[i][3].ToString() + " </cnt3>");//No.of Farmers
                    strb.Append("<cnt4>" + dt.Rows[i][4].ToString() + " </cnt4>");//Seed Distributed
                    strb.Append("<cnt5>" + dt.Rows[i][5].ToString() + " </cnt5>");//Value of Subsidy
                   

                    strb.Append("<dataportmode> 4 </dataportmode>");
                    strb.Append("<modedesc> " + (DateTime.Today.AddDays(-1)).Day.ToString() + " </modedesc>");  
                    strb.Append("<data_lvl_code> 1 </data_lvl_code>");
                    strb.Append("<yr> " + (DateTime.Today.AddDays(-1)).Year.ToString() + " </yr>");
                    strb.Append("<mnth> " + (DateTime.Today.AddDays(-1)).Month.ToString() + " </mnth>");

                    strb.Append("</DASH>");
                }
            }
            else
            {
                strb.Append("0");
                strb1.Append("0");
            }
            strb.Append("</RetDMDashCaption>");
            strb1.Append("</RetDMDashStateGraph>");


            return strb.ToString();
        }
        catch (Exception ex)
        {
            throw new SoapException(ex.Message, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri);
        }
    }
}




