using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ApiServiciosMicroformas.Models
{
    [DataContract(Name = "ResultadoError", Namespace = " Mincetur.Administracion.ServiciosInterop.ApiServiciosInteropMigraciones")]

    public class ResultadoErrorModel
    {
        [DataMember(Name = "IdTipo", Order = 1)]
        public int IdTipo { get; set; }

        //[DataMember(Name = "IdError", Order = 1)]
        //public string IdError { get; set; }

        [DataMember(Name = "DesError", Order = 2)]
        public string DesError { get; set; }
    }
}
