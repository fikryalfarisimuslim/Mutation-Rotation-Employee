using BioHR.Model.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioHR.Pages.Organization
{
    public partial class RotationEmployee : System.Web.UI.Page
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
                    iUploadSK.Disabled = true;
                    iKeterangan.Disabled = true;

                    btnTanggalSK.Disabled = true;
                    btnTanggalBerlaku.Disabled = true;

                }
            }
        }
    }
}