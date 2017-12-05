using BioHR.Controller.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BioHR.Model.Database
{
    public class MachineProcessDataCatalog : DatabaseSql
    {
        public static DataTable GetConfigMachine()
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataMesinAbsensi = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_GET_ConfigMachine";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataMesinAbsensi);
                /*
                gvConfigMesinPresensi.DataSource = dataMesinAbsensi;
                gvConfigMesinPresensi.DataBind();
                */
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataMesinAbsensi;
        }
  
        public static void AddConfigMachine(string MCHNM, string MCHIP, int MCHPRT, int GRPID, string GRTYP, int MCHST, string DESCR)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_Insert_ConfigMachine";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MCHNM", MCHNM);
                cmd.Parameters.AddWithValue("@MCHIP", MCHIP);
                cmd.Parameters.AddWithValue("@MCHPRT", MCHPRT);
                cmd.Parameters.AddWithValue("@GRPID", GRPID);
                cmd.Parameters.AddWithValue("@GRTYP", GRTYP);
                cmd.Parameters.AddWithValue("@MCHST", MCHST);
                cmd.Parameters.AddWithValue("@DESCR", DESCR);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public static DataTable GetWithdrawalMachine()
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataWithdrawalMachine = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_GET_LogError_Machine";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataWithdrawalMachine);

                generateImage(dataWithdrawalMachine);
               
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataWithdrawalMachine;
        }

        public static DataTable generateImage(DataTable data)
        {
            data.Columns.Add("img", typeof(String));
            foreach (DataRow row in data.Rows)
            {
                if (row["ERMSG"].ToString().Equals("Successfully Retrieve Data Absensi"))
                {
                    row["img"] = "~/Images/Resources/state-true.png";

                }
                else
                {
                    row["img"] = "~/Images/Resources/state-false.png";
                }
            }
            return data;
        }

        public static DataTable GetLogMachineAttendance()
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataLogMachineAttendance = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_GET_LogMachineAttendance";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataLogMachineAttendance);

                //add coloumn image
                generateImage(dataLogMachineAttendance);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataLogMachineAttendance;
        }

        public static void DelimitConfigMachine(int MCHID)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_Delimit_ConfigMachine";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MCHID", MCHID);


                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public static void UpdateConfigMachine(int MCHID, string MCHNM, string MCHIP, int MCHPRT, int GRPID, string GRTYP, int MCHST, string DESCR)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_Update_ConfigMachine";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MCHID", MCHID);
                cmd.Parameters.AddWithValue("@MCHNM", MCHNM);
                cmd.Parameters.AddWithValue("@MCHIP", MCHIP);
                cmd.Parameters.AddWithValue("@MCHPRT", MCHPRT);
                cmd.Parameters.AddWithValue("@GRPID", GRPID);
                cmd.Parameters.AddWithValue("@GRTYP", GRTYP);
                cmd.Parameters.AddWithValue("@MCHST", MCHST);
                cmd.Parameters.AddWithValue("@DESCR", DESCR);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public static DataTable GetSearchingMachineBy(string search, int byactive)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataLogMachineAttendance = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_GET_SearchingMachineBy";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SEARCH", search);
                cmd.Parameters.AddWithValue("@BYACTIVE", byactive);
                adapter.SelectCommand = cmd;
                adapter.Fill(dataLogMachineAttendance);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataLogMachineAttendance;
        }

        public static DataTable GetSearchingLogMachineBy(string search, string start, string end)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataLogMachineAttendance = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPresensi.usp_GET_SearchingLogMachineBy";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SEARCH", search);
                cmd.Parameters.AddWithValue("@START", start);
                cmd.Parameters.AddWithValue("@END", end);
                adapter.SelectCommand = cmd;
                adapter.Fill(dataLogMachineAttendance);

                //add column image
                generateImage(dataLogMachineAttendance);

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataLogMachineAttendance;
        }
        
    }
}