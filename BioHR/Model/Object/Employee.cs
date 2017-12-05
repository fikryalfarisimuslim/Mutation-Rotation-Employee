using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioHR.Model.Object
{
    public class Employee
    {
        protected int _urutan;
        protected string _nik;
        protected string _name;
        protected string _positionName;
        protected string _unitName;

        public int SequenceId
        {
            get { return _urutan; }
            set { _urutan = value; }
        }

        public string Nik
        {
            get { return _nik; }
            set { _nik = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string PositionName
        {
            get { return _positionName; }
            set { _positionName = value; }
        }

        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }
    }
}