using BioHR.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioHR.Pages.MachineAttendance
{
    public partial class EditMachineAttendance : BioHR.Controller.BasePage
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                tbNamaMesin.Text = Request.QueryString["name"];
                tbIpMesin.Text = Request.QueryString["ip"];
                tbPortMesin.Text = Request.QueryString["port"];
                tbDesMesin.Text = Request.QueryString["des"];
                string tipe = Request.QueryString["tipe"];
                ddlTipeMesin.Items.FindByText(tipe).Selected = true;
            }
        }

        protected void btnBatal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MachineAttendance/ConfigMachineAttendance.aspx");
        }

        protected void btnSimpan_Click(object sender, EventArgs e)
        {
            MachineProcessDataCatalog.UpdateConfigMachine(Convert.ToInt32(id), tbNamaMesin.Text.Trim(), tbIpMesin.Text.Trim(), Convert.ToInt32(tbPortMesin.Text), Convert.ToInt32(ddlTipeMesin.SelectedItem.Value), ddlTipeMesin.SelectedItem.Text, 1, tbDesMesin.Text.Trim());
            Response.Redirect("~/Pages/MachineAttendance/ConfigMachineAttendance.aspx");
        }

    }
}