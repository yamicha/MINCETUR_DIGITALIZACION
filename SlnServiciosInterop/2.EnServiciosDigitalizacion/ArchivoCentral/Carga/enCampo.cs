namespace EnServiciosDigitalizacion.ArchivoCentral.Carga
{
    public  class enCampo : enBase
    {
        public long ID_CAMPO { get; set; }
        public long ID_TABLA { get; set; }
        public string COD_CAMPO { get; set; }
        public string DES_CAMPO { get; set; }
        public int NRO_CAMPO { get; set; }
        public string TIPO_DATO { get; set; }
        public string TIPO { get; set; }
        public int LONGITUD { get; set; }
        public string DATO_EJEMPLO { get; set; }
        public string OBLIGATORIO { get; set; }
        public string TRANSF_OFIC { get; set; }
        public string TRANSF_ORIG { get; set; }
        public string TRANSF_VALID { get; set; }
        public string FLG_CLASIFICACION { get; set; }
        public string FLG_AUTOINCREMENT { get; set; }
        public string QUERY_CAMPO { get; set; }
        public string TIPO_CAMPO { get; set; }

        public string FLG_VALIDA_PK { get; set; }
        

    }
}
