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
                cmd.CommandText = @"bioHR.usp_Get_ListAllEmployee";
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

        public static DataTable InsertSKEmployee(string CTRNO, string CTRDC, string CTRDT, string CTRPR, string EFFDT, string CTRTY, string USRDT, string FILNM, string FILOR, string FLPTH, string FILSZ,string FLTYP, string REFCD)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dt = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.usp_InsertSKEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CTRNO", CTRNO);
                cmd.Parameters.AddWithValue("@CTRDC", CTRDC);
                cmd.Parameters.AddWithValue("@CTRDT", CTRDT);
                cmd.Parameters.AddWithValue("@CTRPR", CTRPR);
                cmd.Parameters.AddWithValue("@EFFDT", EFFDT);
                cmd.Parameters.AddWithValue("@CTRTY", CTRTY);
                cmd.Parameters.AddWithValue("@USRDT", USRDT);
                cmd.Parameters.AddWithValue("@FILNM", FILNM);
                cmd.Parameters.AddWithValue("@FILOR", FILOR);
                cmd.Parameters.AddWithValue("@FLPTH", FLPTH);
                cmd.Parameters.AddWithValue("@FILSZ", FILSZ);
                cmd.Parameters.AddWithValue("@FLTYP", FLTYP);
                cmd.Parameters.AddWithValue("@REFCD", REFCD);
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

        public static DataTable MutationOrganization(string PERNR,string CNAME, string POSID, string PRPOS, string CTRNO, string SKNME, string EFFDT, string USRDT, int SEQNO)
        {
            
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dt = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.usp_MaintainMutasiKaryawan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PERNR", PERNR);
                cmd.Parameters.AddWithValue("@CNAME", CNAME);
                cmd.Parameters.AddWithValue("@POSID", POSID);
                cmd.Parameters.AddWithValue("@PRPOS", PRPOS);
                cmd.Parameters.AddWithValue("@CTRNO", CTRNO);
                cmd.Parameters.AddWithValue("@SKNME", SKNME);
                cmd.Parameters.AddWithValue("@EFFDT", EFFDT);
                cmd.Parameters.AddWithValue("@USRDT", USRDT);
                cmd.Parameters.AddWithValue("@SEQNO", SEQNO);
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
    }
}