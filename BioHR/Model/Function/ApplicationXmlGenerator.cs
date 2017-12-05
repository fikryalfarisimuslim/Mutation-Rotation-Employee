using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BioHR.Model.Object;

namespace BioHR.Model.Function
{
    public class ApplicationXmlGenerator
    {
        public static XDocument GenerateUploadedFileListToXml(List<Files> detailsDocument)
        {
            XDocument xmlDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("DetailsDocument", from dt in detailsDocument
                                                select new XElement("DetDocument",
                                                    new XElement("FILNM", Convert.ToString(dt.FileOriginal)),
                                                    new XElement("FILOR", Convert.ToString(dt.FileName)),
                                                    new XElement("FLPTH", Convert.ToString(dt.FilePath)),
                                                    new XElement("FILSZ", Convert.ToString(dt.FileSize)))
                    ));
            return xmlDocument;
        }

        public static XDocument GenerateUploadedFileToXml(Files detailsDocument)
        {
            Files dt = detailsDocument;

            XDocument xmlDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("Files",
                  new XElement("FILOR", dt.FileOriginal),
                  new XElement("FILNM", dt.FileName),
                  new XElement("FLPTH", dt.FilePath),
                  new XElement("FILSZ", dt.FileSize),
                  new XElement("FLTYP", dt.FileType),
                  new XElement("REFCD", dt.ReferenceCode)
                  )
            );
            return xmlDocument;
        }

        public static XDocument GenerateHeaderQueueMailToXml(List<HeaderMail> detailsDocument)
        {
            XDocument xmlDocument = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("DetailsDocument", from dt in detailsDocument
                                                select new XElement("DetDocument",
                                                    new XElement("IDMEL", Convert.ToString(dt.MailId)))
                    ));
            return xmlDocument;
        }

    }
}