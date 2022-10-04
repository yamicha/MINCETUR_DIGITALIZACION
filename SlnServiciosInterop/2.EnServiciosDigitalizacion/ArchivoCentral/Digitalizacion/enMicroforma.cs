using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class enMicroforma : enBase
    {
        public long ID_MICROFORMA { get; set; }
        public string DESC_SOPORTE { get; set; }
        public string CODIGO_SOPORTE { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public long ID_TIPO_SOPORTE { get; set; }

        
    }
}
