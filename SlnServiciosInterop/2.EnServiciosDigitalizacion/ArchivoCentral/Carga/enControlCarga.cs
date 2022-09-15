namespace EnServiciosDigitalizacion.ArchivoCentral.Carga
{
    public  class enControlCarga : enBase
    {
        public long ID_CONTROL_CARGA { get; set; }
        public long ID_TABLA { get; set; }
        public long ID_USUARIO { get; set; }
        public int? NRO_REGISTROS { get; set; }
        public string FLG_CARGA { get; set; }
        public string FLG_VALIDO { get; set; }

    }
}
