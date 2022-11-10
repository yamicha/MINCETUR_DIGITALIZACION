using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
   public class enDocumento :enBase
    {
        public long ID_DOCUMENTO { get; set; }
        public long ID_DOCUMENTO_ASIGNADO { get; set; }
        public long ID_USUARIO { get; set; }
        public long ID_LOTE { get; set; }
        public long PESO_ADJ { get; set; }
        public long ID_ESTADO_DOCUMENTO { get; set; }
        public string DESCRIPCION_ESTADO { get; set; }
        public string NOMBRE_USUARIO { get; set; }  
         public long NRO_REPROCESADOS { get; set; }
        public string OBSERVACION { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public string STR_FEC_MODIFICACION { get; set; }
        public string FLG_DIGITALIZAR { get; set; }
        
        public List<enDocumento> ListaDocumento  { get; set; }
}
}
