using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ApiServiciosDigitalizacion.Models
{
    [DataContract(Name = "DatosMigra", Namespace = " Mincetur.Administracion.ServiciosInterop.ApiServiciosInteropMigraciones")]
    public class DatosMigraModel
    {
        [DataMember(Name = "Credencial", Order = 1)]
        public CredencialModel CredencialModel { get; set; }

        [DataMember(Name = "Solicitud", Order = 1)]
        public SolicitudModel SolicitudModel { get; set; }
    }
}
