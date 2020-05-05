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
    public class Login_DL
    {
        public DataTable GetLoginDetails(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Seed_GetLoginDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = objbe.username;
                    da.SelectCommand.Parameters.Add("@year", SqlDbType.NVarChar).Value = objbe.year;
                    da.SelectCommand.Parameters.Add("@Season", SqlDbType.NVarChar).Value = objbe.season;
                    da.SelectCommand.Parameters.Add("@state", SqlDbType.NVarChar).Value = objbe.statecd;
                    da.SelectCommand.Parameters.Add("@dist", SqlDbType.NVarChar).Value = objbe.distcd;
                    da.SelectCommand.Parameters.Add("@mand", SqlDbType.NVarChar).Value = objbe.mandalcd;
                    da.SelectCommand.Parameters.Add("@role", SqlDbType.Int).Value = objbe.role;
                    da.SelectCommand.Parameters.Add("@spcode", SqlDbType.NVarChar).Value = objbe.SPcode;
                    da.SelectCommand.Parameters.Add("@updatedUSer", SqlDbType.NVarChar).Value = objbe.userid;
                    da.SelectCommand.Parameters.Add("@updt_ip", SqlDbType.NVarChar).Value = objbe.ipaddress;
                    da.SelectCommand.Parameters.Add("@newpwd", SqlDbType.NVarChar).Value = objbe.pwd;
                    da.SelectCommand.Parameters.Add("@action", SqlDbType.Char).Value = objbe.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        


        public int UserLoginStatus(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                SqlCommand cmd = new SqlCommand("Seed_UserLoginStatus_IU", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value =objbe.username;
                cmd.Parameters.Add("@Login_or_LogoutDateAndTime", SqlDbType.DateTime).Value = objbe.date_time;
                cmd.Parameters.Add("@IpAddress", SqlDbType.NVarChar).Value = objbe.ipaddress;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = objbe.loginStatus;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = objbe.Action;
                cmd.Parameters.Add("@LoginSno", SqlDbType.Int);
                cmd.Parameters["@LoginSno"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                int code = Convert.ToInt32(cmd.Parameters["@LoginSno"].Value);
                con.Close();
                con.Dispose();
                return code;
            }
        }


        public void UpdateUserLoginStatus(Master_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                SqlCommand cmd = new SqlCommand("Seed_UserLoginStatus_IU", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginSno_toUpdate", SqlDbType.BigInt).Value = objbe.userid;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = objbe.loginStatus;
                cmd.Parameters.Add("@Login_or_LogoutDateAndTime", SqlDbType.DateTime).Value = objbe.date_time;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = objbe.Action;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
