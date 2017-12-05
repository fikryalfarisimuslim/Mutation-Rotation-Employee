using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioHR.Controller.Function;

namespace BioHR.MasterPages
{
    public partial class FormPage : System.Web.UI.MasterPage
    {
        MenuGenerator Menu = new MenuGenerator();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["biofarma_userid"] != null)
            {
                Menu.GenerateMenu();
                navAccordion.InnerHtml = Menu.ListMenu.ToString();
                lbUserName.Text = Session["biofarma_username"].ToString();
            }
        }
    }
}