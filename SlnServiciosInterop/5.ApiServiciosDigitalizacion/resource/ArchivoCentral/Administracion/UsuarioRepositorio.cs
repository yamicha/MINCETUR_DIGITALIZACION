using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using NeServiciosDigitalizacion.ArchivoCentral.Administracion;
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion
{
    public class UsuarioRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neUsuario _rule = null;

        public UsuarioRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neUsuario(_objCoConexionDb);
        }

        public List<enUsuario> Usuario_Listar(ref enAuditoria auditoria)
        {
             return _rule.Usuario_Listar(ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
