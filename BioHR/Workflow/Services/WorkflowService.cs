using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BioHR.Workflow.Model.Database;
using BioHR.Workflow.Model.Object;

namespace BioHR.Workflow.Services
{
    public class WorkflowService
    {
        #region :: Maintain Document Services ::

        /* Method used to insert document into workflow table */
        public static void DocumentWorkflowInserted(int documentId, string documentCode, string nik, XDocument xmlDataDocument)
        {
            WorkflowApproval.InsertToWorkflow(documentId, documentCode, nik, xmlDataDocument); // Calling data access layer which is method that insert data into database
        }

        public static void ArchiveDocumentWorkflow(int documentId, string documentCode, string nik)
        {

        }
        #endregion

        #region :: Review Document Services ::
        public static void ApproveDocumentWorkflow(int documentId, string documentCode, string nik, string positionId, string commentReview)
        {
            WorkflowApproval.ReviewDocWorkflow(documentId, documentCode, nik, positionId, (int)Status.Workflow.Approved, commentReview);
        }

        public static void CorrectDocumentWorkflow(int documentId, string documentCode, string nik, string positionId, string commentReview)
        {
            WorkflowApproval.ReviewDocWorkflow(documentId, documentCode, nik, positionId, (int)Status.Workflow.Corrected, commentReview);
            
        }

        public static void RejectDocumentWorkflow(int documentId, string documentCode, string nik, string positionId, string commentReview)
        {
            WorkflowApproval.ReviewDocWorkflow(documentId, documentCode, nik, positionId, (int)Status.Workflow.Rejected, commentReview);
        }

        #endregion
    }
}