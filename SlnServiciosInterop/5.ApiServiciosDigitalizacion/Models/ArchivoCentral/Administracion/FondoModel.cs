using System.Runtime.Serialization;


namespace ApiServiciosDigitalizacion.Models.ArchivoCentral.Administracion
{

    [DataContract(Name = "Fondo", Namespace = "Mincetur.ArchivoCentral.ServiciosInterop.ApiServiciosDigitalizacion")]
    public class FondoModel
    {
        [DataMember(Name = "strIdFondo", Order = 1)]
        public int IdFondo { get; set; }

        [DataMember(Name = "strDescFondo", Order = 2)]
        public string DescFondo { get; set; }

        [DataMember(Name = "strFlgEstado", Order = 3)]
        public string FlgEstado { get; set; }

        [DataMember(Name = "strUsuarioCreacion", Order = 4)]
        public string UsuCreacion { get; set; }

        [DataMember(Name = "strUsuarioModificacion", Order = 5)]
        public string UsuModificacion { get; set; }

        [DataMember(Name = "strIpCreacion", Order = 5)]
        public string IpCreacion { get; set; }
    }

}
