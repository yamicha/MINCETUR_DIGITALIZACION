using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class enFondo
    {
        public long ID_FONDO { get; set; }
        public string DESC_FONDO { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public string FEC_CREACION { get; set; }
        public string IP_CREACION { get; set; }
        public string USU_MODIFICACION { get; set; }
        public string FEC_MODIFICACION { get; set; }
        public string IP_MODIFICACION { get; set; }
    }
}
