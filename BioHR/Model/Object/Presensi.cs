namespace BioHR.Model.Object
{
    public class Presensi
    {
        protected int _urutan;
        private string _nik;
        private string _date;
        private string _time;
        private string _serialMachine;
        private string _description;

        public int SequenceId
        {
            get { return _urutan; }
            set { _urutan = value; }
        }
        public string Nik { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string SerialMachine { get; set; }
        public string Description { get; set; }
    }
}