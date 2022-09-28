using System.Runtime.Serialization;

namespace ApiServiciosDigitalizacion.Models.ArchivoCentral.Administracion
{
    [DataContract(Name = "Observacion", Namespace = "Mincetur.ArchivoCentral.ServiciosInterop.ApiServiciosDigitalizacion")]
    public class ObservacionModel
    {
        [DataMember(Name = "strIdObservacion", Order = 1)]
        public int IdObservacion { get; set; }

        [DataMember(Name = "strDescObservacion", Order = 2)]
        public string DescObservacion { get; set; }

        [DataMember(Name = "strFlgEstado", Order = 3)]
        public string FlgEstado { get; set; }

        [DataMember(Name = "strUsuarioCreacion", Order = 4)]
        public string UsuCreacion { get; set; }

        [DataMember(Name = "strUsuarioModificacion", Order = 5)]
        public string UsuModificacion { get; set; }
    }
}
