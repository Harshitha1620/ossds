using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Seed_BE
{
    public class Master_BE
    {
        //LOGIN
        public string username { get; set; }
        public string role { get; set; }
        public string pwd { get; set; }
        public string loginStatus { get; set; }
        public DateTime date_time { get; set; }
        public int loginuserid { get; set; }
        public string sectionid { get; set; }

        //LOCATIONS
        public string statecd { get; set; }
        public string statename { get; set; }
        public string distcd { get; set; }
        public string distname { get; set; }
        public string mandalcd { get; set; }
        public string mandalname { get; set; }
        public string villagename { get; set; }
        public string villcode { get; set; }
        public string SPcode { get; set; }

        //COMMON
        public string year { get; set; }
        public string month { get; set; }
        public string season { get; set; }
        public string ipaddress { get; set; }
        public string userid { get; set; }
        public string active { get; set; }
        public string Action { get; set; }
        public DateTime efct_dt { get; set; }
        public DataTable TVP { get; set; }

        //Crop Master
        public string CropId { get; set; }
        public string CropName { get; set; }
        public string type { get; set; }
        public string no_of_acres { get; set; }
        public string qty { get; set; }
        public string packsize { get; set; }
        public Int32 slno { get; set; }
        public string scheme { get; set; }

        //COMPANY
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}
