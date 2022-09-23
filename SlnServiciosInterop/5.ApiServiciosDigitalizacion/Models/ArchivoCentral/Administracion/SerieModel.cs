using System.Runtime.Serialization;


namespace ApiServiciosDigitalizacion.Models.ArchivoCentral.Administracion
{
    [DataContract(Name = "Serie", Namespace = "Mincetur.ArchivoCentral.ServiciosInterop.ApiServiciosDigitalizacion")]
    public class SerieModel
    {
        [DataMember(Name = "strIdSerie", Order = 1)]
        public int IdSerie { get; set; }

        [DataMember(Name = "strIdSeccion", Order = 2)]
        public int IdSeccion { get; set; }

        [DataMember(Name = "strDescCodSerie", Order = 3)]
        public string DescCodSerie { get; set; }

        [DataMember(Name = "strDescSerie", Order = 4)]
        public string DescSerie { get; set; }

        [DataMember(Name = "strFlgEstado", Order = 5)]
        public string FlgEstado { get; set; }

        [DataMember(Name = "strUsuarioCreacion", Order = 6)]
        public string UsuCreacion { get; set; }

        [DataMember(Name = "strUsuarioModificacion", Order = 7)]
        public string UsuModificacion { get; set; }
    }
}
