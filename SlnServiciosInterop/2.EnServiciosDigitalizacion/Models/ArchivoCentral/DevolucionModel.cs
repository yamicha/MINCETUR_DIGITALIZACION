using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models
{
   public class DevolucionModel
    {
        public long IdLote { get; set; }

        public long IdArea { get; set; }

        public long IdUsuario { get; set; }

        public string Comentario { get; set; }

        public List<DevolucionModel> ListaIdsLotes { get; set; }

        public DateTime FecDevolucion { get; set; }
        public string IpCreacion { get; set; }
    }
}
