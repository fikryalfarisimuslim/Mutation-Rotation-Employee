using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioHR.Model.Object
{
    public class OrganizationRelation
    {
        public string RelationType { get; set; }
        public string RelationId { get; set; }
        public string OrganizationTypeParent { get; set; }
        public string OrganizationIdParent { get; set; }
        public string OrganizationCodeParent { get; set; }
        public string OrganizationNameParent { get; set; }
        public string OrganizationTypeChild { get; set; }
        public string OrganizationIdChild { get; set; }
        public string OrganizationCodeChild { get; set; }
        public string OrganizationNameChild { get; set; }

    }
}