using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models.Ventanilla
{
    public class MicroArchivoModels : enBase
    {
        public long IdMicroforma { get; set; }
        public long IdDocAlmacenamiento { get; set; }
        public long TipoArchivo { get; set; }
        public string Direccion { get; set; }
        public long IdUsuario { get; set; }
        public string Observacion { get; set; }
        public string Usucreacion { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }
        public string IpCreacion { get; set; }
        public  List<MicroArchivoModels> ListaIdsMicroforma { get; set; }

    }
}
