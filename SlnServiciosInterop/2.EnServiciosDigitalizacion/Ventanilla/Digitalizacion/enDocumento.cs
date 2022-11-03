using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
    public class enDocumento
    {

        public long ID_DOC { get; set; }
        public long ID_EXPE { get; set; }
        public long ID_DOC_CMS { get; set; }
        public string DES_NOM_ABR { get; set; }
        public string NUM_SIZE_ARCHIVO { get; set; }
        public string EXTENSION { get; set; }
        public string DES_OBS { get; set; }
        
    }
}
