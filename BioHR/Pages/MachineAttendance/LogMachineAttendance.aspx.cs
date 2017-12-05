using BioHR.Model.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioHR.Pages.MachineAttendance
{
    public partial class LogMachineAttendance : BioHR.Controller.BasePage
    {
        public static DataTable temp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                temp = MachineProcessDataCatalog.GetLogMachineAttendance();
            }
            gvLogMachineAttendance.DataSource = temp;
            gvLogMachineAttendance.DataBind();
        }

        protected void btnWithdrawal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MachineAttendance/WithdrawalMachineAttendance.aspx");
        }

        protected void OnPagingLogMachine(object sender, GridViewPageEventArgs e)
        {
            gvLogMachineAttendance.DataSource = temp;
            gvLogMachineAttendance.PageIndex = e.NewPageIndex;
            gvLogMachineAttendance.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            temp = MachineProcessDataCatalog.GetSearchingLogMachineBy(tbSearch.Text.Trim(), startDate.Text.Trim(), endDate.Text.Trim());
            gvLogMachineAttendance.DataSource = temp;
            gvLogMachineAttendance.DataBind();

        }
    }
}