using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnServiciosDigitalizacion
{
    public class enAcceso : CoServiciosDigitalizacion.coHBase
    {
        public int ID_SIS { get; set; }
        public string COD_FUENTE { get; set; }
        public int ID_PERSONA { get; set; }
        public int ID_TIPOACCESO { get; set; } = -1;
        public string IP_ACCESO { get; set; }
        public string DES_OBS { get; set; }
        public string DES_URL { get; set; }
    }
}
