using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioHR.Pages.MachineAttendance
{
    public partial class EmployeeAttendanceLogMachine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDataDdlEmployee();

        }

        private void PopulateDataDdlEmployee()
        {
            DataTable dt = ((DataView)sdsDataKaryawan.Select(DataSourceSelectArguments.Empty)).Table;
            DataRow dr = dt.NewRow();
            dr["PERNR"] = "";
            dr["CNAME"] = "";
            dr["PRORG"] = "";
            dr["PRPOS"] = "";
            dt.Rows.Add(dr);
            ddlName.DataSource = dt;

            ddlName.DataSource = sdsDataKaryawan;
            ddlName.DataValueField = "PERNR";
            ddlName.DataTextField = "CNAME";

            ddlName.DataBind();
            ddlName.SelectedValue = "";
        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sdsDataKaryawanbyPRNR.SelectParameters.RemoveAt(0);
            System.Web.UI.WebControls.ControlParameter param = new System.Web.UI.WebControls.ControlParameter();
            param.Name = "pPERNR";
            param.ControlID = "ddlName";
            param.PropertyName = "SelectedValue";
            sdsDataKaryawanbyPRNR.SelectParameters.Add(param);
            sdsDataKaryawanbyPRNR.DataBind();
            DataTable dt = ((DataView)sdsDataKaryawanbyPRNR.Select(DataSourceSelectArguments.Empty)).Table;
            if (dt.Rows.Count > 0)
            {
                PopulateIdentitas(dt);
            }
        }

        private void PopulateIdentitas(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                tbNik.Text = dt.Rows[0]["PERNR"].ToString();
                ddlName.SelectedValue = dt.Rows[0]["PERNR"].ToString();
                tbPosition.Text = dt.Rows[0]["PRPOS"].ToString();
                tbUnitName.Text = dt.Rows[0]["PRORG"].ToString();
            }
        }

        protected void tbNik_TextChanged(object sender, EventArgs e)
        {
            sdsDataKaryawanbyPRNR.SelectParameters.RemoveAt(0);
            System.Web.UI.WebControls.ControlParameter param = new System.Web.UI.WebControls.ControlParameter();
            param.Name = "pPERNR";
            param.ControlID = "tbNik";
            param.PropertyName = "Text";
            sdsDataKaryawanbyPRNR.SelectParameters.Add(param);
            sdsDataKaryawanbyPRNR.DataBind();

            DataTable dt = ((DataView)sdsDataKaryawanbyPRNR.Select(DataSourceSelectArguments.Empty)).Table;
            if (dt.Rows.Count > 0)
            {
                PopulateIdentitas(dt);
            }
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            divFailureMessage.Visible = true;
            lbFailureMessage.Text = errorMessage;
        }
    }
}