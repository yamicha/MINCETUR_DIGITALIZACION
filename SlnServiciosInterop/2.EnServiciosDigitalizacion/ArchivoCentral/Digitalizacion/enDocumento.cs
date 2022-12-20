using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class enDocumento :enBase
    {
        public long ID_DOCUMENTO { get; set; }
        public long ID_CONTROL_CARGA { get; set; }
        public long ID_DOCUMENTO_ASIGNADO { get; set; }
        public long ID_USUARIO { get; set; }
        public long ID_LOTE { get; set; }
        public long ID_LASERFICHE { get; set; }
        public long ID_ESTADO_DOCUMENTO { get; set; }
        public string DESCRIPCION_ESTADO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public long ID_FONDO { get; set; }
        public long ID_SECCION { get; set; }
        public long ID_SERIE { get; set; }
        public long NRO_REPROCESADOS { get; set; }
        public string NOM_DOCUMENTO { get; set; }
        public string DES_LARGA_SECCION { get; set; }
        public string DES_SERIE { get; set; }
        public string DESCRIPCION { get; set; }
        public string DES_FONDO { get; set; }
        public long ANIO { get; set; }
        public long FOLIOS { get; set; }
        public long IMAGEN { get; set; }
        public long ID_AREA_PROCEDENCIA { get; set; }
        
        public string OBSERVACION { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public string STR_FEC_MODIFICACION { get; set; }
        public string NRO_LOTE { get; set; }
        
        public List<enDocumento> ListaDocumento  { get; set; }
}
}
