using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
    public class enDocumento_Obs :enBase
    {
        public long ID_DOCUMENTO_OBS { get; set; }
        public long ID_DOCUMENTO { get; set; }
        public long ID_TIPO_OBSERVACION { get; set; }
        public string DESC_TIPO_OBSERVACION { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public string OBSERVACION { get; set; }
        
    }
}
