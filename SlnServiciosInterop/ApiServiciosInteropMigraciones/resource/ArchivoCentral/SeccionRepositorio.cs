using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosMicroformas.ArchivoCentral;
using EnServiciosMicroformas;
using NeServiciosMicroformas.ArchivoCentral;
using CoServiciosMicroformas;

namespace ApiServiciosMicroformas.resource.ArchivoCentral
{
    public class SeccionRepositorio : IDisposable
    {

        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private  coConexionDb _objCoConexionDb;
        private neSeccion _rule = null; 

        public SeccionRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neSeccion(_objCoConexionDb);
        }


        public List<enSeccion> Seccion_Listar(enSeccion entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Seccion_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enSeccion>();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
