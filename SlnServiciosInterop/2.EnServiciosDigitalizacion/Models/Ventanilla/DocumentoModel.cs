using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models.Ventanilla
{
    public class DocumentoModel
    {
        public long IdDocumento { get; set; }

        public int IdControlCarga { get; set; }
        public string UsuModificacion { get; set; }
        public string IpModificacion { get; set; }
        public string IpCreacion { get; set; }
        public long IdUsuario { get; set; }
        public string UsuCreacion { get; set; }
        public List<DocumentoModel> ListaIdsDocumento { get; set; }
        public long IdDocumentoAsignado { get; set; }
        public long IdLaserfiche { get; set; }
        public string FlgDigitalizar { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFIn { get; set; }
        public string ExpeObservacion { get; set; }
    }
}
