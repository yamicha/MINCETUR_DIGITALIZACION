using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models.Ventanilla
{
    public class AdjuntoModels
    {
        public long IdExpediente { get; set; }
        public long IdocAdjunto { get; set; }
        public string NombreArchivo { get; set; }
        public int PesoArchivo { get; set; }
        public string Extension { get; set; }
        public int FlgTipo { get; set; }
        public int FlgLink { get; set; }
        public long IdArchivo { get; set; }
        public string UsuCreacion { get; set; }
        public long IdDocumento { get; set; }
        public string DocPrincipal { get; set; }
    }
}
