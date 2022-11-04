using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models.Ventanilla
{
    public class ExpedienteModels
    {
        public long IdExpediente {get;set;}
        public int UsuCrea { get; set; }
        public string IpCrea { get; set; }
        public List<AdjuntoModels> ListaAdjuntos {get;set;}

    }
}
