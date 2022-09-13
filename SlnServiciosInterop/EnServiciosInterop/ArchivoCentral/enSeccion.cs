using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosMicroformas.ArchivoCentral
{
   public  class enSeccion
    {
        public int ID_SECCION { get; set; }
        public string DES_CORTA_SECCION { get; set; }
        public string DES_LARGA_SECCION { get; set; }

        public string FLG_ESTADO { get; set; }

        public string USU_CREACION { get; set; }

        public string STR_FEC_CREACION { get; set; }

        public string IP_CREACION { get; set; }
        public string USU_MODIFICACION { get; set; }
        public string STR_FEC_MODIFICACION { get; set; }

        public string IP_MODIFICACION { get; set; }


    }
}
