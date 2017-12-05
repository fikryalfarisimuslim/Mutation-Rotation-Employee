using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BioHR.Controller.Database
{
    public class MailCatalog : DatabaseSql
    {
        public static void GenerateQueueMailToBeSend(int documentId, string documentCode, int templateId = 7)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "biohr.sp_ConstructHrAdminNotificationMail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int);
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@pTMPID", SqlDbType.Int);

                cmd.Parameters["@pDOCID"].Value = documentId;
                cmd.Parameters["@pDOCCD"].Value = documentCode;
                cmd.Parameters["@pTMPID"].Value = templateId;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

        }

        public static DataTable GetQueueMailToBeSend()
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtOvertime = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "bioHr.sp_GetListQueueMail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;

                cmd.Parameters.AddWithValue("@pDOCCD", ConfigurationManager.AppSettings["ApplicationCode"]);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtOvertime);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dtOvertime;
        }

        public static void DequequeMailList(XDocument xmlDataDocument)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "bioHr.sp_SetListQueueMailFlag";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.Add("@pQUEUEMAIL", SqlDbType.Xml);

                cmd.Parameters["@pQUEUEMAIL"].Value = xmlDataDocument.ToString();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

        }

        public static void GenerateQueueMailToBeSend(string begda, string endda, string poscdFrom, string poscdTo,
            int approvalAction)
        {
            SqlConnection conn = GetConnectionCorrespondence();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "biosrt.usp_ConstructNotificationMailDelegasi";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;

                cmd.Parameters.Add("@pBEGDA", SqlDbType.Date);
                cmd.Parameters.Add("@pENDDA", SqlDbType.Date);
                cmd.Parameters.Add("@pPCDFR", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pPCDTO", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pVALAPP", SqlDbType.Int);

                cmd.Parameters["@pBEGDA"].Value = begda;
                cmd.Parameters["@pENDDA"].Value = endda;
                cmd.Parameters["@pPCDFR"].Value = poscdFrom;
                cmd.Parameters["@pPCDTO"].Value = poscdTo;
                cmd.Parameters["@pVALAPP"].Value = approvalAction;

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