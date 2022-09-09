using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ApiServiciosMicroformas.Models
{
    [DataContract(Name = "Solicitud", Namespace = " Mincetur.Administracion.ServiciosInterop.ApiServiciosInteropMigraciones")]
    public class SolicitudModel
    {
        [DataMember(Name = "strNumDocumento", Order = 1)]
        public string NumDocumento { get; set; }
    }
}
