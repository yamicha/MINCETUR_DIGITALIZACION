using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models.Ventanilla
{
    public class DocumentoValidarModel
    {
        public long IdDocumentoAsignado { get; set; }
        public long IdDocumento { get; set; }
        public long FlgConforme { get; set; }
        public long IdEstadoDocumento { get; set; }
        public long IdTipoObservacion { get; set; }
        public string Comentario { get; set; }
        public string UsuCreacion { get; set; }
        public string IpCreacion { get; set; }
        public List<DocumentoValidarModel> LisIdDocumento { get; set; }

    }
}
