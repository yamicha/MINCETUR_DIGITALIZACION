namespace EnServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class enSerie
    {
        public long ID_SERIE { get; set; }
        public long ID_SECCION { get; set; }
        public string COD_SERIE { get; set; }
        public string DES_SERIE { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public string FEC_CREACION { get; set; }
        public string IP_CREACION { get; set; }
        public string USU_MODIFICACION { get; set; }
        public string FEC_MODIFICACION { get; set; }
        public string IP_MODIFICACION { get; set; }
    }
}
