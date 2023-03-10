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
        public string FLG_MICROFORMA { get; set; }
        public string FLG_DEVOLUCION { get; set; }
        public string DES_AREA { get; set; }
        public string AREA_PROCEDENCIA { get; set; }    
        public string OBS_DEVOLUCION { get; set; }
        public string STR_FEC_DEVOLUCION { get; set; }
        public string USU_DEVOLUCION { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
    }
}
