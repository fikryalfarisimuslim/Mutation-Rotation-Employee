using BioHR.Model.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

               
            
        }

        protected void getValueNoSK(object sender, EventArgs e)
        {
            string noSK = iNoSK.Text.Trim();
            
            dtblContractDetailByNoSK = OrganizationDataCatalog.GetDataContractDetailByNoSK(noSK);

            

            if (dtblContractDetailByNoSK != null)
            {
                foreach (DataRow dr in dtblContractDetailByNoSK.Rows)
                {
                    iTanggalSK.Value = dtblContractDetailByNoSK.Rows[0]["CTRDT"].ToString();
                    iJudulSK.Value = dtblContractDetailByNoSK.Rows[0]["PRMNM"].ToString();
                    iNamaPengesah.Value = dtblContractDetailByNoSK.Rows[0]["CNAME"].ToString();
                    iTanggalBerlaku.Value = dtblContractDetailByNoSK.Rows[0]["EFFDT"].ToString();
                    //iUploadSK.Value = dtblContractDetailByNoSK.Rows[0]["FILNM"].ToString();
                    //iUploadSK.Value = "ABCASD";
                    iKeterangan.Value = dtblContractDetailByNoSK.Rows[0]["CTRDC"].ToString();
                    
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