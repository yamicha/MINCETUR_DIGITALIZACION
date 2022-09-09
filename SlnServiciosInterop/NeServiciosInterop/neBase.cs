using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosMicroformas;

namespace NeServiciosMicroformas
{
    public class neBase : coHBase
    {
        private coConexionDb _objCoConexionDb;

        public neBase(coConexionDb objCoConexionDb)
        {
            this._objCoConexionDb = objCoConexionDb ?? new coConexionDb() { ServerCnx = "local" };
        }

        protected coConexionDb objCoConexionDb
        {
            get { return _objCoConexionDb; }
        }
    }
}
