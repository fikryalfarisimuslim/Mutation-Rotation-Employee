using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BioHR.Controller.Database;
using BioHR.Workflow.Model.Object;

namespace BioHR.Model.Database
{
    public class OrganizationDataCatalog : DatabaseSql
    {
        public static DataTable GetPosisi()
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.usp_CountPosition";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dt;
        }

        public static DataTable GetDataContractDetailByNoSK(string noSK)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataContractDetailByNoSK = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.sp_GET_Data_ContractDetailMutation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCTRNO", noSK);
                adapter.SelectCommand = cmd;
                adapter.Fill(dataContractDetailByNoSK);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataContractDetailByNoSK;
        }

        internal static void GetDataContractDetailByNoSK(System.Web.UI.WebControls.TextBox iNoSK)
        {
            throw new NotImplementedException();
        }

        public static DataTable GetListAllEmployee()
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataListAllEmployee = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.usp_GetListAllEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataListAllEmployee);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataListAllEmployee;
        }

        public static DataTable GetParameterDropDownList()
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dt = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.usp_Get_DropdownList_SK";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pPRMTY", "SK");
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dt;
        }

        public static DataTable GetListEmptyPosition()
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.usp_GetListEmptyPosition";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dt;
        }

        public static DataTable GetDataContractDetailRotation(string noSK)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataContractDetailRotation = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.sp_GET_Data_ContractDetailRotation";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCTRNO", noSK);
                adapter.SelectCommand = cmd;
                adapter.Fill(dataContractDetailRotation);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataContractDetailRotation;
        }

        public static DataTable GetDataContractDetailAll()
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataContractDetailAll = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.sp_GET_Data_ContractDetailAll";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataContractDetailAll);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataContractDetailAll;
        }
    }
}