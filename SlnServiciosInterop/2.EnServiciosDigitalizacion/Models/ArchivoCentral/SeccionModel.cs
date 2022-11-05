using System;
using System.Collections.Generic;
using System.Text;

namespace EnServiciosDigitalizacion.Models
{
   public class SeccionModel
    {
        public int IdSeccion { get; set; }

        public string DescCortaSeccion { get; set; }

        public string DescLargaSeccion { get; set; }

        public string FlgEstado { get; set; }

        public string UsuCreacion { get; set; }
        public string UsuModificacion { get; set; }
    }
}
