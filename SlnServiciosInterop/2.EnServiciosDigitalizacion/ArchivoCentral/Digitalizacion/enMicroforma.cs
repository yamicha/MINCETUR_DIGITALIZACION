﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
   public class enMicroforma : enBase
    {
        public long ID_MICROFORMA { get; set; }
        public string DESC_SOPORTE { get; set; }
        public string CODIGO_SOPORTE { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public long ID_TIPO_SOPORTE { get; set; }
        public string CODIGO_FEDATARIO { get; set; }
        public string OBSERVACION { get; set; }
        public string FECHA { get; set; }
        public string HORA { get; set; }
        public string NRO_ACTA { get; set; }
        public string NRO_COPIAS { get; set; }
        public string DESC_ESTADO { get; set; }
        public long ID_ESTADO { get; set; }
        public long MA_ID_DOC_CONFORMIDAD { get; set; }
        public long MA_TIPO_ARCHIVO { get; set; }
        public string MA_DIRECCION { get; set; }
        public string MA_RESPONSABLE { get; set; }
        public string MA_FEC_CREACION { get; set; }
        public string MA_OBSERVACION { get; set; }

    }
}
