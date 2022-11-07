using System.Runtime.Serialization;

namespace ApiServiciosDigitalizacion.Models.Ventanilla.Administracion
{
    [DataContract(Name = "Soporte", Namespace = "Mincetur.ArchivoCentral.ServiciosInterop.ApiServiciosDigitalizacion")]
    public class SoporteModel
    {
        [DataMember(Name = "strIdSoporte", Order = 1)]
        public int IdSoporte { get; set; }

        [DataMember(Name = "strDescSoporte", Order = 2)]
        public string DescSoporte { get; set; }

        [DataMember(Name = "strFlgEstado", Order = 3)]
        public string FlgEstado { get; set; }

        [DataMember(Name = "strUsuarioCreacion", Order = 4)]
        public string UsuCreacion { get; set; }

        [DataMember(Name = "strUsuarioModificacion", Order = 5)]
        public string UsuModificacion { get; set; }
    }
}
