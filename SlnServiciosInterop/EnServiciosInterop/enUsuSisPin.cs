using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  EnServiciosMicroformas

{
    public class enUsuSisPin : enBase
    {
        public int ID_USUSIS { get; set; }
        public int ID_USUSISPIN { get; set; }
        public string DES_PIN { get; set; }
        public DateTime FEC_INI { get; set; }
        public DateTime FEC_FIN { get; set; }
        public int USU_CREA { get; set; }
        public DateTime FEC_CREA { get; set; }
        public string IP_CREA { get; set; }
        public int USU_MODI { get; set; }
        public DateTime FEC_MODI { get; set; }
        public string IP_MODI { get; set; }
    }
}
