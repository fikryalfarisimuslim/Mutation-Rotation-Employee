using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioHR.Workflow.Model.Object
{
    public class Approver
    {
        public int SEQID { get; set; }
        public string GRPID { get; set; }
        public string POSID { get; set; }
        public string IDJAB { get; set; }
        public string PERNR { get; set; }
        public string STAPP { get; set; }
    }
}