using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using BioHR.Model.Database;
using BioHR.Model.Object;

namespace BioHR.Controller.Database
{
    public class UserCatalog
    {
        private bool _isError;
        private string _errorMessage;
        private User _user;
        private UserAvatar _userAvatar; 

        public bool IsError
        {
            get { return _isError; }
            set { _isError = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public User UserAuthentication(string username, string password, string hostname, string hostip)
        {
            SqlConnection conn = DatabaseSql.GetConnectionMaster();
            SqlCommand cmd     = DatabaseSql.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "EXEC bioumum.sp_AUTHENTICATION_LOGIN @username, @pass, @applicationCode, @hostname, @hostip;";

                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100);
                cmd.Parameters["@username"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 100);
                cmd.Parameters["@pass"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@applicationCode", SqlDbType.NVarChar, 100);
                cmd.Parameters["@applicationCode"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@hostname", SqlDbType.NVarChar, 100);
                cmd.Parameters["@hostname"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@hostip", SqlDbType.NVarChar, 100);
                cmd.Parameters["@hostip"].Direction = ParameterDirection.Input;

                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@pass"].Value     = password;
                cmd.Parameters["@applicationCode"].Value = ConfigurationManager.AppSettings["ApplicationCode"];
                cmd.Parameters["@hostname"].Value = hostname;
                cmd.Parameters["@hostip"].Value   = hostip;

                SqlDataReader reader = DatabaseSql.GetDataReader(cmd);
                {
                    while (reader.Read())
                    {
                        string nik      = Convert.ToString(reader["userid"]);  // PERNR
                        string userName = Convert.ToString(reader["username"]);// CNAME
                        string posid    = Convert.ToString(reader["posid"]);   // POSID
                        string posName  = Convert.ToString(reader["posname"]); // PRPOS
                        string unitCode = Convert.ToString(reader["unitCode"]);// COCTR
                        string unitName = Convert.ToString(reader["unitname"]);// PRORG
                        string roleId   = Convert.ToString(reader["roleid"]);  // ROLID
                        string roleName = Convert.ToString(reader["rolename"]);// ROLNM
                        string grade    = Convert.ToString(reader["grade"]);   // PSGRP

                        _user = new User(nik, posid, userName, posName, unitCode, unitName, roleId, roleName, grade, hostname, "hostip");
                    }
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMessage = ex.Message;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return _user;
        }

        public static object[] getUserDataByOrganization(string orgid)
        {
            SqlConnection conn = DatabaseSql.GetConnectionMaster();
            string _cmdSql = @"select PRORG,PRBUS,PRJOB,COCNM,PRPOS,ORGID,BUSAR,JOBID,COCTR,POSID from bioumum.USER_DATA_NEW where POSID ='" + orgid + "'";
            SqlCommand cmd = DatabaseSql.GetCommand(conn, _cmdSql);
            try
            {
                conn.Open();
                SqlDataReader reader = DatabaseSql.GetDataReader(cmd);
                object[] data = null;

                while (reader.Read())
                {
                    object[] value = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString() };
                    data = value;
                }

                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        public static Boolean SignatureAuthentication(string username, string password)
        {
            SqlConnection conn = DatabaseSql.GetConnectionMaster();
            SqlCommand cmd = DatabaseSql.GetCommand();
            Boolean result = false;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioumum.sp_AUTHENTICATION_SIGNATURE";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pUSRNM", SqlDbType.VarChar, 15).Value = username;
                cmd.Parameters.Add("@pPASWD", SqlDbType.VarChar, 50).Value = password;
                cmd.Parameters.Add("@pRESULT", SqlDbType.Bit).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToBoolean(cmd.Parameters["@pRESULT"].Value);

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return result;
        }

        public User SingleSignOnUserAuthentication(string personalNumber, string hostname, string hostip)
        {
            SqlConnection conn = DatabaseSql.GetConnectionMaster();
            SqlCommand cmd = DatabaseSql.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "EXEC bioumum.sp_AUTHENTICATION_LOGIN_CTI @userNik, @applicationCode;";

                cmd.Parameters.Add("@userNik", SqlDbType.NVarChar, 100);
                cmd.Parameters["@userNik"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@applicationCode", SqlDbType.NVarChar, 100);
                cmd.Parameters["@applicationCode"].Direction = ParameterDirection.Input;

                cmd.Parameters["@userNik"].Value = personalNumber;
                cmd.Parameters["@applicationCode"].Value = ConfigurationManager.AppSettings["ApplicationCode"];

                SqlDataReader reader = DatabaseSql.GetDataReader(cmd);
                {
                    while (reader.Read())
                    {
                        string nik = Convert.ToString(reader["userid"]);  // PERNR
                        string userName = Convert.ToString(reader["username"]);// CNAME
                        string posid = Convert.ToString(reader["posid"]);   // POSID
                        string posName = Convert.ToString(reader["posname"]); // PRPOS
                        string unitCode = Convert.ToString(reader["unitCode"]);// COCTR
                        string unitName = Convert.ToString(reader["unitname"]);// PRORG
                        string roleId = Convert.ToString(reader["roleid"]);  // ROLID
                        string roleName = Convert.ToString(reader["rolename"]);// ROLNM
                        string grade = Convert.ToString(reader["grade"]);   // PSGRP

                        _user = new User(nik, posid, userName, posName, unitCode, unitName, roleId, roleName, grade, hostname, hostip);
                    }
                }
            } catch (Exception ex) {
                IsError = true;
                ErrorMessage = ex.Message;
                throw;
            } finally {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return _user;
        }

        public UserAvatar GetProfileAvatarInformation(string personalNumber)
        {
            SqlConnection conn = DatabaseSql.GetConnectionMaster();
            SqlCommand cmd = DatabaseSql.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "bioumum.usp_GET_ProfileAvatarInformation";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userNik", SqlDbType.NVarChar, 100);
                cmd.Parameters["@userNik"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@applicationCode", SqlDbType.NVarChar, 100);
                cmd.Parameters["@applicationCode"].Direction = ParameterDirection.Input;

                cmd.Parameters["@userNik"].Value = personalNumber;
                cmd.Parameters["@applicationCode"].Value = ConfigurationManager.AppSettings["ApplicationCode"];

                SqlDataReader reader = DatabaseSql.GetDataReader(cmd);
                {
                    while (reader.Read())
                    {
                        _userAvatar = new UserAvatar()
                        {
                            UserId = Convert.ToString(reader["PERNR"]), //PERNR
                            UserName = Convert.ToString(reader["CNAME"]), //CNAME
                            UserEmail = Convert.ToString(reader["EMAIL"]), //EMAIL
                            UserAvatarImage = Convert.ToString(reader["IMGURL"]), //Image Avatar Link
                            UserOrganization = Convert.ToString(reader["PRORG"]), //PRORG
                            UserPosition = Convert.ToString(reader["POSNM"]) //POSNM
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                ErrorMessage = ex.Message;
                throw;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return _userAvatar;
        }

        public void SetAuditTrailApplicationLogin(string personalNumber, string userName, string loginStatus)
        {
            SqlConnection conn = DatabaseSql.GetConnectionMaster();
            SqlCommand cmd = DatabaseSql.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioumum.usp_Set_AuditTrailApplicationLogin";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pPERNR", SqlDbType.VarChar, 15).Value = personalNumber;
                cmd.Parameters.Add("@pUSRNM", SqlDbType.VarChar, 30).Value = userName;
                cmd.Parameters.Add("@pAPPCD", SqlDbType.VarChar, 5).Value = ConfigurationManager.AppSettings["ApplicationCode"];
                cmd.Parameters.Add("@pAPPST", SqlDbType.VarChar, 51).Value = loginStatus;


                cmd.ExecuteNonQuery();

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
	
    }
}