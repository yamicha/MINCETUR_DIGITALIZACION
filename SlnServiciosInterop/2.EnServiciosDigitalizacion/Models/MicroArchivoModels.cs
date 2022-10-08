﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models
{
    public class MicroArchivoModels : enBase
    {
        public long IdMicroforma { get; set; }
        public long IdDocConformidad { get; set; }
        public long TipoArchivo { get; set; }
        public string Direccion { get; set; }
        public long IdUsuario { get; set; }
        public string Observacion { get; set; }
        public string Usucreacion { get; set; }
        public  List<MicroArchivoModels> ListaIdsMicroforma { get; set; }

    }
}