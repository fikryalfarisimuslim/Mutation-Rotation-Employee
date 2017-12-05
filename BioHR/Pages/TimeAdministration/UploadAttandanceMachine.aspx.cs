using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using BioHR.Model.Database;
using BioHR.Model.Function;

namespace BioHR.Pages.TimeAdministration
{
    public partial class UploadAttandanceMachine : BioHR.Controller.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            readExcel();
        }
        private void readExcel()
        {
            try
            {
                if (Path.GetFileName(FileUpload1.PostedFile.FileName) != "")
                {
                    //Upload and save the file
                    string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(excelPath);

                    string conString = string.Empty;
                    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 or higher
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;

                    }
                    conString = string.Format(conString, excelPath);
                    using (OleDbConnection excel_con = new OleDbConnection(conString))
                    {
                        excel_con.Open();
                        string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                        DataTable dtExcelData = new DataTable();

                        using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                        {
                            oda.Fill(dtExcelData);
                        }
                        excel_con.Close();

                        ViewState["uploadData"] = dtExcelData;
                        gvLogResult.DataSource = ViewState["uploadData"];
                        gvLogResult.DataBind();
                        lblTotalRow.Visible = true;
                        lblTotalRow.Text = "Total Rows : " + dtExcelData.Rows.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            isSuccess =  Bulk_Insert();
            //DataTable dtExcelData = new DataTable();
            ////var userId = Session["biofarma_userid"].ToString();
            //var userId = "K815";
            //bool isSuccess = false;
            //if (ViewState["uploadData"] != null)
            //{
            //    dtExcelData = (DataTable)ViewState["uploadData"];
            //    XDocument detailsDocument = ApplicationXmlGenerator.GeneratePresenceTravelToXml(PresenceListCatalog.ListPresensi(dtExcelData));
            //    isSuccess = UploadPresenceTravelEmployee(detailsDocument, userId);
            //}

            if (isSuccess)
            {
                divFailureMessage.Visible = false;
                DisplayInfoMessage("Upload Berhasil,Mohon dicek kembali");
                ViewState["uploadData"] = null;
                gvLogResult.DataSource = null;
                gvLogResult.DataBind();
                lblTotalRow.Visible = false;
            }
        }
        
        protected bool Bulk_Insert()
        {
            var errorMessage = "";
            Boolean isError = true;
            DataTable dtResult = null;
            if (ViewState["uploadData"] != null)
            {
                 dtResult = (DataTable)ViewState["uploadData"];
            }
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("CLDAT", typeof(string)));
            dt.Columns.Add(new DataColumn("PERNR", typeof(string)));
            dt.Columns.Add(new DataColumn("CLOCK", typeof(string)));
            dt.Columns.Add(new DataColumn("STATE", typeof(int)));
            dt.Columns.Add(new DataColumn("MCHNO", typeof(string)));
            dt.Columns.Add(new DataColumn("FLAGS", typeof(int)));
            dt.Columns.Add(new DataColumn("USRDT", typeof(string)));

            foreach (DataRow row in dtResult.Rows )
            {
                string clockDate = Convert.ToDateTime(row["Date"]).ToShortDateString();
                string nikClock = ManualConvertNik(row["NIKLM"].ToString());
                string clockAttendance = Convert.ToDateTime(row["Time"]).ToString("HH:mm:ss");
                string machineNumber = row["Location ID"].ToString();
                int flags = 0;
                int state =  row["Status1"].ToString().ToUpper() == "C/OUT" ? 1 : 0;
                string userChange = HttpContext.Current.Session["biofarma_userid"].ToString() ;
                //string userChange = "K815";
                dt.Rows.Add(clockDate, nikClock, clockAttendance,state, machineNumber, flags, userChange);
            }
            try
            {
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
                            sqlBulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("STATE", "STATE"));
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
            catch (Exception ex)
            {
                isError = false;
                errorMessage = ex.Message;
            }

            if (!isError) {
                DisplayErrorMessage(errorMessage);
            }

            return isError;
        }
        protected void gvLogResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLogResult.PageIndex = e.NewPageIndex;
            gvLogResult.DataSource = ViewState["uploadData"];
            gvLogResult.DataBind();
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            divFailureMessage.Visible = true;
            lbFailureMessage.Text = errorMessage;
        }

        public void DisplayInfoMessage(string infoMessage)
        {
            divInfoMessage.Visible = true;
            lbInfoMessage.Text = infoMessage;
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

        public string ConstructDate(string data)
        {
            return data.Substring(4, 2) + "/" + data.Substring(6, 2) + "/" + data.Substring(0, 4);
        }

        public string ConstructTime(string data)
        {
            return data.Substring(0, 2) + ":" + data.Substring(2, 2);
        }
    }
}