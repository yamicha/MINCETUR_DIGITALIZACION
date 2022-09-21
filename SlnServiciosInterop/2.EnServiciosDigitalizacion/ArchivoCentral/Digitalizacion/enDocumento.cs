using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class enDocumento
    {
        public long ID_DOCUMENTO { get; set; }
        public long ID_ESTADO_DOCUMENTO { get; set; }
        public long ID_CONTROL_CARGA { get; set; }
        public string COD_DOCUMENTO { get; set; }
        public long ID_FONDO { get; set; }
        public long ID_SECCION { get; set; }
        public long ID_SERIE { get; set; }
        public long ID_TIPO_DOCUMENTO { get; set; }
        public string NOM_DOCUMENTO { get; set; }
        public string DESCRIPCION { get; set; }
        public long ANIO { get; set; }
        public long FOLIOS { get; set; }
        public string OBSERVACION { get; set; }
        public string FLG_VALIDO { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public DateTime FEC_CREACION { get; set; }
        public string IP_CREACION { get; set; }
        public string USU_MODIFICACION { get; set; }
        public DateTime? FEC_MODIFICACION { get; set; }
        public string IP_MODIFICACION { get; set; }
        public long? ID_LASERFICHE { get; set; }
    }
}
