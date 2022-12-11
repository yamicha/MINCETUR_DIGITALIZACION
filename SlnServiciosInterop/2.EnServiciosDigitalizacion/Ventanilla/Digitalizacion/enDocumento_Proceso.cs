using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
   public class enDocumento_Proceso : enBase
    {
        public long ID_DOCUMENTO_PROCESO { get; set; }
        public long ID_DOCUMENTO_ASIGNADO { get; set; }
        public long ID_DOCUMENTO { get; set; }
        public long ID_ESTADO_DOCUMENTO { get; set; }
        public string DESCRIPCION_ESTADO { get; set; }
        public string DES_TIP_DOC { get; set; }
        public string DES_ASUNTO { get; set; }
        public string DES_OBS { get; set; }
        public string NUM_DOC { get; set; }
        public long NUM_FOLIOS { get; set; }
        public string DES_CLASIF { get; set; }
        public string HORA_INICIO { get; set; }
        public string HORA_FIN { get; set; }
        public string OBSERVACION { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public long ID_USU_CREACION { get; set; }
        public string NRO_LOTE { get; set; }
        

    }
}
