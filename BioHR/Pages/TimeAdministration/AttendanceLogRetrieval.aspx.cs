using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BioHR.Model.Database;
using BioHR.Model.Function;
using BioHR.Model.Object;

namespace BioHR.Pages.TimeAdministration
{
    public partial class AttendanceLogRetrieval : BioHR.Controller.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //tbPathLogAttendance.Text = @ConfigurationManager.AppSettings["AttendanceLogPath"];
            }
        }

        #region :: Data Catalog Service Region ::

        protected bool ProcessAttendanceLog() 
        {
            var errorMessage = "";
            var infoMessage = "";
            Boolean isError = false;

            try {
                infoMessage = PresenceCatalog.ProcessAttendanceLog();
            } catch (Exception ex) {
                isError = true;
                errorMessage = ex.Message;
            }

            if (isError) {
                DisplayErrorMessage(errorMessage);
                return true;
            }
            DisplayMessage(infoMessage);

            return false;
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            divFailureMessage.Visible = true;
            lbFailureMessage.Text = errorMessage;
        }

        public void DisplayMessage(string infoMessage)
        {
            divInfoMessage.Visible = true;
            lbInfoMessage.Text = infoMessage;
        }

        public void DisplayInfoMessage(string infoMessage)
        {
            divInfoMessage.Visible = true;
            lbInfoMessage.Text = infoMessage;
        }

        #endregion

        #region :: Attachment file Function ::

        protected List<Files> ConstructFileList(List<HttpPostedFile> uploadedFiles)
        {
            var listUploadedFile = new List<Files>();
            foreach (HttpPostedFile httpPostedFile in uploadedFiles)
            {
                var file = new Files();

                file.FileOriginal = httpPostedFile.FileName;
                file.FileName = DateTime.Today + "_" + httpPostedFile.FileName;
                file.FilePath =  "~/" + ConfigurationManager.AppSettings["UploadPath"];
                file.FileLink = "~/" + ConfigurationManager.AppSettings["UploadPath"] + "/" + httpPostedFile.FileName;
                file.FileSize = httpPostedFile.ContentLength / 1024;

                listUploadedFile.Add(file);
            }

            return listUploadedFile;
        } 

        public int CreateDocFileAttachment(int documentId, string documentCode, XDocument xmlDataDocumentAttachment)
        {
            var errorMessage = "";
            Boolean isError = false;

            try {
                DocumentFlowDataCatalog.SetDocumentFileAttacment(documentId, documentCode, xmlDataDocumentAttachment);
            }
            catch (Exception ex) {
                isError = true;
                errorMessage = ex.Message;
            }

            if (isError) {
                DisplayErrorMessage(errorMessage);
            }

            return documentId;
        }

        #endregion

        #region :: Grid view Log Function ::
        protected void gvLogResult_OnPreRender(object sender, EventArgs e)
        {
            if (gvLogResult.Rows.Count > 0)
            {
                gvLogResult.UseAccessibleHeader = true;
                gvLogResult.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void Bulk_Insert()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("CLDAT", typeof(string)));
            dt.Columns.Add(new DataColumn("PERNR", typeof(string)));
            dt.Columns.Add(new DataColumn("CLOCK", typeof(string)));
            dt.Columns.Add(new DataColumn("MCHNO", typeof(string)));
            dt.Columns.Add(new DataColumn("FLAGS", typeof(int)));
            dt.Columns.Add(new DataColumn("USRDT", typeof(string)));

            foreach (GridViewRow row in gvLogResult.Rows)
            {
                string clockDate = row.Cells[0].Text;
                string nikClock = row.Cells[1].Text;
                string clockAttendance = row.Cells[2].Text;
                string machineNumber = row.Cells[3].Text;
                int flags = 0;
                string userChange = HttpContext.Current.Session["biofarma_userid"].ToString();
                dt.Rows.Add(clockDate, nikClock, clockAttendance, machineNumber);
            }

            if (dt.Rows.Count > 0)
            {
                string connString = ConfigurationManager.ConnectionStrings["BioHRConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conn))
                    {
                        sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CLDAT", "CLDAT"));
                        sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("PERNR", "PERNR"));
                        sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("CLOCK", "CLOCK"));
                        sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("MCHNO", "MCHNO"));
                        sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("FLAGS", "FLAGS"));
                        sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("USRDT", "USRDT"));
                        sqlBulkCopy.DestinationTableName = "biopresensi.Log_MachineAttendance";

                        conn.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }

        #endregion

        #region :: Presensi Reader Function ::
        public bool ValidateUploadedFile()
        {
            var files = (List<HttpPostedFile>)Session["biofarma_fileAttachment"];

            /* if the user trying to upload more than one file, then return false */
            //if (files != null)
            //{
            //    if (files.Count <= 1)
            //    {
            //        return true;
            //    }
            //} 

            return true;
        }

        public List<Presensi> FileTextReader(string pathFile, string fileName, string machineType)
        {
            var listLogs = new List<Presensi>();

            using (StreamReader sr = File.OpenText(pathFile))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    //string[] logs = {s.Substring(0, 4), s.Substring(4, 8), s.Substring(12, 4), s.Substring(16, 6) };
                    var log = new Presensi();

                    if (machineType == "0")
                    {
                        log.Nik = ManualConvertNik(s.Substring(0, 4));
                        log.Date = ConstructDate(s.Substring(4, 8));
                        log.Time = ConstructTime(s.Substring(12, 4));
                        log.SerialMachine = s.Substring(16, 6);
                    }
                    else
                    {
                        log.Nik = s.Substring(24, 4);
                        log.Date = ConstructDate(s.Substring(2, 8));
                        log.Time = ConstructTime(s.Substring(10, 4));
                        log.SerialMachine = s.Substring(14, 10);
                    }
                    

                    listLogs.Add(log);
                }
            }

            return listLogs;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public string ConstructDate(string data)
        {
            return data.Substring(4, 2) + "/" + data.Substring(6, 2) + "/" + data.Substring(0, 4);
        }

        public string ConstructTime(string data)
        {
            return data.Substring(0, 2) + ":" + data.Substring(2, 2);
        }

        public string ManualConvertNik(string nik)
        {
            // used to convert nik with leading 5 to K, so if we have nik 5460 it will be converted into K460
            string leadingDigit = nik.Substring(0, 1);
            if (leadingDigit == "5")
            {
                return "K" + nik.Substring(1, 3);
            }
            return nik;
        }
        #endregion

        #region :: Form Function ::
        protected void btnImport_OnClick(object sender, EventArgs e)
        {
            //tbResult.Text = FileTextReader(tbPathLogAttendance.Text, "");

            // validate that the user only uploading one file per processing
            if (ValidateUploadedFile()) 
            {
                string filePath = Server.MapPath("~/" + ConfigurationManager.AppSettings["UploadPath"]) + "\\" + Session["biofarma_uploadedFileName"]; // get full path of file from the uploaded one ( exp. C:\BioHR\Uploads\file.txt )

                DataTable dataTable = ToDataTable(FileTextReader(filePath, "", ddlMachineAbsensiType.SelectedValue));
                gvLogResult.DataSource = dataTable;
                gvLogResult.DataBind();
            }
            else { DisplayInfoMessage("Hanya satu file upload yang di perbolehkan untuk sekali proses"); }
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            Bulk_Insert();
            ProcessAttendanceLog();
        }
        #endregion

    }
}