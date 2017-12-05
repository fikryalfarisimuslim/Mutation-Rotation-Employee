﻿namespace BioHR.Model.Object
{
    public class User
    {
        protected string _nama;
        protected string _userId;
        protected string _posid;
        protected string _roleId;
        protected string _userName;
        protected string _roleName;
        protected string _positionName;
        protected string _unitCode;
        protected string _unitName;
        protected string _password;
        protected string _grade;

        protected string _hostName;
        protected string _hostIP;

        public string Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }

        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Posid
        {
            get { return _posid; }
            set { _posid = value; }
        }

        public string RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string PositionName
        {
            get { return _positionName; }
            set { _positionName = value; }
        }

        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value; }
        }

        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        public string Grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        public User() { }

        public User(string nik, string nama, string roleid)
        {
            _userId = nik;
            _nama = nama;
            _roleId = roleid;
        }

	    public User(string nik, string nama, string roleid, string username, string rolename, string password)
        {
            _userId = nik;
            _nama = nama;
            _roleId = roleid;
            _userName = username;
            _roleName = rolename;
            _password = password;
        }

	    public User(string nik, string positionId, string nama, string posname, string untcode, string untname, string roleid, string rolename, string grade, string hostname, string hostip)
        {
            _userId = nik;
	        _posid = positionId; 
            _nama = nama;
	        _positionName = posname;
	        _unitCode = untcode;
	        _unitName = untname;
            _roleId = roleid;
            _roleName = rolename;
	        _grade = grade;
            _hostName = hostname;
            _hostIP = hostip;
        }

    }
}