using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
   public class enLote : enBase
    {
        public long ID_LOTE { get; set; }
        public string NRO_LOTE { get; set; }
        public long CANT_EXPEDIENTES { get; set; }
        public long CANT_ADJUNTOS { get; set; }
        public long PESO_TOTALADJUNTOS { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public string FLG_MICROFORMA { get; set; }
        public string FLG_DEVOLUCION { get; set; }
        public string DES_AREA { get; set; }
        public string OBS_DEVOLUCION { get; set; }
        public string STR_FEC_DEVOLUCION { get; set; }
        public string USU_DEVOLUCION { get; set; }
        public string FEC_INICIO { get; set; }
        public string FEC_FIN { get; set; }
    }
}
