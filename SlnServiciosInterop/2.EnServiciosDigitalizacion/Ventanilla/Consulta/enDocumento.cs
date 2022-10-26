using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Consulta
{
    public class enDocumento
    {
        public long ID_EXPE { get; set; }
        public long ID_PERSONA { get; set; }
        public long ID_SUB { get; set; }
        public long ID_SUBOFI { get; set; }
        
        public long ID_DOC { get; set; }
        public long ID_TIP_DOC { get; set; }
        public long NUM_FOLIOS { get; set; }
        public long USU_CREA { get; set; }
        public long ID_TUPA { get; set; }
        public long ID_CLASIF { get; set; }      
        public string DES_PERSONA { get; set; }
        public string ABR_SUBOFI { get; set; }
        public string DES_SUBOFI { get; set; }
        public string DES_TIP_DOC { get; set; }
        public string DES_ASUNTO { get; set; }
        public string DES_OBS { get; set; }
        public string DES_AREA { get; set; }
        public string NUM_DOC { get; set; }
        public string COD_LOG { get; set; }
        public string DES_CLASIF { get; set; }
        public string FEC_EXPE { get; set; }
        public string FEC_EXPE_STR { get; set; }
        public DateTime int_FEC_EXPE { get; set; }
        
    }
}
