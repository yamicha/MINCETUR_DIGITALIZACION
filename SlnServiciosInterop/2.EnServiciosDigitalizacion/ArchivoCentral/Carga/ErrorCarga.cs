using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnServiciosDigitalizacion.Carga
{
    public  class ErrorCarga
    {
        public long ID_ERROR_CARGA { get; set; }
        public long ID_CONTROL_CARGA { get; set; }
        public int NRO_LINEA { get; set; }
        public string DESCRIPCION_ERROR { get; set; }
        public string FLG_ESTADO { get; set; }
        public string USU_CREACION { get; set; }
    }
}
