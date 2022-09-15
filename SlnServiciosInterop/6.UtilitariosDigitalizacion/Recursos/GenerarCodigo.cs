using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Recursos
{
   public class GenerarCodigo
    {
        public static string GenerarCodigoTemporal()
        {
            string CODIGO_TEMPORAL = Guid.NewGuid().ToString();
            return CODIGO_TEMPORAL;
        }
    }
}
