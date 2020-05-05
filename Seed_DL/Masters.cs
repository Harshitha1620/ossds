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
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "Season";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt.Rows[0][0].ToString();
                }
            }
        }



        public DataTable GetDetails(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_GetDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = objbe.Action;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = objbe.statecd;
                    da.SelectCommand.Parameters.Add("@sectionid", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.VarChar).Value = objbe.mandalcd;
                    da.SelectCommand.Parameters.Add("@extent", SqlDbType.VarChar).Value = objbe.villcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable Company_IUDR(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Company_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@company_id", SqlDbType.VarChar).Value = objbe.CompanyID;
                    da.SelectCommand.Parameters.Add("@comapny_name", SqlDbType.VarChar).Value = objbe.CompanyName;
                    da.SelectCommand.Parameters.Add("@active", SqlDbType.VarChar).Value = objbe.active;
                    da.SelectCommand.Parameters.Add("@effective_dt", SqlDbType.DateTime).Value = objbe.efct_dt;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = objbe.username;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = objbe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable Crop_IUDR(Master_BE objBe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_CropDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objBe.CropId;
                    da.SelectCommand.Parameters.Add("@CropName", SqlDbType.VarChar).Value = objBe.CropName;
                    da.SelectCommand.Parameters.Add("@cropType", SqlDbType.VarChar).Value = objBe.type;
                    da.SelectCommand.Parameters.Add("@no_of_acres", SqlDbType.VarChar).Value = objBe.no_of_acres;
                    da.SelectCommand.Parameters.Add("@qty", SqlDbType.VarChar).Value = objBe.qty;
                    da.SelectCommand.Parameters.Add("@slno", SqlDbType.Int).Value = objBe.slno;
                    da.SelectCommand.Parameters.Add("@Scheme", SqlDbType.Char).Value = objBe.scheme;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.NVarChar).Value = objBe.username;
                    da.SelectCommand.Parameters.Add("@iP", SqlDbType.NVarChar).Value = objBe.ipaddress;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = objBe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable Issustopsale(Master_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_IssueStopSale", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = obj.Action;
                    da.SelectCommand.Parameters.Add("@tvp", SqlDbType.Structured).Value = obj.TVP;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
