using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models
{
    public class MicroEvaluarModel
    {
        public long IdMicroforma { get; set; }
        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public long FlgConforme { get; set; }
        public string UsuCreacion { get; set; }
        public List<MicroEvaluarModel> ListaIdsMicroforma { get; set; }
        public long IdDocConformidad { get; set; }
        

    }
}
