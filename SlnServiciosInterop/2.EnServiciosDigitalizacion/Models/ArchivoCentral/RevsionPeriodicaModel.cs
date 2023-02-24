using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models
{
    public class RevsionPeriodicaModel
    {
        public long IdMicroforma { get; set; }
        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public long FlgConforme { get; set; }
        public long FlgAccion { get; set; }
        public long IdUsuario { get; set; }
        public long IdDocRevision { get; set; }
        public string UsuCreacion { get; set; }
        public string TipoPrueba { get; set; }
        public string FecRevision { get; set; }
        public string IpCreacion { get; set; }
        
        public List<MicroEvaluarModel> ListaIdsMicroforma { get; set; }
    
        

    }
}
