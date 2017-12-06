﻿using BioHR.Model.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioHR.Pages.Organization
{
    public partial class RotationEmployee : BioHR.Controller.BasePage
    {

        DataTable dtblContractDetailRotation = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getValueNoSK(object sender, EventArgs e)
        {
            string noSK = iNoSK.Text.Trim();

            dtblContractDetailRotation = OrganizationDataCatalog.GetDataContractDetailRotation(noSK);



            if (dtblContractDetailRotation != null)
            {
                foreach (DataRow dr in dtblContractDetailRotation.Rows)
                {
                    iTanggalSK.Value = dtblContractDetailRotation.Rows[0]["CTRDT"].ToString();
                    iJudulSK.Value = dtblContractDetailRotation.Rows[0]["PRMNM"].ToString();
                    iNamaPengesah.Value = dtblContractDetailRotation.Rows[0]["CNAME"].ToString();
                    iTanggalBerlaku.Value = dtblContractDetailRotation.Rows[0]["EFFDT"].ToString();
                    //iUploadSK.Value = dtblContractDetailByNoSK.Rows[0]["FILNM"].ToString();
                    //iUploadSK.Value = "ABCASD";
                    iKeterangan.Value = dtblContractDetailRotation.Rows[0]["CTRDC"].ToString();

                    iTanggalSK.Disabled = true;
                    iJudulSK.Disabled = true;
                    iNamaPengesah.Disabled = true;
                    iTanggalBerlaku.Disabled = true;
                    iKeterangan.Disabled = true;

                    btnTanggalSK.Disabled = true;
                    btnTanggalBerlaku.Disabled = true;

                    btnSK.Enabled = false;
                    FileUpload2.Enabled = false;

                }
            }
        }

        protected void BtnSK_OnClick(object sender, EventArgs e)
        {
            string filePath = FileUpload2.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                string fn = DateTime.Now.ToString("yyyyMMdd") + "_FileSK_" + filename;
                string SaveLocation = Server.MapPath("~/Upload") + "\\" + fn;
                try
                {
                    FileUpload2.PostedFile.SaveAs(SaveLocation);
                    Response.Write("The file has been uploaded.");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }

        }
    }
}