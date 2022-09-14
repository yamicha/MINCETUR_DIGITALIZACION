using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoServiciosDigitalizacion
{
    public class coConexionDb : coHBase
    {
        public string ServerCnx { get; set; }
        public string UserCnx { get; set; }
        public string PassCnx { get; set; }

        public string TNS_ADMIN { get; set; }
    }
}
