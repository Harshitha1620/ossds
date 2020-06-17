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
    public class DAOReports
    {
        public DataTable GetDetails(Master_BE objbe, String ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_DAODashboard", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = objbe.Action;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable getSpsDistrict(Master_BE objbe, String ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_ViewSp", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = objbe.Action;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable getSpsMandal(Master_BE objbe, String ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_ViewSp", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = objbe.Action;//3 ,4
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = objbe.mandalcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ViewDistributionCntMandWs(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Grid_ViewDistribution", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@from", SqlDbType.Date).Value = objbe.frmdt;
                    da.SelectCommand.Parameters.Add("@to", SqlDbType.Date).Value = objbe.todt;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable ViewDistributionDistWs(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Grid_ViewDistribution", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@from", SqlDbType.Date).Value = objbe.frmdt;
                    da.SelectCommand.Parameters.Add("@to", SqlDbType.Date).Value = objbe.todt;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllotmentSales(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Grid_Allotment_Sales", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.Char).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.Char).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.Char).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = objbe.mandalcd;
                    da.SelectCommand.Parameters.Add("@crop", SqlDbType.Char).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        //Daily report
        public DataTable GetDailyReport(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Grid_DailyReport_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    if (objbe.distcd != "0")
                        da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    if (objbe.mandalcd != "0")
                        da.SelectCommand.Parameters.Add("@mand", SqlDbType.VarChar).Value = objbe.mandalcd;
                    if (objbe.SPcode != "0")
                        da.SelectCommand.Parameters.Add("@sp", SqlDbType.VarChar).Value = objbe.SPcode;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllotedCrops(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Grid_DailyReport_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetCvs(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Grid_DailyReport_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetMandals(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Grid_DailyReport_DAO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.VarChar).Value = objbe.Action;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
