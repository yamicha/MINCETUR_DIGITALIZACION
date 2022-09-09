using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServiciosMicroformas.Recursos
{
   public class Css_Codigo
    {
        public static string Generar_Codigo_Temporal()
        {
            string CODIGO_TEMPORAL = Guid.NewGuid().ToString();
            return CODIGO_TEMPORAL;
        }
    }
}
