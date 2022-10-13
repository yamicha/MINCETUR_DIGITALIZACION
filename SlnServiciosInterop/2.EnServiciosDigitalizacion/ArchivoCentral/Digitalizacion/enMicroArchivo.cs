using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class enMicroArchivo : enBase
    {
        public long ID_MICROFORMA { get; set; }
        public long ID_MICROARCHIVO { get; set; }
        
        public long ID_DOC_CONFORMIDAD { get; set; }
        public long TIPO_ARCHIVO { get; set; }
        public string DIRECCION { get; set; }
        public string RESPONSABLE { get; set; }
        public string FECHA { get; set; }
        public string HORA { get; set; }
        public string OBSERVACION { get; set; }

    }
}
