using System.Configuration;
using System.Data.SqlClient;

namespace BioHR.Controller.Database
{
    public class DatabaseSql
    {
	    public static string GetDbConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BioHRConnectionString"].ConnectionString;
        }

        public static string GetDbConnectionStringEss()
        {
            return ConfigurationManager.ConnectionStrings["BioESSConnectionString"].ConnectionString;
        }

        public static string GetDbConnectionStringMaster()
        {
            return ConfigurationManager.ConnectionStrings["BioFarmaConnectionString"].ConnectionString;
        }

        public static string GetDbConnectionStringCorrespondence()
        {
            return ConfigurationManager.ConnectionStrings["BioCorrespondenceConnectionString"].ConnectionString;
        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetDbConnectionString());
        }

        public static SqlConnection GetConnectionHr()
        {
            return new SqlConnection(GetDbConnectionString());
        }

        public static SqlConnection GetConnectionEss()
        {
            return new SqlConnection(GetDbConnectionStringEss());
        }

        public static SqlConnection GetConnectionMaster()
        {
            return new SqlConnection(GetDbConnectionStringMaster());
        }

        public static SqlConnection GetConnectionCorrespondence()
        {
            return new SqlConnection(GetDbConnectionStringCorrespondence());
        }

        public static SqlCommand GetCommand()
        {
            return new SqlCommand();
        }

        public static SqlCommand GetCommand(SqlConnection con, string sqlCommand)
        {
            return new SqlCommand(sqlCommand, (SqlConnection)con);
        }

        public static SqlDataReader GetDataReader(SqlCommand cmd)
        {
            return cmd.ExecuteReader();
        }

        public static SqlParameter GetParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }
    }
}