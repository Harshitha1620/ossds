//By Harshitha on 17/06/2020 
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
    public class Admin
    {
        public DataTable InsertSeedAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Allot_Districts", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@tvp", SqlDbType.Structured).Value = objbe.TVP;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = objbe.cropVariety;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@scheme", SqlDbType.VarChar).Value = objbe.scheme;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "I";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Allotment_UDR(Master_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = obj.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = obj.season;
                    if (obj.CropId == "")
                        da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = null;
                    else
                        da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = obj.CropId;

                    if (obj.cropVariety == "")
                        da.SelectCommand.Parameters.Add("@cropV", SqlDbType.Int).Value = null;
                    else
                        da.SelectCommand.Parameters.Add("@cropV", SqlDbType.Int).Value = obj.cropVariety;

                    if (obj.agency == "")
                        da.SelectCommand.Parameters.Add("@agency", SqlDbType.Int).Value = null;
                    else
                        da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = obj.agency;

                    if (obj.scheme == "")
                        da.SelectCommand.Parameters.Add("@scheme", SqlDbType.Int).Value = null;
                    else
                        da.SelectCommand.Parameters.Add("@scheme", SqlDbType.VarChar).Value = obj.scheme;

                    if (obj.distcd == "")
                        da.SelectCommand.Parameters.Add("@dist", SqlDbType.Int).Value = null;
                    else
                        da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = obj.distcd;

                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSeedAllotmentbySeason(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "R";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSeedAllotmentbyCCode(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "R";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSeedAllotmentbyDistCode(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "R3";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSeedAllotmentbyAgency(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "R4";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDistWsAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "R5";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSeedSchemeAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "R6";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@scheme", SqlDbType.VarChar).Value = objbe.scheme;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable DeleteSeedAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "D";
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = objbe.allotid;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable UpdateSeedAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "U";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@scheme", SqlDbType.VarChar).Value = objbe.scheme;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = objbe.cropVariety;
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = objbe.allotid;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = objbe.allotedQty;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable UpdateNfsmAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "NU";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@scheme", SqlDbType.VarChar).Value = objbe.scheme;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = objbe.cropVariety;
                    da.SelectCommand.Parameters.Add("@allotid", SqlDbType.VarChar).Value = objbe.allotid;
                    da.SelectCommand.Parameters.Add("@allotedQty", SqlDbType.VarChar).Value = objbe.allotedQty;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable FreezeSeedAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Freeze_Allotment_Districts", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@tvp", SqlDbType.Structured).Value = objbe.dtfreeze;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable NFSM_FreezeSeedAllotment(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_Freeze_Allotment_Districts", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@tvp1", SqlDbType.Structured).Value = objbe.dtfreeze;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "NFSM";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetFreezednfsmAllotments(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "FNFSM";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@cropV", SqlDbType.VarChar).Value = objbe.cropVariety;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetFreezedAllotmentsbySeason(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "F1";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetFreezedAllotmentsbyCCode(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "F2";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetFreezedAllotmentsbyDistCode(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "F3";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetFreezedAllotmentsbyAgency(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "F4";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetFreezedAllotmentsbyScheme(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "F5";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@CropCode", SqlDbType.VarChar).Value = objbe.CropId;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@agency", SqlDbType.VarChar).Value = objbe.agency;
                    da.SelectCommand.Parameters.Add("@scheme", SqlDbType.VarChar).Value = objbe.scheme;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetFreezedAllotmentsDistWs(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_AllotDistricts_UDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = "distWs";
                    da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@season", SqlDbType.VarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = objbe.distcd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
