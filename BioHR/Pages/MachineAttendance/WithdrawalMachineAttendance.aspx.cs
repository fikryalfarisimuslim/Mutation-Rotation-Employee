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
    public partial class WithdrawalMachineAttendance : BioHR.Controller.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvWithdrawalMachineAttendance.DataSource = MachineProcessDataCatalog.GetWithdrawalMachine();
                gvWithdrawalMachineAttendance.DataBind();
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MachineAttendance/LogMachineAttendance.aspx");
        }

        protected void btnRecallMachine_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Penarik Mesin Berhasil')", true);
        }

        protected void btnRecallAllMachine_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Penarikan Semua Mesin Berhasil')", true);
        }

    }
}