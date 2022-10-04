using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models
{
    public class MicroformaModel
    {
        public long IdLote { get; set; }

        public long IdSoporte { get; set; }

        public string Fecha { get; set; }

        public string CodigoSoporte { get; set; }
        public string NroActa { get; set; }
        public string NroCopias { get; set; }

        public string CodigoFedatario { get; set; }
        public string Observacion { get; set; }

        public List<MicroformaModel> ListaIdsLotes { get; set; }
    }
}
