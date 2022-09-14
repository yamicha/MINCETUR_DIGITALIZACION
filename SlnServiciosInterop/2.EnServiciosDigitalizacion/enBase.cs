using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnServiciosDigitalizacion
{
    public class enBase : CoServiciosDigitalizacion.coHBase
    {
        protected enBase() { }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public string FEC_CREACION { get; set; }
        public string USU_MODIFICACION { get; set; }
        public string FEC_MODIFICACION { get; set; }
        public string IP_CREACION { get; set; }
        public string IP_MODIFICACION { get; set; }
        
    }
}
