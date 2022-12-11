using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
    public class enMicroformaProceso : enBase
    {
        public long ID_MICROFORMA_PROCESO { get; set; }
        public long? ID_ESTADO_MICROFORMA { get; set; }
        public string OBSERVACION { get; set; }
        public string DESC_ESTADO { get; set; }
        public long ID_MICROFORMA { get; set; }
        public string STR_FEC_GRABACION { get; set; }

    }
}
