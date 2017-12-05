using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioHR.Model.Dictionary
{
    public enum Bulan : byte
    {
        Januari = 1, Februari, Maret, April, Mei, Juni, Juli, Agustus, September, Oktober, November, Desember
    }

    public enum BulanRomawi : byte
    {
        I = 1, II, III, IV, V, VI, VII, VIII, IX, X, XI, XII
    }

    public enum PayrollComponent : byte
    {
        Pendapatan = 1, Potongan, RapelPendapatan, RapelPotongan
    }
    public enum TravelVehicle : byte
    {
        KeretaApi = 1, Bus, PesawatUdara, KapalLaut, Travel, Taxi, Other

    }
    public enum TravelType
    {
        PDDN,
        PDLN
    }
}