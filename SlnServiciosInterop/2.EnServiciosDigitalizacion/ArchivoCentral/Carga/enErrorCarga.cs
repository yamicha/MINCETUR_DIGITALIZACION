namespace EnServiciosDigitalizacion.Carga
{
    public  class enErrorCarga :enBase
    {
        public long ID_ERROR_CARGA { get; set; }
        public long ID_CONTROL_CARGA { get; set; }
        public int NRO_LINEA { get; set; }
        public string DESCRIPCION_ERROR { get; set; }

    }
}
