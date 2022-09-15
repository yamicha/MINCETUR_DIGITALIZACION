using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnServiciosDigitalizacion.ArchivoCentral.Carga
{
    public class enLeyenda : enBase 
    {
        public long ID_LEYENDA { get; set; }
        public long ID_TABLA { get; set; }
        public string DESCRIPCION_LEYENDA { get; set; }
        public string LINK_LEYENDA { get; set; }
        public long ORDEN_LEYENDA { get; set; }
        public string SCRIPT_LEYENDA { get; set; }

    }
}
