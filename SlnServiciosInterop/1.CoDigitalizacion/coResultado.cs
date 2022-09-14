using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoServiciosDigitalizacion
{
    public class coResultado : coHBase
    {
        public int ID_TIPO { get; set; }
        public string ID_ERROR { get; set; }
        public string DES_ERROR { get; set; }
        public string VALOR { get; set; }
        public string VALOR1 { get; set; }
        public string VALOR2 { get; set; }
    }
}
