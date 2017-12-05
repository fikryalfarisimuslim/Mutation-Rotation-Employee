using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using BioHR.Model.Database;

namespace BioHR
{
    public partial class Default : BioHR.Controller.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod]
        public static string GetGraph()
        {
            DataTable dtPosisi = OrganizationDataCatalog.GetPosisi();
            List<Default.GrafikPosisi> listPosisi = new List<Default.GrafikPosisi>();


            for (int i = 0; i < dtPosisi.Rows.Count; i++)
            {
                Default.GrafikPosisi grafik = new Default.GrafikPosisi();
                grafik.NamaJabatan = dtPosisi.Rows[i]["PRMNM"].ToString();
                grafik.Jumlah = Convert.ToInt32(dtPosisi.Rows[i]["JUMLAH"].ToString());
                listPosisi.Add(grafik);
            }
            string n = string.Empty; string JSONString = string.Empty;
            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(listPosisi);

            return JSONString;
        }

        public class GrafikPosisi
        {
            public string NamaJabatan { get; set; }
            public int Jumlah { get; set; }

        }
    }
}