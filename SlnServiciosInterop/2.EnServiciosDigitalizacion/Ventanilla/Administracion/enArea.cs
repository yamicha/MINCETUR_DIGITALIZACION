using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Administracion
{
   public class enArea
    {
        public long ID_AREA { get; set; }
        public string DES_AREA { get; set; }
        public string SIGLA { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
        public string FEC_CREACION { get; set; }
        public string IP_CREACION { get; set; }
        public string USU_MODIFICACION { get; set; }
        public string FEC_MODIFICACION { get; set; }
        public string IP_MODIFICACION { get; set; }
    }
}
