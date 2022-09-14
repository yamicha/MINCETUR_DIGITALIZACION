using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnServiciosDigitalizacion.Carga
{
    public  class Tabla :enBase
    {
        public long ID_TABLA { get; set; } 
        public string DESCRIPCION_TABLA { get; set; }
        public string COD_TABLA_TEMPORAL { get; set; }
        public string COD_TABLA_OFICIAL { get; set; }
    }

}
