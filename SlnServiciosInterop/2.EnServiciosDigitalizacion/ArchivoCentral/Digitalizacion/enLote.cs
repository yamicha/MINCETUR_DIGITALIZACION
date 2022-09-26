using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class enLote : enBase
    {
        public long ID_LOTE { get; set; }
        public string NRO_LOTE { get; set; }
        public string STR_FEC_CREACION { get; set; }
    }
}
