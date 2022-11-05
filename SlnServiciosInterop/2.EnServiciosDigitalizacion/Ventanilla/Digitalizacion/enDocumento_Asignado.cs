using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
   public class enDocumento_Asignado : enBase
    {
        public long ID_DOCUMENTO_ASIGNADO { get; set; }
        public long ID_DOCUMENTO { get; set; }
        public long ID_LOTE { get; set; }
        public long ID_USUARIO { get; set; }
        public string FLG_DIGITALIZADO { get; set; }
        public string FLG_CONFORME { get; set; }
        public string FLG_REPROCESO { get; set; }
        public string FLG_FEDATARIO { get; set; }
        public string HORA_INICIO { get; set; }
        public string HORA_FIN { get; set; }
        public long ID_LASERFICHE { get; set; }
        
        public List<enDocumento> ListaDocumento  { get; set; }
}
}
