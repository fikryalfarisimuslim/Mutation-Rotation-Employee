using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioHR.Controller.Function;

namespace BioHR.Pages.Approval
{
    public partial class RequestApprovalList : BioHR.Controller.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //InitializeGridView(); // temporary method to see the header when data empty
            }
        }

        #region :: Query String Function ::

        public bool IsQueryStringExist(string queryKey)
        {
            return (Request.QueryString[queryKey] != null && Request.QueryString[queryKey] != "");
        }

        public void GetQueryStringData()
        {
            if ((IsQueryStringExist("docid")) && (IsQueryStringExist("doccd")))
            {
                Session["document_id"] = ExtractQueryString(Request.QueryString["docid"].ToString());
                Session["document_code"] = ExtractQueryString(Request.QueryString["doccd"].ToString());
            }
        }

        public string GetQueryStringData(string dt, bool encrypted)
        {
            string data = "";

            if (Request.QueryString[dt] != null && Request.QueryString[dt] != "")
            {
                data = encrypted ? ExtractQueryString(Request.QueryString[dt]) : Request.QueryString[dt];
            }

            return data;
        }

        public string ExtractQueryString(string queryData)
        {
            return CryptographFactory.Decrypt(queryData, true);
        }

        public string EncryptQueryString(string queryData)
        {
            return CryptographFactory.Encrypt(queryData, true);
        }

        #endregion

        #region :: Grid view Review List Approval Function ::

        public void InitializeGridView()
        {
            var dt = new DataTable();

            dt.Columns.Add(new DataColumn("DOCID", typeof(int)));
            dt.Columns.Add(new DataColumn("DOCCD", typeof(string)));
            dt.Columns.Add(new DataColumn("BEGDA", typeof(string)));
            dt.Columns.Add(new DataColumn("PERNR", typeof(string)));
            dt.Columns.Add(new DataColumn("CNAME", typeof(string)));
            dt.Columns.Add(new DataColumn("PRORG", typeof(string)));
            dt.Columns.Add(new DataColumn("DOCTY", typeof(string)));
            dt.Columns.Add(new DataColumn("DOCDSC", typeof(string)));

            gvApprovalList.DataSource = dt;
            gvApprovalList.DataBind();
        }

        public string GetLabelClass(object docCode)
        {
            string label = "label label-mini ";

            switch (docCode.ToString())
            {
                case "PSC":
                    label += "label-primary";
                    break;
                case "DYF":
                    label += "label-default";
                    break;
                case "ILS":
                    label += "label-warning";
                    break;
                default:
                    label += "label-info";
                    break;
            }

            return label;
        }

        public string GetDocumentName(object docCode)
        {
            string attendanceStatus = "";

            switch (docCode.ToString())
            {
                case "0":
                    attendanceStatus = "Masuk Bekerja";
                    break;
                case "1":
                    attendanceStatus = "Pulang Bekerja";
                    break;
                case "2":
                    attendanceStatus = "Awal Lembur";
                    break;
                case "3":
                    attendanceStatus = "Akhir Lembur";
                    break;
            }

            return attendanceStatus;
        }

        public string GetReviewLink(object docId, object docCd, object docUrl)
        {
            string urlLink = "#";

            //urlLink = "~/Pages/Attendance/EmployeeManualAbsence.aspx?id=" + CryptographFactory.Encrypt(docId.ToString(), true);
            urlLink = docUrl + "?docid=" + EncryptQueryString(docId.ToString()) + "&doccd=" + EncryptQueryString(docCd.ToString()) + "&role=" + EncryptQueryString(GetDetailOvertimeMode()) + "&mode=" + EncryptQueryString("review");

            return urlLink;
        }

        public string GetDetailOvertimeMode()
        {
            var roleid = Session["biofarma_roleid"].ToString();

            return roleid == ConfigurationManager.AppSettings["FiaturRoleId"] ? "fiatur" : "hr";
        }

        protected void gvApprovalList_OnPreRender(object sender, EventArgs e)
        {
            if (gvApprovalList.Rows.Count > 0)
            {
                gvApprovalList.UseAccessibleHeader = true;
                gvApprovalList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        #endregion

    }
}