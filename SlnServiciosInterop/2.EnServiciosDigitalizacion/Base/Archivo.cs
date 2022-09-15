using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnServiciosDigitalizacion.Base
{
    public class Archivo
    {
     
        public long ID_ARCHIVO { get; set; }
        public string CODIGO_ARCHIVO { get; set; }
        public string NOMBRE_ARCHIVO { get; set; }
        public decimal PESO_ARCHIVO { get; set; }
        public string RUTA_LINK { get; set; }
        public string EXTENSION { get; set; }
        

    }
}
