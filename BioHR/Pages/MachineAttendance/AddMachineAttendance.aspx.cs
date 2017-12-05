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

namespace BioHR.Pages.MachineAttendance
{
    public partial class AddMachineAttendance1 : BioHR.Controller.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBatal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MachineAttendance/ConfigMachineAttendance.aspx");
        }

        protected void btnSimpan_Click(object sender, EventArgs e)
        {
            MachineProcessDataCatalog.AddConfigMachine(tbNamaMesin.Text.Trim(), tbIpMesin.Text.Trim(), Convert.ToInt32(tbPortMesin.Text), Convert.ToInt32(ddlTipeMesin.SelectedValue), ddlTipeMesin.SelectedItem.Text, 1, tbDesMesin.Text.Trim());
            Response.Redirect("~/Pages/MachineAttendance/ConfigMachineAttendance.aspx");
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Connection Successfully')", true);

        }

    }
}