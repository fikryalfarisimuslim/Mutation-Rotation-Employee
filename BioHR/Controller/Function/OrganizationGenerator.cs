using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using BioHR.Model.Object;

namespace BioHR.Controller.Function
{
    public class OrganizationGenerator
    {
        protected Organization _organization = new Organization();
        protected StringBuilder _listOrganization = new StringBuilder();

        public StringBuilder ListOrganization
        {
            get { return _listOrganization; }
            set { _listOrganization = value; }
        }

        public void GenerateOrganization()
        {
            Database.OrganizationCatalog getOrganization = new Controller.Database.OrganizationCatalog();
            IList<Organization> topLevelOrganizations =
                Controller.Helper.TreeHelper.ConvertToForest(getOrganization.GetOrganizations());

            foreach (Organization topLevelOrganization in topLevelOrganizations)
            {
                RenderOrganizationItems(topLevelOrganization);
            }
        }

        public void RenderOrganizationItems(Organization organizationItem)
        {
            string organizationName = organizationItem.OrganizationName;

            if ((organizationItem.Parent == null) && (organizationItem.Children.Count == 0))
            {
                GenerateOrganizationListStructure("#", organizationName, "1",
                    organizationItem.OrganizationStatus);
            }
            else if (organizationItem.Children.Count > 0)
            {
                GenerateOrganizationListStructure("#", organizationName, "2",
                    organizationItem.OrganizationStatus);
                string temp = "";
                foreach (Organization child in organizationItem.Children)
                {

                    if (child.Children.Count > 0)
                    {
                        RenderOrganizationItems(child);

                    }
                    else
                    {
                        GenerateOrganizationListStructure(child.Id.ToString(), child.OrganizationName.ToString(),
                            "1",
                            child.OrganizationStatus);
                    }
                }

                ListOrganization.Append("</ol>");
                ListOrganization.Append("</li>");
            }
        }

        protected void GenerateOrganizationListStructure(string organizationID, string organizationName, string type,
           string status)
        {
            if (type == "1")
            {
                ListOrganization.Append("<li class ='dd-item'>");
                if (status == "C")
                {
                    ListOrganization.Append(
                        "<div class = 'dd-handle'><i class='fa fa-check-square'></i><a href='OrganizationalAssignment.aspx?orgid=" +
                        organizationID + "'> " + organizationName + "</a></div>");
                }
                else if (status == "L")
                {
                    ListOrganization.Append(
                        "<div class = 'dd-handle'><i class='fa fa-chevron-right'></i><a href='OrganizationalAssignment.aspx?orgid=" +
                        organizationID + "'> " + organizationName + "</a></div>");
                }
                else
                {
                    ListOrganization.Append(
                        "<div class = 'dd-handle'><i class='fa fa-chevron-down'></i><a href='OrganizationalAssignment.aspx?orgid=" +
                        organizationID + "'> " + organizationName + "</a></div>");
                }
                ListOrganization.Append("</li>");
            }
            else if (type == "2")
            {
                ListOrganization.Append("<li class ='dd-item'>");
                if (status == "C")
                {
                    ListOrganization.Append(
                        "<div class = 'dd-handle'><i class='fa fa-check-square'></i><a href='OrganizationalAssignment.aspx?orgid=" +
                        organizationID + "'> " + organizationName + "</a></div>");
                }
                else if (status == "L")
                {
                    ListOrganization.Append(
                        "<div class = 'dd-handle'><i class='fa fa-chevron-right'></i><a href='OrganizationalAssignment.aspx?orgid=" +
                        organizationID + "'> " + organizationName + "</a></div>");
                }
                else
                {
                    ListOrganization.Append(
                        "<div class = 'dd-handle'><i class='fa fa-chevron-down'></i><a href='OrganizationalAssignment.aspx?orgid=" +
                        organizationID + "'> " + organizationName + "</a></div>");
                }
                ListOrganization.Append("<ol class = 'dd-list'>");


            }
        }
    }
}