using System.Runtime.Serialization;

namespace ApiServiciosMicroformas.Models.ArchivoCentral
{
    [DataContract(Name = "Seccion", Namespace = "Mincetur.ArchivoCentral.ServiciosInterop.ApiServiciosMicroformas")]
    public class SeccionModel
    {
        [DataMember(Name = "strIdseccion", Order = 1)]
        public int IdSeccion { get; set; }

        [DataMember(Name = "strDescCortaSeccion", Order = 2)]
        public string DescCortaSeccion { get; set; }

        [DataMember(Name = "strDescLargaSeccion", Order = 3)]
        public string DescLargaSeccion { get; set; }

        [DataMember(Name = "strFlgEstado", Order = 4)]
        public string FlgEstado { get; set; }

        [DataMember(Name = "strUsuarioCreacion", Order = 5)]
        public string UsuCreacion { get; set; }

        [DataMember(Name = "strUsuarioModificacion", Order = 6)]
        public string UsuModificacion { get; set; }

    }
}
