using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioHR.Workflow.Model.Object
{
    public class Status
    {
        public enum Document
        {
            Drafted = 0, 
            Submitted,
            Approved,
            Corrected,
            Rejected,
            Archived
        }

        public enum Workflow
        {
            Open = 0,
            Pending,
            Approved,
            Corrected,
            Rejected
        }
    }
}