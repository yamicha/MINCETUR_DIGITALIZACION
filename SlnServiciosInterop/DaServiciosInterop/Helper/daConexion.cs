using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosMicroformas;

namespace DaServiciosMicroformas
{

    public class daConexion : coHBase
    {
        private coConexionDb _objCoConexionDb;
        protected daConexion(coConexionDb objCoConexionDb)
        {
            this._objCoConexionDb = objCoConexionDb ?? new coConexionDb();
    }

    public string CadenaConexion
        {
            get
            {
                
                return string.Format("Data Source={0};USER ID={1};Password={2};Pooling=True;Min Pool Size=1; Max Pool Size=25;Connection Lifetime=60;Tns_Admin={3}", this._objCoConexionDb.ServerCnx, this._objCoConexionDb.UserCnx, this._objCoConexionDb.PassCnx, this._objCoConexionDb.TNS_ADMIN);

            }
        }
    }
}
