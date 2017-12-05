using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BioHR.Model.Object;

namespace BioHR.Controller.Function
{
    public class MenuGenerator
    {
        protected StringBuilder _listMenu = new StringBuilder();

        public StringBuilder ListMenu
        {
            get { return _listMenu; }
            set { _listMenu = value; }
        }

        public void GenerateMenu()
        {
            BioHR.Controller.Database.MenuCatalog getMenu = new Controller.Database.MenuCatalog();
            IList<Menu> topLevelMenus = Controller.Helper.TreeHelper.ConvertToForest(getMenu.GetMenuFromDb());

            foreach (Menu topLevelMenu in topLevelMenus)
            {
                RenderMenuItems(topLevelMenu);
            }
        }

        public void GenerateMenuHorizontal()
        {
            BioHR.Controller.Database.MenuCatalog getMenu = new Controller.Database.MenuCatalog();
            IList<Menu> topLevelMenus = Controller.Helper.TreeHelper.ConvertToForest(getMenu.GetMenuFromDb());

            foreach (Menu topLevelMenu in topLevelMenus)
            {
                RenderMenuItemsHorizontal(topLevelMenu);
            }
        }

        public void RenderMenuItems(Menu menuItem)
        {
            string menuName      = menuItem.MenuName.ToString();
            string navigationUrl = menuItem.NavUrl.ToString();
            string iconClass     = menuItem.IconClass.ToString();

            if ((menuItem.Parent == null) && (menuItem.Children.Count == 0)) {
                GenerateMenuListStructure(menuName, navigationUrl, iconClass, "1");
            }
            else if (menuItem.Children.Count > 0)
            {
                if (menuItem.Parent == null) {
                    GenerateMenuListStructure(menuName, navigationUrl, iconClass, "2");
                }
                else if (menuItem.Parent != null) {
                    GenerateMenuListStructure(menuName, navigationUrl, iconClass, "3");
                }
                foreach (Menu child in menuItem.Children) {
                    if (child.Children.Count > 0) {
                        RenderMenuItems(child);
                    }
                    else {
                        GenerateMenuListStructure(child.MenuName.ToString(), child.NavUrl.ToString(), child.IconClass.ToString(), "4");
                    }
                }
                ListMenu.Append("</ul>");
                ListMenu.Append("</li>");
            }
        }

        public void RenderMenuItemsHorizontal(Menu menuItem)
        {
            string menuName      = menuItem.MenuName.ToString();
            string navigationUrl = menuItem.NavUrl.ToString();
            string iconClass     = menuItem.IconClass.ToString();

            if ((menuItem.Parent == null) && (menuItem.Children.Count == 0)) {
                GenerateMenuListStructureHorizontal(menuName, navigationUrl, iconClass, "3");
            }
            else if (menuItem.Children.Count > 0)
            {
                if (menuItem.Parent == null) {
                    GenerateMenuListStructureHorizontal(menuName, navigationUrl, iconClass, "1");
                }
                else if (menuItem.Parent != null) {
                    GenerateMenuListStructureHorizontal(menuName, navigationUrl, iconClass, "2");
                }
                foreach (Menu child in menuItem.Children) {
                    if (child.Children.Count > 0) {
                        RenderMenuItemsHorizontal(child);
                    }
                    else {
                        GenerateMenuListStructureHorizontal(child.MenuName.ToString(), child.NavUrl.ToString(), child.IconClass.ToString(), "3");
                    }
                }
                ListMenu.Append("</ul>");
                ListMenu.Append("</li>");
            }
        }

        protected void GenerateMenuListStructureHorizontal(string menuName, string navUrl, string navIcon, string type)
        {
            string active = menuName == "Dashboard" ? "active" : "";
            if (type == "1")
            {
                ListMenu.Append("<li class = 'dropdown' class='" + active + "'>");
			ListMenu.Append("<a href = 'javascript:;' data-toggle='dropdown' data-hover='dropdown' class='dropdown-toggle' >");
			    ListMenu.Append("<span>" + menuName + "</span> ");
			    ListMenu.Append("<i class = 'icon-angle-down'></i>");
			ListMenu.Append("</a>");
			ListMenu.Append("<ul class = 'dropdown-menu'>");
			    /*Generate <li> element for sub menu*/
			//ListMenu.Append("</ul>");
                //ListMenu.Append("</li>");
            }
            if (type == "2")
            {
                ListMenu.Append("<li class = 'dropdown'>");
			ListMenu.Append("<a href = 'javascript:;' data-toggle='dropdown' data-hover='dropdown' class='dropdown-toggle' >");
			    ListMenu.Append("<span>" + menuName + "</span> ");
			    ListMenu.Append("<i class = 'icon-angle-right'></i>");
		    ListMenu.Append("</a>");
            ListMenu.Append("<ul class = 'dropdown-menu'>");
			    /*Generate <li> element for sub menu*/
			//ListMenu.Append("</ul>");
                //ListMenu.Append("</li>");
            }
            if (type == "3")
            {
                ListMenu.Append("<li class='" + active + "'><a href = '" + navUrl + "'>" + menuName + "</a></li>");
            }
        }

        protected void GenerateMenuListStructure(string menuName, string navUrl, string navIcon, string type)
        {
            if (type == "1")
            {
                ListMenu.Append("<li>");
			ListMenu.Append("<a href = '" + navUrl + "'>");
			    ListMenu.Append("<i class = '" + navIcon + "'></i>");
			    ListMenu.Append("<span>" + menuName + "</span>");
			ListMenu.Append("</a>");
                ListMenu.Append("</li>");
            }
            if (type == "2")
            {
                ListMenu.Append("<li class = 'sub-menu'>");
			ListMenu.Append("<a href = 'javascript:;'>");
			    ListMenu.Append("<i class = '" + navIcon + "'></i>");
			    ListMenu.Append("<span>" + menuName + "</span>");
			ListMenu.Append("</a>");
			ListMenu.Append("<ul class = 'sub'>");
			    /*Generate <li> element for sub menu*/
			//ListMenu.Append("</ul>");
                //ListMenu.Append("</li>");
            }
            if (type == "3")
            {
                ListMenu.Append("<li class = 'sub-menu'>");
			ListMenu.Append("<a href = 'javascript:;'>");
			    ListMenu.Append("<span>" + menuName + "</span>");
			    ListMenu.Append("</a>");
			ListMenu.Append("<ul class = 'sub'>");
			    /*Generate <li> element for sub menu*/
			//ListMenu.Append("</ul>");
                //ListMenu.Append("</li>");
            }
            if (type == "4")
            {
                ListMenu.Append("<li><a href = '" + navUrl + "'>" + menuName + "</a></li>");
            }
        }
    }
}