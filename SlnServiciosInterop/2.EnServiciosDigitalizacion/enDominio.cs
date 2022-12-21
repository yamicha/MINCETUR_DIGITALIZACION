using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion
{
    public class enDominio
    {
        public long ID_DOMINIO_PADRE { get; set; }
        public long ID_DOMINIO { get; set; }
        public string COD_ITEM { get; set; }
        public string DESC_ITEM { get; set; }
        public int FLG_ESTADO { get; set; }
    }
}
