using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BioHR.Model.Object;

namespace BioHR.Model.Function
{
    public class EmployeeListConstructor
    {
        public static List<Employee> SelectedEmployee(DataTable documentDataTable)
        {
            List<Employee> listSelectedEmployee = new List<Employee>();
            string userid = HttpContext.Current.Session["biofarma_userid"].ToString();

            if (documentDataTable.Rows.Count > 0)
            {
                int seqId = 0;

                foreach (DataRow row in documentDataTable.Rows)
                {
                    var det = new Employee();

                    det.Nik = row["PERNR"].ToString();
                    det.Name = row["CNAME"].ToString();
                    det.PositionName = row["PRPOS"].ToString();
                    det.UnitName = row["PRORG"].ToString();

                    seqId++;
                    det.SequenceId = seqId;

                    listSelectedEmployee.Add(det);
                }
            }

            return listSelectedEmployee;
        }
    }
}