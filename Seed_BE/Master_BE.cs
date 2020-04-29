using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public int active { get; set; }
        public int Action { get; set; }
        public DateTime efct_dt { get; set; }
    }
}
