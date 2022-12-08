using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class enDocumento_Proceso : enBase
    {
        public long ID_DOCUMENTO_PROCESO { get; set; }
        public long ID_DOCUMENTO { get; set; }
        public long ID_DOCUMENTO_ASIGNADO { get; set; }
        public long ID_LASERFICHE { get; set; }
        public long ID_ESTADO_DOCUMENTO { get; set; }
        public string DESCRIPCION_ESTADO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public string NOM_DOCUMENTO { get; set; }
        public string DES_LARGA_SECCION { get; set; }
        public string DES_SERIE { get; set; }
        public string DESCRIPCION { get; set; }
        public string DES_FONDO { get; set; }
        public string NRO_LOTE { get; set; }     
        public string HORA_INICIO { get; set; }
        public string HORA_FIN { get; set; }
        public string OBSERVACION { get; set; }
        public long ID_USU_CREACION { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public string STR_FEC_MODIFICACION { get; set; }

    }
}
