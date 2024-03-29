﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Ventanilla.Digitalizacion
{
   public class enMicroforma : enBase
    {
        public enMicroforma() {
            MicroArchivo = new enMicroArchivo(); 
        }
        public long ID_MICROFORMA { get; set; }
        public string DESC_SOPORTE { get; set; }
        public string CODIGO_SOPORTE { get; set; }
        public string STR_FEC_CREACION { get; set; }
        public long ID_TIPO_SOPORTE { get; set; }
        public string CODIGO_FEDATARIO { get; set; }
        public string NRO_VOLUMEN { get; set; }
        public string OBSERVACION { get; set; }
        public string FECHA { get; set; }
        public string HORA { get; set; }
        public long ID_DOC_APERTURA { get; set; }
        public long ID_DOC_CIERRE { get; set; }
        public long ID_DOC_CONFORMIDAD { get; set; }
        
        public string NRO_ACTA { get; set; }
        public string NRO_COPIAS { get; set; }
        public string DESC_ESTADO { get; set; }
        public string FLG_CONFORME { get; set; }
        public long ID_ESTADO { get; set; }
        public long NRO_REVISIONES { get; set; }
        public string STR_FEC_GRABACION { get; set; }
        public string CANT_EXPEDIENTES { get; set; }
        public string NRO_REPROCESADOS { get; set; }
        public string FLG_MICROARCHIVO { get; set; }
        public string STR_USUARIO_CREACION { get; set; }
        public enMicroArchivo MicroArchivo { get; set; }
        


    }
}
