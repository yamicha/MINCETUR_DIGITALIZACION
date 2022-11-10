using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
    public class enAdjuntos
    {

        public long ID_DOC { get; set; }
        public long ID_EXPE { get; set; }
        public long ID_DOC_CMS { get; set; }
        public string DES_NOM_ABR { get; set; }
        public long NUM_SIZE_ARCHIVO { get; set; }
        public string EXTENSION { get; set; }
        public string DES_OBS { get; set; }
        public long ID_DOC_ADJ { get; set; }
        public int FLG_LINK { get; set; }

    }
}
