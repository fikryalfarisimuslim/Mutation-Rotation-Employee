using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using BioHR.Workflow.Model.Object;

namespace BioHR.Workflow.Controller.Function
{
    public class XmlGenerator
    {
        public static XDocument GenerateApproverToXml(List<Approver> listApprover)
        {
            XDocument xmlDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                                                  new XElement("ListApprover", from dt in listApprover
                                                                               select new XElement("DetApprover",
                                                                                      new XElement("SEQID", Convert.ToInt16(dt.SEQID)),
                                                                                      new XElement("GRPID", Convert.ToString(dt.GRPID)),
                                                                                      new XElement("POSID", Convert.ToString(dt.POSID)),
                                                                                      new XElement("PERNR", Convert.ToString(dt.PERNR)),
                                                                                      new XElement("STAPP", Convert.ToString(dt.STAPP)))
                                                                                      ));

            return xmlDocument;
        }
    }
}