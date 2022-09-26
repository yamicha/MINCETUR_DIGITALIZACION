using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


    }

}
