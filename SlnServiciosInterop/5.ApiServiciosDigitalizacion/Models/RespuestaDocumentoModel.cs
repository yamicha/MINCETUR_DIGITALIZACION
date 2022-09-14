using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ApiServiciosDigitalizacion.Models
{
    [DataContract(Name = "Documento", Namespace = " Mincetur.Administracion.ServiciosInterop.ApiServiciosInteropMigraciones")]
    public class RespuestaDocumentoModel
    {
        [DataMember(Name = "strNumRespuesta", Order = 1)]
        public string NumRespuesta { get; set; }

        [DataMember(Name = "strCalidadMigratoria", Order = 2)]
        public string CalidadMigratoria { get; set; }

        [DataMember(Name = "strNombres", Order = 3)]
        public string Nombres { get; set; }

        [DataMember(Name = "strPrimerApellido", Order = 4)]
        public string PrimerApellido { get; set; }

        [DataMember(Name = "strSegundoApellido", Order = 5)]
        public string SegundoApellido { get; set; }

    }
}
