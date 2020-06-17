//By Harshitha on 16/06/2020
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
    public class SeedRequest
    {
        public DataTable InsertRequest(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = objbe.mandalcd;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = objbe.userid;
                    da.SelectCommand.Parameters.Add("@ip", SqlDbType.VarChar).Value = objbe.ipaddress;
                    da.SelectCommand.Parameters.Add("@tvp", SqlDbType.Structured).Value = objbe.TVP;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "MAOI";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable getCrops(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "getCrops";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
     
        public DataTable ViewRequest(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ViewRequestMandal(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = objbe.mandalcd;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "R1";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ViewRequests(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "R";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ViewRequestsByDm(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@ag", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "DM";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ViewRequestsBySm(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@ag", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "SM";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable UpdateRequest(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Request_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@atvp", SqlDbType.Structured).Value = objbe.dtrequest;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = objbe.userid;
                    da.SelectCommand.Parameters.Add("@ip", SqlDbType.VarChar).Value = objbe.ipaddress;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = "DAOU";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
