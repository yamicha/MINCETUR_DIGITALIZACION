using System.Collections.Generic;
using System.Runtime.Serialization;


namespace ApiServiciosDigitalizacion.Models.ArchivoCentral.Digitalizacion
{

    [DataContract(Name = "Documento", Namespace = "Mincetur.ArchivoCentral.ServiciosInterop.ApiServiciosDigitalizacion")]
    public class DocumentoModel
    {
        [DataMember(Name = "IntIdDocumento", Order = 1)]
        public long IdDocumento { get; set; }

        [DataMember(Name = "IntIdControlCarga", Order = 2)]
        public int IdControlCarga { get; set; }

        [DataMember(Name = "strUsuModificacion", Order = 3)]
        public string UsuModificacion { get; set; }

        [DataMember(Name = "strIpModificacion", Order = 4)]
        public string IpModificacion { get; set; }


        [DataMember(Name = "strIpCreacion", Order = 5)]
        public string IpCreacion { get; set; }

        [DataMember(Name = "IntIdUsuario", Order = 6)]
        public long IdUsuario { get; set; }

        [DataMember(Name = "strUsuCreacion", Order = 7)]
        public string UsuCreacion { get; set; }
        [DataMember(Name = "ArrayListDocumentos", Order = 8)]
        public List<DocumentoModel> ListaIdsDocumento { get; set; }


    }

}
