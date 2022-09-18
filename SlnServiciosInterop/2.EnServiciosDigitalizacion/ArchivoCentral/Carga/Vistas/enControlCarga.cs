using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Carga.Vistas
{
    public class enControlCarga : enBase
    {
        public long ID_CONTROL_CARGA { get; set; }
        public long ID_TABLA { get; set; }
        public long ID_USUARIO { get; set; }
        public int? NRO_REGISTROS { get; set; }
        public string FLG_VALIDO { get; set; }
        public string FLG_CARGA { get; set; }
        public string STR_FLG_CARGA { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public string STR_FEC_MODIFICACION { get; set; }
    }
}
