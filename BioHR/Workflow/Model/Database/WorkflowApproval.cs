using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BioHR.Workflow.Model.Database
{
    public class WorkflowApproval : BioHR.Controller.Database.DatabaseSql
    {
        public static void InsertToWorkflow(int documentId, string documentCode, string nik, XDocument xmlApprover)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"EXEC bioHR.sp_WF_InsertIntoWorkflow @pDOCID, @pDOCCD, @pPERNR, @pDETAPP";

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int).Value = documentId;
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30).Value = documentCode;
                cmd.Parameters.Add("@pPERNR", SqlDbType.VarChar, 30).Value = nik;
                cmd.Parameters.Add("@pDETAPP", SqlDbType.Xml).Value = xmlApprover.ToString();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public static void ReviewDocWorkflow(int documentId, string documentCode, string nik, string positionId, int statusReview, string commentReview)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"EXEC bioHR.sp_WF_ReviewDocumentWorkflow @pDOCID, @pDOCCD, @pPERNR, @pPOSID, @pVALAPP, @pCMTAPP";

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int).Value = documentId;
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30).Value = documentCode;
                cmd.Parameters.Add("@pPERNR", SqlDbType.VarChar, 30).Value = nik;
                cmd.Parameters.Add("@pPOSID", SqlDbType.VarChar, 30).Value = positionId;
                cmd.Parameters.Add("@pVALAPP", SqlDbType.VarChar, 10).Value = Convert.ToString(statusReview);
                cmd.Parameters.Add("@pCMTAPP", SqlDbType.VarChar, 500).Value = commentReview;

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