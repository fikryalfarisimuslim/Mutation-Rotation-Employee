using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioHR.Controller.Function;
using BioHR.Model.Database;
using System.Data;
using System.Text;

namespace BioHR.Pages.Organization
{
    public partial class ListOfEmployee : BioHR.Controller.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                DataTable dt = OrganizationDataCatalog.GetListAllEmployee();


                //Building an HTML string.
                StringBuilder html = new StringBuilder();

              
                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    html.Append("<td class='inbox-small-cells' style='text-align:center'>");
                    html.Append("<input type='checkbox' class='mail-checkbox'/>");
                    html.Append("</td>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }


                //Append the HTML string to Placeholder.
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                /*For DropdownList*/
                //Populating a DataTable from database.
                DataTable dt2 = OrganizationDataCatalog.GetParameterDropDownList();

                DropDownListSK.DataSource = dt2;
                DropDownListSK.DataTextField = "PRMNM";
                DropDownListSK.DataValueField = "PRMKD";
                DropDownListSK.DataBind();
            }
        }

        protected void btnPilih_OnClick(object sender, EventArgs e)
        {
            
        }

    }
}