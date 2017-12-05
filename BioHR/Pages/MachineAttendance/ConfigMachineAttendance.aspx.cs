using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioHR.Controller.Function;
using BioHR.Model.Database;

namespace BioHR.Pages.MachineAttendance
{
    public partial class AddMachineAttendance : BioHR.Controller.BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvConfigMachineAttendance.DataSource = MachineProcessDataCatalog.GetConfigMachine();
                gvConfigMachineAttendance.DataBind();
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e){
            Response.Redirect("~/Pages/MachineAttendance/AddMachineAttendance.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string editConfig = (sender as LinkButton).CommandArgument;
            Response.Redirect("~/Pages/MachineAttendance/EditMachineAttendance.aspx?" + editConfig);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string delConfig = (sender as LinkButton).CommandArgument;
            MachineProcessDataCatalog.DelimitConfigMachine(Convert.ToInt32(delConfig));
            Response.Redirect("~/Pages/MachineAttendance/ConfigMachineAttendance.aspx");
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Connection Successfully')", true);

        }

        protected void tbSearch_TextChanged(object sender, EventArgs e)
        {
            gvConfigMachineAttendance.DataSource = MachineProcessDataCatalog.GetSearchingMachineBy(tbSearch.Text.Trim(), Convert.ToInt32(ddlTipeMesin.SelectedValue));
            gvConfigMachineAttendance.DataBind();
        }

        protected void tbSearch_onClick(object sender, EventArgs e)
        {
            gvConfigMachineAttendance.DataSource = MachineProcessDataCatalog.GetSearchingMachineBy(tbSearch.Text.Trim(), Convert.ToInt32(ddlTipeMesin.SelectedValue));
            gvConfigMachineAttendance.DataBind();
        }
    }
}