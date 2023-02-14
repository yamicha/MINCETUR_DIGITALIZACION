using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models.Ventanilla
{
    public class MicroModel
    {
        public long IdMicroforma { get; set; }
        public long IdLote { get; set; }
        public long IdDocApertura { get; set; }
        public long IdDocCierre { get; set; }

        public long IdDocConformidad { get; set; }
        
        public int IdEstado { get; set; }
        public int IdSoporte { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string CodigoSoporte { get; set; }
        public string NroVolumen { get; set; }    
        public string NroActa { get; set; }
        public string NroCopias { get; set; }
        public string CodigoFedatario { get; set; }
        public string Observacion { get; set; }
        public List<MicroModel> ListaIdsLotes { get; set; }
        public string UsuCreacion { get; set; }
        public string UsuModificacion { get; set; }
        public string IpCreacion { get; set; }
        
        public MicroArchivoModels MicroArchivo { get; set; }
    }
}
