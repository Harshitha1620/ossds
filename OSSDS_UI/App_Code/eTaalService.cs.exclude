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


[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class eTaalService : System.Web.Services.WebService {

    SuperAdmin rprt = new SuperAdmin();
    DataTable dt = new DataTable();
    string con = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString();
    Validate objValidate = new Validate();
    IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);

    public eTaalService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public struct TxData
    {
        public string ServiceId;
        public string ServiceName;
        public string Tx_Cnt;
    }

    


    [WebMethod]
    public TxData[] Get_OSSDS_TxCnt(string WS_UserName, string WS_Password, string FromDate, string ToDate)
    {
        TxData[] obj = null;
        if (WS_UserName == "OSSDS_ETAAL" && WS_Password == "Seed$etaal@321")
        {
            if (objValidate.IsDate(FromDate) && objValidate.IsDate(ToDate))
            {

                DataTable dttemp = new DataTable();
                DataTable dt = rprt.eTaalService(FromDate, ToDate, con);
                if (dt.Rows.Count > 0)
                {
                    obj = new TxData[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        obj[i].ServiceId = dt.Rows[i]["ServiceId"].ToString();
                        obj[i].ServiceName = dt.Rows[i]["ServiceName"].ToString();
                        obj[i].Tx_Cnt = dt.Rows[i]["Tx_Cnt"].ToString();
                        i++;
                    }
                }
            }
            else
            {
                /*INVALID USER TO ACCESS THIS API*/
                obj = new TxData[1];
                obj[0].ServiceId = "0";
                obj[0].ServiceName = "Invalid Date";
            }
        }
        return obj;
    }



    
}
