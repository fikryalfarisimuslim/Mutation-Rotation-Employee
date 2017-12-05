using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BioHR.Controller.Database;
using System.Data.SqlClient;
using System.Data;
using BioHR.Model.Database;
using BioHR.Model.Object;

namespace BioHR.Controller.Database
{
    public class OrganizationCatalog
    {
        List<Organization> listOrganization = new List<Organization>();

        public List<Organization> GetOrganizationFromDb()
        {
            SqlConnection conn = DatabaseSql.GetConnection();
            SqlCommand cmd = DatabaseSql.GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM BIOFARMA.bioumum.V_ORGANIZATION_STRUCTURE;";

                SqlDataReader reader = DatabaseSql.GetDataReader(cmd);
                while (reader.Read())
                {
                    Organization m = new Organization();
                    m.Id = Convert.ToInt16(reader["ORGID"]);
                    m.OrganizationName = Convert.ToString(reader["ORGNM"]);
                    //If the Parent ID [PRRID] in database == Null, then it was the first level (root)
                    if (reader["PRTID"] != DBNull.Value)
                    {
                        m.Parent = new Organization();
                        m.Parent.Id = Convert.ToInt16(reader["PRTID"]);
                    }
                    listOrganization.Add(m);
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return listOrganization;
        }

        public List<Organization> GetOrganizations()
        {
            SqlConnection conn = DatabaseSql.GetConnection();
            string _cmdSql = @"SELECT OL.OICLD, OD.ORGNM , OL.OIPRT, OL.STRID, OL.OTCLD, OL.[LEVEL], COALESCE(OS.ORGST, 'X') AS ORGST
                                 FROM BIOFARMA.bioumum.ORGANIZATION_DATA OD ,BIOFARMA.bioumum.ORGANIZATIONAL_RELATION OL FULL JOIN BIOFARMA.bioumum.ORGANIZATIONAL_STATUS OS ON OL.OICLD = OS.ORGID
                                 WHERE OD.ORGID = OL.OICLD ORDER BY ORGST ASC";
            SqlCommand cmd = DatabaseSql.GetCommand(conn, _cmdSql);
            try
            {
                conn.Open();
                SqlDataReader reader = DatabaseSql.GetDataReader(cmd);
                List<Organization> organizations = new List<Organization>();
                string temp = "";
                while (reader.Read())
                {
                    if (temp != Convert.ToString(reader["ORGNM"]))
                    {
                        Organization m = new Organization();
                        temp = m.OrganizationName = Convert.ToString(reader["ORGNM"]);
                        m.Id = Convert.ToInt16(reader["OICLD"]);
                        m.OrganizationStatus = Convert.ToString(reader["ORGST"]);
                        if (reader["OIPRT"] != DBNull.Value)
                        {
                            m.Parent = new Organization();
                            m.Parent.Id = Convert.ToInt16(reader["OIPRT"]);
                        }
                        organizations.Add(m);
                    }
                }
                return organizations;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}