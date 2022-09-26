using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace ApiServiciosDigitalizacion.Models
{
    [DataContract(Name = "ResultadoMigra", Namespace = " Mincetur.Administracion.ServiciosInterop.ApiServiciosInteropMigraciones")]
    public class ResultadoMigraModel
    {
        [DataMember(Name = "ResultadoError", Order = 1)]
        public ResultadoErrorModel ResultadoErrorModel { get; set; }

        //[DataMember(Name = "RespuestaDocumento", Order = 2)]
        //public RespuestaDocumentoModel RespuestaDocumentoModel { get; set; }
    }
}
