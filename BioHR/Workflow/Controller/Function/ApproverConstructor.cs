using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BioHR.Model.Object;
using BioHR.Workflow.Model.Object;

namespace BioHR.Workflow.Controller.Function
{
    public class ApproverConstructor
    {
        public static List<Approver> Approvers(List<object[]> approverObjects)
        {
            List<Approver> listApprovers = new List<Approver>();

            if (approverObjects.Count > 0)
            {
                int seqId = 0;

                foreach (object[] data in approverObjects)
                {
                    Approver app = new Approver();
                    app.GRPID = data[0].ToString();
                    app.POSID = data[1].ToString();
                    app.PERNR = data[2].ToString();
                    app.STAPP = seqId == 0 ? "1" : "0"; 
                    seqId++; // Increment the sequence number for approver
                    app.SEQID = seqId;

                    listApprovers.Add(app);
                }
            }

            return listApprovers;
        }
    }

}