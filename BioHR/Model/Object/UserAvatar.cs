using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioHR.Model.Object
{
    public class UserAvatar
    {
        private string _userId;
        private string _userName;
        private string _userEmail;
        private string _userAvatarImage;
        private string _userOrganization;
        private string _userPosition;

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

        public string UserAvatarImage
        {
            get { return _userAvatarImage; }
            set { _userAvatarImage = value; }
        }

        public string UserOrganization
        {
            get { return _userOrganization; }
            set { _userOrganization = value; }
        }

        public string UserPosition
        {
            get { return _userPosition; }
            set { _userPosition = value; }
        }
    }
}