using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
    public class enDocumentoTemporal :enBase
    {
        public long ID_DOCUMENTO { get; set; }
        public long ID_CONTROL_CARGA { get; set; }
        public string NRO_LINEA { get; set; }
        public string ID_FONDO { get; set; }
        public string ID_SECCION { get; set; }
        public string ID_SERIE { get; set; }
        public string NOM_DOCUMENTO { get; set; }
        public string DES_LARGA_SECCION { get; set; }
        public string DES_SERIE { get; set; }
        public string DESCRIPCION { get; set; }
        public string DES_FONDO { get; set; }
        public string ANIO { get; set; }
        public string FOLIOS { get; set; }
        public string OBSERVACION { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public string STR_FEC_MODIFICACION { get; set; }
        public int FLG_REPETIDO { get; set; }
        
    }
}
