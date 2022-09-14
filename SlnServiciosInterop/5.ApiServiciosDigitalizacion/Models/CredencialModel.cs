using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ApiServiciosDigitalizacion.Models
{
    [DataContract(Name = "Credencial", Namespace = " Mincetur.Administracion.ServiciosInterop.ApiServiciosInteropMigraciones")]
    public class CredencialModel
    {
        [DataMember(Name = "Usuario", Order = 1)]
        public string Usuario { get; set; } = "-1";

        [DataMember(Name = "Pin", Order = 2)]

        public string Pin { get; set; }

        //[DataMember(Name = "Tipo", Order = 3)]
        //public int Tipo { get; set; } = 3;
    }
}
