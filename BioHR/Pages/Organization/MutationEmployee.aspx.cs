﻿using BioHR.Model.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace BioHR.Pages.Organization
{
    public partial class MutationEmployee : BioHR.Controller.BasePage
    {

        DataTable dtblContractDetailByNoSK = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            
                //Populating a DataTable from database.
                DataTable dt = OrganizationDataCatalog.GetListEmptyPosition();


                //Building an HTML string.
                StringBuilder html = new StringBuilder();

                html.Append("<table id='tableHidden' style='display:none'>");
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }
                html.Append("<table>");


                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });


                iTanggalSK.Disabled = true;
                iTanggalBerlaku.Disabled = true;
        }

        protected void getValueNoSK(object sender, EventArgs e)
        {
            string noSK = iNoSK.Text.Trim();
            string tanggalSK;
            string tanggalBerlaku;
            
            dtblContractDetailByNoSK = OrganizationDataCatalog.GetDataContractDetailByNoSK(noSK);

            if (dtblContractDetailByNoSK != null)
            {
                foreach (DataRow dr in dtblContractDetailByNoSK.Rows)
                {
                    tanggalSK = dtblContractDetailByNoSK.Rows[0]["CTRDT"].ToString();
                    DateTime dtTanggalSK = Convert.ToDateTime(tanggalSK);
                    iTanggalSK.Value = string.Format("{0:MM/dd/yyyy}", dtTanggalSK);

                    iJudulSK.Value = dtblContractDetailByNoSK.Rows[0]["PRMNM"].ToString();
                    iNamaPengesah.Value = dtblContractDetailByNoSK.Rows[0]["CTRPR"].ToString();

                    tanggalBerlaku = dtblContractDetailByNoSK.Rows[0]["EFFDT"].ToString();
                    DateTime dtTanggalBerlaku = Convert.ToDateTime(tanggalBerlaku);
                    iTanggalBerlaku.Value = string.Format("{0:MM/dd/yyyy}", dtTanggalBerlaku);

                    fileUploadText.Value = dtblContractDetailByNoSK.Rows[0]["FILNM"].ToString();
                    iKeterangan.Value = dtblContractDetailByNoSK.Rows[0]["CTRDC"].ToString();

                    iTanggalSK.Disabled = true;
                    iJudulSK.Disabled = true;
                    iNamaPengesah.Disabled = true;
                    iTanggalBerlaku.Disabled = true;
                    FileUpload2.Enabled = false;
                    iKeterangan.Disabled = true;

                    btnTanggalSK.Disabled = true;
                    btnTanggalBerlaku.Disabled = true;
                    btnSK.Enabled = false;
                }
            }
        }

        protected void BtnSK_OnClick(object sender, EventArgs e)
        {
            string filePath = FileUpload2.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string fn;
            string filesize = FileUpload2.PostedFile.ContentLength.ToString();;
            
            iTanggalSK.Disabled = true;
            iJudulSK.Disabled = true;
            iNamaPengesah.Disabled = true;
            iTanggalBerlaku.Disabled = true;
            FileUpload2.Enabled = false;
            //iUploadSK.Disabled = true;
            iKeterangan.Disabled = true;
            btnSK.Enabled = false;
            //string contenttype = String.Empty;

            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                fn = DateTime.Now.ToString("yyyyMMdd") + "_FileSK_" + filename;
                string SaveLocation = Server.MapPath("~/Upload") + "\\" + fn;
                OrganizationDataCatalog.InsertSKEmployee(iNoSK.Text.Trim(), iJudulSK.Value + " " + iKeterangan.Value, iTanggalSK.Value, iNamaPengesah.Value, iTanggalBerlaku.Value, iJudulSK.Value, "1856", fn, fn, "~/Upload", filesize, ext, "SK");
                try
                {
                    FileUpload2.PostedFile.SaveAs(SaveLocation);
                    //Response.Write("The file has been uploaded.");

                    
                }
                catch (Exception ex)
                {
                    //Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                //Response.Write("Please select a file to upload.");
            }

        }

        protected void btnHidden_OnClick(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                
            }

            OrganizationDataCatalog.MutationOrganization(txtHidden1.Value, txtHidden2.Value, txtHidden3.Value, txtHidden4.Value, iNoSK.Text, iJudulSK.Value, iTanggalBerlaku.Value, "1853" , Convert.ToInt32(txtHidden5.Value));
            //Response.Write("Berhasil Mutasi");
        }

        protected void btnBatal_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Organization/ListOfEmployee.aspx");
        }

        protected void btnSimpan_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Organization/ListOfEmployee.aspx");
        }

    }
}