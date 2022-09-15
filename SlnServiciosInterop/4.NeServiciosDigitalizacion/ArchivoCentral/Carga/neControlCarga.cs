using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Carga; 
using EnServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Carga; 

namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion.Carga
{
    public class neControlCarga : neBase
    {
        DaControlCarga _objDa = null;
        public neControlCarga(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaControlCarga(objCoConexionDb);
        }
      

    }
}
