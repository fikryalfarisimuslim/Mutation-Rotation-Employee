using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BioHR.Model.Object;

namespace BioHR.Model.Function
{
    public class PresenceListCatalog
    {
        public static List<Presensi> ListPresensi(DataTable documentDataTable)
        {
            List<Presensi> listPresensiTravel = new List<Presensi>();
            //string userid = HttpContext.Current.Session["biofarma_userid"].ToString();

            if (documentDataTable.Rows.Count > 0)
            {
                int seqId = 0;

                foreach (DataRow row in documentDataTable.Rows)
                {
                    var det = new Presensi();

                    int datediff = (int)(DateTime.Parse(row["Tanggal Selesai"].ToString()) - DateTime.Parse(row["Tanggal Mulai"].ToString())).TotalDays;

                    if(datediff ==  0)
                    {
                        det.Nik = row["NIK"].ToString();
                        det.Date = row["Tanggal Mulai"].ToString();
                        det.Time = null;
                        det.SerialMachine = null;
                        det.Description = row["KETERANGAN"].ToString();
                        
                        seqId++;
                        det.SequenceId = seqId;

                        listPresensiTravel.Add(det);
                    }
                    else if (datediff >= 1)
                    {
                        det.Nik = row["NIK"].ToString();
                        det.Date = row["Tanggal Mulai"].ToString();
                        det.Time = null;
                        det.SerialMachine = null;
                        det.Description = row["KETERANGAN"].ToString();

                        seqId++;
                        det.SequenceId = seqId;

                        listPresensiTravel.Add(det);

                        for (int i = 0; i < datediff; i++)
                        {
                            det = new Presensi();
                            det.Nik = row["NIK"].ToString();
                            det.Date = DateTime.Parse(row["Tanggal Mulai"].ToString()).AddDays(i+1).ToString();
                            det.Time = null;
                            det.SerialMachine = null;
                            det.Description = row["KETERANGAN"].ToString();

                            seqId++;
                            det.SequenceId = seqId;

                            listPresensiTravel.Add(det);
                        }  
                    }

                    //seqId++;
                    //det.SequenceId = seqId;

                    //listPresensiTravel.Add(det);
                }
            }
            return listPresensiTravel;
        }
    }
}