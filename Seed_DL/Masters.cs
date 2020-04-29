using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Seed_BE;

namespace Seed_DL
{
    public class Masters
    {
        //Locations
        public DataTable GetLocations(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_GetLocations", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = objbe.Action;
                    da.SelectCommand.Parameters.Add("@state", SqlDbType.VarChar).Value = objbe.statecd;
                    da.SelectCommand.Parameters.Add("@district", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@mandal", SqlDbType.VarChar).Value = objbe.mandalcd;
                    da.SelectCommand.Parameters.Add("@village", SqlDbType.VarChar).Value = objbe.villcode;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@Season", SqlDbType.VarChar).Value = objbe.season;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public string GetSeasonByMonth(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_GetDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@month", SqlDbType.VarChar).Value = objbe.month;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt.Rows[0][0].ToString();
                }
            }
        }

    }
}
