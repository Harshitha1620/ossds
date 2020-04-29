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
/// Summary description for DistrictService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DistrictService : System.Web.Services.WebService {

    AdminReports rprt = new AdminReports();
    DataTable dt = new DataTable();
    CommonFuncs cf = new CommonFuncs();
    Masters objm = new Masters();
    string con = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();
    string year="", season = "";

    public DistrictService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    public struct DistData
    {
        public string Year;
        public string Season;
        public string District;
        public string Mandal;
        public string Crop;        
        public string Allotment;
        public string CropVariety;
        public string StockReceived;
        public string Sales;
        public string Farmers;
        public string SubsidyGiven;
    }


    private DistData[] getDataFromDataTable_District(DataTable dt)
    {
        DistData[] obj = new DistData[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            obj[i].Year = dt.Rows[i][0].ToString();
            obj[i].Season = dt.Rows[i][1].ToString();
            obj[i].District = dt.Rows[i][2].ToString();
            obj[i].Mandal = dt.Rows[i][3].ToString();
            obj[i].Crop = dt.Rows[i][4].ToString();            
            obj[i].Allotment = dt.Rows[i][5].ToString();
            obj[i].CropVariety = dt.Rows[i][6].ToString();
            obj[i].StockReceived = dt.Rows[i][7].ToString();
            obj[i].Sales = dt.Rows[i][8].ToString();
            obj[i].Farmers = dt.Rows[i][9].ToString();
            obj[i].SubsidyGiven = dt.Rows[i][10].ToString();
            i++;
        }
        return obj;
    }



    [WebMethod]
    public DistData[] GetMandWsDistribution(string user, string pwd,string dist)
    {
        DistData[] objData = null;
        if (user == "NIC" && pwd == "Sa@12345")
        {
            season = objm.GetSeasonByMonth(DateTime.Now.Month.ToString(),con);
            year = cf.getCurrentFinancialYear();
            DataTable dt = rprt.SrvcDMS(year, season, dist,con);
            objData = getDataFromDataTable_District(dt);
            return objData;
        }
        else
        {
            return objData;
        }
    }
   

}
