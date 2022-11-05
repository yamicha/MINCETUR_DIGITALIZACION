using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
    public class enRevision
    {
        public long ID_REVISION { get; set; }
        public long ID_MICROFORMA { get; set; }
        public long ID_DOC_REVISION { get; set; }
        public string RESPONSABLE { get; set; }
        public string STR_FLG_CONFORME { get; set; }
        public string STR_FLG_ACCION { get; set; }
        public string TIPO_PRUEBA { get; set; }
        public string OBSERVACION { get; set; }
        public string FEC_REVISION { get; set; }
    }
}
