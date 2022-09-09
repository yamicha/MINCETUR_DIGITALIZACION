using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnServiciosMicroformas;

namespace NeServiciosMicroformas
{
    public class neAccesoThread : neBase
    {
        private enAcceso _objEnAcceso;
        public neAccesoThread(string strServerCnx) : base(new CoServiciosMicroformas.coConexionDb() { ServerCnx = strServerCnx })
        {

        }

        private void enviarAccesoSincrono()
        {
            if (_objEnAcceso != null)
            {
                try
                {
                    new neAcceso(base.objCoConexionDb.ServerCnx).enviarAcceso(this._objEnAcceso);
                }
                catch {}
            }
        }

        public void enviarAccesoAsincrono(enAcceso objEAcceso)
        {
            if (objEAcceso != null) this._objEnAcceso = objEAcceso;
            try
            {
                System.Threading.Thread asyncWorker = new System.Threading.Thread(new System.Threading.ThreadStart(enviarAccesoSincrono));
                asyncWorker.Start();                
            }
            catch { }
        }
    }
}
