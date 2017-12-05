using System.Collections.Generic;

namespace BioHR.Model.Object
{
    public class Organization : BioHR.Controller.Helper.ITreeNode<Organization>
    {
        //Current Node Information
        protected int _organizationId;
        protected string _organizationName;
        protected string _organizationStatus;
        protected string _organizationType;
        protected string _navUrl;
        protected string _iconClass;
        protected Organization _parent;
        protected IList<Organization> _children;

        /// <summary>
        /// Using ITreeNode Helper Function, which is a helper function to convert flat array into tree node
        /// We have to implement the ITreeNode interface (ITreeNode<ClassObject>) into the object class (using inheritance)
        /// We also have to provide at least three properties in the object class with pointed name and type, as because it was available in the Interface
        /// so we have to implement it. The three properties are :
        /// Id : Int
        /// Parent : Class Object
        /// Children : IList<ClassObject>
        /// </summary>

        public int Id
        {
            get { return _organizationId; }
            set { _organizationId = value; }
        }

        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
        }

        public string OrganizationType
        {
            get { return _organizationType; }
            set { _organizationType = value; }
        }

        public string OrganizationStatus
        {
            get { return _organizationStatus; }
            set { _organizationStatus = value; }
        }

        public string NavUrl
        {
            get { return _navUrl; }
            set { _navUrl = value; }
        }

        public string IconClass
        {
            get { return _iconClass; }
            set { _iconClass = value; }
        }

        public Organization Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public IList<Organization> Children
        {
            get { return _children; }
            set { _children = value; }
        }

        public Organization() { }

        public Organization(int organizationId, string organizationName, Organization parentId)
        {
            _organizationId = organizationId;
            _organizationName = organizationName;
            _parent = parentId;
        }

        public Organization(int organizationId, string organizationName, string organizationStatus, Organization parentId)
        {
            _organizationId = organizationId;
            _organizationName = organizationName;
            _organizationStatus = organizationStatus;
            _parent = parentId;
        }

        public Organization(int organizationId, string organizationName, Organization parentId, string navUrl, string iconClass)
        {
            _organizationId = organizationId;
            _organizationName = organizationName;
            _parent = parentId;
            _navUrl = navUrl;
            _iconClass = iconClass;
        }
    }
}